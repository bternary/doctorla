using CoreLibrary;
using CoreLibrary.Notifications;
using CoreLibrary.Payment;
using Data;
using Data.DataViews;
using Data.Domain;
using Data.Interfaces;
using GrapeCity.Documents.Html;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PagedList.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Web.Resources;
using Data.Extensions;
using Domain.Interfaces.Base;
using Web.Models;
using Microsoft.Extensions.Configuration;
using Domain.Enums;

namespace Web.Controllers
{
    public class SaglikcimController : Controller
    {
        private readonly NotificationSender sendNotify;
        private readonly DataContext dbcontext;
        private readonly IRepository<County> county;
        private readonly IRepository<City> city;
        private IRepository<UserType> usertypedb;
        private readonly IWebHostEnvironment rootpath;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _settings;
        public SaglikcimController(IWebHostEnvironment _rootpath, IHttpContextAccessor httpContextAccessor,
            DataContext dbcontext,
            IRepository<UserType> usertypedb,
            IRepository<County> county,
            IRepository<City> city,
            IConfiguration settings
            )
        {
            rootpath = _rootpath;
            _httpContextAccessor = httpContextAccessor;
            this.dbcontext = dbcontext;
            this.usertypedb = usertypedb;
            sendNotify = new NotificationSender();
            this.county = county;
            this.city = city;
            _settings = settings;
        }

        public IActionResult Anasayfa()
        {
            return View();
        }

        public IActionResult TakipModeli()
        {
            try
            {
                var itm = dbcontext.Package.Where(p => p.IsActive && !p.IsDeleted)
                    .Include(p => p.Offers)
                    .Include(p => p.RelPackageDetail)
                    .ThenInclude(p => p.PackageDetail)
                    .ToList();
                return View(itm);
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - TakipModeli", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }
        public IActionResult GetPackageDetail(int packageId, int doctorId = 0)
        {
            var package = dbcontext.Package.Where(p => p.IsActive && !p.IsDeleted && p.Id == packageId)
                .Include(p => p.Offers)
                .Include(p => p.RelPackageDetail)
                .ThenInclude(p => p.PackageDetail).FirstOrDefault();
            User doctor = null;
            if (doctorId > 0)
                doctor = dbcontext.User.Where(p => p.Id == doctorId).FirstOrDefault();
            return PartialView("~/Views/Saglikcim/Partials/_GetPackageDetail.cshtml", new PackageDetailModel { Package = package, Doctor = doctor });
        }


        public JsonResult DoctorCodeCheck(int code)
        {
            try
            {
                var doctor = dbcontext.DoctorDetail.Where(x => x.DoctorUniqueId == code).Include(x => x.User).Select(x => new { ad = x.User.FullName(), id = x.UserId }).FirstOrDefault();
                if (doctor != null)
                {
                    return Json(new { status = 1, title = "İşlem Başarılı", message = "Doktor Bulundı", doctor = doctor });
                }
                return Json(new { status = -1, title = "İşlem Başarısız", message = "Böyle Bir Doktor Bulunmamaktadır" });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - DoctorCodeCheck", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }

        public ActionResult DailycheckPaketKontrol(int doktorId)
        {
            try
            {
                List<Claim> useridentity = GetIdentitiy();
                Int16 userid = Convert.ToInt16(useridentity.FirstOrDefault(x => x.Type == "id").Value);
                if (userid == 0)
                {
                    return Json(new { status = -1, title = "Giriş Bulunamadı", message = "Lütfen Giriş Yapınız" });
                }
                User user = GetUser();
                if (user == null)
                    return RedirectToAction("Giris", "Doctorla");
                DailyCheck dailyCheck = dbcontext.DailyCheck.FirstOrDefault(x => x.PackageName == "Doktor Takip Paketi" && x.UserId == user.Id && x.NurseId == doktorId);
                if (dailyCheck != null)
                {
                    return Json(new { status = 1, message = "Doktor Takip Paketi hesabınıza tanımlanmıştır." });
                }
                else
                {
                    return Json(new { status = 2, message = "Ücretsiz Takip Paketi hesabınıza tanımlanmıştır." });
                }
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - DailycheckPaketKontrol", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }

        #region OtherPages
        public ActionResult Hakkimizda()
        {
            return View();
        }
        public ActionResult privacy_policy()
        {
            return View();
        }
        public ActionResult SatisPolitikasi()
        {
            return View();
        }
        public ActionResult CerezPolitikasi()
        {
            return View();
        }
        public ActionResult TibbiBirimler()
        {
            try
            {
                List<Department> departments = dbcontext.Department
                    .Include(x => x.RelUserDepartments)
                    .ThenInclude(x => x.User)
                    .Where(x => x.RelUserDepartments.Any(p => p.IsActive && !p.IsDeleted && p.User.IsActive && !p.User.IsDeleted && p.User.TypeId== (int)UserTypesEnum.Doctor) && x.IsActive && !x.IsDeleted)
                    .OrderBy(x => x.Name)
                    .ToList();
                //foreach (var item in departments.ToList())
                //{
                //    if (item.RelUserDepartments.Where(x => x.User.IsActive).ToList().Count == 0)
                //        departments.Remove(item);
                //}
                return View(departments);
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - TibbiBirimler", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }
        public ActionResult Doktorlarimiz(string BolumAdi)
        {
            try
            {
                Department selectedDepartment = dbcontext.Department.FirstOrDefault(x => x.Name.Replace(" ", "") == BolumAdi && x.IsActive && !x.IsDeleted);
                if (selectedDepartment == null)
                    return RedirectToAction("TibbiBirimler", "Doctorla");

                TempData["Bölüm Adı"] = BolumAdi;
                TempData["bolumAdi"] = selectedDepartment.Name;
                List<RelUserDepartment> doctors = dbcontext.RelUserDepartment
                    .Where(x => x.DepartmentId == selectedDepartment.Id && x.User.IsActive && !x.User.IsDeleted && x.IsActive && !x.IsDeleted && x.User.TypeId == (int)UserTypesEnum.Doctor)
                    .Include(x => x.User)
                    .ThenInclude(x => x.DoctorDetail)
                    .ToList();
                return View(doctors);
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - Doktorlarimiz", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }
        public ActionResult DoktorBilgileri(string BolumAdi, int id, string DoktorAdi)
        {
            try
            {
                if (id == 0)
                    return RedirectToAction("TibbiBirimler", "Doctorla");
                Department selectedDepartment = dbcontext.Department.FirstOrDefault(x => x.Name.Replace(" ", "") == BolumAdi && x.IsActive && !x.IsDeleted);
                if (selectedDepartment == null)
                    return RedirectToAction("TibbiBirimler", "Doctorla");
                DoctorDetail doctordetail = dbcontext.DoctorDetail.Where(x => x.UserId == id).Include(x => x.User).Include(x => x.DoctorEducations).Include(x => x.DoctorExperiences).Include(x => x.DoctorMedicalInterests).Include(x => x.DoctorScientificMembership).FirstOrDefault();
                RelUserDepartment relUserDepartment = dbcontext.RelUserDepartment.Where(x => x.UserId == id && x.DepartmentId == selectedDepartment.Id).FirstOrDefault();
                if (doctordetail == null)
                    return RedirectToAction("TibbiBirimler", "Doctorla");
                if (doctordetail.User == null)
                    return RedirectToAction("TibbiBirimler", "Doctorla");
                if (!doctordetail.User.IsActive && doctordetail.User.IsDeleted)
                    return RedirectToAction("TibbiBirimler", "Doctorla");
                doctordetail.PageView++;
                dbcontext.SaveChanges();
                TempData["bolumId"] = selectedDepartment.Id;
                TempData["userId"] = doctordetail.UserId;
                ViewBag.Price = relUserDepartment.Price;
                ViewBag.SessionTime = relUserDepartment.SessionTime;
                return View(doctordetail);
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - DoktorBilgileri", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }
        [Authorize(Roles = "Hasta,Doktor,Hemşire")]
        public ActionResult LiveChat(string roomname)
        {
            try
            {
                User user = GetUser();
                bool IsDoctor = user.UserType.Id == 1 || user.UserType.Id == 2;
                Appointment appointment = dbcontext.Appointment.FirstOrDefault(x => x.SessionKey == roomname && x.AppointmentFinishDate > DateTime.Now && x.IsActive && !x.IsDeleted);
                if (appointment != null)
                {
                    dbcontext.AppointmentProcess.Add(new AppointmentProcess() { Appointment = appointment, IDate = DateTime.Now, IsDoctor = IsDoctor, User = user, ProcessMessage = user.UserType.Name + " " + user.Name + " " + user.SurName + " Adlı Kişi Canlı Görüşmeye Giriş Yaptı" });
                    dbcontext.SaveChanges();
                    ViewBag.chatid = roomname;
                    TimeSpan sessionend = appointment.AppointmentFinishDate - DateTime.Now;
                    ViewBag.Minute = sessionend.Minutes;
                    string name = user.Name + " " + user.SurName;
                    ViewBag.Name = name.ToLower().Trim('ç', 'c').Trim('ü', 'u').Trim('ğ', 'g').Trim('İ', 'i').Trim('ö', 'o').Trim('ş', 's');
                    ViewBag.Seconds = sessionend.Seconds;
                    return View();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - LiveChat", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }
        public ActionResult dailyCheckLive(int id)
        {
            try
            {
                User user = GetUser();
                DailyCheck dailyCheck = dbcontext.DailyCheck.FirstOrDefault(x => x.Id == id && x.LiveEndDate > DateTime.Now && !x.IsDeleted);
                if (dailyCheck != null && (dailyCheck.UserId == user.Id || dailyCheck.NurseId == user.Id))
                {
                    ViewBag.chatid = dailyCheck.LiveRoomName;
                    string name = user.Name + " " + user.SurName;
                    ViewBag.Name = name.ToLower().Trim('ç', 'c').Trim('ü', 'u').Trim('ğ', 'g').Trim('İ', 'i').Trim('ö', 'o').Trim('ş', 's');
                    return View();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - dailyCheckLive", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }
        [HttpPost]
        public JsonResult Contact(Contact contact, string validationcheck, string validation)
        {
            try
            {
                if (String.IsNullOrEmpty(contact.Name))
                    return Json(new { status = -1, title = "Bilgi Eksik", message = "Lütfen İsim Yazınız" });
                if (String.IsNullOrEmpty(contact.Phone))
                    return Json(new { status = -1, title = "Bilgi Eksik", message = "Lütfen Telefon Yazınız" });
                if (String.IsNullOrEmpty(contact.Message))
                    return Json(new { status = -1, title = "Bilgi Eksik", message = "Lütfen Mesaj Yazınız" });
                if (validationcheck != validation)
                    return Json(new { status = -1, title = "Doğrulama Hatası", message = "Toplama İşlemi Hatalı" });
                contact.IDate = DateTime.Now;
                dbcontext.Contact.Add(contact);
                dbcontext.SaveChanges();
                return Json(new { status = 1, title = "İşlem Başarılı", message = "Mesajınız Başarılı Bir Şekilde Kaydedildi" });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - Contact", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }

        #endregion



        #region UserProfile ------

        [Authorize(Roles = "Hasta")] // User Check İşlemi
        public ActionResult Profilim(int page = 1, string order = "0", string ordertype = "asc", string filter = "")
        {
            try
            {
                List<Claim> useridentity = GetIdentitiy();
                Int16 userid = Convert.ToInt16(useridentity.FirstOrDefault(x => x.Type == "id").Value);
                User user = dbcontext.User.Where(x => x.Id == userid).Include(x => x.UserDetail).Include(x => x.DailyCheck).ThenInclude(sn => sn.Nurse).FirstOrDefault();
                if (user == null)
                    return RedirectToAction("Giris", "Doctorla");

                // DailyCheck dailyCheck = dbcontext.DailyCheck.Where(x => x.UserId == userid).FirstOrDefault();

                IQueryable<Appointment> appointments = dbcontext.Appointment.Where(x => x.UserId == GetUser().Id).Include(x => x.Department);
                ViewBag.Order = order;
                ViewBag.OrderType = ordertype;
                ViewBag.Filter = filter;
                switch (order)
                {

                    case "0":
                        order = "Department.Name";
                        break;
                    case "1":
                        order = "DoctorName";
                        break;
                    case "2":
                        order = "AppointmentDate";
                        break;
                    case "3":
                        order = "Status";
                        break;
                    default:
                        order = "AppointmentDate";
                        break;
                }
                if (ordertype.ToLower() == "asc")
                    appointments = appointments.OrderBy(order);
                else
                    appointments = appointments.OrderByDescending(order);
                PagedList<Appointment> appointmentsPaged = new PagedList<Appointment>(appointments, page, 10);

                ViewBag.Name = user.Name;
                ViewBag.SurName = user.SurName;
                ViewBag.AccountBalance = user.AccountBalance;
                ViewBag.DailyCheckCount = user.DailyCheck.Count;
                ViewBag.Numara = user.Id;
                ViewBag.IsActive = user.IsActive;

                return View(appointmentsPaged);
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - Profilim-1", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }
        [Authorize(Roles = "Hasta")] // User Check İşlemi
        public ActionResult RandevuTaleplerim(int page = 1)
        {
            try
            {
                List<Claim> useridentity = GetIdentitiy();
                Int16 userid = Convert.ToInt16(useridentity.FirstOrDefault(x => x.Type == "id").Value);
                User user = dbcontext.User.Where(x => x.Id == userid).Include(x => x.UserDetail).Include(x => x.DailyCheck).ThenInclude(sn => sn.Nurse).FirstOrDefault();
                if (user == null)
                    return RedirectToAction("Giris", "Doctorla");
                List<NotifyWarning> notifyWarnings = dbcontext.NotifyWarning.Where(x => x.UserId == GetUser().Id && x.Date >= DateTime.Now).Include(x => x.User).Include(x => x.Department).ThenInclude(x => x.RelUserDepartments).ThenInclude(x => x.User).OrderBy(x => x.Status).ThenByDescending(x => x.Date).ToList();
                if (notifyWarnings == null) // KUllanıcıya ait mi kontrolü
                    return null;
                PagedList<NotifyWarning> notifyWarningsPaged = new PagedList<NotifyWarning>(notifyWarnings.AsQueryable(), page, 10);

                ViewBag.Name = user.Name;
                ViewBag.SurName = user.SurName;
                ViewBag.AccountBalance = user.AccountBalance;
                ViewBag.DailyCheckCount = user.DailyCheck.Count;
                ViewBag.Numara = user.Id;
                ViewBag.IsActive = user.IsActive;
                return View(notifyWarningsPaged);
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - RandevuTaleplerim-1", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }

        public ActionResult EditProfile()
        {
            try
            {
                List<Claim> useridentity = GetIdentitiy();
                Int16 userid = Convert.ToInt16(useridentity.FirstOrDefault(x => x.Type == "id").Value);
                User user = dbcontext.User.Where(x => x.Id == userid).Include(x => x.UserDetail).Include(x => x.DailyCheck).ThenInclude(sn => sn.Nurse).FirstOrDefault();
                List<Address> adres = dbcontext.Address.Where(x => x.UserId == user.Id).Include(x => x.Country).Include(x => x.City).Include(x => x.County).ToList();
                if (user == null)
                    return RedirectToAction("Giris", "Doctorla");
                user.Address = adres;
                List<Country> countrys = dbcontext.Country.ToList();
                TempData["Countrys"] = countrys;
                ViewBag.BloodType = user.UserDetail.Bloodtype;
                ViewBag.Name = user.Name;
                ViewBag.SurName = user.SurName;
                ViewBag.AccountBalance = user.AccountBalance;
                ViewBag.DailyCheckCount = user.DailyCheck.Count;
                ViewBag.Numara = user.Id;
                return View(user);
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - EditProfile", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }
        [Authorize(Roles = "Hasta")]
        public PartialViewResult getUserAppointment(int page = 1)
        {
            try
            {
                List<Appointment> appointments = dbcontext.Appointment.Where(x => x.UserId == GetUser().Id).Include(x => x.Department).ToList();
                if (appointments == null) // KUllanıcıya ait mi kontrolü
                    return null;
                User user = GetUser();
                PagedList<Appointment> appointmentsPaged = new PagedList<Appointment>(appointments.AsQueryable(), page, 10);
                ViewBag.Name = user.Name + " " + user.SurName;
                return PartialView("~/Views/Saglikcim/Partials/_UserAppointment.cshtml", appointmentsPaged);
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - getUserAppointment", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }
        [Authorize(Roles = "Hasta")]
        public ActionResult getPackages(int page = 1)
        {
            try
            {
                List<Claim> useridentity = GetIdentitiy();
                Int16 userid = Convert.ToInt16(useridentity.FirstOrDefault(x => x.Type == "id").Value);
                User user = dbcontext.User.Where(x => x.Id == userid).Include(x => x.UserDetail).Include(x => x.DailyCheck).ThenInclude(sn => sn.Nurse).FirstOrDefault();
                if (user.Id == 0)
                    return RedirectToAction("Giris", "Doctorla");

                List<DailyCheck> dailyChecks = dbcontext.DailyCheck.Where(x => x.UserId == GetUser().Id && x.IsDeleted == false).Include(x => x.DailyCheckDetail).ThenInclude(x => x.ValuesTitle).Include(x => x.Nurse).ToList();
                var doctorAdi = "";
                string uyarı = "";
                foreach (var item in dailyChecks)
                {
                    if (item.LiveRequestDate < DateTime.Now)
                    {
                        item.IsRequest = false;
                    }
                    doctorAdi = item.Nurse.FullName();
                    foreach (var values in item.DailyCheckDetail.Where(x => x.IsNew == true))
                    {
                        uyarı += "<li><strong>" + values.ValuesTitle.Name + "</strong> Görevi Eklendi</li>";

                        values.IsNew = false;
                    }
                }
                dbcontext.SaveChanges();
                if (dailyChecks == null) // KUllanıcıya ait mi kontrolü
                    return null;
                PagedList<DailyCheck> dailyChecksPaged = new PagedList<DailyCheck>(dailyChecks.AsQueryable(), page, 10);
                ViewBag.Name = user.Name;
                ViewBag.SurName = user.SurName;
                ViewBag.AccountBalance = user.AccountBalance;
                ViewBag.DailyCheckCount = user.DailyCheck.Count;
                ViewBag.Uyarı = uyarı;
                ViewBag.DoktorAdi = doctorAdi;
                return View(dailyChecksPaged);
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - getPackages", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }
        [Authorize(Roles = "Hasta")]
        [HttpPost]
        public ActionResult Profilim(User updateuser, string UserDetail_Bloodtype, string photofile, int Country, int City, int County, string AddressDetail)
        {
            try
            {
                List<Claim> useridentity = GetIdentitiy();
                Int16 userid = Convert.ToInt16(useridentity.FirstOrDefault(x => x.Type == "id").Value);
                User user = dbcontext.User.Where(x => x.Id == userid).Include(x => x.Address).Include(x => x.UserDetail).FirstOrDefault();
                if (user == null)
                    return RedirectToAction("Giris", "Doctorla");
                if (!String.IsNullOrEmpty(photofile))
                {
                    var basePath = Path.Combine(_settings["BaseFileDirectory"], "UserImages");
                    var photoName = "";
                    if (user.PhotoUrl.EndsWith("defaultuser.png"))
                    {
                        photoName = Guid.NewGuid().ToString() + ".png";
                        user.PhotoUrl = _settings["BaseFileSharePath"] + "/UserImages/" + photoName;
                    }
                    else
                    {
                        var splited = user.PhotoUrl.Split('/');
                        photoName = splited[splited.Length - 1];
                    }

                    var filePath = Path.Combine(basePath, photoName);
                    var bytes = Convert.FromBase64String(photofile.Split(',')[1]);
                    using (var File = new FileStream(filePath, FileMode.Create))
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
                user.UUDate = DateTime.Now;
                user.UserDetail.UserJob = updateuser.UserDetail.UserJob;
                user.UserDetail.Note = updateuser.UserDetail.Note;
                user.Gender = updateuser.Gender;
                user.UserDetail.Height = updateuser.UserDetail.Height;
                user.UserDetail.Weight = updateuser.UserDetail.Weight;
                user.UserDetail.Bloodtype = UserDetail_Bloodtype;
                user.UserDetail.ChronicDiseases = updateuser.UserDetail.ChronicDiseases;
                user.UserDetail.FamilyDiseases = updateuser.UserDetail.FamilyDiseases;
                user.UserDetail.RegularlyMedicines = updateuser.UserDetail.RegularlyMedicines;
                user.UserDetail.HearUs = updateuser.UserDetail.HearUs;
                user.UserDetail.SurgicalHistory = updateuser.UserDetail.SurgicalHistory;
                user.Address.FirstOrDefault().CountryId = Country;
                user.Address.FirstOrDefault().CityId = City;
                user.Address.FirstOrDefault().CountyId = County;
                user.Address.FirstOrDefault().AddressDetail = AddressDetail;
                dbcontext.SaveChanges();
                TempData["Kaydet"] = "Güncelleme Başarılı";
                return RedirectToAction("EditProfile", "Doctorla");
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - Profilim-2", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }

        [Authorize(Roles = "Hasta")]
        [HttpPost]
        public ActionResult UploadImage(IFormFile Userphoto)
        {
            try
            {
                List<Claim> useridentity = GetIdentitiy();
                Int16 userid = Convert.ToInt16(useridentity.FirstOrDefault(x => x.Type == "id").Value);
                User user = dbcontext.User.FirstOrDefault(x => x.Id == userid);
                if (Userphoto != null)
                    if (Userphoto.Length > 0)
                    {
                        var basePath = Path.Combine(_settings["BaseFileDirectory"], "UserImages");
                        var photoName = "";

                        if (user.PhotoUrl.EndsWith("defaultuser.png"))
                        {
                            photoName = Guid.NewGuid().ToString() + ".png";
                            user.PhotoUrl = _settings["BaseFileSharePath"] + "/UserImages/" + photoName;
                        }
                        else
                        {
                            var splited = user.PhotoUrl.Split('/');
                            photoName = splited[splited.Length - 1];
                        }

                        var filePath = Path.Combine(basePath, photoName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            Userphoto.CopyToAsync(stream);
                        }
                    }
                dbcontext.SaveChanges();
                return RedirectToAction("Profilim", "Doctorla");
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - UploadImage", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }
        [HttpPost]


        #endregion

        #region ----Paketler-----


        [Authorize(Roles = "Hasta")]
        public PartialViewResult GetDailyCheckDetail(int Id, int page = 1)
        {
            try
            {
                var userId = GetUser().Id;
                DailyCheck package = dbcontext.DailyCheck.FirstOrDefault(x => x.Id == Id && x.UserId == userId);
                if (package == null) // KUllanıcıya ait mi kontrolü
                    return null;
                List<DailyCheckDetail> dailyChecks = dbcontext.DailyCheckDetail.Where(x => x.DailyCheckId == Id).Include(x => x.DailyCheck).Include(x => x.ValuesTitle).Include(x => x.Values).ToList();
                ViewBag.IsPremium = package.IsPremium;
                return PartialView("~/Views/Saglikcim/Partials/DailyCheckDetail.cshtml", dailyChecks);
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - GetDailyCheckDetail", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }





        [Authorize(Roles = "Hasta")]
        public ActionResult CreateDailyCheckDetail(int Id, string Values, string files)
        {
            try
            {
                if (GetUser() == null)
                    return RedirectToAction("Giris", "Doctorla");
                if (Id == 0 && dbcontext.DailyCheck.FirstOrDefault(x => x.Id == Id).UserId != GetUser().Id)
                    return Json(new { status = -1, title = "İşlem Başarısız", message = "Lütfen Değerleri Giriniz" });
                DailyCheck dailycheck = dbcontext.DailyCheck.Where(x => x.Id == Id).Include(x => x.User).Include(x => x.DailyCheckDetail).FirstOrDefault();
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
                //var json = api.RequestPost<Dictionary<string, object>>("DailyCheck/SaglikcimAddDailyCheck", new { Id, Values, files });
                string filenames = "";
                string fileshtml = " ";

                //if (json["filename"].ToString() != "-1")
                //{
                if (!String.IsNullOrEmpty(files))
                {
                    foreach (var detailfile in Regex.Split(files, ":::"))
                    {
                        if (!String.IsNullOrEmpty(detailfile))
                        {
                            string filename = Guid.NewGuid().ToString() + "-" + dailycheck.User.Name + "_" + dailycheck.User.SurName;
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
                //    //-----------------------------

                dailycheck.IsNewData = true;
                dbcontext.SaveChanges();
                return Json(new { status = 1, files = fileshtml, Date = DateTime.Now.ToString("yyyy.MM.dd HH:mm"), Id = detailvaluecode, title = "İşlem Başarılı", message = "Değerleriniz Başarılı Bir Şekilde Eklendi" });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - CreateDailyCheckDetail", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }
        [HttpPost]
        public ActionResult UpdateDailyCheckDetail(string Key, string Values)
        {
            try
            {
                if (GetUser() == null)
                    return RedirectToAction("Giris", "Doctorla");
                if (dbcontext.DailyCheck.FirstOrDefault(x => x.Id == dbcontext.DailyCheckDetail.FirstOrDefault(x => x.Id == dbcontext.DailyCheckDetailValues.FirstOrDefault(x => x.Key == Key).DailyCheckDetailId).DailyCheckId && x.UserId == GetUser().Id) == null) // KUllanıcıya ait mi kontrolü
                    return null;
                if (Values == null && String.IsNullOrEmpty(Key))
                    return Json(new { status = -1, title = "İşlem Başarısız", message = "Lütfen Değerleri Giriniz" });
                string[] valuesarray = Values.Split(',');
                List<DailyCheckValues> DailyCheckvalues = JsonConvert.DeserializeObject<List<DailyCheckValues>>(Values);
                int[] valueids = DailyCheckvalues.Select(x => x.DailyCheckDetailId).ToArray();
                List<DailyCheckDetailValues> oldvalues = dbcontext.DailyCheckDetailValues.Where(x => valueids.Contains(x.DailyCheckDetailId) && x.Key == Key).ToList();
                foreach (var item in oldvalues)
                {
                    if (DailyCheckvalues.FirstOrDefault(x => x.DailyCheckDetailId == item.DailyCheckDetailId) != null)
                        item.Value = DailyCheckvalues.FirstOrDefault(x => x.DailyCheckDetailId == item.DailyCheckDetailId).Value;
                    else
                        item.Value = "";
                    DailyCheckvalues.Remove(DailyCheckvalues.FirstOrDefault(x => x.DailyCheckDetailId == item.DailyCheckDetailId));
                }
                if (valueids.Length != oldvalues.Count)
                {
                    foreach (var item in DailyCheckvalues)
                    {
                        dbcontext.DailyCheckDetailValues.Add(new DailyCheckDetailValues()
                        {
                            DailyCheckDetailId = oldvalues.FirstOrDefault().DailyCheckDetailId,
                            IDate = oldvalues.FirstOrDefault().IDate,
                            Key = Key,
                            Value = item.Value,
                            TitleOrder = dbcontext.DailyCheckDetail.FirstOrDefault(x => x.Id == item.DailyCheckDetailId).TitleOrder
                        });
                    }
                }
                dbcontext.SaveChanges();
                return Json(new { status = 1, title = "İşlem Başarılı", message = "Ölçüleriniz Başarılı Bir Şekilde Güncellenmiştir" });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - UpdateDailyCheckDetail", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }
        [Authorize(Roles = "Hasta,Doktor,Hemşire")]
        [HttpGet]
        public ActionResult Hatirlaticilar(int Id)
        {
            try
            {
                if (GetUser() == null)
                    return RedirectToAction("Giris", "Doctorla");
                DailyCheck dailyCheck = dbcontext.DailyCheck.Where(x => x.Id == Id && (x.UserId == GetUser().Id || x.NurseId == GetUser().Id)).Include(x => x.DailyCheckAlerts).FirstOrDefault();
                return Json(new { phone = dailyCheck.ExtraPhone, alerts = dailyCheck.DailyCheckAlerts.Select(x => new { Id = x.Id, alertdate = x.AlertDay.ToString("dd/MM/yyyy HH:mm"), daycounter = x.DayCounter, message = x.Message }).ToList() });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - Hatirlaticilar", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }
        [Authorize(Roles = "Hasta,Doktor,Hemşire")]
        public ActionResult HatirlaticiEkle(int Id, string ExtraPhone, DateTime AlertDay, int AlertDayCounter, string Message)
        {
            try
            {
                if (GetUser() == null)
                    return RedirectToAction("Giris", "Doctorla");
                DailyCheck dailyCheck = dbcontext.DailyCheck.Where(x => x.Id == Id && (x.UserId == GetUser().Id || x.NurseId == GetUser().Id)).Include(x => x.DailyCheckAlerts).FirstOrDefault();
                if (dailyCheck == null)
                    return Json(new { status = -1, Id = dailyCheck.Id, title = "İşlem Başarısız", message = "Hatırlatıcı Eklenemedi" });
                dailyCheck.ExtraPhone = ExtraPhone != null ? ExtraPhone : dailyCheck.ExtraPhone;
                dbcontext.DailyCheckAlerts.Add(new DailyCheckAlerts { DailyCheckId = dailyCheck.Id, AlertDay = AlertDay, DayCounter = AlertDayCounter, Message = Message ?? "" });
                dbcontext.SaveChanges();
                return Json(new { status = 1, Id = dailyCheck.Id, title = "İşlem Başarılı", message = "Hatırlatıcı Başarılı Bir Şekilde Eklendi" });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - HatirlaticiEkle", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }
        [Authorize(Roles = "Hasta,Doktor,Hemşire")]
        public ActionResult HatirlaticiSil(int Id)
        {
            try
            {
                if (GetUser() == null)
                    return RedirectToAction("Giris", "Doctorla");
                DailyCheckAlerts alerts = dbcontext.DailyCheckAlerts.Where(x => x.Id == Id).FirstOrDefault();
                DailyCheck dailyCheck = dbcontext.DailyCheck.Where(x => x.Id == alerts.DailyCheckId && (x.UserId == GetUser().Id || x.NurseId == GetUser().Id)).FirstOrDefault();
                if (alerts == null || dailyCheck == null)
                    return Json(new { status = -1, title = "İşlem Başarısız", message = "Hatırlatıcı Silinemedi" });
                dbcontext.DailyCheckAlerts.Remove(alerts);
                dbcontext.SaveChanges();
                return Json(new { status = 1, Id = Id, title = "İşlem Başarılı", message = "Hatırlatıcı Başarılı Bir Şekilde Silindi" });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - HatirlaticiSil", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }
        [Authorize(Roles = "Hasta,Doktor,Hemşire")]
        public ActionResult HatirlaticiGüncelle(int Id, string ExtraPhone, DateTime AlertDay, int AlertDayCounter, string Message)
        {
            try
            {
                if (GetUser() == null)
                    return RedirectToAction("Giris", "Doctorla");
                DailyCheckAlerts alerts = dbcontext.DailyCheckAlerts.Where(x => x.Id == Id).FirstOrDefault();
                DailyCheck dailyCheck = dbcontext.DailyCheck.Where(x => x.Id == alerts.DailyCheckId && (x.UserId == GetUser().Id || x.NurseId == GetUser().Id)).FirstOrDefault();
                if (alerts == null || dailyCheck == null)
                    return Json(new { status = -1, title = "İşlem Başarısız", message = "Hatırlatıcı Güncellenemedi" });
                dailyCheck.ExtraPhone = ExtraPhone != null ? ExtraPhone : dailyCheck.ExtraPhone;
                alerts.AlertDay = AlertDay;
                alerts.DayCounter = AlertDayCounter;
                alerts.Message = Message;
                dbcontext.DailyCheckAlerts.Update(alerts);
                dbcontext.SaveChanges();
                return Json(new { status = 1, Id = Id, title = "İşlem Başarılı", message = "Hatırlatıcı Başarılı Bir Şekilde Güncellendi" });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - HatirlaticiGüncelle", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }
        public JsonResult UpdateDailyCheck(int Id, DateTime AlertDay, string ExtraPhone, int AlertDayCounter, string AlertDayHours)
        {
            try
            {
                if (AlertDay < DateTime.Now)
                    return Json(new { status = -1, title = "Tarih Hatası", message = "Geçmiş Tarihlere Hatırlatıcı Açamazsınız!" });
                DailyCheck dailyCheck = dbcontext.DailyCheck.FirstOrDefault(x => x.Id == Id);
                if (dailyCheck.UserId != GetUser().Id)
                    return null;
                dailyCheck.AlertDay = AlertDay;
                dailyCheck.ExtraPhone = ExtraPhone;
                dailyCheck.AlertDayCounter = AlertDayCounter;
                dailyCheck.AlertDayHours = AlertDayHours;
                dbcontext.DailyCheck.Update(dailyCheck);
                dbcontext.SaveChanges();
                return Json(new { status = 1, Id = dailyCheck.Id, title = "İşlem Başarılı", message = "Değerleriniz Başarılı Bir Şekilde Eklendi" });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - UpdateDailyCheck", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }

        #region ----DailyCheck Chat-----
        [Authorize(Roles = "Doktor,Hasta")]
        public ActionResult Sohbet(int id)
        {
            try
            {
                List<Claim> useridentity = GetIdentitiy();
                Int16 userid = Convert.ToInt16(useridentity.FirstOrDefault(x => x.Type == "id").Value);
                User user = dbcontext.User.Where(x => x.Id == userid).Include(x => x.UserDetail).Include(x => x.DailyCheck).ThenInclude(sn => sn.Nurse).FirstOrDefault();
                if (user == null)
                    return RedirectToAction("Giris", "Doctorla");

                ViewBag.Name = user.Name;
                ViewBag.SurName = user.SurName;
                ViewBag.AccountBalance = user.AccountBalance;
                ViewBag.DailyCheckCount = user.DailyCheck.Count;
                ViewBag.Numara = user.Id;
                DailyCheck dailycheck = dbcontext.DailyCheck.Where(x => x.Id == id).Include(x => x.User).Include(x => x.Nurse).Include(x => x.PackageChat).FirstOrDefault();
                if (dailycheck != null)
                    if (dailycheck.UserId == GetUser().Id)
                        return View(dailycheck);
                return RedirectToAction("Profilim", "Doctorla");
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - Sohbet", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }
        [Authorize(Roles = "Hasta")]
        public ActionResult Doktorlarim()
        {
            try
            {
                List<DailyCheck> dailycheck = dbcontext.DailyCheck.Where(x => x.UserId == GetUser().Id && x.IsDoctor == true).Include(x => x.User).Include(x => x.Nurse).Include(x => x.PackageChat).ToList();
                ViewBag.DailyCheckCount = dailycheck.Count;
                return View(dailycheck);
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - Doktorlarim", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }
        [Authorize(Roles = "Hasta")]
        [HttpPost]
        public ActionResult MesajGonder(string Message, int DailyCheckId, string files)
        {
            try
            {
                //var json = api.RequestPost<Dictionary<string, object>>("DailyCheck/MesajGonderHasta", new {Message,DailyCheckId,files});
                var isFile = false;
                //---------------- Upload Files
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
                    IsDoctor = false,
                    IsFile = isFile,
                };
                dbcontext.PackageChat.Add(packageChat);
                dbcontext.SaveChanges();
                return Json(new { status = 1, Id = DailyCheckId, date = DateTime.Now.ToString("dd.MM.yyyy HH:mm tt"), file = files, title = "İşlem Başarılı", message = "Ölçüleriniz Başarılı Bir Şekilde Güncellenmiştir" });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - MesajGonder", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }

        #endregion

        #endregion




        #region Appointments Business Functions ----

        [Authorize(Roles = "Hasta")]
        public PartialViewResult GetAppointmentDetail(string sessionkey)
        {
            try
            {
                User user = GetUser();
                Appointment userappointment = dbcontext.Appointment.Where(x => !x.IsDeleted && x.SessionKey == sessionkey).Include(x => x.Department).Include(x => x.AppointmentFiles).FirstOrDefault();
                if (userappointment != null)
                {
                    User doctor = dbcontext.User.FirstOrDefault(x => x.Id == userappointment.DoctorId);
                    userappointment.DoctorName = doctor.Name + " " + doctor.SurName;
                    return PartialView("~/Views/Saglikcim/Partials/_AppointmentDetailModal.cshtml", userappointment);
                }
                return null;
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - GetAppointmentDetail", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }

        [Authorize(Roles = "Hasta")]
        [HttpPost]
        public ActionResult deleteAppointment(string sessionkey, string deleteReason)
        {
            try
            {
                User user = GetUser();
                if (user == null)
                    return RedirectToAction("Giris", "Doctorla");
                Appointment appointment = dbcontext.Appointment.Where(x => !x.IsDeleted && x.Status == 0 && x.UserId == user.Id && x.SessionKey == sessionkey).FirstOrDefault();
                if (appointment != null)
                {
                    if (appointment.AppointmentDate < DateTime.Now.AddHours(1))
                        return Json(new { status = -1, title = "İşlem Başarısız", message = "Randevu Başlama Saatine 1 Saat Kaldıktan Sonra Randevuyu İptal Edemezsiniz!" });

                    Appointment appointmentlog = new Appointment()
                    {
                        IsDeleted = true,
                        UserCancelReason = deleteReason,
                        Status = -2,
                        SessionKey = "",
                        User = user,
                        DoctorId = appointment.DoctorId,
                        DepartmentId = appointment.DepartmentId,
                        AppointmentDate = appointment.AppointmentDate,
                        AppointmentFinishDate = appointment.AppointmentFinishDate,
                        SessionPrice = appointment.SessionPrice,
                        SessionCode = appointment.SessionCode,
                        Sick = new Sick() { Name = "" },
                        IsPrivate = true,
                        IDate = DateTime.Now,
                        DoctorName = appointment.DoctorName
                    };
                    dbcontext.Appointment.Add(appointmentlog);
                    dbcontext.SaveChanges();
                    Random rnd = new Random();
                    string sessioncode = rnd.Next(100000, 999999).ToString();
                    appointment.SessionCode = sessioncode;
                    appointment.Status = 0;
                    appointment.IsDeleted = false;
                    appointment.UserId = 1;
                    dbcontext.AppointmentProcess.Add(new AppointmentProcess() { Appointment = appointment, IDate = DateTime.Now, IsDoctor = false, User = user, ProcessMessage = user.UserType.Name + " " + user.Name + " " + user.SurName + " Randevu İptali, Kullanıcı Tarafından Gerçekleştirildi.. Silme Sebebi:" + deleteReason });
                    Donations donation = dbcontext.Donations.FirstOrDefault(x => x.AppointmentId == appointment.Id);
                    if (donation != null)
                        dbcontext.Donations.Remove(donation);
                    dbcontext.SaveChanges();
                    User usercredit = dbcontext.User.FirstOrDefault(x => x.Id == user.Id);
                    usercredit.AccountBalance += appointment.SessionPrice;
                    dbcontext.SaveChanges();
                    var response = sendNotify.SendNotificationAsync(new NotificationPostData()
                    {
                        FcmTokens = dbcontext.NotifyTokens.Where(x => x.UserId == appointment.DoctorId).Select(x => x.Token).ToList(),
                        MessageData = new NotificationMessageData()
                        {
                            Title = "Randevu İptali",
                            Message = user.Name + " " + user.SurName + " Tarafından " + appointment.AppointmentDate.ToString("dd.MM.yyyy HH:mm") + "-" + appointment.AppointmentFinishDate.ToString("HH:mm") + " Tarihinde Bulunan Randevunuz İptal Edildi",
                            Link = "",
                            Action = "",
                            Image = "/images/logo.png"
                        }
                    });
                    return Json(new { status = 1, title = "İşlem Başarılı", message = "Tebrikler! Randevu İptali İle" + appointment.SessionPrice + " TL Kredi Kazandınız. Krediniz Sonraki İşleminizde Otomatik Olarak Kullanılacaktır" });
                }
                return Json(new { status = -1, title = "İşlem Başarısız", message = "Randevu Silinmiş veya Bu Randevuya Yetkiniz Bulunmuyor.." });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - deleteAppointment", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }


        [Authorize(Roles = "Hasta")]
        public ActionResult ratesOfAppointment(string sessionkey)
        {
            try
            {
                User user = GetUser();
                if (user == null)
                    return RedirectToAction("Giris", "Doctorla");
                Appointment appointment = dbcontext.Appointment.Where(x => !x.IsDeleted && x.UserId == user.Id && x.SessionKey == sessionkey).FirstOrDefault();
                if (appointment == null)
                    return Json(new { status = -1, title = "İşlem Başarısız", message = "Randevu Bilgilerinize ulaşılmıyor.." });
                return Json(new { status = 1, sessionkey = sessionkey, Rate = appointment.AppointmentRate, Note = appointment.AppointmentRateNote });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - ratesOfAppointment", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return Json(new { status = -1, title = "İşlem Başarısız", message = "Randevu Bilgileriniz Getirilirken Hata Oluştu.." });
            }
        }
        [Authorize(Roles = "Hasta")]
        [HttpPost]
        public ActionResult UpdateratesOfAppointment(string sessionkey, int Rate, string Note)
        {
            try
            {
                User user = GetUser();
                if (user == null)
                    return RedirectToAction("Giris", "Doctorla");
                Appointment appointment = dbcontext.Appointment.Where(x => !x.IsDeleted && x.UserId == user.Id && x.SessionKey == sessionkey).FirstOrDefault();
                if (appointment == null)
                    return Json(new { status = -1, title = "İşlem Başarısız", message = "Randevu Bilgilerinize ulaşılmıyor.." });
                appointment.AppointmentRate = Rate;
                appointment.AppointmentRateNote = Note;
                if (Rate == -1)
                {
                    appointment.AppointmentRate = -3;
                    List<int> admins = dbcontext.User.Where(x => x.TypeId == 4 && x.IsActive).Select(x => x.Id).ToList();
                    NotificationSender sendNotify = new NotificationSender();
                    var response = sendNotify.SendNotificationAsync(new NotificationPostData()
                    {
                        FcmTokens = dbcontext.NotifyTokens.Where(x => admins.Contains(x.UserId)).Select(x => x.Token).ToList(),
                        MessageData = new NotificationMessageData() { Title = "Doktor Gelmedi!", Message = user.Name + " " + user.SurName + "Adlı Kullanıcı Doktorun Randevuya Gelmediğini Oyladı!!  Randevu Kodu:" + appointment.SessionCode, Link = "", Action = "", Image = "https://www.doctorla.co/images/NotificaitonLogo.png" }
                    });
                }
                string ratetext = "";
                if (Rate == -1)
                    ratetext = "Doktor Gelmedi";
                else if (Rate == 1)
                    ratetext = "Çok Kötü";
                else if (Rate == 2)
                    ratetext = "Kötü";
                else if (Rate == 3)
                    ratetext = "Daha İyi Olabilir";
                else if (Rate == 4)
                    ratetext = "Orta";
                else if (Rate == 5)
                    ratetext = "İyi";
                else if (Rate == 5)
                    ratetext = "Çok İyi";
                dbcontext.AppointmentProcess.Add(new AppointmentProcess() { AppointmentId = appointment.Id, IDate = DateTime.Now, IsDoctor = false, User = user, ProcessMessage = user.UserType.Name + " " + user.Name + " " + user.SurName + " Kullanıcı Oy Kullandı: Seviye " + ratetext + "  Not: " + Note });
                dbcontext.SaveChanges();
                return Json(new { status = 1, title = "İşlem Başarılı", message = "Randevu Notunuz ve Oylamanız Başarılı Bir Şekilde Alınmıştır." });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - UpdateratesOfAppointment", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return Json(new { status = -1, title = "İşlem Başarısız", message = "Randevu Bilgileriniz Getirilirken Hata Oluştu.." });
            }
        }

        [Authorize(Roles = "Hasta")]
        [HttpPost]
        public ActionResult AppointmentDetailUpdate(string sessionkey, string[] appointdetailfiles, string AppointmentNote, string AppointmentDoctorNote)
        {
            try
            {
                User user = GetUser();
                if (user == null)
                    return RedirectToAction("Giris", "Doctorla");
                Appointment appointment = dbcontext.Appointment.Where(x => !x.IsDeleted && x.UserId == user.Id && x.SessionKey == sessionkey).FirstOrDefault();
                if (appointment.Id == 0)
                    return Json(new { status = -1, title = "İşlem Başarısız", message = "Randevu Bilgilerinize ulaşılmıyor.." });
                var json = new Dictionary<string, object>();
                foreach (var detailfile in appointdetailfiles)
                {
                    if (!String.IsNullOrEmpty(detailfile))
                    {
                        string filename = Guid.NewGuid().ToString();
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
                        var basePath = Path.Combine(_settings["BaseFileDirectory"], "AppointmentFiles");
                        var filePath = Path.Combine(basePath, filename);
                        var bytes = Convert.FromBase64String(detailfile.Split(',')[1]);
                        using (var File = new FileStream(filePath, FileMode.Create))
                        {
                            File.Write(bytes, 0, bytes.Length);
                            File.Flush();
                        }
                        dbcontext.AppointmentFiles.Add(new AppointmentFiles() { FileName = filename, AppointmentId = appointment.Id, IsDoctor = false });
                    }
                }
                appointment.AppointmentNote = AppointmentNote;
                dbcontext.SaveChanges();
                return Json(new { status = 1, title = "İşlem Başarılı", message = "Randevu Bilgileriniz Güncellenmiştir.." });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - AppointmentDetailUpdate", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return Json(new { status = -1, title = "İşlem Başarısız", message = "Randevu Bilgileriniz Güncellenirken Hata Oluştu.." });
            }
        }

        [Authorize(Roles = "Hasta")]
        [HttpPost]
        public JsonResult DeleteAppointmentFile(string FileName)
        {
            try
            {
                AppointmentFiles file = dbcontext.AppointmentFiles.FirstOrDefault(x => x.FileName == FileName);
                var basePath = Path.Combine(_settings["BaseFileDirectory"], "AppointmentFiles");
                var fullPath = Path.Combine(basePath, FileName);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                dbcontext.AppointmentFiles.Remove(file);
                dbcontext.SaveChanges();
                return Json(new { status = 1, title = "İşlem Başarılı", message = "Dosyanız Silinmiştir.." });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - DeleteAppointmentFile", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return Json(new { status = -1, title = "İşlem Başarısız", message = "Randevu Bilgileriniz Güncellenirken Hata Oluştu.." });
            }
        }

        [Authorize(Roles = "Hasta")]
        [HttpPost]
        public ActionResult AppointmentPrivate(string sessionkey)
        {
            try
            {
                User user = GetUser();
                if (user == null)
                    return RedirectToAction("Giris", "Doctorla");
                Appointment appointment = dbcontext.Appointment.Where(x => !x.IsDeleted && x.UserId == user.Id && x.SessionKey == sessionkey).FirstOrDefault();
                if (appointment == null)
                    return Json(new { status = -1, title = "İşlem Başarısız", message = "Randevu Bilgilerinize ulaşılmıyor.." });
                appointment.IsPrivate = !appointment.IsPrivate;
                dbcontext.SaveChanges();
                return Json(new { status = 1, title = "İşlem Başarılı", message = appointment.IsPrivate ? "Randevunuz Gizlenmiştir.." : "Randevunuz Diğer Doktorlar Tarafından Ulaşılabilir Hale Gelmiştir", privatestatus = appointment.IsPrivate });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - AppointmentPrivate", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return Json(new { status = -1, title = "İşlem Başarısız", message = "Randevu Bilgileriniz Güncellenirken Hata Oluştu.." });
            }
        }
        public JsonResult getAppointments(int departmentId, int doctorid, string date, int IsNextDate)
        {
            try
            {
                int nextappointmentstatus = 1;
                DateTime appointdate = DateTime.Now;
                try
                {
                    if (!String.IsNullOrEmpty(date))
                        appointdate = DateTime.Parse(date);
                }
                catch (Exception e)
                {
                }

                if (IsNextDate != -1) appointdate = IsNextDate == 0 ? appointdate.AddDays(-1) : appointdate.AddDays(1);
                List<Appointment> appointmentsdb = dbcontext.Appointment.Where(x => x.DoctorId == doctorid && x.DepartmentId == departmentId && x.AppointmentDate > DateTime.Now).ToList();
                var appointments = appointmentsdb.Where(x => x.IsActive && !x.IsDeleted && x.AppointmentDate.Day == appointdate.Day).OrderBy(x => x.AppointmentDate).Select(x => new { id = x.SessionKey, date = x.AppointmentDate, finishdate = x.AppointmentFinishDate, sessiontime = x.SessionTime, sessionprice = x.SessionPrice, userId = x.UserId, IsPreview = x.IsPreview }).ToList();
                if (appointments.Count == 0)
                {
                    Appointment nextappointment = new Appointment();
                    if (IsNextDate == 0)
                        nextappointment = appointmentsdb.Where(x => x.IsActive && x.Status == 0 && !x.IsDeleted && x.AppointmentDate <= appointdate).OrderByDescending(x => x.AppointmentDate).FirstOrDefault();
                    else
                        nextappointment = appointmentsdb.Where(x => x.IsActive && x.Status == 0 && !x.IsDeleted && x.AppointmentDate >= appointdate).OrderBy(x => x.AppointmentDate).FirstOrDefault();

                    if (nextappointment != null)
                    {
                        appointments = appointmentsdb.Where(x => x.IsActive && x.Status == 0 && !x.IsDeleted && x.AppointmentDate.Day == nextappointment.AppointmentDate.Day).OrderBy(x => x.AppointmentDate).Select(x => new { id = x.SessionKey, date = x.AppointmentDate, finishdate = x.AppointmentFinishDate, sessiontime = x.SessionTime, sessionprice = x.SessionPrice, userId = x.UserId, IsPreview = x.IsPreview }).ToList();
                        appointdate = nextappointment.AppointmentDate;
                    }
                    else { nextappointmentstatus = 0; }
                }
                bool leftarrow = appointmentsdb.FirstOrDefault(x => x.AppointmentDate.Day < appointdate.Day) != null ? true : false;
                bool rightarrow = appointmentsdb.FirstOrDefault(x => x.AppointmentDate.Day > appointdate.Day) != null ? true : false;
                User doctor = dbcontext.User.FirstOrDefault(x => x.Id == doctorid);
                Department department = dbcontext.Department.FirstOrDefault(x => x.Id == departmentId);
                RelUserDepartment userdepartment = dbcontext.RelUserDepartment.FirstOrDefault(x => x.DepartmentId == departmentId && x.UserId == doctorid);
                return Json(new { appointments = appointments, doctorname = doctor.Name + " " + doctor.SurName, department = department.Name, date = appointdate.ToShortDateString(), nextappointmentstatus = nextappointmentstatus, leftarrow = leftarrow, rightarrow = rightarrow });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - getAppointments", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return Json(new { status = -1, title = "İşlem Başarısız", message = "İşlem Sırasında Bir Sorunla Karşılaşıldı. Lütfen Bu Durumu Bize Bildiriniz.." });
            }
        }
        [Authorize(Roles = "Hasta")]
        [HttpPost]
        public ActionResult TakeAppointment(string appointmentKey, string DonationCompany = "", int discount = 0) // discount Kredi kullanımında 1 olucak
        {
            try
            {
                User user = GetUser();
                if (user == null)
                    return RedirectToAction("Giris", "Doctorla");
                if (user.IsActive)
                {
                    List<Claim> useridentity = GetIdentitiy();
                    Int16 userid = Convert.ToInt16(useridentity.FirstOrDefault(x => x.Type == "id").Value);
                    if (appointmentKey == null)
                        return Json(new { status = -1, title = "İşlem Başarısız", message = "Randevu Kayıtı Artık Bulunamıyor. Lütfen Başka Randevu Seçiniz." });
                    Appointment appointment = dbcontext.Appointment.Where(x => x.IsActive && !x.IsDeleted && x.AppointmentDate >= DateTime.Now && x.UserId == 1 && x.SessionKey == appointmentKey).Include(x => x.Department).FirstOrDefault();
                    if (appointment.Id == 0)
                        return Json(new { status = -1, title = "İşlem Başarısız", message = "Randevu Kayıtı Artık Bulunamıyor. Lütfen Başka Randevu Seçiniz." });
                    if (appointment.InProcessDates != null && appointment.InProcess)
                    {
                        TimeSpan processdate = DateTime.Now - appointment.InProcessDates.Value;
                        if (appointment.InProcessUserId != user.Id && processdate.TotalSeconds < 135)
                            return Json(new { status = -1, title = "Randevu İşlemde", message = "Bu Randevu İşlem Aşamasındadır. Lütfen 2 Dakika Sonra Tekrar Deneyiniz" });
                    }

                    var remoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString() != "::1" ? HttpContext.Connection.RemoteIpAddress.Address.ToString() : "127.0.0.1"; // Burayı kaldırın localde
                    User doctor = dbcontext.User.FirstOrDefault(x => x.Id == appointment.DoctorId);
                    appointment.DoctorName = doctor.Name + " " + doctor.SurName;
                    decimal discountAmount = 0;
                    if (user.AccountBalance >= appointment.SessionPrice)
                    {
                        appointment.UserId = user.Id;
                        appointment.SessionKey = Guid.NewGuid().ToString();
                        Donations donation = new Donations() { IsActive = true, Price = (double)appointment.SessionPrice * 0.02, IDate = DateTime.Now, DonationType = 0, AppointmentId = appointment.Id, UserId = user.Id, Name = user.Name + " " + user.SurName, Email = user.Email, Phone = user.Phone, DonationCompany = appointment.DonationCompanys };
                        dbcontext.Donations.Add(donation);
                        dbcontext.AppointmentProcess.Add(new AppointmentProcess() { Appointment = appointment, IDate = DateTime.Now, IsDoctor = false, User = user, ProcessMessage = "Ödeme Kredi Kullanılarak Başarılı Bir Şekilde Gerçekleştirildi" });
                        user.AccountBalance -= appointment.SessionPrice;
                        dbcontext.Appointment.Update(appointment);
                        dbcontext.SaveChanges();
                        return Json(new { status = 2, title = "Randevu Alındı", message = "Bu Randevu Hesap Krediniz Kullanılarak Satın Alınmıştır." });
                    }
                    else
                    {
                        discountAmount = user.AccountBalance;
                    }
                    dynamic iframelilnk = PayTRPayment.StartAppointmentPayment(user, appointment, (double)discountAmount, remoteIpAddress);
                    dbcontext.AppointmentProcess.Add(new AppointmentProcess() { Appointment = appointment, IDate = DateTime.Now, IsDoctor = false, User = user, ProcessMessage = "Kullanıcı Ödeme İşlemini Açtı" });
                    appointment.InProcess = true;
                    appointment.DonationCompanys = DonationCompany;
                    appointment.InProcessUserId = user.Id;
                    appointment.InProcessDates = DateTime.Now;
                    dbcontext.SaveChanges();
                    if (iframelilnk.status.Value == "success")
                    {
                        return Json(new { status = 1, token = iframelilnk.token.Value });
                    }
                    else
                    {
                        return Json(new { status = 0, title = "Ödeme Başarısız", message = "Ödeme Sırasında Hata Oluştu" });
                    }
                }
                else
                {
                    return Json(new { status = -1, title = "İşlem Başarısız", message = "Hesabınız onaylı değil! Lütfen önce hesabınızı onaylayın!" });
                }
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - TakeAppointment", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return Json(new { status = -1, title = "İşlem Başarısız", message = "İşlem Sırasında Bir Sorunla Karşılaşıldı. Lütfen Bu Durumu Bize Bildiriniz.." });
            }
        }
        [Authorize(Roles = "Hasta")]
        [HttpPost]
        public ActionResult BuyDailyCheckNew(int packageId, int offerId, int doctorId)
        {
            try
            {
                List<Claim> useridentity = GetIdentitiy();
                Int16 userid = Convert.ToInt16(useridentity.FirstOrDefault(x => x.Type == "id").Value);
                if (userid == 0)
                {
                    return Json(new { status = -1, title = "Giriş Bulunamadı", message = "Lütfen Giriş Yapınız" });
                }
                User user = GetUser();
                if (user == null)
                    return RedirectToAction("Giris", "Doctorla");
                if (user.IsActive)
                {
                    var package = dbcontext.Package.Include(p => p.Offers).Where(p => p.Id == packageId).FirstOrDefault();
                    if (package != null)
                    {
                        var offer = package.Offers.FirstOrDefault(p => p.Id == offerId);
                        if (offer.IsFree)
                        {
                            if (package.IsDoctor || package.IsDoctorSpec)
                            {
                                if (dbcontext.DailyCheck.Any(p => p.PackageId == packageId && p.NurseId == doctorId && p.UserId == user.Id))
                                {
                                    return Json(new { status = -1, message = "Bu pakete zaten sahipsiniz!" });
                                }
                                else
                                {
                                    if (SetFreePackage(package, offer, user.Id, doctorId))
                                        return Json(new { status = 2, message = $"{package.PackegeName} hesabınıza tanımlanmıştır." });
                                    else
                                        return Json(new { status = -1, message = "İşlem Sırasında Bir Hata Oluştu!" });
                                }
                            }
                            else
                            {
                                if (dbcontext.DailyCheck.Any(p => p.PackageId == packageId && p.UserId == user.Id))
                                {
                                    return Json(new { status = -1, message = "Bu pakete zaten sahipsiniz!" });
                                }
                                else
                                {
                                    if (SetFreePackage(package, offer, user.Id, 1))
                                        return Json(new { status = 2, message = $"{package.PackegeName} hesabınıza tanımlanmıştır." });
                                    else
                                        return Json(new { status = -1, message = "İşlem Sırasında Bir Hata Oluştu!" });
                                }
                            }
                        }
                        else
                        {
                            var amount = (double)offer.NewAmount;
                            if (user.AccountBalance > 0)
                            {
                                if ((decimal)amount > user.AccountBalance)
                                {
                                    amount -= (double)user.AccountBalance;
                                }
                                else
                                {
                                    user.AccountBalance -= (decimal)amount;
                                    createPackage(user.Id, package, (decimal)amount, offer.ValidityDates, doctorId, $"BalanceCheckPackagev{package.Id}");
                                    dbcontext.PaymentProcess.Add(new PaymentProcess()
                                    {
                                        IDate = DateTime.Now,
                                        userId = userid,
                                        ProcessMessage = "Takip Paketi Kayıt Başarılı || Paket Adı:" + package.PackegeName + " Kişi:" + user.Name + " " + user.SurName + " Başlangıç Tarihi:" + DateTime.Now + " - " + offer.ValidityDates + "  Ücret:" + 0 + " Kredi:" + amount,
                                        ServiceId = package.Id
                                    });
                                    dbcontext.SaveChanges();
                                    return Json(new { status = 2, message = $"{package.PackegeName} hesabınıza tanımlanmıştır." });
                                }
                            }
                            var remoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString() != "::1" ? HttpContext.Connection.RemoteIpAddress.Address.ToString() : "127.0.0.1"; // Burayı kaldırın localde
                            dynamic iframelilnk = PayTRPayment.StartDailyCheckPayment(user, package, doctorId, amount, offer.ValidityDates, remoteIpAddress);
                            if (iframelilnk.status.Value == "success")
                            {
                                return Json(new { status = 1, token = iframelilnk.token.Value });
                            }
                            else
                            {
                                dbcontext.PaymentProcess.Add(new PaymentProcess()
                                {
                                    IDate = DateTime.Now,
                                    ProcessMessage = JsonConvert.SerializeObject(iframelilnk),
                                    ServiceId = 0,
                                    userId = 1
                                });
                                dbcontext.SaveChanges();
                                return Json(new { status = 0, title = "Ödeme Başarısız", message = "Ödeme Sırasında Hata Oluştu" });
                            }
                        }
                    }
                    else
                        return Json(new { status = -1, message = "Bu paket Satışa Kapalıdır!" });
                }
                else
                {
                    return Json(new { status = -1, message = "Hesabınız onaylı değil! Lütfen hesabınızı onaylayın!" });
                }
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - BuyDailyCheck", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }
        private bool SetFreePackage(Package package, PackageOffers offer, int userId, int doctorId)
        {
            try
            {
                DailyCheck newdailypackage = new DailyCheck()
                {
                    PaymentId = $"FreeDailyCheckPackagev{package.Id}",
                    UserId = userId,
                    IsPremium = true,
                    PackageName = package.PackegeName,
                    AlertDay = DateTime.Now,
                    Finish = DateTime.Now.AddDays(offer.ValidityDates),
                    PaymentPrice = 0,
                    Status = 0,
                    Start = DateTime.Now,
                    AlertDayCounter = 1,
                    NurseAlertDays = "0",
                    NurseId = doctorId,
                    IsDeleted = false,
                    IsDoctor = doctorId > 0,
                    PackageId=package.Id
                };
                dbcontext.DailyCheck.Add(newdailypackage);
                dbcontext.SaveChanges();

                foreach (var item in dbcontext.DailyCheckPackagesValues.Where(x => x.IsDefault).ToList())
                {
                    dbcontext.DailyCheckDetail.Add(
                    new DailyCheckDetail()
                    {
                        DailyCheckId = newdailypackage.Id,
                        TitleOrder = item.TitleOrder,
                        ValuesTitleId = item.Id
                    }
                    );
                }
                dbcontext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - UcretsizDoktorPaket", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return false;
            }
        }
        [HttpPost]
        public JsonResult Donation(Donations donation)
        {
            try
            {
                dbcontext.Donations.Add(donation);
                donation.IsActive = false;
                donation.IDate = DateTime.Now;
                donation.DonationType = 1;
                dbcontext.SaveChanges();
                var remoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString() != "::1" ? HttpContext.Connection.RemoteIpAddress.Address.ToString() : "127.0.0.1"; // Burayı kaldırın localde
                dynamic iframelilnk = PayTRPayment.StartSupportPayment(donation, remoteIpAddress);

                if (iframelilnk.status.Value == "success")
                {

                    return Json(new { status = 1, token = iframelilnk.token.Value });
                }
                else
                {
                    return Json(new { status = 0, title = "Ödeme Başarısız", message = "Ödeme Sırasında Hata Oluştu" });
                }
            }
            catch (Exception ex)
            {

                LogsServices.LogsAdd("Saglikcim - Donation", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return Json(new { status = -1, title = "İşlem Başarısız", message = "İşlem Sırasında Bir Sorunla Karşılaşıldı. Lütfen Bu Durumu Bize Bildiriniz.." });
            }
        }
        private void createPackage(int userId, Package package, decimal price, int day, int doctorId, string paymentId)
        {
            DailyCheck dailyCheckKontrol = dbcontext.DailyCheck.FirstOrDefault(x => x.PackageId == package.Id && x.UserId == userId);
            if (dailyCheckKontrol != null)
            {
                if (dailyCheckKontrol.Finish > DateTime.Now)
                {
                    dailyCheckKontrol.Finish = dailyCheckKontrol.Finish.AddDays(day);
                }
                else
                {
                    dailyCheckKontrol.Start = DateTime.Now;
                    dailyCheckKontrol.Finish = DateTime.Now.AddDays(day);
                }
            }
            else
            {
                DailyCheck newdailypackage = new DailyCheck()
                {
                    PaymentId = paymentId,
                    UserId = userId,
                    IsPremium = package.IsPremium,
                    PackageName = package.PackegeName,
                    AlertDay = DateTime.Now,
                    Finish = DateTime.Now.AddDays(day),
                    PaymentPrice = price,
                    Status = Convert.ToInt16(package.IsPremium == true ? -1 : 0),
                    Start = DateTime.Now,
                    AlertDayCounter = 1,
                    NurseAlertDays = "0",
                    NurseId = 1,
                    IsDeleted = false,
                    PackageId = package.Id
                };
                if (doctorId > 0)
                {
                    newdailypackage.IsDoctor = true;
                    newdailypackage.NurseId = doctorId;
                }
                dbcontext.DailyCheck.Add(newdailypackage);
                dbcontext.SaveChanges();
                if (!package.IsPremium)
                {
                    int ordercounter = 0;
                    var packageValues = package.RelPackageValues
                        .Where(p => p.IsActive && !p.IsDeleted)
                        .Select(p => p.DailyCheckPackagesValues).ToList();

                    foreach (var item in packageValues)
                    {
                        dbcontext.DailyCheckDetail.Add(new DailyCheckDetail()
                        {
                            DailyCheckId = newdailypackage.Id,
                            TitleOrder = ++ordercounter,
                            ValuesTitleId = Convert.ToInt16(item)
                        });
                    }
                }
                dbcontext.SaveChanges();
                foreach (var item in dbcontext.DailyCheckPackagesValues.Where(x => x.IsDefault).ToList())
                {
                    dbcontext.DailyCheckDetail.Add(
                         new DailyCheckDetail()
                         {
                             DailyCheckId = newdailypackage.Id,
                             TitleOrder = item.TitleOrder,
                             ValuesTitleId = item.Id
                         }
                     );
                }
            }
        }

        [HttpPost]
        public string RandevuOdemesi()
        {
            try
            {
                Appointment appointment = new Appointment(); User user = new User();
                var validateResult = PayTRPayment.ValidatePayment();

                if (!validateResult.IsSuccess)
                {
                    dbcontext.AppointmentProcess.Add(new AppointmentProcess() { Appointment = appointment, IDate = DateTime.Now, IsDoctor = false, User = user, ProcessMessage = "Ücret ödeme işlemi:" + " status:" + validateResult.Status + " merchant:" + validateResult.MerchantOid + " Hata:" + validateResult.ErrorMessage });
                    return "OK";
                }
                if (validateResult.PaymentType == PaymentType.Appointment)
                {
                    string sessioncode = validateResult.Responses[1];
                    int userid = Convert.ToInt16(validateResult.Responses[2]);
                    decimal discount = Convert.ToInt16(validateResult.Responses[3]) / 100;
                    user = dbcontext.User.FirstOrDefault(x => x.Id == userid);
                    user.AccountBalance -= discount;
                    //if (user.AccountBalance < 0)
                    //    user.AccountBalance = 0;
                    appointment = dbcontext.Appointment.Where(x => x.SessionCode == sessioncode).Include(x => x.Department).FirstOrDefault();
                    appointment.InProcess = false;
                    appointment.InProcessUserId = 0;
                    if (validateResult.Status == "success")
                    {
                        appointment.UserId = user.Id;
                        appointment.SessionKey = Guid.NewGuid().ToString();
                        dbcontext.Appointment.Update(appointment);
                        Donations donation = new Donations() { IsActive = true, Price = (double)appointment.SessionPrice * 0.02, IDate = DateTime.Now, DonationType = 0, AppointmentId = appointment.Id, UserId = user.Id, Name = user.Name + " " + user.SurName, Email = user.Email, Phone = user.Phone, DonationCompany = appointment.DonationCompanys };
                        dbcontext.Donations.Add(donation);
                        dbcontext.AppointmentProcess.Add(new AppointmentProcess() { Appointment = appointment, IDate = DateTime.Now, IsDoctor = false, User = user, ProcessMessage = "Ödeme Başarılı Bir Şekilde Gerçekleştirildi" + " //  merchant:" + validateResult.MerchantOid });
                        var response = sendNotify.SendNotificationAsync(new NotificationPostData()
                        {
                            FcmTokens = dbcontext.NotifyTokens.Where(x => x.UserId == appointment.DoctorId).Select(x => x.Token).ToList(),
                            MessageData = new NotificationMessageData() { Title = "Randevunuz Alındı", Message = user.Name + " " + user.SurName + " Tarafından " + appointment.AppointmentDate.ToString("dd.MM.yyyy HH:mm") + "-" + appointment.AppointmentFinishDate.ToString("HH:mm") + " Tarihinde Bulunan Randevunuzu Satın Aldı", Link = "", Action = "", Image = "https://www.doctorla.co/images/NotificaitonLogo.png" }
                        });
                    }
                    else
                    {
                        dbcontext.AppointmentProcess.Add(new AppointmentProcess() { Appointment = appointment, IDate = DateTime.Now, IsDoctor = false, User = user, ProcessMessage = "Ücret ödeme işlemi:" + " status:" + validateResult.Status + " merchant:" + validateResult.MerchantOid + " Hata:" + validateResult.ErrorMessage });
                    }
                    try
                    {
                        List<int> admins = dbcontext.User.Where(x => x.TypeId == 4 && x.IsActive).Select(x => x.Id).ToList();
                        NotificationSender sendNotify = new NotificationSender();
                        var response = sendNotify.SendNotificationAsync(new NotificationPostData()
                        {
                            FcmTokens = dbcontext.NotifyTokens.Where(x => admins.Contains(x.UserId)).Select(x => x.Token).ToList(),
                            MessageData = new NotificationMessageData() { Title = user.Name + " " + user.SurName + "Randevu Aldı", Message = "Doktor: " + appointment.DoctorName + "  " + appointment.Department.Name + " Departmanına Saat:" + appointment.AppointmentDate, Link = "", Action = "", Image = "https://www.doctorla.co/images/NotificaitonLogo.png" }
                        });
                    }
                    catch (Exception)
                    {
                    }
                    dbcontext.SaveChanges();

                }
                else if (validateResult.PaymentType == PaymentType.Support)  // Donation
                {
                    int donationsid = Convert.ToInt16(validateResult.Responses[1]);
                    Donations donation = dbcontext.Donations.FirstOrDefault(x => x.Id == donationsid);
                    donation.IsActive = true;
                    List<int> admins = dbcontext.User.Where(x => x.TypeId == 4 && x.IsActive).Select(x => x.Id).ToList();
                    NotificationSender sendNotify = new NotificationSender();
                    var response = sendNotify.SendNotificationAsync(new NotificationPostData()
                    {
                        FcmTokens = dbcontext.NotifyTokens.Where(x => admins.Contains(x.UserId)).Select(x => x.Token).ToList(),
                        MessageData = new NotificationMessageData() { Title = "Bağış alındı", Message = donation.Name + " Tarafından " + donation.Price + " TL  Bağış Yapıldı. Telefon:" + donation.Phone, Link = "", Action = "", Image = "https://www.doctorla.co/images/NotificaitonLogo.png" }
                    });
                    dbcontext.SaveChanges();


                }
                else if ((validateResult.PaymentType == PaymentType.DoctorDailycheck || validateResult.PaymentType == PaymentType.DailyCheck)
                    && validateResult.Status == "success")  //Paketler  Hasta-Hemşire / Doktor
                {
                    string packageId = validateResult.Responses[1];
                    int userid = Convert.ToInt16(validateResult.Responses[2]);
                    decimal price = (decimal)(Convert.ToInt32(validateResult.Responses[3]) / 100.00);
                    int day = Convert.ToInt16(validateResult.Responses[4]);
                    Package package = dbcontext.Package
                      .Include(p => p.Offers)
                      .Include(p => p.RelPackageValues)
                      .ThenInclude(p => p.DailyCheckPackagesValues)
                      .FirstOrDefault(x => x.Id == Convert.ToInt16(packageId));
                    user = dbcontext.User.FirstOrDefault(x => x.Id == userid);
                    try
                    {
                        var offer = package.Offers.Where(p => p.IsActive && !p.IsDeleted && p.ValidityDates == day).FirstOrDefault();
                        var usedCredit = offer.NewAmount - price;
                        user.AccountBalance -= usedCredit;
                        int doctorId = 0;
                        if (validateResult.PaymentType == PaymentType.DoctorDailycheck) // Doktor Paketi
                            doctorId = Convert.ToInt16(validateResult.Responses[5]);
                        createPackage(user.Id, package, price, day, doctorId, validateResult.MerchantOid);
                        dbcontext.PaymentProcess.Add(new PaymentProcess()
                        {
                            IDate = DateTime.Now,
                            userId = userid,
                            ProcessMessage = "Takip Paketi Kayıt Başarılı || Paket Adı:" + package.PackegeName + " Kişi:" + user.Name + " " + user.SurName + " Başlangıç Tarihi:" + DateTime.Now + " - " + day + "  Ücret:" + price + " Kredi:" + usedCredit,
                            ServiceId = package.Id
                        });
                        dbcontext.SaveChanges();
                        return "OK";

                    }
                    catch (Exception ex)
                    {
                        dbcontext.PaymentProcess.Add(new PaymentProcess()
                        {
                            IDate = DateTime.Now,
                            userId = user.Id,
                            ProcessMessage = "Hata: " + GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(),
                            ServiceId = Convert.ToInt32(packageId)
                        });
                        dbcontext.SaveChanges();
                    }

                    try
                    {
                        List<int> admins = dbcontext.User.Where(x => x.TypeId == 4 && x.IsActive).Select(x => x.Id).ToList();
                        NotificationSender sendNotify = new NotificationSender();
                        var response = sendNotify.SendNotificationAsync(new NotificationPostData()
                        {
                            FcmTokens = dbcontext.NotifyTokens.Where(x => admins.Contains(x.UserId)).Select(x => x.Token).ToList(),
                            MessageData = new NotificationMessageData() { Title = user.Name + " " + user.SurName + "Paket Aldı", Message = "Takip Paketi Detayı || Paket Adı:" + package.PackegeName + " Kişi:" + user.Name + " " + user.SurName + " Başlangıç Tarihi:" + DateTime.Now + " - " + day + "  Ücret:" + price, Link = "", Action = "", Image = "https://www.doctorla.co/images/NotificaitonLogo.png" }
                        });
                    }
                    catch (Exception ex)
                    {
                        dbcontext.PaymentProcess.Add(new PaymentProcess()
                        {
                            IDate = DateTime.Now,
                            userId = user.Id,
                            ProcessMessage = "Hata: " + GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(),
                            ServiceId = Convert.ToInt32(packageId)
                        });
                        dbcontext.SaveChanges();
                    }
                    return "OK";
                }
                else
                {
                    LogsServices.LogsAdd("Saglikcim - RandevuOdemesi", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "Ödeme Tipi Bulunamadı", 1);
                    return null;
                }
                dbcontext.SaveChanges();
                return "OK";
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - RandevuOdemesi", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }
        public ActionResult DestekBasarili(int destekno)
        {
            try
            {
                var createimage = SendDonationDocument(destekno);
                Donations donation = dbcontext.Donations.FirstOrDefault(x => x.Id == destekno);
                return View(donation);
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - DestekBasarili", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }
        public ActionResult OdemeHatali()
        {
            return View();
        }
        public JsonResult GetDepartments()
        {
            try
            {
                List<Department> departments = dbcontext.Department.Where(x => x.IsActive && !x.IsDeleted).Include(x => x.RelUserDepartments).ThenInclude(x => x.User).Where(x => x.RelUserDepartments.Count > 0).OrderBy(x => x.Name).ToList();
                foreach (var item in departments.ToList())
                {
                    if (item.RelUserDepartments.Where(x => x.User.IsActive).ToList().Count == 0)
                        departments.Remove(item);
                }
                return Json(departments.Select(x => new { id = x.Id, name = x.Name }).ToList());
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - GetDepartments", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }
        public JsonResult GetDoctors(int departmentId, string token)
        {
            try
            {
                int requestUserid = !String.IsNullOrEmpty(token) ? dbcontext.NotifyTokens.FirstOrDefault(x => x.Token == token).UserId : -1;
                var doctors = dbcontext.RelUserDepartment.Include(X => X.Department.Appointment).Where(x => x.DepartmentId == departmentId && x.IsActive && !x.IsDeleted).Include(x => x.User).Where(x => x.User.IsActive).Select(x => new { doctorid = x.User.Id, doctorname = x.User.Name + " " + x.User.SurName, minprice = x.Price, minprictetime = x.SessionTime, appointments = new List<Appointment>() }).ToList();
                foreach (var item in doctors.ToList())
                {
                    item.appointments.AddRange(dbcontext.Appointment.Where(x => x.DoctorId == item.doctorid && x.IsActive && !x.IsDeleted && x.UserId == 1 && x.DepartmentId == departmentId && x.AppointmentDate >= DateTime.Now).OrderBy(x => x.SessionPrice).Take(1));
                }
                return Json(doctors.OrderByDescending(x => x.appointments.Count).Select(x => new { departmentId = departmentId, id = x.doctorid, name = x.doctorname, minprice = x.minprice, minprictetime = x.minprictetime, appointmentcount = x.appointments.Count, hasNotifyWarning = dbcontext.NotifyWarning.FirstOrDefault(t => t.DoctorId == x.doctorid && t.DepartmentId == departmentId && t.UserId == requestUserid) != null ? 1 : 0 }).ToList());
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - GetDoctors", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }
        #endregion
        [Authorize(Roles = "Hasta")]
        public async Task<IActionResult> SendAppointmentDonationDocument(string appointmentCode)
        {
            try
            {
                User user = GetUser();
                if (user == null)
                    return RedirectToAction("Giris", "Doctorla");
                Appointment appointment = dbcontext.Appointment.Where(x => x.SessionCode == appointmentCode && x.UserId == user.Id).Include(x => x.User).FirstOrDefault();
                if (appointment != null)
                {
                    FileStream fileStream;
                    var basePath = Path.Combine(_settings["BaseFileDirectory"], "AppointmentFiles");
                    string imagepath = Path.Combine(basePath, appointment.SessionCode + ".jpeg");

                    var cd = new System.Net.Mime.ContentDisposition
                    {
                        FileName = "destekbelgesi_" + appointment.SessionCode + ".jpeg",
                        Inline = false
                    };
                    Response.Headers.Add("Content-Disposition", cd.ToString());
                    Response.Headers.Add("X-Content-Type-Options", "nosniff");

                    if (System.IO.File.Exists(imagepath))
                    {
                        fileStream = new FileStream(imagepath, FileMode.Open);
                        return new FileStreamResult(fileStream, "application/octet-stream");
                    }

                    var imagePath = rootpath.WebRootPath + "/images/dayanismahareketiyeni.jpg";
                    var html = new StringBuilder();
                    html.Append(@"<html><body >");
                    html.Append(@"<image src='" + imagePath + "'  />");
                    html.Append(@"<h3 style='position:absolute; top:684px; left:306px; font-size:40px; color:#fff; font-family: 'Poppins', sans-serif;'>Sayın " + appointment.User.Name.ToUpper() + " " + appointment.User.SurName.ToUpper() + "</h3>");
                    html.Append(@"</body></html>");

                    using (var re1 = new GcHtmlRenderer(html.ToString()))
                    {
                        JpegSettings jpegSettings1 = new JpegSettings();
                        jpegSettings1.DefaultBackgroundColor = System.Drawing.Color.White;
                        jpegSettings1.WindowSize = new Size(1080, 1920);
                        re1.RenderToJpeg(imagepath, jpegSettings1);
                    }
                    fileStream = new FileStream(imagepath, FileMode.Open);
                    return new FileStreamResult(fileStream, "application/octet-stream");
                }

                return null;
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - SendAppointmentDonationDocument", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }

        public bool SendDonationDocument(int destekno)
        {
            try
            {
                string name = dbcontext.Donations.FirstOrDefault(x => x.Id == destekno).Name.ToUpper();
                string imagepath = rootpath.WebRootPath + "/AppointmentFiles/destekbelgesi_" + destekno + ".jpeg";

                var defaultimagePath = rootpath.WebRootPath + "/images/dayanismahareketiyeni.jpg";
                var html = new StringBuilder();
                html.Append(@"<html><body >");
                html.Append(@"<image src='" + defaultimagePath + "'  />");
                html.Append(@"<h3 style='position:absolute; top:684px; left:306px; font-size:40px; color:#fff; font-family: 'Poppins', sans-serif;'>Sayın " + name + "</h3>");
                html.Append(@"</body></html>");

                using (var re1 = new GcHtmlRenderer(html.ToString()))
                {
                    JpegSettings jpegSettings1 = new JpegSettings();
                    jpegSettings1.DefaultBackgroundColor = System.Drawing.Color.White;
                    jpegSettings1.WindowSize = new Size(1080, 1920);
                    re1.RenderToJpeg(imagepath, jpegSettings1);
                }
                return true;
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - SendDonationDocument", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return false;
            }

        }

        [Authorize(Roles = "Hasta")]
        public JsonResult HesapOnayKodu()
        {
            User user = GetUser();
            if (user == null)
                return Json(new { status = -1, title = "İşlem Başarısız", message = "Lütfen kullanıcı bilgilerinizi kontrol edin" });
            TimeSpan span = DateTime.Now - user.UUDate.Value;
            string dakika = span.ToString(@"mm");
            int zaman = 20 - (Convert.ToUInt16(dakika));
            if (span < new TimeSpan(0, 20, 0) && user.RefreshToken != null)
            {
                return Json(new { status = 1, title = "İşlem Başarılı", message = "Onay kodunuz daha önce gönderilmiş", tel = user.Phone, dakika = zaman });
            }
            else
            {
                Random rnd = new Random();
                int random = rnd.Next(100000, 999999);
                user.RefreshToken = random.ToString();
                user.UUDate = DateTime.Now;
                dbcontext.User.Update(user);
                dbcontext.SaveChanges();
                string mesaj = ("Onay kodunuz: " + user.RefreshToken + "   Sağlıklı Günler Dileriz... Doctorla.");
                SmsServices.SendSms(dbcontext.User.FirstOrDefault(x => x.Id == user.Id).Phone, mesaj);
                return Json(new { status = 2, title = "İşlem Başarılı", message = "Değerleriniz Başarılı Bir Şekilde Eklendi", tel = user.Phone });
            }
        }
        [Authorize(Roles = "Hasta")]
        public ActionResult HesapOnay(string Kod)
        {
            User user = GetUser();
            if (user == null)
                return RedirectToAction("Giris", "Doctorla");
            if (Kod != user.RefreshToken)
                return Json(new { status = -1, title = "İşlem Başarısız", message = "Lütfen kullanıcı bilgilerinizi kontrol edin" });

            user.IsActive = true;
            user.UUDate = DateTime.Now;
            user.RefreshToken = null;
            dbcontext.SaveChanges();
            return Json(new { status = 1, title = "İşlem Başarılı", message = "Değerleriniz Başarılı Bir Şekilde Eklendi" });
        }

        #region Login - Register ----
        public ActionResult Giris()
        {
            try
            {
                List<Country> countrys = dbcontext.Country.ToList();
                TempData["Countrys"] = countrys;
                List<Department> department = dbcontext.Department.ToList();
                TempData["department"] = department;
                return View();
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - Giris-1", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }

        [HttpPost]
        public ActionResult Giris(string Email, string Password)
        {
            try
            {
                User user = dbcontext.User.Include(x => x.UserType).Include(x => x.RoleGroup).FirstOrDefault(x => x.Email == Email && x.Password == Password && x.IsDeleted == false);
                if (user != null)
                {
                    user.LastLoginDate = DateTime.Now;
                    dbcontext.SaveChanges();
                    string token = "";

                    SetIdentity(user, token);
                    if (IsAjaxRequest(Request)) //Hizli Randevu Girişi
                        return Json(new { status = 1, title = "Hoşgeldiniz", message = "Başarılı Bir Şekilde Giriş Yaptınız", name = user.Name + " " + user.SurName, usertype = user.UserType.Name });
                    string typename = usertypedb.FirstOrDefault(x => x.Id == user.TypeId).Name;
                    if (typename == "Hasta")
                        return RedirectToAction("Profilim", "Doctorla");
                    else if (typename == "Admin")
                    {
                        var response = sendNotify.SendNotificationAsync(new NotificationPostData()
                        {
                            FcmTokens = dbcontext.NotifyTokens.Where(x => x.UserId == user.Id).Select(x => x.Token).ToList(),
                            MessageData = new NotificationMessageData() { Title = "Hoşgeldiniz", Message = "Doctorla paneline Giriş Yaptınız", Link = "", Action = "", Image = "https://www.doctorla.co/images/NotificaitonLogo.png" }
                        });
                        return Redirect("/AdminPanel/Anasayfa");
                    }
                    else if (typename == "Doktor")
                    {
                        var response = sendNotify.SendNotificationAsync(new NotificationPostData()
                        {
                            FcmTokens = dbcontext.NotifyTokens.Where(x => x.UserId == user.Id).Select(x => x.Token).ToList(),
                            MessageData = new NotificationMessageData() { Title = "Hoşgeldiniz", Message = "Doctorla paneline Giriş Yaptınız", Link = "", Action = "", Image = "https://www.doctorla.co/images/NotificaitonLogo.png" }
                        });
                        return Redirect("/DoctorPanel/Anasayfa");
                    }
                    else
                    {
                        var response = sendNotify.SendNotificationAsync(new NotificationPostData()
                        {
                            FcmTokens = dbcontext.NotifyTokens.Where(x => x.UserId == user.Id).Select(x => x.Token).ToList(),
                            MessageData = new NotificationMessageData() { Title = "Hoşgeldiniz", Message = "Doctorla paneline Giriş Yaptınız", Link = "", Action = "", Image = "https://www.doctorla.co/images/logo.png" }
                        });
                        return Redirect("/NursePanel/AnaSayfa");
                    }
                }
                if (IsAjaxRequest(Request)) //Hizli Randevu Girişi
                    return Json(new { status = -1, title = "Giriş Başarısız", message = "Kullanıcı Adı veya Şifreniz Yanlış!" });
                List<Country> countrys = dbcontext.Country.ToList();
                TempData["Countrys"] = countrys;
                List<Department> department = dbcontext.Department.ToList();
                TempData["department"] = department;
                TempData["Error"] = true;
                return View();
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - Giris-2", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }
        [HttpPost]
        public ActionResult KayitOl(User user, string Country, string City, string County, string AddressDetail, string doctorTitle, string doctorUniversity, int doctorDepartment, int IsDoctor, string PasswordCheck, string IsUser, string termsAgree)
        {
            try
            {
                //
                if (dbcontext.User.FirstOrDefault(x => x.Email == user.Email || x.Phone == user.Phone) != null)
                    return Json(new { status = -1, title = "Kayıt Hatası", message = "Kullanıcı Eposta veya Telefonu Kayıtlı!" });
                var errors = ModelState.Select(x => x.Value.Errors)
                               .Where(y => y.Count > 0).Skip(1)
                               .ToList();
                string errormessage = "<ul>";
                if (errors.Count != 0)
                    errors.RemoveAt(errors.Count - 1); // Hataların sonuncusunu silme
                if (errors.Count > 0) // Ortak Kullanıcı Mesajları
                {
                    foreach (var item in errors)
                    {
                        errormessage += "<li>" + item.FirstOrDefault().ErrorMessage + "</li>";
                    }
                }
                if (user.Password != PasswordCheck)
                    errormessage += "<li>Şifreleriniz Uyuşmuyor Kontrol Ediniz</li>";
                if (user.Birthdate.ToShortDateString() == "1.01.0001")
                    errormessage += "<li>Doğum Tarihinizi Giriniz</li>";
                if (user.Phone.IndexOf("_") != -1)
                    errormessage += "<li>Geçerli Bir Telefon Giriniz</li>";
                if (Country == "-1")
                    errormessage += "<li>Lütfen Ülke Seçiniz</li>";
                if (City == "-1")
                    errormessage += "<li>Lütfen Şehir Seçiniz</li>";
                if (County == "-1")
                    errormessage += "<li>Lütfen İlçe Seçiniz</li>";
                if (AddressDetail == null)
                    errormessage += "<li>Lütfen Mahallenizi Giriniz</li>";
                if (IsUser == "-1")
                {
                    if (doctorTitle == "-1")
                        if (IsDoctor == 1)
                            errormessage += "<li>Lütfen Ünvan Seçiniz</li>";
                    if (doctorUniversity == "-1")
                        errormessage += "<li>Lütfen Üniversite Seçiniz</li>";
                    if (doctorDepartment == -1)
                        errormessage += "<li>Lütfen Uzmanlık Seçiniz</li>";
                }
                errormessage += "</ul>";
                if (errormessage != "<ul></ul>")
                    return Json(new { status = -1, title = "Kayıt Hatası", message = errormessage });
                user.UserDetail = new UserDetail() { };
                if (IsUser == "-1")  // User mı sağlık görevlisi mi kontrolü
                {
                    if (IsDoctor == 1) // 1 ise doktor degilse hemşire
                        user.TypeId = dbcontext.UserType.Where(x => x.Name == "Doktor").FirstOrDefault().Id;
                    else
                        user.TypeId = dbcontext.UserType.Where(x => x.Name == "Hemşire").FirstOrDefault().Id;

                    Random rnd = new Random();
                    int random = rnd.Next(1000000, 9999999);
                    while (dbcontext.DoctorDetail.FirstOrDefault(x => x.DoctorUniqueId == random) != null)
                        random = rnd.Next(1000000, 9999999);
                    user.DoctorDetail = new DoctorDetail();
                    user.DoctorDetail.DoctorUniqueId = random;
                    user.DoctorDetail.UniverstyName = doctorUniversity;

                    if (String.IsNullOrEmpty(doctorTitle) || doctorTitle == "0" || doctorTitle == "-1")
                    {
                        user.DoctorDetail.Title = dbcontext.Department.FirstOrDefault(x => x.Id == doctorDepartment)?.Name;
                    }
                    else
                    {
                        user.DoctorDetail.Title = doctorTitle;
                    }

                    List<RelUserDepartment> departmns = new List<RelUserDepartment>() { new RelUserDepartment() { DepartmentId = doctorDepartment, UserId = user.Id } };
                    user.RelUserDepartments = departmns;
                    user.IsActive = false;
                    if (user.Gender == "M")
                        user.PhotoUrl = "/images/Users/erkekdoktor.png";
                    else if (user.Gender == "F")
                        user.PhotoUrl = "/images/Users/kadindoktor.png";
                }
                else
                {
                    user.IsActive = false;
                    user.TypeId = dbcontext.UserType.Where(x => x.Name == "Hasta").FirstOrDefault().Id;
                    user.PhotoUrl = "/images/Users/defaultuser.png";
                }
                List<Address> adress = new List<Address>();
                adress.Add(new Address() { TypeId = 1, CityId = Convert.ToInt32(City), CountryId = Convert.ToInt32(Country), CountyId = Convert.ToInt32(County), AddressDetail = AddressDetail });
                user.Address = adress;
                user.RoleGroupId = dbcontext.RoleGroup.Where(x => x.Name == "User").FirstOrDefault().Id;
                user.IDate = DateTime.Now;
                user.LastLoginDate = DateTime.Now;
                user.UUDate = DateTime.Now;
                dbcontext.User.Add(user);
                dbcontext.SaveChanges();
                string token = "";
                SetIdentity(user, token);

                return Json(new { status = 1, title = "İşlem Başarılı", message = "Kayıdınız Başarılı Bir Şekilde Oluşturulmuştur. Kişisel Profilinize Yönlendiriliyorsunuz.", isUserReg = IsUser });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - SifreSifirlamaLink", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }
        [HttpPost]
        public ActionResult SifreSifirlamaLink(string Phone, string Kod)
        {
            try
            {
                User user = dbcontext.User.Include(x => x.UserType).Include(x => x.RoleGroup).FirstOrDefault(x => x.Phone == Phone && x.RefreshToken == Kod && x.IsDeleted == false);
                if (user != null)
                {
                    user.RefreshToken = Guid.NewGuid().ToString() + "usr" + user.Id;
                    dbcontext.User.Update(user);
                    dbcontext.SaveChanges();
                    return Json(new { status = 1, title = "İşlem Başarılı", message = "Şifre sıfırlama linkiniz telefon numaranıza gönderilmiştir!", token = user.RefreshToken });
                }
                else return Json(new { status = -1, title = "İşlem Başarısız", message = "Girdiğiniz Telefon numarasına kayıtlı bir hesap bulunmamaktadır!" });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - SifreSifirlamaLink", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }
        [HttpPost]
        public ActionResult SifreSifirlamaKod(string Phone)
        {
            try
            {
                User user = dbcontext.User.Include(x => x.UserType).Include(x => x.RoleGroup).FirstOrDefault(x => x.Phone == Phone && x.IsDeleted == false);
                if (user != null)
                {
                    if (user.RefreshTokenEndTime == null)
                        user.RefreshTokenEndTime = DateTime.Now.AddMinutes(-3);
                    TimeSpan span = DateTime.Now - user.RefreshTokenEndTime.Value;
                    if (span.TotalMinutes > 2)
                    {
                        Random rnd = new Random();
                        int random = rnd.Next(100000, 999999);
                        user.RefreshToken = random.ToString();
                        user.RefreshTokenEndTime = DateTime.Now;
                        dbcontext.User.Update(user);
                        dbcontext.SaveChanges();
                        string mesaj = ("Şifre Değiştirme Onay kodunuz: " + user.RefreshToken + "   Sağlıklı Günler Dileriz... Doctorla.");
                        SmsServices.SendSms(dbcontext.User.FirstOrDefault(x => x.Id == user.Id).Phone, mesaj);
                    }
                    return Json(new { status = 1, title = "İşlem Başarılı", message = "Şifre sıfırlama onay kodunuz telefon numaranıza gönderilmiştir!", tel = user.Phone });
                }
                else return Json(new { status = -1, title = "İşlem Başarısız", message = "Girdiğiniz Telefon numarasına kayıtlı bir hesap bulunmamaktadır!" });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - SifreSifirlamaLink", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }

        public ActionResult SifreSifirlama(string refreshToken)
        {
            try
            {
                User user = dbcontext.User.Where(x => x.RefreshToken == refreshToken).FirstOrDefault();
                if (user != null)
                { return View(user); }
                return Redirect("/Doctorla/AnaSayfa");
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - SifreSifirlama", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }
        [HttpPost]
        public ActionResult SifreYenile(string Password, string refreshToken)
        {
            try
            {
                User user = dbcontext.User.Where(x => x.RefreshToken == refreshToken).FirstOrDefault();
                if (user != null)
                {
                    user.Password = Password;
                    user.RefreshToken = "";
                    dbcontext.User.Update(user);
                    dbcontext.SaveChanges();
                    return Json(new { status = 1, title = "İşlem Başarılı", message = "Şifre sıfırlama linkiniz mail adresinize gönderilmiştir!" });
                }
                else return Json(new { status = -1, title = "İşlem Başarısız", message = "Sistem tarafında bir hata oluştu. Şifreniz sıfırlanamadı!" });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - SifreYenile", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
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
                User user = dbcontext.User.Where(x => x.Id == userid).Include(x => x.UserDetail).Include(x => x.RoleGroup).Include(x => x.UserType).Include(x => x.Address).FirstOrDefault();
                return user;
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - GetUser", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }

        public void SetIdentity(User user, string token) // Kullanıcı Bilgileri Kaydedildi
        {
            try
            {
                string typename = usertypedb.FirstOrDefault(x => x.Id == user.TypeId).Name;
                var claims = new List<Claim> {
                new Claim(ClaimTypes.Name,user.Name + " " + user.SurName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,typename),
                new Claim("id",user.Id.ToString()),
                new Claim("rolename",user.RoleGroup==null?"":user.RoleGroup.Name),
                new Claim("token",token==null?"test":token),
                new Claim("typeid",user.TypeId.ToString())
            };
                if (typename == "Doktor" || typename == "Hemşire")
                {
                    DoctorDetail doctordetail = dbcontext.DoctorDetail.FirstOrDefault(x => x.UserId == user.Id);
                    claims.Add(new Claim("doctortitle", doctordetail.Title != null|| doctordetail.Title == "0" || doctordetail.Title=="-1" ? doctordetail.Title : "Odyoloji"));//TODO:odyoloji magic
                }
                if (user.UserType.Name == "Doktor")
                {
                    DoctorDetail doctordetail = dbcontext.DoctorDetail.FirstOrDefault(x => x.UserId == user.Id);
                    claims.Add(new Claim("doctorCode", doctordetail.DoctorUniqueId.ToString()));
                }

                var userIdentity = new ClaimsIdentity(claims, "user");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                HttpContext.SignInAsync(principal);

            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - SetIdentity", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
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
                LogsServices.LogsAdd("Saglikcim - GetIdentitiy", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }

        #endregion


        #region Get City and Country List ----
        public JsonResult GetCity(int CountryId)
        {
            try
            {
                var citys = city.Where(x => x.CountryId == CountryId).OrderBy(x => x.Name).Select(x => new { id = x.Id, Name = x.Name }).ToList();
                return Json(citys);
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - GetCity", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }
        public JsonResult GetCounty(int CityId)
        {
            try
            {
                var countys = county.Where(x => x.CityId == CityId).OrderBy(x => x.Name).Select(x => new { id = x.Id, Name = x.Name }).ToList();
                return Json(countys);
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - GetCounty", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }
        #endregion


        public ActionResult Cikis()
        {
            try
            {

                HttpContext.SignOutAsync();
                return RedirectToAction("Yonlendiriliyorsunuz", "Doctorla");
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - Cikis", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }
        public ActionResult Yonlendiriliyorsunuz()
        {
            return View();
        }

        #endregion


        #region Notifications --------------------------------------

        public ActionResult setNotificationForAppointment(int departmentId, int doctorId, string token, int status)
        {
            try
            {

                User user = GetUser();
                if (user == null)
                    return RedirectToAction("Giris", "Doctorla");
                int userid = user != null ? user.Id : dbcontext.NotifyTokens.FirstOrDefault(x => x.Token == token).UserId;
                NotifyWarning checknotify = dbcontext.NotifyWarning.FirstOrDefault(x => x.DepartmentId == departmentId && x.DoctorId == doctorId && x.UserId == userid);
                if (checknotify == null)
                {
                    NotifyWarning notifywarn = new NotifyWarning()
                    {
                        DoctorId = doctorId,
                        DepartmentId = departmentId,
                        UserId = userid,
                    };
                    dbcontext.NotifyWarning.Add(notifywarn);
                    dbcontext.SaveChanges();
                    return Json(new { status = 1, title = "Hatırlatıcı Eklendi", message = "Randevu Oluşturulduğunda Bilgisayar ve Telefonunuza Bilgilendirme Mesajı Gönderilecektir" });
                }
                if (checknotify != null && status == 0)
                {
                    dbcontext.NotifyWarning.Remove(checknotify);
                    dbcontext.SaveChanges();
                    return Json(new { status = 1, title = "Hatırlatıcı Kaldırıldı", message = "Hatırlatıcınız Kaldırıldı." });
                }
                return Json(new { status = -1 });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - setNotificationForAppointment", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }

        public ActionResult setNotifyToken(string token)
        {
            try
            {
                if (!String.IsNullOrEmpty(token))
                {
                    User user = GetUser();
                    if (user == null)
                        return RedirectToAction("Giris", "Doctorla");
                    NotifyTokens notify = dbcontext.NotifyTokens.FirstOrDefault(x => x.Token == token);
                    if (notify != null)
                        if (notify.UserId != 0 && user == null)
                            return Json("");
                    if (notify == null)
                    {
                        Random rnd = new Random();
                        int randomid = rnd.Next(1000000, 9999999);
                        while (dbcontext.NotifyTokens.FirstOrDefault(x => x.UserId == randomid) != null)
                            randomid = rnd.Next(1000000, 9999999);

                        NotifyTokens newnotify = new NotifyTokens()
                        {
                            IDate = DateTime.Now,
                            LastDate = DateTime.Now,
                            Token = token,
                            UserId = user != null ? user.Id : randomid,
                            userType = user == null ? 0 : user.UserDetail != null ? 1 : 2
                        };
                        dbcontext.NotifyTokens.Add(newnotify);
                    }
                    else
                    {
                        notify.LastDate = DateTime.Now;
                        if (user != null)
                        {
                            notify.UserId = user.Id;
                            if (user.UserType.Name == "Doktor" || user.UserType.Name == "Hemşire")
                                notify.userType = 2;
                            else
                                notify.userType = 1;
                        }
                    }
                    dbcontext.SaveChanges();
                }
                return Json("");
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - setNotifyToken", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }

        #endregion

        public ActionResult RandevuTalepEt(int DoctorId, int DepartmentId, DateTime Tarih, string Not, short requestType)

        {
            try
            {
                User user = GetUser();
                if (user == null)
                    return RedirectToAction("Giris", "Doctorla");
                if (user.IsActive)
                {
                    if (Tarih >= DateTime.Now)
                    {
                        if (dbcontext.Appointment.Where(x => x.DoctorId == DoctorId && x.AppointmentDate <= Tarih && x.AppointmentFinishDate > Tarih).FirstOrDefault() != null)
                            return Json(new { status = -1, title = "Talep Uyarısı", message = "Talep Ettiğiniz Tarihte Bir Randevu Mevcut" });
                        if (dbcontext.NotifyWarning.Where(x => x.DoctorId == DoctorId && x.UserId == GetUser().Id && x.Date >= DateTime.Now && x.Status == 0).ToList().Count >= 3)
                            return Json(new { status = -1, title = "Talep Uyarısı", message = "Aynı Doktordan Üçten Fazla Talepte Bulunamazsınız" });
                        if (dbcontext.NotifyWarning.Where(x => x.DoctorId == DoctorId && x.UserId == user.Id && x.Date == Tarih && x.Status == 0).ToList().Count != 0)
                            return Json(new { status = -1, title = "Talep Uyarısı", message = "Aynı Doktordan Aynı Tarih ve Saatte Talepte Bulunamazsınız" });

                        if (dbcontext.RelUserDepartment.FirstOrDefault(x => x.DepartmentId == DepartmentId && x.UserId == DoctorId) == null)
                            DepartmentId = dbcontext.RelUserDepartment.FirstOrDefault(x => x.UserId == DoctorId).DepartmentId;

                        dbcontext.NotifyWarning.Add(new NotifyWarning() { UserId = GetUser().Id, DepartmentId = DepartmentId, DoctorId = DoctorId, Date = Tarih, Note = Not, Status = 0, RequestType = requestType });
                        dbcontext.SaveChanges();
                        SmsServices.SendSms(dbcontext.User.FirstOrDefault(x => x.Id == DoctorId).Phone, "Randevu Talebi Aldınız. Lütfen Yönetim Panelinizi Kontrol Edin.. Doctorla ");
                        return Json(new { status = 1, title = "İşlem Başarılı", message = "Randevu Talebiniz Alınmıştır." });
                    }
                    return Json(new { status = -1, title = "İşlem Başarısız", message = "Geçmiş Zamanda Talep Oluşturamazsınız." });
                }
                else
                {
                    return Json(new { status = -1, title = "İşlem Başarısız", message = "Hesabınız onaylı değil! Lütfen hesabınızı onaylayın!" });
                }

            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - RandevuTalepEt", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }


        public JsonResult liveRequestOlustur(int Id, DateTime liveRequestDate)
        {
            try
            {
                DailyCheck dailyCheck = dbcontext.DailyCheck.FirstOrDefault(x => x.Id == Id);
                if (dailyCheck.UserId != GetUser().Id)
                    return null;
                dailyCheck.IsRequest = !dailyCheck.IsRequest;
                dailyCheck.LiveRequestDate = liveRequestDate;
                dbcontext.DailyCheck.Update(dailyCheck);
                dbcontext.SaveChanges();
                return Json(new { status = 1, Id = dailyCheck.Id, activeStatus = dailyCheck.IsRequest, date = dailyCheck.LiveRequestDate, title = "İşlem Başarılı", message = "Değerleriniz Başarılı Bir Şekilde Eklendi" });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - liveRequestOlustur", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }
        public JsonResult liveRequestDetay(int Id)
        {
            try
            {
                bool canliGorusmeKosul = false;
                DailyCheck dailyCheck = dbcontext.DailyCheck.FirstOrDefault(x => x.Id == Id);
                if (dailyCheck.LiveStartDate < DateTime.Now && dailyCheck.LiveEndDate > DateTime.Now)
                    canliGorusmeKosul = true;
                if (dailyCheck.UserId != GetUser().Id)
                    return null;
                return Json(new { status = 1, date = dailyCheck.LiveStartDate, id = Id, title = "İşlem Başarılı", message = "Fark Başarılı Bir Şekilde Gönderildi", kosul = canliGorusmeKosul });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - liveRequestDetay", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }

        }
        public JsonResult liveRequestIptal(int Id)
        {
            try
            {
                DailyCheck dailyCheck = dbcontext.DailyCheck.FirstOrDefault(x => x.Id == Id);
                if (dailyCheck.UserId != GetUser().Id)
                    return null;
                dailyCheck.IsRequest = false;
                dailyCheck.LiveStartDate = null;
                dailyCheck.LiveEndDate = null;
                dailyCheck.LiveRequestDate = null;
                dbcontext.DailyCheck.Update(dailyCheck);
                dbcontext.SaveChanges();
                return Json(new { status = 1, Id = dailyCheck.Id, activeStatus = dailyCheck.IsRequest, title = "İşlem Başarılı", message = "Talebi İptaliniz Başarıyla Gerçekleşti." });
            }
            catch (Exception ex)
            {
                LogsServices.LogsAdd("Saglikcim - liveRequestIptal", _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "" + ex.ToString(), 1);
                return null;
            }
        }

        public void ErrorLogs(string page)
        {
            LogsServices.LogsAdd(page, _httpContextAccessor.HttpContext.Request.Path.Value.ToString(), GetUser() != null ? "UserId:" + GetUser().Id + " " : "");
        }
        public bool IsAjaxRequest(HttpRequest request)
        {
            return request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }
        [Authorize()]
        public ActionResult Password()
        {
            List<Claim> useridentity = GetIdentitiy();
            Int16 userid = Convert.ToInt16(useridentity.FirstOrDefault(x => x.Type == "id").Value);
            User user = dbcontext.User.Where(x => x.Id == userid).Include(x => x.UserDetail).Include(x => x.DailyCheck).ThenInclude(sn => sn.Nurse).FirstOrDefault();
            if (user == null)
                return RedirectToAction("Giris", "Doctorla");
            ViewBag.Name = user.Name;
            ViewBag.SurName = user.SurName;
            ViewBag.AccountBalance = user.AccountBalance;
            ViewBag.DailyCheckCount = user.DailyCheck.Count;
            ViewBag.Numara = user.Id;
            return View(); ;
        }
        [HttpPost]
        public ActionResult ChangePassword(string Oldpass, string Newpass)
        {
            try
            {
                User user = GetUser();
                if (user == null)
                    return RedirectToAction("Giris", "Doctorla");

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
    }
}