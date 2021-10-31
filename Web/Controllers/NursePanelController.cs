using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CoreLibrary;
using CoreLibrary.Notifications;
using Data;
using Data.DataViews;
using Data.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PagedList.Core;
using Web.Resources;

namespace Web.Controllers
{
    [Authorize(Roles = "Hemşire")]
    public class NursePanelController : Controller
    {
        private readonly DataContext dbcontext;
        NotificationSender sendNotify = new NotificationSender();

        private readonly IHttpContextAccessor _httpContextAccessor;
        public NursePanelController(IHttpContextAccessor httpContextAccessor, DataContext dbcontext)
        {
            _httpContextAccessor = httpContextAccessor;
            this.dbcontext = dbcontext;
        }
        public IActionResult Anasayfa(string weekdate)
        {
            try
            {
                DateTime date;
                if (!String.IsNullOrWhiteSpace(weekdate))
                    date = DateTime.Parse(weekdate);
                else
                    date = DateTime.Now;
                DateTime today = DateTime.Now;
                DateTime start = date.Date.AddDays(-(int)date.DayOfWeek + 1), end = start.AddDays(7); // Get Week
                ViewBag.startdate = start;
                ViewBag.enddate = end;
                ViewBag.selecteddate = date;
                User user = GetUser();
                List<DailyCheck> Alldailycheck = dbcontext.DailyCheck.Where(x => x.NurseId == user.Id && x.Status == 0 && x.IsPremium == true).OrderBy(x => x.AlertDay).Include(x => x.Nurse).Include(x => x.User).ToList();
                //List<DailyCheck> Alldailycheck = api.RequestGet<List<DailyCheck>>($"DailyCheck/NurseAnaSayfa/{user.Id}");
                ViewBag.DailyChecks = Alldailycheck;
                if (IsAjaxRequest(Request))
                    return PartialView("~/Views/NursePanel/Shared/_takvim.cshtml", Alldailycheck);

                return View(Alldailycheck);
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("NursePanel - Anasayfa", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }


        #region UserSecurity
        public User GetUser()
        {
            try
            {
                List<Claim> useridentity = GetIdentitiy();
                if (useridentity == null)
                    return null;
                if (useridentity.FirstOrDefault(x => x.Type == "id") == null)
                    return null;
                Int16 userid = Convert.ToInt16(useridentity.FirstOrDefault(x => x.Type == "id").Value);
                User user = dbcontext.User.Where(x => x.Id == userid).Include(x => x.UserType).Include(x => x.DoctorDetail).Include(x => x.RelUserDepartments).FirstOrDefault();
                //User usera = api.RequestGet<User>($"UserSecurity/DoctorGetUser/{userid}");
                return user;
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("NursePanel - GetUser", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }

        public List<Claim> GetIdentitiy() // User Kimliğini Aldık. Kullanımı Asagidaki gibidir.
        {
            try
            {
                List<Claim> checkuser = User.Claims.ToList();
                if (checkuser != null)
                    return checkuser;
                return null;
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("NursePanel - GetIdentitiy", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }
        #endregion

        #region UserProfile ------

        public ActionResult Profilim()
        {
            try
            {
                User user = GetUser();
                List<Address> adres = dbcontext.Address.Where(x => x.UserId == user.Id).Include(x => x.Country).Include(x => x.City).Include(x => x.County).ToList();
                if (user == null)
                    return RedirectToAction("Giris");
                if (user.RelUserDepartments.Count == 0)
                    user.RelUserDepartments.Add(new RelUserDepartment() { DepartmentId = 0, UserId = user.Id });
                user.Address = adres;
                List<Country> countrys = dbcontext.Country.ToList();
                TempData["Countrys"] = countrys;
                List<RelUserDepartment> departmans = dbcontext.RelUserDepartment.Where(x => x.UserId == user.Id).Include(x => x.Department).ToList();
                ViewBag.Departments = departmans;
                return View(user);
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("NursePanel - Profilim-1", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }

        [HttpPost]
        public ActionResult Profilim(User updateuser, int sessiontime, int sessionprice, string photofile, int departmentid, int Country, int City, int County, string AddressDetail)
        {
            try
            {
                User user = GetUser();
                List<Address> adres = dbcontext.Address.Where(x => x.UserId == user.Id).Include(x => x.Country).Include(x => x.City).Include(x => x.County).ToList();
                user.Address = adres;
                if (!String.IsNullOrEmpty(photofile))
                {
                    if (user.PhotoUrl == "erkekdoktor.png" || user.PhotoUrl == "kadindoktor.png")
                        user.PhotoUrl = Guid.NewGuid().ToString() + ".png";

                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\Users", user.PhotoUrl);
                    var bytes = Convert.FromBase64String(photofile.Split(',')[1]);
                    using (var File = new FileStream(filePath + updateuser.PhotoUrl, FileMode.Create))
                    {
                        File.Write(bytes, 0, bytes.Length);
                        File.Flush();
                    }
                }
                user.TC = updateuser.TC;
                user.Name = updateuser.Name;
                user.SurName = updateuser.SurName;
                user.Phone = updateuser.Phone;
                user.Email = updateuser.Email;
                user.Birthdate = updateuser.Birthdate;
                user.Gender = updateuser.Gender;
                user.Address.FirstOrDefault().CountryId = Country;
                user.Address.FirstOrDefault().CityId = City;
                user.Address.FirstOrDefault().CountyId = County;
                user.Address.FirstOrDefault().AddressDetail = AddressDetail;
                
                user.DoctorDetail.HospitalName = updateuser.DoctorDetail.HospitalName;
                user.UUDate = DateTime.Now;
                if (departmentid != -1 && departmentid != 0)
                {
                    RelUserDepartment departmentupdate = dbcontext.RelUserDepartment.FirstOrDefault(x => x.DepartmentId == departmentid && x.UserId == user.Id);
                    departmentupdate.SessionTime = sessiontime <= 0 ? 1 : sessiontime;
                    departmentupdate.Price = sessionprice <= 0 ? 1 : sessionprice;
                }

                if (String.IsNullOrEmpty(updateuser.DoctorDetail.Title) || updateuser.DoctorDetail.Title == "0" || updateuser.DoctorDetail.Title == "-1")
                {
                    user.DoctorDetail.Title = dbcontext.Department.FirstOrDefault(x => x.Id == departmentid)?.Name;
                }
                else
                {
                    user.DoctorDetail.Title = updateuser.DoctorDetail.Title;
                }

                dbcontext.Update(user);
                int a = dbcontext.SaveChanges();
                if (user == null)
                    return RedirectToAction("Giris");
                List<Country> countrys = dbcontext.Country.ToList();
                TempData["Countrys"] = countrys;
                List<RelUserDepartment> departmans = dbcontext.RelUserDepartment.Where(x => x.UserId == user.Id).Include(x => x.Department).ToList();
                ViewBag.Departments = departmans;
                return View(user);
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("NursePanel - Profilim-2", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }

        [HttpPost]
        public ActionResult ChangePassword(string newpass)
        {
            try
            {
                User user = GetUser();
                if (user == null)
                    return RedirectToAction("Giris");
                if (!String.IsNullOrEmpty(newpass) && newpass.Length >= 5)
                {
                    user.Password = newpass;
                    dbcontext.SaveChanges();
                    return Json(new { status = 1, title = "İşlem Başarılı", message = "Şifreniz Güncellenmiştir" });
                }
                return Json(new { status = -1, title = "İşlem Başarısız", message = "Lütfen En Az 5 Haneli Şifre Girin" });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("NursePanel - ChangePassword", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }

        #endregion


        #region DailyCheck Process -------------

        [HttpPost]
        public ActionResult CreateSession(int DepartmentId, DateTime startdate, int Price = 0, int Time = 0, int IsMultiAppointment = 0, string Enddate = "", int Mola = 0, int IsPreview = 0)
        {
            try
            {
                User user = GetUser();
                if (user == null)
                    return RedirectToAction("Giris");
                if (!user.IsActive)
                    return Json(new { status = -1, title = "Dikkat", message = "Hesabınız Henüz Onaylanmamıştır. Onaylandıktan Sonra Randevu Açabilirsiniz. Anlayışınız İçin Teşekkür Ederiz.." });
                if (startdate < DateTime.Now)
                    return Json(new { status = -1, title = "Tarih Hatası", message = "Geçmiş Tarihlere Kayıt Açamazsınız!" });
                RelUserDepartment userdepartment = user.RelUserDepartments.FirstOrDefault(x => x.DepartmentId == DepartmentId);
                if (IsMultiAppointment == 0) // Tekli Kayıt
                {
                    DateTime finishdate = startdate.AddMinutes(Time == 0 ? userdepartment.SessionTime : Time);
                    Appointment appointcheck = dbcontext.Appointment.FirstOrDefault(x => x.DoctorId == user.Id && x.IsActive && x.Status != -1 && x.Status != -2 && x.Status != -3 && !x.IsDeleted && ((x.AppointmentDate <= startdate && startdate < x.AppointmentFinishDate) || (x.AppointmentDate < finishdate && finishdate < x.AppointmentFinishDate) || (startdate < x.AppointmentDate && finishdate > x.AppointmentFinishDate)));
                    if (appointcheck != null)
                        return Json(new { status = -1, title = "Kayıtlı Tarih", message = "Bu zaman aralığıyla çakışan randevunuz mevcut! Lütfen başka saat dilimi seçiniz.." });
                    Random rnd = new Random();
                    string sessioncode = rnd.Next(100000, 999999).ToString();
                    Appointment newappointment = new Appointment()
                    {
                        IDate = DateTime.Now,
                        DoctorId = user.Id,
                        DepartmentId = DepartmentId,
                        AppointmentDate = startdate,
                        AppointmentFinishDate = finishdate,
                        DoctorName = user.Name + " " + user.SurName,
                        IsPreview = IsPreview == 1,
                        Sick = new Sick() { Name = "" },
                        SessionKey = Guid.NewGuid().ToString(),
                        SessionPrice = Price == 0 ? userdepartment.Price : Price,
                        SessionTime = Time == 0 ? userdepartment.SessionTime : Time,
                        SessionCode = sessioncode,
                        UserId = 1,
                        IsActive = true,
                        IsDeleted = false
                    };
                    dbcontext.Appointment.Add(newappointment);
                    dbcontext.AppointmentProcess.Add(new AppointmentProcess() { Appointment = newappointment, IDate = DateTime.Now, IsDoctor = true, User = user, ProcessMessage = "Doktor Yeni Randevu Oluşturdu" });
                }
                else  // Coklu Kayıt
                {
                    DateTime multidate = startdate;
                    DateTime multienddate = new DateTime(startdate.Year, startdate.Month, startdate.Day, Convert.ToInt16(Enddate.Split(':')[0]), Convert.ToInt16(Enddate.Split(':')[1]), 0);
                    DateTime finishdate;
                    while (multidate.AddMinutes((Time == 0 ? userdepartment.SessionTime : Time) + Mola) <= multienddate)
                    {
                        finishdate = multidate.AddMinutes(Time == 0 ? userdepartment.SessionTime : Time);
                        Appointment appointcheck = dbcontext.Appointment.FirstOrDefault(x => x.DoctorId == user.Id && x.IsActive && x.Status != -1 && x.Status != -2 && x.Status != -3 && !x.IsDeleted && ((x.AppointmentDate <= startdate && startdate < x.AppointmentFinishDate) || (x.AppointmentDate < finishdate && finishdate < x.AppointmentFinishDate) || (startdate < x.AppointmentDate && finishdate > x.AppointmentFinishDate)));
                        if (appointcheck == null)
                        {
                            Random rnd = new Random();
                            string sessioncode = rnd.Next(100000, 999999).ToString();
                            Appointment newappointment = new Appointment()
                            {
                                IDate = DateTime.Now,
                                DoctorId = user.Id,
                                DepartmentId = DepartmentId,
                                AppointmentDate = multidate,
                                AppointmentFinishDate = finishdate,
                                Sick = new Sick() { Name = "" },
                                IsPreview = IsPreview == 1,
                                SessionKey = Guid.NewGuid().ToString(),
                                SessionPrice = Price == 0 ? userdepartment.Price : Price,
                                SessionTime = Time == 0 ? userdepartment.SessionTime : Time,
                                SessionCode = sessioncode,
                                UserId = 1,
                                IsActive = true,
                                IsDeleted = false
                            };
                            dbcontext.Appointment.Add(newappointment);
                            dbcontext.AppointmentProcess.Add(new AppointmentProcess() { Appointment = newappointment, IDate = DateTime.Now, IsDoctor = true, User = user, ProcessMessage = "Doktor Yeni Randevu Oluşturdu" });
                        }
                        multidate = finishdate.AddMinutes(Mola);
                    }
                }
                dbcontext.SaveChanges();
                List<int> usertokens = dbcontext.NotifyWarning.Where(x => x.DepartmentId == DepartmentId && x.DoctorId == user.Id).Select(x => x.UserId).ToList();
                if (usertokens.Count != 0)
                {
                    Department department = dbcontext.Department.FirstOrDefault(x => x.Id == DepartmentId);
                    var response = sendNotify.SendNotificationAsync(new NotificationPostData()
                    {
                        FcmTokens = dbcontext.NotifyTokens.Where(x => usertokens.Contains(x.UserId)).Select(x => x.Token).ToList(),
                        MessageData = new NotificationMessageData() { Title = "Randevu Açıldı", Message = "Merhabalar," + department.Name + " Bölümüne " + user.DoctorDetail.Title + " " + user.Name + " " + user.SurName + " Tarafından Randevu Açılmıştır.", Link = "", Action = "", Image = "https://www.doctorla.co/images/NotificaitonLogo.png" }
                    });
                    dbcontext.NotifyWarning.RemoveRange(dbcontext.NotifyWarning.Where(x => x.DepartmentId == DepartmentId && x.DoctorId == user.Id).ToList());
                }
                dbcontext.SaveChanges();

                return Json(new { status = 1, title = "İşlem Başarılı", message = "Randevu Kayıtınız Başarılı Bir Şekilde Oluşturulmuştur.Randevu Listeniz Güncelleniyor.", date = startdate });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("NursePanel - CreateSession", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }


        public PartialViewResult GetUserDetail(string sessionkey)
        {
            try
            {
                User user = GetUser();
                //if (!user.IsActive)
                //    return null;
                DailyCheckDetail viewdata = new DailyCheckDetail();
                Appointment userappointment = dbcontext.Appointment.Where(x => !x.IsDeleted && x.SessionKey == sessionkey).Include(x => x.AppointmentFiles).FirstOrDefault();
                if (userappointment != null && userappointment.UserId != 1)
                {
                    User userdetail = dbcontext.User.Where(x => x.Id == userappointment.UserId).Include(x => x.UserDetail).FirstOrDefault();
                    List<Appointment> appointments = dbcontext.Appointment.Where(x => !x.IsDeleted && x.Status != -2 && x.UserId == userappointment.UserId && (!x.IsPrivate || x.DoctorId == user.Id)).Include(x => x.Department).OrderBy(x => x.AppointmentDate).ToList();
                    foreach (var item in appointments)
                    {
                        item.DoctorName = dbcontext.User.Where(x => x.Id == item.DoctorId).Select(x => new { DoctorName = x.Name + " " + x.SurName }).FirstOrDefault().DoctorName;
                    }
                    userdetail.Appointment = appointments;
                    //viewdata.Appointment = userappointment;
                    //viewdata.User = userdetail;
                    //if (userappointment.DoctorId == user.Id) //Not Güncelleme İçin Kontrol
                    //    viewdata.Permission = true;
                    //else
                    //    viewdata.Permission = false;
                    return PartialView("~/Views/Nurse/Shared/_UserDetailModal.cshtml", viewdata);
                }
                return null;
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("NursePanel - GetUserDetail", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }

        [HttpPost]
        public ActionResult UpdateAppointmentNote(string sessionkey, string doctornote)
        {
            try
            {
                User user = GetUser();
                if (user == null)
                    return RedirectToAction("Giris");
                Appointment userappointment = dbcontext.Appointment.Where(x => !x.IsDeleted && x.SessionKey == sessionkey).FirstOrDefault();
                if (userappointment.DoctorId == user.Id)
                {
                    userappointment.AppointmentDoctorNote = doctornote;
                    dbcontext.SaveChanges();
                    return Json(new { status = 1, title = "İşlem Başarılı", message = "Notunuz Güncellenmiştir" });
                }
                return Json(new { status = -1, title = "İşlem Başarısız", message = "Randevu Silinmiş veya Bu Notu Düzeltmeye Yetkiniz Bulunmuyor.." });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("NursePanel - UpdateAppointmentNote", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }


        [HttpPost]
        public ActionResult deleteAppointment(string sessionkey, string deleteReason)
        {
            try
            {
                User user = GetUser();
                if (user == null)
                    return RedirectToAction("Giris");
                Appointment appointment = dbcontext.Appointment.Where(x => !x.IsDeleted && x.DoctorId == user.Id && x.SessionKey == sessionkey).FirstOrDefault();
                if (appointment != null)
                {
                    if (appointment.UserId == 1) //Kayıt Yoksa
                        dbcontext.Appointment.Remove(appointment);
                    else
                    {
                        if (String.IsNullOrWhiteSpace(deleteReason))
                            return Json(new { status = 0, session = sessionkey }); // Reserved Session Delete Proccess. Wait for Reason
                        else
                        {
                            Random rnd = new Random();
                            string sessioncode = rnd.Next(100000, 999999).ToString();
                            appointment.SessionCode = sessioncode;
                            appointment.IsDeleted = true;
                            appointment.DoctorDeleteReason = deleteReason;
                            appointment.Status = -1;
                            dbcontext.AppointmentProcess.Add(new AppointmentProcess() { Appointment = appointment, IDate = DateTime.Now, IsDoctor = true, User = user, ProcessMessage = user.UserType.DefaultName + " " + user.Name + " " + user.SurName + " Randevu İptali, Doktor Tarafından Gerçekleştirildi.. Silme Sebebi:" + deleteReason });
                            User checkuser = dbcontext.User.FirstOrDefault(x => x.Id == appointment.UserId);
                            Donations donation = dbcontext.Donations.FirstOrDefault(x => x.AppointmentId == appointment.Id);
                            if (donation != null)
                                dbcontext.Donations.Remove(donation);
                            checkuser.AccountBalance += appointment.SessionPrice;
                        }
                    }
                    var response = sendNotify.SendNotificationAsync(new NotificationPostData()
                    {
                        FcmTokens = dbcontext.NotifyTokens.Where(x => x.UserId == appointment.UserId).Select(x => x.Token).ToList(),
                        MessageData = new NotificationMessageData() { Title = "Randevu İptali", Message = "Doktorunuz " + user.Name + " " + user.SurName + " Tarafından " + appointment.AppointmentDate.ToString("dd.MM.yyyy HH:mm") + "-" + appointment.AppointmentFinishDate.ToString("HH:mm") + " Tarihinde Bulunan Randevunuz İptal Edildi", Link = "", Action = "", Image = "https://www.doctorla.co/images/NotificaitonLogo.png" }
                    });
                    dbcontext.SaveChanges();
                    return Json(new { status = 1, title = "İşlem Başarılı", message = "Randevu Başarılı Bir Şekilde Silinmiştir" });
                }
                return Json(new { status = -1, title = "İşlem Başarısız", message = "Randevu Silinmiş veya Bu Randevuya Yetkiniz Bulunmuyor.." });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("NursePanel - deleteAppointment", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }




        #endregion


        #region -----Paketler----
        public ActionResult UpdateUserInfo(int Id, string UserInfo)
        {
            try
            {
                if (GetUser() == null)
                    return RedirectToAction("Giris");
                //api.RequestPost<object>("DailyCheck/NurseUpdateUserInfo", new { Id, UserInfo, userId = GetUser().Id });
                DailyCheck dailyCheck = dbcontext.DailyCheck.Where(x => x.Id == Id && x.NurseId == GetUser().Id).Include(x => x.DailyCheckDetail).FirstOrDefault();
                dailyCheck.UserInfo = UserInfo;
                dbcontext.SaveChanges();
                return Json(new { status = 1, title = "İşlem Başarılı", message = "Kullanıcı Ön Bilgisi Eklendi" });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("NursePanel - UpdateUserInfo", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }
        [HttpPost]
        public ActionResult updateUserDailycheckDetails(int Id, string[] deleted, string[] added)
        {
            try
            {
                if (GetUser() == null)
                    return RedirectToAction("Giris");
                //api.RequestPost<EmptyResult>("DailyCheck/NurseupdateUserDailycheckDetails", new { Id, deleted, added });
                DailyCheck dailycheck = dbcontext.DailyCheck.FirstOrDefault(x => x.Id == Id);
                if (dailycheck == null)
                    return null;
                if (Id != null && dailycheck.NurseId != GetUser().Id)
                    return null;
                List<DailyCheckDetail> dailycheckdetails = dbcontext.DailyCheckDetail.Where(x => x.DailyCheckId == Id).ToList();
                foreach (var item in deleted)
                {
                    DailyCheckDetail deletedetail = dailycheckdetails.FirstOrDefault(x => x.ValuesTitleId.ToString() == item);
                    if (deletedetail != null)
                    {
                        dbcontext.DailyCheckDetailValues.RemoveRange(dbcontext.DailyCheckDetailValues.Where(x => x.DailyCheckDetailId == deletedetail.Id).ToList());
                        dbcontext.DailyCheckDetail.Remove(deletedetail);
                    }
                }
                int lastorder = dailycheckdetails.Where(x => x.TitleOrder < 100).OrderByDescending(x => x.TitleOrder).FirstOrDefault() != null ? dailycheckdetails.Where(x => x.TitleOrder < 100).OrderByDescending(x => x.TitleOrder).FirstOrDefault().TitleOrder + 1 : 1;
                foreach (var item in added)
                {
                    if (dailycheckdetails.FirstOrDefault(x => x.ValuesTitleId.ToString() == item) == null)
                        dbcontext.DailyCheckDetail.Add(new DailyCheckDetail() { DailyCheckId = Id, TitleOrder = lastorder, ValuesTitleId = Convert.ToInt16(item) });
                    lastorder++;
                }
                dailycheck.Status = 0;
                dbcontext.SaveChanges();
                return Json(new { status = 1, title = "İşlem Başarılı", message = "Kullanıcı Ön Bilgisi Eklendi" });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("NursePanel - updateUserDailycheckDetails", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }
        public IActionResult GecmisPaketler(string name, int page = 1)
        {
            try
            {
                User user = GetUser();
                //List<DailyCheck> dailychecks = api.RequestGet<List<DailyCheck>>($"DailyCheck/NurseGecmisPaketler/{user.Id}");
                List<DailyCheck> dailychecks = dbcontext.DailyCheck.Where(x => x.NurseId == user.Id && x.IsPremium == true).OrderBy(x => x.Status).Include(x => x.User).Include(x => x.DailyCheckDetail).ToList();
                if (!String.IsNullOrEmpty(name))
                    dailychecks = dailychecks.Where(x => (x.User.Name.ToLower() + " " + x.User.SurName.ToLower()).Contains(name)).ToList();
                PagedList<DailyCheck> dailychecksPaged = new PagedList<DailyCheck>(dailychecks.AsQueryable(), page, 10);

                return View(dailychecksPaged);
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("NursePanel - GecmisPaketler", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }
        public PartialViewResult GetPackagesValues(int Id)
        {
            try
            {
                List<DailyCheckDetail> DailyCheckPackages = new List<DailyCheckDetail>();
                //var DailyCheckPackages = api.RequestGet<List<DailyCheckDetail>>($"DailyCheck/NurseGetPackagesValues/{Id}/{GetUser().Id}");
                if (Id != 0 && dbcontext.DailyCheck.FirstOrDefault(x => x.Id == Id).NurseId == GetUser().Id)
                {
                    DailyCheckPackages = dbcontext.DailyCheckDetail.Include(x => x.DailyCheck).Where(x => x.DailyCheckId == Id && x.DailyCheck.NurseId == GetUser().Id).ToList();
                }
                ViewBag.PackageValues = dbcontext.DailyCheckPackagesValues.Where(x => !x.IsDefault).ToList();
                return PartialView("~/Views/NursePanel/Shared/_OlcumBelirle.cshtml", DailyCheckPackages);
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("NursePanel - GetPackagesValues", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }
        public ActionResult CreateDailyCheckDetail(int Id, string Values, string files)//1. KullanıcıNote  , 2. NurseNote, 3.Files - OtherValues
        {
            try
            {
                if (GetUser() == null)
                    return RedirectToAction("Giris");
                if (Values == null && Id == 0 && dbcontext.DailyCheck.FirstOrDefault(x => x.Id == Id).NurseId != GetUser().Id)
                    return Json(new { status = -1, title = "İşlem Başarısız", message = "Lütfen Değerleri Giriniz" });

                DailyCheck dailycheck = dbcontext.DailyCheck.Where(x => x.Id == Id).Include(x => x.Nurse).Include(x => x.DailyCheckDetail).FirstOrDefault();
                List<DailyCheckValues> dailyCheckvalues = JsonConvert.DeserializeObject<List<DailyCheckValues>>(Values);
                Random rnd = new Random();
                string detailvaluecode = rnd.Next(100000, 999999).ToString();
                foreach (var item in dailycheck.DailyCheckDetail)
                {
                    if (item.TitleOrder != 1102)
                    {
                        DailyCheckDetailValues dailyCheckDetail = new DailyCheckDetailValues()
                        {
                            DailyCheckDetailId = item.Id,
                            TitleOrder = item.TitleOrder,
                            Value = dailyCheckvalues.FirstOrDefault(x => x.DailyCheckDetailId == item.Id) != null ? dailyCheckvalues.FirstOrDefault(x => x.DailyCheckDetailId == item.Id).Value : "",
                            IDate = DateTime.Now,
                            Key = detailvaluecode
                        };
                        dbcontext.DailyCheckDetailValues.Add(dailyCheckDetail);
                    }
                }
                int dailycheckfileid = dailycheck.DailyCheckDetail.FirstOrDefault(x => x.TitleOrder == 1100).Id;
                if (dailyCheckvalues.FirstOrDefault(x => x.DailyCheckDetailId == dailycheckfileid) == null)
                {
                    DailyCheckDetailValues hastanot = new DailyCheckDetailValues()
                    {
                        DailyCheckDetailId = dailycheckfileid,
                        TitleOrder = 1100,
                        Value = "",
                        IDate = DateTime.Now,
                        Key = detailvaluecode
                    };
                    dbcontext.DailyCheckDetailValues.Add(hastanot);
                }
                dailycheckfileid = dailycheck.DailyCheckDetail.FirstOrDefault(x => x.TitleOrder == 1101).Id;
                if (dailyCheckvalues.FirstOrDefault(x => x.DailyCheckDetailId == dailycheckfileid) == null)
                {
                    DailyCheckDetailValues hemsirenot = new DailyCheckDetailValues()
                    {
                        DailyCheckDetailId = dailycheckfileid,
                        TitleOrder = 1101,
                        Value = "",
                        IDate = DateTime.Now,
                        Key = detailvaluecode
                    };
                    dbcontext.DailyCheckDetailValues.Add(hemsirenot);
                }
                //---------------- Upload Files
                //var json= api.RequestPost<Dictionary<string,object>>("DailyCheck/NurseCreateDailyCheckDetail", new { Id,Values,files});
                string filenames = "";
                string fileshtml = " ";

                //if (json["filename"].ToString()!="-1")
                //{
                if (!String.IsNullOrEmpty(files))
                {
                    foreach (var detailfile in Regex.Split(files, ":::"))
                    {
                        if (!String.IsNullOrEmpty(detailfile))
                        {
                            string filename = Guid.NewGuid().ToString() + "-" + dailycheck.Nurse.Name + "_" + dailycheck.Nurse.SurName;
                            if (detailfile.Contains("pdf"))
                                filename += ".pdf";
                            else if (detailfile.Contains("word"))
                                filename += ".docx";
                            else if (detailfile.Contains("sheet"))
                                filename += ".xlsx";
                            else if (detailfile.Contains("png") || detailfile.Contains("jpg") || detailfile.Contains("jpeg"))
                                filename += ".png";
                            else
                                return null;
                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\DailyCheckFiles", filename);
                            var bytes = Convert.FromBase64String(detailfile.Split(',')[1]);
                            using (var File = new FileStream(filePath, FileMode.Create))
                            {
                                File.Write(bytes, 0, bytes.Length);
                                File.Flush();
                            }
                            filenames += filename + ",";
                            fileshtml += @"<a style='color:blue' href='/DailyCheckFiles/" + filename + "'  download>" + filename.Substring(0, 10) + "..</a>";
                        }
                    }
                    filenames = filenames.Remove(filenames.Length - 1);
                }
                //}

                dailycheckfileid = dailycheck.DailyCheckDetail.FirstOrDefault(x => x.TitleOrder == 1102).Id;
                DailyCheckDetailValues filevalue = new DailyCheckDetailValues()
                {
                    DailyCheckDetailId = dailycheckfileid,
                    TitleOrder = 1102,
                    Value = filenames,
                    IDate = DateTime.Now,
                    Key = detailvaluecode
                };
                dbcontext.DailyCheckDetailValues.Add(filevalue);
                //-----------------------------


                dbcontext.SaveChanges();
                //return Json(new { status = json["status"], files = fileshtml, Date = DateTime.Now.ToString("yyyy.MM.dd HH:mm"), Id = json["detailvaluecode"].ToString(), title = json["title"], message = json["message"] }); 
                return Json(new { status = 1, filename = filenames, Date = DateTime.Now.ToString("yyyy.MM.dd HH:mm"), detailvaluecode = detailvaluecode, title = "İşlem Başarılı", message = "Değerleriniz Başarılı Bir Şekilde Eklendi" });

            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("NursePanel - CreateDailyCheckDetail", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }
        [HttpPost]
        public JsonResult UpdateDailyCheckDetail(string Key, string Values)
        {
            try
            {
                if (Values == null && String.IsNullOrEmpty(Key))
                    return Json(new { status = -1, title = "İşlem Başarısız", message = "Lütfen Değerleri Giriniz" });
                string[] valuesarray = Values.Split(',');
                //api.RequestPost<EmptyResult>("DailyCheck/NurseUpdateDailyCheckDetail", new { Key, Values });
                List<DailyCheckValues> DailyCheckvalues = JsonConvert.DeserializeObject<List<DailyCheckValues>>(Values);
                int[] valueids = DailyCheckvalues.Select(x => x.DailyCheckDetailId).ToArray();

                List<DailyCheckDetailValues> oldvalues = dbcontext.DailyCheckDetailValues.Where(x => valueids.Contains(x.DailyCheckDetailId) && x.Key == Key).ToList();
                foreach (var item in DailyCheckvalues)
                {
                    if (oldvalues.FirstOrDefault(x => x.DailyCheckDetailId == item.DailyCheckDetailId) != null)
                        oldvalues.FirstOrDefault(x => x.DailyCheckDetailId == item.DailyCheckDetailId).Value = DailyCheckvalues.FirstOrDefault(x => x.DailyCheckDetailId == item.DailyCheckDetailId).Value;
                    else
                        dbcontext.DailyCheckDetailValues.Add(new DailyCheckDetailValues()
                        {
                            DailyCheckDetailId = item.DailyCheckDetailId,
                            IDate = oldvalues.FirstOrDefault().IDate,
                            Value = item.Value,
                            TitleOrder = dbcontext.DailyCheckDetail.FirstOrDefault(x => x.Id == item.DailyCheckDetailId).TitleOrder,
                            Key = Key
                        });
                }
                dbcontext.SaveChanges();
                return Json(new { status = 1, title = "İşlem Başarılı", message = "Ölçüleriniz Başarılı Bir Şekilde Güncellenmiştir" });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("NursePanel - UpdateDailyCheckDetail", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }
        #endregion

        public PartialViewResult GetDailyCheckDetail(int Id, int page = 1)
        {
            try
            {
                List<DailyCheckDetail> dailyChecks = dbcontext.DailyCheckDetail.Where(x => x.DailyCheckId == Id).Include(x => x.DailyCheck).Include(x => x.ValuesTitle).Include(x => x.Values).ToList();
                PagedList<DailyCheckDetail> dailyChecksPaged = new PagedList<DailyCheckDetail>(dailyChecks.AsQueryable(), page, 10);

                return PartialView("~/Views/NursePanel/Shared/_UserDetailModal.cshtml", dailyChecksPaged);
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("NursePanel - GetDailyCheckDetail", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }
        public void ErrorLogs(string page)
        {
            //api.RequestPost<object>("Logs/LogsAdd", new { page });
            LogsServices.LogsAdd(page, _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "");
        }
        public bool IsAjaxRequest(HttpRequest request)
        {
            return request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }


    }

}