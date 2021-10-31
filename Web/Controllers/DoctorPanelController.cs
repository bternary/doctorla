using CoreLibrary;
using CoreLibrary.Notifications;
using Data;
using Data.DataViews;
using Data.Domain;
using Data.Interfaces;
using Data.Interfaces.Repositories;
using Domain.Interfaces.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using Web.Resources;

namespace Web.Controllers
{
    [Authorize(Roles = "Doktor")]
    public class DoctorPanelController : Controller
    {
        NotificationSender sendNotify = new NotificationSender();


        private readonly DataContext dbcontext;
        private readonly IUserRepository ususerContexter;
        private readonly ICountryRepository counterDb;
        private readonly IRepository<UserType> usertypedb;
        private readonly IConfiguration _settings;

        private readonly IHttpContextAccessor _httpContextAccessor;
        public DoctorPanelController(IHttpContextAccessor httpContextAccessor,
            DataContext dbcontext,
            IUserRepository ususerContexter,
            ICountryRepository counterDb,
            IRepository<UserType> usertypedb,
            IConfiguration settings
            )
        {

            _httpContextAccessor = httpContextAccessor;
            this.dbcontext = dbcontext;
            this.ususerContexter = ususerContexter;
            this.counterDb = counterDb;
            this.usertypedb = usertypedb;
            _settings = settings;
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
                User user = GetUser();
                List<RelUserDepartment> departmans = dbcontext.RelUserDepartment.Where(x => x.UserId == user.Id).Include(x => x.Department).ToList();
                //List<RelUserDepartment> departmans = api.RequestGet<List<RelUserDepartment>>($"Department/DoctorAnasayfa/{user.Id}");
                ViewBag.Departments = departmans;
                ViewBag.startdate = start;
                ViewBag.enddate = end;
                ViewBag.selecteddate = date;
                List<Appointment> Allappointments = dbcontext.Appointment.Where(x => x.DoctorId == user.Id && x.Status != -2).Include(x => x.Department).Include(x => x.User).OrderBy(x => x.AppointmentDate).ToList();
                //List<Appointment> Allappointments = api.RequestGet<List<Appointment>>($"Appointment/GetAllAppointment/{user.Id}");
                List<Appointment> datefiltredAppoint = Allappointments.Where(x => x.AppointmentDate < end && x.AppointmentDate > start).ToList();
                ViewBag.Appointments = datefiltredAppoint;
                ViewBag.TodayEarn = Allappointments.Where(x => !x.IsDeleted && x.Status == 1 && !x.IsPreview && x.UserId != 1 && x.AppointmentDate.Day == today.Day).Sum(x => x.SessionPrice);
                ViewBag.TodaySuccessAppointment = Allappointments.Where(x => !x.IsDeleted && x.Status == 1 && x.UserId != 1 && x.AppointmentDate.Day == today.Day).ToList().Count;
                ViewBag.TodayWaitingAppointment = Allappointments.Where(x => !x.IsDeleted && x.Status == 0 && x.UserId != 1 && x.AppointmentDate >= today && x.AppointmentDate.Day == today.Day).ToList().Count;
                ViewBag.TodayDeletedAppointment = Allappointments.Where(x => x.Status == -1 && x.UserId != 1 && x.AppointmentDate.Day == today.Day).ToList().Count;
                if (IsAjaxRequest(Request))
                    return PartialView("~/Views/DoctorPanel/Shared/_takvim.cshtml", datefiltredAppoint);

                dbcontext.Appointment.Where(x => !x.IsDeleted && x.Status == 0 && x.UserId != 1 && x.AppointmentFinishDate < today).ToList().ForEach(x => x.Status = 1); //Update finished session
                ViewBag.TotalAccountBalance = Allappointments.Where(x => !x.IsDeleted && x.Status == 1 && x.UserId != 1 && x.AppointmentDate.Month == today.Month).Sum(x => x.SessionPrice);
                ViewBag.PageView = user.DoctorDetail.PageView;
                ViewBag.BlogView = user.DoctorDetail.BlogView;
                ViewBag.TotalDeletedAppointment = Allappointments.Where(x => x.Status == -1 && x.AppointmentDate.Month == today.Month).ToList().Count;
                ViewBag.TotalWaitingAppointment = Allappointments.Where(x => !x.IsDeleted && x.Status == 0 && x.UserId != 1 && today < x.AppointmentDate).ToList().Count;
                ViewBag.TotalSuccessAppointment = Allappointments.Where(x => !x.IsDeleted && x.Status == 1 && x.UserId != 1 && x.AppointmentDate.Month == today.Month).ToList().Count;
                ViewBag.TotalEarn = Allappointments.Where(x => !x.IsDeleted && x.Status == 1 && !x.IsPreview && x.UserId != 1 && x.AppointmentDate.Month == today.Month).Sum(x => x.SessionPrice);

                if (departmans != null)
                {
                    ViewBag.SessionPrice = departmans.FirstOrDefault().Price;
                    ViewBag.SessionTime = departmans.FirstOrDefault().SessionTime;
                }
                else
                {
                    ViewBag.SessionPrice = 0;
                    ViewBag.SessionTime = 0;
                }
                ViewBag.doctorTitle = user.DoctorDetail.Title;

                return View(datefiltredAppoint);
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("DoctorPanel - Anasayfa", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }
        public ActionResult UpdateUserInfo(int Id, string UserInfo)
        {
            try
            {
                if (GetUser() == null)
                    return RedirectToAction("Giris");
                DailyCheck dailyCheck = dbcontext.DailyCheck.Where(x => x.Id == Id && x.NurseId == GetUser().Id).Include(x => x.DailyCheckDetail).FirstOrDefault();
                dailyCheck.UserInfo = UserInfo;
                dbcontext.SaveChanges();
                return Json(new { status = 1, title = "İşlem Başarılı", message = "Kullanıcı Ön Bilgisi Eklendi" });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("DoctorPanel - UpdateUserInfo", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }
        public IActionResult GecmisPaketler(string name, int page = 1)
        {
            try
            {
                User user = GetUser();
                List<DailyCheck> dailychecks = dbcontext.DailyCheck.Where(x => x.NurseId == user.Id && x.IsDoctor == true && x.IsPremium == true).OrderBy(x => x.Status).Include(x => x.User).Include(x => x.DailyCheckDetail).ThenInclude(x => x.Values).AsNoTracking().ToList();
                //List<DailyCheck> dailychecksa = api.RequestGet<List<DailyCheck>>($"DoctorPanel/GecmisPaketler/{user.Id}");
                dbcontext.DailyCheck.Where(x => x.NurseId == user.Id && x.IsPremium == true && x.IsDoctor == true).ToList().ForEach(x => x.IsNewData = false);
                dbcontext.SaveChanges();
                if (!String.IsNullOrEmpty(name))
                    dailychecks = dailychecks.Where(x => (x.User.Name.ToLower() + " " + x.User.SurName.ToLower()).Contains(name)).ToList();
                PagedList<DailyCheck> dailychecksPaged = new PagedList<DailyCheck>(dailychecks.AsQueryable(), page, 10);

                ViewBag.doctorTitle = user.DoctorDetail.Title;
                return View(dailychecksPaged);
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("DoctorPanel - GecmisPaketler", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }
        public PartialViewResult GetDailyCheckDetail(int Id, int page = 1)
        {
            try
            {
                List<DailyCheckDetail> dailyChecks = dbcontext.DailyCheckDetail.Where(x => x.DailyCheckId == Id).Include(x => x.DailyCheck).Include(x => x.ValuesTitle).Include(x => x.Values).ToList();
                //List<DailyCheckDetail> dailyChecks = api.RequestGet<List<DailyCheckDetail>>($"DoctorPanel/GetDailyCheckDetailList/{Id}");

                User user = GetUser();

                ViewBag.doctorTitle = user.DoctorDetail.Title;

                return PartialView("~/Views/DoctorPanel/Shared/_UserDetailModalPaket.cshtml", dailyChecks);
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("DoctorPanel - GecmisPaketler", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }
        public JsonResult UpdateDailyCheckDetail(string Key, string Values)
        {
            try
            {
                //var json= api.RequestPost<Dictionary<string,object>>("DailyCheck/NurseUpdateDailyCheckDetail", new { Key, Values });
                if (Values == null && String.IsNullOrEmpty(Key))
                    return Json(new { status = -1, title = "İşlem Başarısız", message = "Lütfen Değerleri Giriniz" });
                string[] valuesarray = Values.Split(',');
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
                LogsServices.LogsAdd("DoctorPanel - UpdateDailyCheckDetail", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }
        public PartialViewResult GetPackagesValues(int Id)
        {
            try
            {
                List<DailyCheckDetail> DailyCheckPackages = new List<DailyCheckDetail>();
                if (Id != 0 && dbcontext.DailyCheck.FirstOrDefault(x => x.Id == Id).NurseId == GetUser().Id)
                {
                    DailyCheckPackages = dbcontext.DailyCheckDetail.Include(x => x.DailyCheck).Where(x => x.DailyCheckId == Id && x.DailyCheck.NurseId == GetUser().Id).ToList();
                }
                ViewBag.PackageValues = dbcontext.DailyCheckPackagesValues.Where(x => !x.IsDefault).ToList();
                User user = GetUser();

                ViewBag.doctorTitle = user.DoctorDetail.Title;
                return PartialView("~/Views/DoctorPanel/Shared/_OlcumBelirle.cshtml", DailyCheckPackages);
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("DoctorPanel - GetPackagesValues", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }
        public JsonResult updateUserDailycheckDetails(int Id, string[] deleted, string[] added)
        {
            try
            {
                //var json=api.RequestPost<Dictionary<string,object>>("DailyCheck/NurseupdateUserDailycheckDetails", new { Id, deleted, added });
                DailyCheck dailycheck = dbcontext.DailyCheck.FirstOrDefault(x => x.Id == Id);
                if (dailycheck == null)
                    return null;
                if (dailycheck.NurseId != GetUser().Id)
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
                        dbcontext.DailyCheckDetail.Add(new DailyCheckDetail() { DailyCheckId = Id, TitleOrder = lastorder, ValuesTitleId = Convert.ToInt16(item), IsNew = true });
                    lastorder++;
                }
                dailycheck.Status = 0;
                dbcontext.SaveChanges();
                return Json(new { status = 1, title = "İşlem Başarılı", message = "Kullanıcı Ön Bilgisi Eklendi" });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("DoctorPanel - updateUserDailycheckDetails", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }

        public JsonResult CreateDailyCheckDetail(int Id, string Values, string files)//1. KullanıcıNote  , 2. NurseNote, 3.Files - OtherValues
        {
            try
            {
                //var json = api.RequestPost<Dictionary<string, object>>("DailyCheck/NurseCreateDailyCheckDetail", new {Id,Values,files });
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
                string filenames = "";
                string fileshtml = " ";

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
                return Json(new { status = 1, files = fileshtml, Date = DateTime.Now.ToString("yyyy.MM.dd HH:mm"), Id = detailvaluecode, title = "İşlem Başarılı", message = "Değerleriniz Başarılı Bir Şekilde Eklendi" });

            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("DoctorPanel - CreateDailyCheckDetail", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }
        public JsonResult UpdateDailyCheck(int Id, DateTime AlertDay, int AlertDayCounter, string AlertDayHours)
        {
            try
            {
                //var json = api.RequestPost<Dictionary<string, object>>("DoctorPanel/UpdateDailyCheck", new { Id, AlertDay, AlertDayCounter, AlertDayHours, userId = GetUser().Id });
                if (AlertDay < DateTime.Now)
                    return Json(new { status = -1, title = "Tarih Hatası", message = "Geçmiş Tarihlere Hatırlatıcı Açamazsınız!" });
                DailyCheck dailyCheck = dbcontext.DailyCheck.Where(x => x.Id == Id).FirstOrDefault();
                if (dailyCheck == null)
                    return null;
                dailyCheck.AlertDay = AlertDay;
                dailyCheck.AlertDayCounter = AlertDayCounter;
                dailyCheck.AlertDayHours = AlertDayHours;
                dbcontext.DailyCheck.Update(dailyCheck);
                dbcontext.SaveChanges();
                return Json(new { status = 1, Id = dailyCheck.Id, title = "İşlem Başarılı", message = "Değerleriniz Başarılı Bir Şekilde Güncellendi" });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("DoctorPanel - UpdateDailyCheck", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }
        public ActionResult createLiveChat(int Id, int timer, int type)
        {
            try
            {
                if (GetUser() == null)
                    return RedirectToAction("Giris");
                //var json = api.RequestPost<Dictionary<string, object>>("DoctorPanel/createLiveChat",new {Id,timer,userId=GetUserId().Id,type});
                var roomname = Guid.NewGuid().ToString();
                DailyCheck dailyCheck = dbcontext.DailyCheck.Where(x => x.Id == Id && x.NurseId == GetUser().Id).FirstOrDefault();

                if (dailyCheck == null)
                    return null;
                if (type == 0)
                {
                    dailyCheck.LiveStartDate = DateTime.Now;
                    dailyCheck.LiveEndDate = DateTime.Now.AddMinutes(timer);
                }
                else
                {
                    dailyCheck.LiveStartDate = dailyCheck.LiveRequestDate;
                    dailyCheck.LiveEndDate = dailyCheck.LiveRequestDate != null ? dailyCheck.LiveRequestDate.Value.AddMinutes(timer) : DateTime.Now.AddMinutes(timer);
                }
                dailyCheck.LiveRoomName = roomname;
                dailyCheck.IsRequest = false;
                dbcontext.DailyCheck.Update(dailyCheck);
                dbcontext.SaveChanges();
                return Json(new { status = 1, Id = dailyCheck.Id, roomName = roomname, title = "İşlem Başarılı", message = "Canlı Görüşme Odası Kuruldu" });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("DoctorPanel - createLiveChat", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }
        public JsonResult liveRequestDetay(int id)
        {
            try
            {
                bool canliGorusmeKosul = false;
                //DailyCheck package = api.RequestGet<DailyCheck>($"DailyCheck/GetDailyCheck/{id}");  
                DailyCheck dailyCheck = dbcontext.DailyCheck.FirstOrDefault(x => x.Id == id);
                if (dailyCheck.LiveStartDate < DateTime.Now && dailyCheck.LiveEndDate > DateTime.Now)
                    canliGorusmeKosul = true;
                if (dailyCheck.NurseId != GetUser().Id)
                    return null;
                return Json(new { status = 1, date = dailyCheck.LiveStartDate, id = id, title = "İşlem Başarılı", message = "Detay Bilgileri Getirildi", kosul = canliGorusmeKosul });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("DoctorPanel - liveRequestDetay", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }
        public JsonResult liveRequestIptal(int Id)
        {
            try
            {
                //var json = api.RequestPost<Dictionary<string, object>>("DoctorPanel/liveRequestIptal", new { Id});
                DailyCheck dailyCheck = dbcontext.DailyCheck.FirstOrDefault(x => x.Id == Id);
                if (dailyCheck.NurseId != GetUser().Id)
                    return null;
                dailyCheck.IsRequest = false;
                dailyCheck.LiveStartDate = DateTime.Now.AddMinutes(-1);
                dailyCheck.LiveEndDate = DateTime.Now.AddMinutes(-1);
                dailyCheck.LiveRequestDate = DateTime.Now.AddMinutes(-1);
                dbcontext.DailyCheck.Update(dailyCheck);
                dbcontext.SaveChanges();
                return Json(new { status = 1, Id = dailyCheck.Id, activeStatus = dailyCheck.IsRequest, title = "İşlem Başarılı", message = "Canlı Görüşme İsteği İptal Edildi." });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("DoctorPanel - liveRequestIptal", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }

        #region UserProfile ------

        public ActionResult Profilim()
        {
            try
            {
                User user = GetUser();
                List<Address> adres = dbcontext.Address.Where(x => x.UserId == user.Id).Include(x => x.Country).Include(x => x.City).Include(x => x.County).ToList();
                //List<Address> adres = api.RequestGet<List<Address>>($"DoctorPanel/Address/{user.Id}");
                if (user == null)
                    return RedirectToAction("Giris");
                if (user.RelUserDepartments.Count == 0)
                    user.RelUserDepartments.Add(new RelUserDepartment() { DepartmentId = 0, UserId = user.Id });
                user.Address = adres;
                List<Country> countrys = dbcontext.Country.ToList();
                //List<Country> countrys = api.RequestGet<List<Country>>("Country/Get");
                TempData["Countrys"] = countrys;
                List<RelUserDepartment> departmans = dbcontext.RelUserDepartment.Where(x => x.UserId == user.Id).Include(x => x.Department).ToList();
                //List<RelUserDepartment> departmans = api.RequestGet<List<RelUserDepartment>>($"Department/DoctorAnasayfa/{user.Id}");
                ViewBag.Departments = departmans;
                ViewBag.doctorTitle = user.DoctorDetail.Title;
                return View(user);
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("DoctorPanel - Profilim-1", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }

        [HttpPost]
        public ActionResult Profilim(User updateuser, string DoctorDetail_Title, string photofile, int Country, int City, int County, string AddressDetail)
        {
            try
            {
                User user = GetUser();
                if (user == null)
                    return RedirectToAction("Giris");
                List<Address> adres = dbcontext.Address.Where(x => x.UserId == user.Id).Include(x => x.Country).Include(x => x.City).Include(x => x.County).ToList();
                //List<Address> adres = api.RequestGet<List<Address>>($"DoctorPanel/Address/{user.Id}");
                user.Address = adres;
                //if (!String.IsNullOrEmpty(photofile)) { 
                //    if (user.PhotoUrl == "erkekdoktor.png" || user.PhotoUrl == "kadindoktor.png")
                //        user.PhotoUrl = Guid.NewGuid().ToString() + ".png";

                //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\Users", user.PhotoUrl);
                //    var bytes = Convert.FromBase64String(photofile.Split(',')[1]);
                //    using (var File = new FileStream(filePath + updateuser.PhotoUrl, FileMode.Create))
                //    {
                //        File.Write(bytes, 0, bytes.Length);
                //        File.Flush();
                //    }
                //}
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
                
                if (String.IsNullOrEmpty(DoctorDetail_Title) || DoctorDetail_Title == "0" || DoctorDetail_Title == "-1")
                {
                    user.DoctorDetail.Title = string.Empty;
                }
                else
                {
                    user.DoctorDetail.Title = DoctorDetail_Title;
                }


                user.DoctorDetail.HospitalName = updateuser.DoctorDetail.HospitalName;
                user.UUDate = DateTime.Now;
                //if (departmentid != -1 && departmentid != 0)
                //{
                //    RelUserDepartment departmentupdate = dbcontext.RelUserDepartment.FirstOrDefault(x => x.DepartmentId == departmentid && x.UserId == user.Id);
                //    //RelUserDepartment departmentupdate = api.RequestGet<RelUserDepartment>($"Department/RelUserDepartmentGet/{departmentid}/{user.Id}"); ;
                //    departmentupdate.SessionTime = sessiontime <= 0 ? 1 : sessiontime;
                //    departmentupdate.Price = sessionprice <= 0 ? 1 : sessionprice;
                //}

                dbcontext.Update(user);
                dbcontext.SaveChanges();

                List<Country> countrys = dbcontext.Country.ToList();
                //List<Country> countrys = api.RequestGet<List<Country>>("Country/Get");
                TempData["Countrys"] = countrys;
                List<RelUserDepartment> departmans = dbcontext.RelUserDepartment.Where(x => x.UserId == user.Id).Include(x => x.Department).ToList();
                //List<RelUserDepartment> departmans = api.RequestGet<List<RelUserDepartment>>($"Department/DoctorAnasayfa/{user.Id}");
                ViewBag.Departments = departmans;

                ViewBag.doctorTitle = user.DoctorDetail.Title;
                return View(user);
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("DoctorPanel - Profilim-2", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }

        [HttpPost]
        public ActionResult ChangePassword(string Oldpass, string Newpass)
        {
            try
            {
                User user = GetUser();
                if (user == null)
                    return RedirectToAction("Giris");

                //api.RequestPost<object>("",new { userId=user.Id,newpass});
                if (user.Password != Oldpass)
                {
                    return Json(new { status = -1, title = "İşlem Başarısız", message = "Mevcut Şifrenizi Doğru Giriniz!" });

                }
                else if (user.Password == Newpass)
                {
                    return Json(new { status = 3, title = "İşlem Başarısız", message = "Eski Şifreniz ile Yeni Şifreniz Aynı Olamaz!" });
                }
                else
                {

                    user.Password = Newpass;
                    dbcontext.SaveChanges();
                    return Json(new { status = 1, title = "İşlem Başarılı", message = "Şifreniz Güncellenmiştir" });
                }
            }

            catch (Exception ex)
            {
                LogsServices.LogsAdd("DoctorPanel - ChangePassword", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }
        [HttpPost]
        public ActionResult profileUpdatePrice(int sessiontime, int sessionprice, int departmentid, string DoctorDetail_Title)
        {
            try
            {
                User user = GetUser();
                if (user == null)
                    return RedirectToAction("Giris");

                if (departmentid != -1 && departmentid != 0)
                {
                    RelUserDepartment departmentupdate = dbcontext.RelUserDepartment.FirstOrDefault(x => x.DepartmentId == departmentid && x.UserId == user.Id);
                    //RelUserDepartment departmentupdate = api.RequestGet<RelUserDepartment>($"Department/RelUserDepartmentGet/{departmentid}/{user.Id}"); ;
                    departmentupdate.SessionTime = sessiontime <= 0 ? 1 : sessiontime;
                    departmentupdate.Price = sessionprice <= 0 ? 1 : sessionprice;
                }

                if (String.IsNullOrEmpty(DoctorDetail_Title) || DoctorDetail_Title == "0" || DoctorDetail_Title == "-1")
                {
                    user.DoctorDetail.Title = dbcontext.Department.FirstOrDefault(x => x.Id == departmentid)?.Name;
                }
                else
                {
                    user.DoctorDetail.Title = DoctorDetail_Title;
                }

                dbcontext.Update(user);
                int a = dbcontext.SaveChanges();
                return Json(new { status = 1, title = "İşlem Başarılı", message = "Bilgileriniz Baraşıyla Güncellendi" });

            }

            catch (Exception ex)
            {
                LogsServices.LogsAdd("DoctorPanel - ChangePassword", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }
        #endregion


        #region Appointment Process -------------

        //Appointment Status Types:   0:In Proccess, 1:Success, -1: Cancelled by Doctor, -2: Cancelled by User, -3: User -> DoctorMissingOnSession, -100: Cancelled by Admin

        [HttpPost]
        public JsonResult CreateSession(int DepartmentId, DateTime startdate, int Price = 0, int Time = 0, int IsMultiAppointment = 0, string Enddate = "", int Mola = 0, int IsPreview = 0)
        {
            try
            {
                User user = GetUser();
                if (!user.IsActive)
                    return Json(new { status = -1, title = "Dikkat", message = "Hesabınız Henüz Onaylanmamıştır. Onaylandıktan Sonra Randevu Açabilirsiniz. Anlayışınız İçin Teşekkür Ederiz.." });
                if (startdate < DateTime.Now)
                    return Json(new { status = -1, title = "Tarih Hatası", message = "Geçmiş Tarihlere Kayıt Açamazsınız!" });
                RelUserDepartment userdepartment = user.RelUserDepartments.FirstOrDefault(x => x.DepartmentId == DepartmentId);
                //var json =new Dictionary<string,object>();
                if (IsMultiAppointment == 0) // Tekli Kayıt
                {
                    //json = api.RequestPost<Dictionary<string, object>>("DoctorPanel/AppointmentAdd", new { DepartmentId, startdate, Price, Time,IsPreview, userId = user.Id, userName = user.Name + " " + user.SurName });
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
                    //json = api.RequestPost<Dictionary<string, object>>("DoctorPanel/AppointmentAddMulti", new { DepartmentId, startdate, Price, Time, Enddate, Mola, IsPreview, userId = user.Id, userName = user.Name + " " + user.SurName });

                    DateTime multidate = startdate;
                    DateTime multienddate = new DateTime(startdate.Year, startdate.Month, startdate.Day, Convert.ToInt16(Enddate.Split(':')[0]), Convert.ToInt16(Enddate.Split(':')[1]), 0);
                    DateTime finishdate;
                    while (multidate.AddMinutes((Time == 0 ? userdepartment.SessionTime : Time) + Mola) <= multienddate)
                    {
                        finishdate = multidate.AddMinutes(Time == 0 ? userdepartment.SessionTime : Time);
                        Appointment appointcheck = dbcontext.Appointment.FirstOrDefault(x => x.DoctorId == user.Id && x.IsActive && x.Status != -1 && x.Status != -2 && x.Status != -3 && !x.IsDeleted && ((x.AppointmentDate <= startdate && multidate < x.AppointmentFinishDate) || (x.AppointmentDate < finishdate && finishdate < x.AppointmentFinishDate) || (multidate < x.AppointmentDate && finishdate > x.AppointmentFinishDate)));
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
                if (usertokens.Count == 0)
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
                LogsServices.LogsAdd("DoctorPanel - CreateSession", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
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
                DoctorAppointmentDetail viewdata = new DoctorAppointmentDetail();
                Appointment userappointment = dbcontext.Appointment.Where(x => !x.IsDeleted && x.SessionKey == sessionkey).Include(x => x.AppointmentFiles).FirstOrDefault();
                //Appointment userappointment = api.RequestGet<Appointment>($"DoctorPanel/UserDetailAppointment/{sessionkey}");
                if (userappointment != null && userappointment.UserId != 1)
                {
                    User userdetail = dbcontext.User.Where(x => x.Id == userappointment.UserId).Include(x => x.UserDetail).FirstOrDefault();
                    //User userdetail = api.RequestGet<User>($"DoctorPanel/UserDetail/{userappointment.UserId }");
                    List<Appointment> appointments = dbcontext.Appointment.Where(x => !x.IsDeleted && x.Status != -2 && x.UserId == userappointment.UserId && (!x.IsPrivate || x.DoctorId == user.Id)).Include(x => x.Department).OrderBy(x => x.AppointmentDate).ToList();
                    //List<Appointment> appointments = api.RequestGet<List<Appointment>>($"DoctorPanel/Appointments/{userappointment.UserId}/{user.Id}");
                    foreach (var item in appointments)
                    {
                        item.DoctorName = dbcontext.User.Where(x => x.Id == item.DoctorId).Select(x => new { DoctorName = x.Name + " " + x.SurName }).FirstOrDefault().DoctorName;
                        //item.DoctorName = api.RequestGet<Dictionary<string, string>>($"DoctorPanel/DoctorName/{user.Id}")["doctorName"];
                    }
                    userdetail.Appointment = appointments;
                    viewdata.Appointment = userappointment;
                    viewdata.User = userdetail;
                    if (userappointment.DoctorId == user.Id) //Not Güncelleme İçin Kontrol
                        viewdata.Permission = true;
                    else
                        viewdata.Permission = false;
                    return PartialView("~/Views/DoctorPanel/Shared/_UserDetailModal.cshtml", viewdata);
                }
                return null;
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("DoctorPanel - GetUserDetail", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
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
                //var json = api.RequestPost<Dictionary<string, object>>("DoctorPanel/AppointmenNote", new {sessionkey,doctornote,user.Id });
                //return Json(new { status = json["status"], title = json["title"], message = json["message"]});
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
                LogsServices.LogsAdd("DoctorPanel - UpdateAppointmentNote", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
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
                //var json = api.RequestPost<Dictionary<string, object>>("DoctorPanel/DeleteAppointment", new { sessionkey, deleteReason, userId = user.Id });
                Appointment appointment = dbcontext.Appointment.Where(x => !x.IsDeleted && x.DoctorId == user.Id && x.SessionKey == sessionkey).FirstOrDefault();
                if (appointment != null)
                {
                    if (appointment.UserId == 1) //Kayıt Yoksa
                    {
                        dbcontext.AppointmentProcess.RemoveRange(dbcontext.AppointmentProcess.Where(x => x.AppointmentId == appointment.Id).ToList());
                        dbcontext.SaveChanges();
                        dbcontext.Appointment.Remove(appointment);
                    }
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
                    //if (Convert.ToInt32(json["userId"])!=-1)
                    //{
                    //var a = api.RequestGet<List<string>>($"Notifys/NotifyWarningToken/{appointment.UserId}");
                    var response = sendNotify.SendNotificationAsync(new NotificationPostData()
                    {
                        //FcmTokens = dbcontext.NotifyTokens.Where(x => x.UserId == Convert.ToInt32(json["userId"])).Select(x => x.Token).ToList(),
                        //MessageData = new NotificationMessageData() { Title = "Randevu İptali", Message = "Doktorunuz " + user.Name + " " + user.SurName + " Tarafından " + json["date"].ToString()+ "-" + json["finish"].ToString() + " Tarihinde Bulunan Randevunuz İptal Edildi", Link = "", Action = "", Image = "https://www.doctorla.co/images/logo.png" }
                        FcmTokens = dbcontext.NotifyTokens.Where(x => x.UserId == appointment.UserId).Select(x => x.Token).ToList(),
                        MessageData = new NotificationMessageData() { Title = "Randevu İptali", Message = "Doktorunuz " + user.Name + " " + user.SurName + " Tarafından " + appointment.AppointmentDate.ToString("dd.MM.yyyy HH:mm") + "-" + appointment.AppointmentFinishDate.ToString("HH:mm") + " Tarihinde Bulunan Randevunuz İptal Edildi", Link = "", Action = "", Image = "https://www.doctorla.co/images/NotificaitonLogo.png" }
                    });
                    dbcontext.SaveChanges();
                    //}




                    return Json(new { status = 1, title = "İşlem Başarılı", message = "Randevu Başarılı Bir Şekilde Silinmiştir" });
                }
                //return Json(new { status = json["status"], session = json["session"], title = json["title"], message = json["message"] });
                return Json(new { status = -1, title = "İşlem Başarısız", message = "Randevu Silinmiş veya Bu Randevuya Yetkiniz Bulunmuyor.." });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("DoctorPanel - deleteAppointment", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }




        #endregion

        public IActionResult GecmisRandevular(string name, int page = 1)
        {
            try
            {
                User user = GetUser();
                List<Appointment> appointments = dbcontext.Appointment.Where(x => x.Status != -2 && x.DoctorId == user.Id).OrderByDescending(x => x.IsActive).ThenByDescending(x => x.UserId != 1).ThenBy(x => x.AppointmentDate).Include(x => x.Department).Include(x => x.User).ToList();
                //List<Appointment> appointments = api.RequestGet<List<Appointment>>($"DoctorPanel/GecmisRandevular/{user.Id}");
                if (!String.IsNullOrEmpty(name))
                    appointments = appointments.Where(x => (x.User.Name.ToLower() + " " + x.User.SurName.ToLower()).Contains(name)).ToList();
                appointments.ForEach(x => x.DoctorName = user.Name + " " + user.SurName);
                PagedList<Appointment> appointmentsPaged = new PagedList<Appointment>(appointments.AsQueryable(), page, 10);


                ViewBag.doctorTitle = user.DoctorDetail.Title;
                return View(appointmentsPaged);
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("DoctorPanel - GecmisRandevular", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }

        #region --DoktorPanel Sohbet--
        public IActionResult Sohbet(int id)
        {
            try
            {
                List<Claim> useridentity = GetIdentitiy();
                Int16 userid = Convert.ToInt16(useridentity.FirstOrDefault(x => x.Type == "id").Value);
                User user = dbcontext.User.Where(x => x.Id == userid).Include(x => x.UserDetail).Include(x => x.DailyCheck).ThenInclude(sn => sn.Nurse).FirstOrDefault();
                //User user = api.RequestGet<User>($"Kayit/User/{userid}");
                DailyCheck dailycheck = dbcontext.DailyCheck.Where(x => x.Id == id && x.NurseId == user.Id).Include(x => x.User).Include(x => x.Nurse).Include(x => x.PackageChat).FirstOrDefault();
                //DailyCheck dailycheck = api.RequestGet<DailyCheck>($"DailyCheck/SohbetDailyCheck/{id}");
                if (dailycheck == null)
                    return RedirectToAction("Anasayfa");
                return View(dailycheck);
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("DoctorPanel - Sohbet", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }
        [HttpPost]
        public ActionResult MesajGonder(string Message, int DailyCheckId, string files)
        {
            try
            {
                var isFile = false;
                string filenames = "";
                string fileshtml = " ";
                if (!String.IsNullOrEmpty(files))
                {
                    foreach (var detailfile in Regex.Split(files, ":::"))
                    {
                        if (!String.IsNullOrEmpty(detailfile))
                        {
                            string filename = Guid.NewGuid().ToString() + "-" + DailyCheckId;
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
                            var basePath = Path.Combine(_settings["BaseFileDirectory"], "DailyCheckFiles");
                            var filePath = Path.Combine(basePath, filename);
                            var bytes = Convert.FromBase64String(detailfile.Split(',')[1]);
                            using (var File = new FileStream(filePath, FileMode.Create))
                            {
                                File.Write(bytes, 0, bytes.Length);
                                File.Flush();
                            }
                            filenames += filename + ",";
                            fileshtml += @"<a style='color:blue' href='" + _settings["BaseFileSharePath"] + "/DailyCheckFiles/" + filename + "'  download>" + filename.Substring(0, 10) + "..</a>";
                        }
                    }
                    filenames = filenames.Remove(filenames.Length - 1);

                }
                if (files != null)
                {
                    isFile = true;
                    Message = filenames;

                }
                PackageChat packageChat = new PackageChat()
                {
                    Message = Message,
                    Date = DateTime.Now,
                    DailyCheckId = DailyCheckId,
                    IsDoctor = true,
                    IsFile = isFile,
                };
                dbcontext.PackageChat.Add(packageChat);
                dbcontext.SaveChanges();
                return Json(new { status = 1, Id = DailyCheckId, date = DateTime.Now.ToString("dd.MM.yyyy HH:mm tt"), file = files, title = "İşlem Başarılı", message = "Mesaj başarıyla gönderildi." });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("DoctorPanel - MesajGonder", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }

        #endregion

        [HttpPost]
        public ActionResult DoktorOlcumEkle(string NameOlcum, int minValue, int maksValue)
        {
            try
            {
                //var json = api.RequestPost<Dictionary<string, object>>("DoctorPanel/DoktorOlcumEkle",new { NameOlcum,minValue,maksValue,userId=GetUser().Id});
                foreach (var item in dbcontext.DailyCheckPackagesValues.Where(x => x.DoctorId == GetUser().Id).Select(x => x.Name).ToList())
                {
                    if (NameOlcum == item)
                    {
                        return Json(new { status = -1, title = "İşlem Başarısız", message = "Eklenmeye Çalışan Ölçüm Mevcut" });
                    }
                }

                DailyCheckPackagesValues packageValues = new DailyCheckPackagesValues()
                {
                    Name = NameOlcum,
                    MinValue = minValue,
                    MaxValue = maksValue,
                    Icon = "flaticon-heartbeat", // sonraki güncellemede dropdown ile ekleyen kişiye seçtirilicek
                    DoctorId = GetUser().Id,
                    IsDoctor = true
                };

                dbcontext.DailyCheckPackagesValues.Add(packageValues);
                dbcontext.SaveChanges();
                User user = GetUser();

                ViewBag.doctorTitle = user.DoctorDetail.Title;
                return Json(new { status = 1, title = "İşlem Başarılı", message = "Ölçüm başarıyla eklendi." });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("DoctorPanel - DoktorOlcumEkle", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }

        public IActionResult Makalelerim()
        {
            return View();
        }
        public IActionResult YorumveSikayetler()
        {
            return View();
        }


        #region UserSecurity ------
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
                LogsServices.LogsAdd("DoctorPanel - GetUser", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
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
                LogsServices.LogsAdd("DoctorPanel - GetIdentitiy", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }

        #endregion

        #region --- Randevu Talep ---
        public PartialViewResult Bildirimler()
        {
            try
            {
                List<NotifyWarning> notifys = dbcontext.NotifyWarning.Where(x => x.Date >= DateTime.Now.AddDays(-3) && x.DoctorId == GetUser().Id).Include(x => x.User).Include(x => x.Department).OrderBy(x => x.Status).ThenByDescending(x => x.Date).ToList();// Status 0:Beklemede 1:Red 2:Onay
                //List<NotifyWarning> notifysa = api.RequestGet<List<NotifyWarning>>($"Notifys/Notifys/{GetUser().Id}");
                return PartialView("~/Views/DoctorPanel/Shared/_DoctorToken.cshtml", notifys);
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("DoctorPanel - Bildirimler", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }
        public ActionResult isRequest()
        {
            try
            {
                if (GetUser() == null)
                    return RedirectToAction("Giris");
                var veriler = dbcontext.DailyCheck.Where(x => x.NurseId == GetUser().Id && x.IsRequest && (x.LiveRequestDate != null || x.LiveRequestDate > DateTime.Now)).Include(x => x.User).Select(x => new { request = x.IsRequest, userad = x.User.FullName(), x.Id, x.LiveRequestDate }).ToList();

                return Json(new { status = -1, title = "İşlem Başarılı", Veriler = veriler, message = "Randevu Talebi Var" });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("DoctorPanel - isRequest", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }
        public JsonResult isRequestDeny(int Id)
        {
            try
            {
                DailyCheck dailyCheck = dbcontext.DailyCheck.Where(x => x.Id == Id).FirstOrDefault();
                if (dailyCheck == null)
                    return null;
                dailyCheck.IsRequest = false;
                dbcontext.DailyCheck.Update(dailyCheck);
                dbcontext.SaveChanges();
                return Json(new { status = 1, Id = dailyCheck.Id, title = "İşlem Başarılı", message = "Değerleriniz Başarılı Bir Şekilde Eklendi" });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("DoctorPanel - isRequestDeny", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }


        public ActionResult RandevuTalep(int Id, short Status, bool isPreview)
        {
            try
            {
                User user = GetUser();
                if (user == null)
                    return RedirectToAction("Giris");
                NotifyWarning notifyWarning = dbcontext.NotifyWarning.Where(x => x.Id == Id && x.DoctorId == user.Id).Include(x => x.User).Include(x => x.Department).FirstOrDefault();
                var jsonResult = new object();// buraya alınması lazım
                int jsonstatus = 1;
                if (Status == 2)
                {
                    jsonResult = CreateSession(notifyWarning.DepartmentId, notifyWarning.Date, isPreview ? 10 : 0, isPreview ? 2 : 0, 0, "", 0, isPreview ? 1 : 0).Value;// buradan 
                    var jsonResulta = jsonResult.ToString().Split(",");
                    jsonstatus = Convert.ToInt32(jsonResulta.First().Split("=").Last());
                }
                if (jsonstatus == 1)
                    notifyWarning.Status = Status;
                dbcontext.NotifyWarning.Update(notifyWarning);
                dbcontext.SaveChanges();
                if (Status == 2)
                {
                    SmsServices.SendSms(dbcontext.User.FirstOrDefault(x => x.Id == notifyWarning.UserId).Phone, "Randevu Talebiniz Olumlu Sonuçlandı. Hemen Randevunuzu Alabilirsiniz.. Doctorla ");
                    return Json(jsonResult);
                }
                SmsServices.SendSms(dbcontext.User.FirstOrDefault(x => x.Id == notifyWarning.UserId).Phone, "Randevu Talebiniz Olumsuz Sonuçlandı. Diğer Doktorlarımızdan Randevu Alabilir veya Talep Açabilirsiniz.. Doctorla ");
                return Json(new { status = -1, title = "İşlem Başarılı", message = "Randevuyu Reddettiniz.İstek Listeniz Yenileniyor" });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("DoctorPanel - RandevuTalep", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }
        #endregion
        public void ErrorLogs(string page)
        {
            //api.RequestPost<object>("Logs/LogsAdd", new { page,3 });
            LogsServices.LogsAdd(page, _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "");
        }
        public bool IsAjaxRequest(HttpRequest request)
        {
            return request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }


    }

}