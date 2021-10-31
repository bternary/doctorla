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
using Data.Interfaces;
using Data.Interfaces.Repositories;
using Domain.Enums;
using Domain.Interfaces.Base;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PagedList.Core;
using CoreLibrary.MethodExtensions;
using Admin.Models;

namespace Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminPanelController : Controller
    {
        private readonly IUserRepository userContext;
        private readonly DataContext dbcontext;
        private readonly IRepository<UserType> usertypedb;
        private readonly ICountryRepository counterDb;
        NotificationSender sendNotify = new NotificationSender();
        private readonly IConfiguration _settings;

        public AdminPanelController(IUserRepository userContext, ICountryRepository counterDb, IRepository<UserType> usertypedb, DataContext dbcontext, IConfiguration settings)
        {
            this.userContext = userContext;
            this.counterDb = counterDb;
            this.usertypedb = usertypedb;
            this.dbcontext = dbcontext;
            _settings = settings;
        }

        public IActionResult Anasayfa(string weekdate)
        {
            DateTime date;
            if (!String.IsNullOrWhiteSpace(weekdate))
                date = DateTime.Parse(weekdate);
            else
                date = DateTime.Now;
            DateTime today = DateTime.Now;
            DateTime start = date.Date.AddDays(-(int)date.DayOfWeek + 1), end = start.AddDays(7); // Get Week
            User user = GetUser();
            ViewBag.startdate = start;
            ViewBag.enddate = end;
            ViewBag.selecteddate = date;
            List<Appointment> Allappointments = dbcontext.Appointment.Where(x => x.Status != -2).Include(x => x.Department).Include(x => x.User).OrderBy(x => x.AppointmentDate).ToList();
            List<Appointment> datefiltredAppoint = Allappointments.Where(x => x.AppointmentDate < end && x.AppointmentDate > start).ToList();
            ViewBag.Appointments = datefiltredAppoint;
            ViewBag.TodayEarn = Allappointments.Where(x => !x.IsDeleted && x.Status == 1 && x.UserId != 1 && x.AppointmentDate.Day == DateTime.Now.Day).Sum(x => x.SessionPrice);
            ViewBag.TodaySuccessAppointment = Allappointments.Where(x => !x.IsDeleted && x.Status == 1 && x.AppointmentDate.Day == DateTime.Now.Day).ToList().Count;
            ViewBag.TodayWaitingAppointment = Allappointments.Where(x => !x.IsDeleted && x.Status == 0 && x.AppointmentDate.Day == DateTime.Now.Day).ToList().Count;
            ViewBag.TodayDeletedAppointment = Allappointments.Where(x => x.Status == -1 && x.AppointmentDate.Day == DateTime.Now.Day).ToList().Count;
            if (IsAjaxRequest(Request))
                return PartialView("~/Views/Shared/_takvim.cshtml", datefiltredAppoint);

            return View(datefiltredAppoint);
        }
        public IActionResult IletisimFormu(int page = 1)
        {
            PagedList<Contact> contact = new PagedList<Contact>(dbcontext.Contact.OrderByDescending(p => p.IDate), page, 10);
            return View(contact);
        }
        public IActionResult UsedCampaignes(int page = 1)
        {
            var list = dbcontext.UsedCampaign.Include(p => p.Campaign).Include(p => p.User);
            PagedList<UsedCampaign> contact = new PagedList<UsedCampaign>(list, page, 10);
            return View(contact);
        }
        public IActionResult Campaignes(int page = 1)
        {
            PagedList<Campaign> contact = new PagedList<Campaign>(dbcontext.Campaign, page, 10);
            return View(contact);
        }
        public IActionResult GetCampaignDetail(int CampaignId = 0)
        {
            Campaign campaign = new Campaign { StartDate = DateTime.Now, EndDate = DateTime.Now };
            if (CampaignId != 0)
                campaign = dbcontext.Campaign.Where(p => p.Id == CampaignId).FirstOrDefault();
            return PartialView("~/Views/Shared/_GetCampaignDetail.cshtml", campaign);
        }
        public JsonResult UpdateCampaignDetail(int campaignId, string name, string code, decimal creditAmount, DateTime startDate, DateTime endDate, bool isActive, int campaignType)
        {
            var campaign = dbcontext.Campaign.Where(p => p.Id == campaignId).FirstOrDefault();
            campaign.Name = name;
            campaign.Code = code;
            campaign.StartDate = startDate;
            campaign.EndDate = endDate;
            campaign.IsActive = isActive;
            campaign.Value = creditAmount;
            campaign.CampaignType = (CampaignType)campaignType;
            dbcontext.SaveChanges();
            return Json(new { status = 1, title = "İşlem Başarılı", message = "Postu Güncellediniz" });
        }
        public JsonResult CreateCampaignDetail(string name, string code, decimal creditAmount, DateTime startDate, DateTime endDate, bool isActive, int campaignType)
        {
            try
            {
                var campaign = new Campaign();
                campaign.Name = name;
                campaign.Code = code;
                campaign.StartDate = startDate;
                campaign.EndDate = endDate;
                campaign.IsActive = isActive;
                campaign.IDate = DateTime.Now;
                campaign.Value = creditAmount;
                campaign.CampaignType = (CampaignType)campaignType;
                dbcontext.Campaign.Add(campaign);
                dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
            return Json(new { status = 1, title = "İşlem Başarılı", message = "Postu Güncellediniz" });
        }
        public IActionResult YorumveSikayetler(string username = "", string doctorname = "", string sessioncode = "", int page = 1)
        {
            User user = GetUser();
            if (user == null && user.TypeId != 4)
                return Redirect("/AdminPanel/Giris");
            if (!String.IsNullOrEmpty(sessioncode) && IsAjaxRequest(Request))
            {
                List<Appointment> appointmentcode = dbcontext.Appointment.Where(x => x.SessionCode == sessioncode).Include(x => x.Department).Include(x => x.User).ToList();
                PagedList<Appointment> appointmentcodePaged = new PagedList<Appointment>(appointmentcode.AsQueryable(), page, 10);

                return PartialView("~/Views/Shared/_AppointmentNoteList.cshtml", appointmentcodePaged);
            }

            List<Appointment> appointments = dbcontext.Appointment.Where(x =>
            (String.IsNullOrEmpty(username) || (x.User.Name.ToLower() + " " + x.User.SurName.ToLower()).Contains(username.ToLower())) &&
            (String.IsNullOrEmpty(doctorname) || (x.DoctorName.ToLower()).Contains(doctorname.ToLower())) &&
            x.AppointmentRate != 0 && x.AppointmentRate != -3 && x.Status == 1).Include(x => x.Department).Include(x => x.User).OrderByDescending(x => x.AppointmentFinishDate).Take(50).ToList();

            PagedList<Appointment> appointmentsPaged = new PagedList<Appointment>(appointments.AsQueryable(), page, 10);

            if (IsAjaxRequest(Request))
                return PartialView("~/Views/Shared/_AppointmentNoteList.cshtml", appointmentsPaged);
            return View(appointmentsPaged);
        }



        #region UserProfile ------


        [HttpPost]
        public JsonResult ChangePassword(string newpass)
        {
            User user = GetUser();
            if (!String.IsNullOrEmpty(newpass) && newpass.Length >= 5)
            {
                user.Password = newpass;
                dbcontext.SaveChanges();
                return Json(new { status = 1, title = "İşlem Başarılı", message = "Şifreniz Güncellenmiştir" });
            }
            return Json(new { status = -1, title = "İşlem Başarısız", message = "Lütfen En Az 5 Haneli Şifre Girin" });
        }

        #endregion


        #region Blogs
        public IActionResult NewBlogPost(int postId)
        {
            try
            {
                User user = GetUser();
                List<string> tagsList = dbcontext.Blog.Select(x => x.Tags).ToList();
                List<string> categoryList = dbcontext.Blog.Select(x => x.Category).ToList();
                var authorsList = dbcontext.User.Where(x => x.TypeId == 4).Select(x => new UserListItemModel { UserName = x.FullName(), Id = x.Id }).ToList();

                ViewBag.tags = tagsList;
                ViewBag.authors = authorsList;
                ViewBag.categorys = categoryList;

                if (postId > 0)
                {
                    ViewBag.type = "update";

                    Blog post = dbcontext.Blog.FirstOrDefault(x => x.Id == postId);

                    return View("~/Views/AdminPanel/NewBlogPost.cshtml", post);

                }
                ViewBag.type = "new";

                return View();
            }
            catch (Exception e)
            {
                return Json(new { status = -1, message = "Post Eklenemedi", hata = e });
                throw;
            }
        }
        public IActionResult Blogs(int page = 1)
        {

            PagedList<Blog> values = new PagedList<Blog>(dbcontext.Blog.OrderByDescending(x => x.IDate), page, 10);

            return View(values);
        }

        public JsonResult UpdatePostActivity(int packageId)
        {
            Blog post = dbcontext.Blog.FirstOrDefault(x => x.Id == packageId);

            post.IsActive = !post.IsActive;
            dbcontext.SaveChanges();
            return Json(new { status = 1, title = "İşlem Başarılı", message = "Postu Güncellediniz", activeStatus = post.IsActive, id = packageId });

        }
        public JsonResult deletePost(int packageId)
        {
            try
            {
                Blog post = dbcontext.Blog.FirstOrDefault(x => x.Id == packageId);

                dbcontext.Blog.Remove(post);
                dbcontext.SaveChanges();
                return Json(new { status = 1, title = "İşlem Başarılı", message = "Post Başarıyla Silindi" });
            }
            catch (Exception)
            {
                return Json(new { status = -1, title = "İşlem Başarısız", message = "Post Silerken Bir Hata Oluştu.." });
            }
        }
        public IActionResult previewPost(int packageId)
        {
            Blog post = dbcontext.Blog.FirstOrDefault(x => x.Id == packageId);
            if (post.Description != null)
                post.Description = post.Description.ChangeImagePath(_settings["BaseImgPath"]);
            if (post.ThumbnailPhoto != null)
                post.ThumbnailPhoto = AddBasePathToImage(post.ThumbnailPhoto);
            if (post.CoverPhoto != null)
                post.CoverPhoto = AddBasePathToImage(post.CoverPhoto);
            if (post.CoverPhotoMobile != null)
                post.CoverPhotoMobile = AddBasePathToImage(post.CoverPhotoMobile);
            return PartialView(post);
        }
        public string AddBasePathToImage(string imgUri)
        {
            return imgUri.StartsWith("/") ? $"{_settings["BaseImgPath"]}{imgUri}" : imgUri;
        }


        public JsonResult AddPost(
            string SeoUrl, string Description, string ShortDescription, string Title
            , string Categorys, string Tags, int UserId, string ThumbnailPhoto
            , string CoverPhoto, string CoverPhotoMobile, string Type, int Id
            )
        {
                User user = GetUser();
                string ThumbnailPhotoFilename = "";
                string CoverPhotoFilename = "";
                string CoverPhotoMobileFilename = "";
                Blog post = dbcontext.Blog.FirstOrDefault(x => x.Id == Id);

                if (Type == "update")
                {
                    post.SeoUrl = SeoUrl;
                    post.Description = Description;
                    post.Category = Categorys;
                    post.Tags = Tags;
                    post.IUser = UserId;
                    post.ShortDescription = ShortDescription;
                    post.Title = Title;
                }
                else
                {
                    post = new Blog()
                    {
                        SeoUrl = SeoUrl,
                        Description = Description,
                        Category = Categorys,
                        Tags = Tags,
                        IsActive = false,
                        IUser = UserId,
                        ShortDescription = ShortDescription,
                        Title = Title,
                        IDate = DateTime.Now
                    };
                }
                if (!String.IsNullOrEmpty(ThumbnailPhoto))
                {
                    foreach (var detailfile in Regex.Split(ThumbnailPhoto, ":::"))
                    {
                        if (!String.IsNullOrEmpty(detailfile))
                        {
                            ThumbnailPhotoFilename = Guid.NewGuid().ToString() + "-" + Id;
                            if (detailfile.Contains("png"))
                                ThumbnailPhotoFilename += ".png";
                            else if (detailfile.Contains("jpg") || detailfile.Contains("jpeg"))
                                ThumbnailPhotoFilename += ".jpg";
                            else
                                return null;
                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\postImages", ThumbnailPhotoFilename);
                            ThumbnailPhotoFilename = "/postImages/" + ThumbnailPhotoFilename;
                            var bytes = Convert.FromBase64String(detailfile.Split(',')[1]);
                            using (var File = new FileStream(filePath, FileMode.Create))
                            {
                                File.Write(bytes, 0, bytes.Length);
                                File.Flush();
                            }

                        }
                    }
                }
                else
                {
                    ThumbnailPhotoFilename = post.ThumbnailPhoto;
                }
                if (!String.IsNullOrEmpty(CoverPhoto))
                {
                    foreach (var detailfile in Regex.Split(CoverPhoto, ":::"))
                    {
                        if (!String.IsNullOrEmpty(detailfile))
                        {
                            CoverPhotoFilename = Guid.NewGuid().ToString() + "-" + Id;
                            if (detailfile.Contains("png"))
                                CoverPhotoFilename += ".png";
                            else if (detailfile.Contains("jpg") || detailfile.Contains("jpeg"))
                                CoverPhotoFilename += ".jpg";
                            else
                                return null;
                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\postImages", CoverPhotoFilename);
                            CoverPhotoFilename = "/postImages/" + CoverPhotoFilename;
                            var bytes = Convert.FromBase64String(detailfile.Split(',')[1]);
                            using (var File = new FileStream(filePath, FileMode.Create))
                            {
                                File.Write(bytes, 0, bytes.Length);
                                File.Flush();
                            }
                        }
                    }
                }
                else
                {
                    CoverPhotoFilename = post.ThumbnailPhoto;
                }
                if (!String.IsNullOrEmpty(CoverPhotoMobile))
                {
                    foreach (var detailfile in Regex.Split(CoverPhotoMobile, ":::"))
                    {
                        if (!String.IsNullOrEmpty(detailfile))
                        {
                            CoverPhotoMobileFilename = Guid.NewGuid().ToString() + "-" + Id;
                            if (detailfile.Contains("png"))
                                CoverPhotoMobileFilename += ".png";
                            else if (detailfile.Contains("jpg") || detailfile.Contains("jpeg"))
                                CoverPhotoMobileFilename += ".jpg";
                            else
                                return null;
                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\postImages", CoverPhotoMobileFilename);
                            CoverPhotoMobileFilename = "/postImages/" + CoverPhotoMobileFilename;
                            var bytes = Convert.FromBase64String(detailfile.Split(',')[1]);
                            using (var File = new FileStream(filePath, FileMode.Create))
                            {
                                File.Write(bytes, 0, bytes.Length);
                                File.Flush();
                            }
                        }
                    }
                }
                else
                {
                    CoverPhotoMobileFilename = post.ThumbnailPhoto;
                }
                post.ThumbnailPhoto = ThumbnailPhotoFilename;
                post.CoverPhoto = CoverPhotoFilename;
                post.CoverPhotoMobile = CoverPhotoMobileFilename;
                if (post.Id == 0)
                    dbcontext.Blog.Add(post);
                else
                    dbcontext.Blog.Update(post);
                dbcontext.SaveChanges();
                return Json(new { status = 1, title = "İşlem Başarılı", message = "Post Başarıyla Gerçekleşti" });
        }

        #region Appointment Process -------------

        [HttpGet]
        public IActionResult RandevuIslemleri(int id = 0, string username = "", string doctorname = "", string sessioncode = "", int page = 1)
        {
            if (String.IsNullOrEmpty(username) || username == "x")
                username = "";
            if (String.IsNullOrEmpty(doctorname) || doctorname == "x")
                doctorname = "";
            if (String.IsNullOrEmpty(sessioncode) || sessioncode == "x")
                sessioncode = "";

            User user = GetUser();
            if (user == null && user.TypeId != 4)
                return Redirect("/AdminPanel/Giris");
            ViewBag.Id = id;
            ViewBag.UserName = username;
            ViewBag.DoctorName = doctorname;
            ViewBag.SessionCode = sessioncode;
            if (!String.IsNullOrEmpty(sessioncode))
            {
                List<Appointment> appointmentcode = dbcontext.Appointment.Where(x => x.SessionCode == sessioncode).Include(x => x.Department).Include(x => x.User).ToList();
                PagedList<Appointment> appointmentcodePaged = new PagedList<Appointment>(appointmentcode.AsQueryable(), page, 10);
                return View(appointmentcodePaged);
            }

            List<Appointment> appointments = dbcontext.Appointment.OrderByDescending(x => x.AppointmentDate).Include(x => x.Department).Include(x => x.User).ToList();
            if (id == 1)
                appointments = appointments.Where(x => x.UserId != 1 && x.Status == 0 && x.AppointmentFinishDate >= DateTime.Now).ToList();
            else if (id == 2)
                appointments = appointments.Where(x => x.UserId == 1 && x.Status == 0 && x.AppointmentFinishDate >= DateTime.Now).ToList();
            else if (id == 3)
                appointments = appointments.Where(x => x.Status == 1 && x.AppointmentFinishDate <= DateTime.Now).ToList();
            else if (id == 4)
                appointments = appointments.Where(x => x.Status == -3).ToList();
            else if (id == 5)
                appointments = appointments.Where(x => x.Status == -2).ToList();
            else if (id == 6)
                appointments = appointments.Where(x => x.Status == -1).ToList();
            else if (id == 7)
                appointments = appointments.Where(x => x.Status == -100).ToList();
            else if (id == 8)
                appointments = appointments.Where(x => x.UserId != 1 && x.Status == 1 && x.AppointmentDate <= DateTime.Now).ToList();
            if (!String.IsNullOrEmpty(username))
                appointments = appointments.Where(x => (x.User.Name.ToLower() + " " + x.User.SurName.ToLower()).Contains(username.ToLower())).ToList();
            if (!String.IsNullOrEmpty(doctorname))
                appointments = appointments.Where(x => String.IsNullOrEmpty(x.DoctorName) == false ? (x.DoctorName.ToLower()).Contains(doctorname.ToLower()) : false).ToList();

            PagedList<Appointment> appointmentsPaged = new PagedList<Appointment>(appointments.AsQueryable(), page, 10);

            return View(appointmentsPaged);
        }

        public PartialViewResult GetUserDetail(string sessionkey)
        {
            DoctorAppointmentDetail viewdata = new DoctorAppointmentDetail();
            Appointment userappointment = dbcontext.Appointment.Where(x => x.SessionKey == sessionkey).Include(x => x.AppointmentFiles).Include(x => x.User).FirstOrDefault();
            if (userappointment != null && userappointment.UserId != 1)
            {
                User userdetail = dbcontext.User.Where(x => x.Id == userappointment.UserId).Include(x => x.UserDetail).FirstOrDefault();
                List<Appointment> appointments = dbcontext.Appointment.Where(x => !x.IsDeleted && x.Status != -2 && x.UserId == userappointment.UserId).Include(x => x.Department).OrderBy(x => x.AppointmentDate).ToList();
                foreach (var item in appointments)
                {
                    item.DoctorName = dbcontext.User.Where(x => x.Id == item.DoctorId).Select(x => new { DoctorName = x.Name + " " + x.SurName }).FirstOrDefault().DoctorName;
                }
                userdetail.Appointment = appointments;
                viewdata.Appointment = userappointment;
                viewdata.User = userdetail;
                viewdata.Permission = true;
                return PartialView("~/Views/Shared/_UserDetailModal.cshtml", viewdata);
            }
            return null;
        }

        [HttpPost]
        public JsonResult UpdateAppointmentNote(string sessionkey, string doctornote)
        {
            Appointment userappointment = dbcontext.Appointment.Where(x => !x.IsDeleted && x.SessionKey == sessionkey).FirstOrDefault();
            if (userappointment != null)
            {
                userappointment.AppointmentDoctorNote = doctornote;
                dbcontext.SaveChanges();
                return Json(new { status = 1, title = "İşlem Başarılı", message = "Notu Güncellediniz" });
            }
            return Json(new { status = -1, title = "İşlem Başarısız", message = "Randevu Silinmiş " });
        }


        [HttpPost]
        public JsonResult deleteAppointment(string sessionkey, string deleteReason)
        {
            User user = GetUser();
            Appointment appointment = dbcontext.Appointment.Where(x => !x.IsDeleted && x.SessionKey == sessionkey).FirstOrDefault();
            if (appointment != null)
            {
                bool donationcheck = false;
                if (appointment.UserId == 1) //Kayıt Yoksa
                {
                    dbcontext.Appointment.Remove(appointment);
                    dbcontext.AppointmentProcess.RemoveRange(dbcontext.AppointmentProcess.Where(x => x.AppointmentId == appointment.Id));
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
                        appointment.Status = -100;
                        appointment.DoctorDeleteReason = user.Name + " " + user.SurName + "Adlı Admin Tarafından Silindi: " + deleteReason;
                        dbcontext.AppointmentProcess.Add(new AppointmentProcess() { Appointment = appointment, IDate = DateTime.Now, IsDoctor = true, User = user, ProcessMessage = user.UserType.DefaultName + " " + user.Name + " " + user.SurName + " Randevu İptali, Admin Tarafından Gerçekleştirildi.. Silme Sebebi:" + deleteReason });
                        User checkuser = dbcontext.User.FirstOrDefault(x => x.Id == appointment.UserId);
                        Donations donation = dbcontext.Donations.FirstOrDefault(x => x.AppointmentId == appointment.Id);
                        if (donation != null)
                        {
                            dbcontext.Donations.Remove(donation);
                            donationcheck = true;
                        }
                    }
                }
                dbcontext.SaveChanges();
                return Json(new { status = 1, title = "İşlem Başarılı", message = "Randevu Başarılı Bir Şekilde Silinmiştir." + (donationcheck ? "Yapılan Bağış Kaldırıldı" : "") });
            }
            return Json(new { status = -1, title = "İşlem Başarısız", message = "Randevu Silinmiş " });
        }

        [HttpPost]
        public JsonResult changeAppointmentStatus(string sessionkey, int appointmentstatus)
        {
            Appointment userappointment = dbcontext.Appointment.Where(x => x.SessionKey == sessionkey).FirstOrDefault();
            if (userappointment != null)
            {
                userappointment.Status = appointmentstatus;
                dbcontext.SaveChanges();
                return Json(new { status = 1, title = "İşlem Başarılı", message = "Randevu Durumunu Güncellediniz" });
            }
            return Json(new { status = -1, title = "İşlem Başarısız", message = "Randevuya Ulaşılmıyor " });
        }

        [HttpPost]
        public JsonResult getAppointmentProcess(string sessionkey)
        {
            Appointment userappointment = dbcontext.Appointment.Where(x => x.SessionKey == sessionkey).Include(x => x.AppointmentProcess).FirstOrDefault();
            if (userappointment != null)
            {
                return Json(new { status = 1, process = JsonConvert.SerializeObject(userappointment.AppointmentProcess.Select(x => new { date = x.IDate, process = x.ProcessMessage })) });
            }
            return Json(new { status = -1 });
        }



        #endregion


        #region Kullanici İşlemleri ------------
        [HttpGet]
        public IActionResult KullaniciIslemleri(int id = 0, string name = "", int page = 1)
        {
            User user = GetUser();
            if (user == null && user.TypeId != 4)
                return Redirect("/AdminPAnel/Giris");
            List<User> users = new List<User>();
            if (id == 0)
                users = dbcontext.User.Where(x => x.TypeId == 3 && x.Id != 1 && (String.IsNullOrEmpty(name) || (x.Name.ToLower() + " " + x.SurName.ToLower()).Contains(name.ToLower()))).Include(x => x.UserDetail).OrderByDescending(x => x.IDate).ToList();
            else if (id == 1)
                users = dbcontext.User.Where(x => x.TypeId == 1 && (String.IsNullOrEmpty(name) || (x.Name.ToLower() + " " + x.SurName.ToLower()).Contains(name.ToLower()))).Include(x => x.DoctorDetail).OrderByDescending(x => x.IsActive).ThenByDescending(x => x.IDate).ToList();
            else if (id == 2)
                users = dbcontext.User.Where(x => x.TypeId == 4 && (String.IsNullOrEmpty(name) || (x.Name.ToLower() + " " + x.SurName.ToLower()).Contains(name.ToLower()))).OrderByDescending(x => x.IDate).ToList();
            else if (id == 3)
                users = dbcontext.User.Where(x => x.IDate > DateTime.Now.AddDays(-2)).Include(x => x.UserDetail).Include(x => x.DoctorDetail).OrderByDescending(x => x.IDate).ToList();
            else if (id == 4)
                users = dbcontext.User.Where(x => x.TypeId == 2 && (String.IsNullOrEmpty(name) || (x.Name.ToLower() + " " + x.SurName.ToLower()).Contains(name.ToLower()))).Include(x => x.DoctorDetail).OrderByDescending(x => x.IsActive).ThenByDescending(x => x.IDate).ToList();


            ViewBag.Id = id;
            ViewBag.Pagename = id == 0 ? "Hasta İşlemleri" : id == 1 ? "Doktor İşlemleri" : "Yetkili İşlemleri";

            PagedList<User> usersPaged = new PagedList<User>(users.AsQueryable(), page, 10);

            ViewBag.Pagename = id == 0 ? "Hasta İşlemleri" : id == 1 ? "Doktor İşlemleri" : id == 2 ? "Yetkili İşlemleri" : "Son 2 Günde Açılan Hesaplar";
            if (IsAjaxRequest(Request))
                return PartialView("~/Views/Shared/_UserList.cshtml", usersPaged);
            return View(usersPaged);

        }

        [HttpPost]
        public ActionResult ChangeUserPassword(int id, string newpassword)
        {
            User user = GetUser();
            if (user == null && user.TypeId != 4)
                return Redirect("/AdminPAnel/Giris");
            User userpassword = dbcontext.User.FirstOrDefault(x => x.Id == id);
            userpassword.Password = newpassword;
            dbcontext.SaveChanges();
            return Json(new { status = 1 });
        }
        [HttpPost]
        public ActionResult ChangeUserStatus(int id)
        {
            User user = GetUser();
            if (user == null && user.TypeId != 4)
                return Redirect("/AdminPAnel/Giris");
            User useractivity = dbcontext.User.FirstOrDefault(x => x.Id == id);
            useractivity.IsActive = !useractivity.IsActive;
            dbcontext.SaveChanges();
            return Json(new { status = 1, userid = useractivity.Id, useractivitystatus = Convert.ToInt16(useractivity.IsActive) });
        }
        [HttpPost]
        public ActionResult changeBalance(int id, int newbalance)
        {
            User user = GetUser();
            if (user == null && user.TypeId != 4)
                return Redirect("/AdminPAnel/Giris");
            User useractivity = dbcontext.User.FirstOrDefault(x => x.Id == id);
            useractivity.AccountBalance = newbalance;
            dbcontext.SaveChanges();
            return Json(new { status = 1 });
        }




        #region Doktor Detayları ------------------

        public IActionResult DoctorDetails(int id)
        {
            if (id == 0)
                return RedirectToAction("KullaniciIslemleri", new { id = 1 });
            User doctor = dbcontext.User.Where(x => x.Id == id).Include(x => x.RelUserDepartments).Include(x => x.DoctorDetail).Include(x => x.DoctorDetail.DoctorEducations).Include(x => x.DoctorDetail.DoctorExperiences).Include(x => x.DoctorDetail.DoctorMedicalInterests).Include(x => x.DoctorDetail.DoctorScientificMembership).FirstOrDefault();
            if (doctor.RelUserDepartments.Count != 0)
                foreach (var item in doctor.RelUserDepartments)
                    item.Department = dbcontext.Department.FirstOrDefault(x => x.Id == item.DepartmentId);
            ViewBag.Departments = dbcontext.Department.ToList();
            return View(doctor);
        }
        public IActionResult UpdatePhoto(int doctorid, string photofile)
        {
            User doctor = dbcontext.User.FirstOrDefault(x => x.Id == doctorid);
            if (!String.IsNullOrEmpty(photofile))
            {
                var basePath = Path.Combine(_settings["BaseFileDirectory"], "UserImages");
                var photoName = "";
                if (doctor.PhotoUrl.EndsWith("defaultuser.png") || doctor.PhotoUrl.EndsWith("doktor.png"))
                {
                    photoName = Guid.NewGuid().ToString() + ".png";
                    doctor.PhotoUrl = _settings["BaseFileSharePath"] + "/UserImages/" + photoName;
                }
                else
                {
                    var splited = doctor.PhotoUrl.Split('/');
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
            dbcontext.SaveChanges();
            return RedirectToAction("DoctorDetails", new { id = doctorid });
        }

        // Doctor Departments
        [HttpPost]
        public JsonResult AddDoctorDepartment(int doctorid = 0, int departmentId = 0, int Price = 10, int SessionTime = 10)
        {
            User user = GetUser();
            if (doctorid != 0 && departmentId != -1)
            {
                RelUserDepartment newdepartment = new RelUserDepartment()
                {
                    UserId = doctorid,
                    DepartmentId = departmentId,
                    IsActive = true,
                    IsDeleted = false,
                    IDate = DateTime.Now,
                    Price = Price,
                    SessionTime = SessionTime,
                    IUser = user.Id
                };
                Department department = dbcontext.Department.FirstOrDefault(x => x.Id == departmentId);
                dbcontext.RelUserDepartment.Add(newdepartment);
                dbcontext.SaveChanges();
                return Json(new { status = 1, id = newdepartment.Id, name = department.Name, time = newdepartment.SessionTime, price = newdepartment.Price });
            }
            return Json(new { status = -1 });
        }
        [HttpPost]
        public JsonResult RemoveDoctorDepartment(int doctordepartmentId)
        {
            if (doctordepartmentId != 0)
            {
                RelUserDepartment reldepartment = dbcontext.RelUserDepartment.FirstOrDefault(x => x.Id == doctordepartmentId);
                dbcontext.RelUserDepartment.Remove(reldepartment);
                dbcontext.SaveChanges();
                return Json(new { status = 1 });
            }
            return Json(new { status = -1 });
        }

        // Education
        [HttpPost]
        public JsonResult AddDoctorEducation(int doctorid, DoctorEducations educations)
        {
            if (doctorid != 0)
            {
                DoctorDetail detail = dbcontext.DoctorDetail.FirstOrDefault(x => x.UserId == doctorid);
                educations.DoctorDetail = detail;
                dbcontext.DoctorEducations.Add(educations);
                dbcontext.SaveChanges();
                return Json(new { status = 1, id = educations.Id, name = educations.Name, branch = educations.Branch, date = educations.BeginDate.ToShortDateString(), enddate = educations.EndDate.Year != 0001 ? educations.EndDate.ToShortDateString() : "Devam Ediyor" });
            }
            return Json(new { status = -1 });
        }
        [HttpPost]
        public JsonResult RemoveDoctorEducation(int educationId)
        {
            if (educationId != 0)
            {
                DoctorEducations education = dbcontext.DoctorEducations.FirstOrDefault(x => x.Id == educationId);
                dbcontext.DoctorEducations.Remove(education);
                dbcontext.SaveChanges();
                return Json(new { status = 1 });
            }
            return Json(new { status = -1 });
        }

        // Experiences
        [HttpPost]
        public JsonResult AddDoctorExperiences(int doctorid, DoctorExperiences experiences)
        {
            if (doctorid != 0 && experiences.BeginDate.Year != 0001)
            {
                DoctorDetail detail = dbcontext.DoctorDetail.FirstOrDefault(x => x.UserId == doctorid);
                experiences.DoctorDetail = detail;
                dbcontext.DoctorExperiences.Add(experiences);
                dbcontext.SaveChanges();
                return Json(new { status = 1, id = experiences.Id, name = experiences.Name, branch = experiences.Branch, date = experiences.BeginDate.ToShortDateString(), enddate = experiences.EndDate != null ? experiences.EndDate.Value.ToShortDateString() : "Devam Ediyor" });
            }
            return Json(new { status = -1 });
        }
        [HttpPost]
        public JsonResult RemoveDoctorExperiences(int experiencesId)
        {
            if (experiencesId != 0)
            {
                DoctorExperiences experiences = dbcontext.DoctorExperiences.FirstOrDefault(x => x.Id == experiencesId);
                dbcontext.DoctorExperiences.Remove(experiences);
                dbcontext.SaveChanges();
                return Json(new { status = 1 });
            }
            return Json(new { status = -1 });
        }


        // Medical Interest
        [HttpPost]
        public JsonResult AddDoctorMedicalInterest(int doctorid, DoctorMedicalInterests medicalInterest)
        {
            if (doctorid != 0)
            {
                DoctorDetail detail = dbcontext.DoctorDetail.FirstOrDefault(x => x.UserId == doctorid);
                medicalInterest.DoctorDetail = detail;
                dbcontext.DoctorMedicalInterests.Add(medicalInterest);
                dbcontext.SaveChanges();
                return Json(new { status = 1, name = medicalInterest.Name });
            }
            return Json(new { status = -1 });
        }
        [HttpPost]
        public JsonResult RemoveDoctorMedicalInterest(int MedicalInterestId)
        {
            if (MedicalInterestId != 0)
            {
                DoctorMedicalInterests medicalInterest = dbcontext.DoctorMedicalInterests.FirstOrDefault(x => x.Id == MedicalInterestId);
                dbcontext.DoctorMedicalInterests.Remove(medicalInterest);
                dbcontext.SaveChanges();
                return Json(new { status = 1 });
            }
            return Json(new { status = -1 });
        }

        // Scientific Membership
        [HttpPost]
        public JsonResult AddDoctorScientificMembership(int doctorid, DoctorScientificMembership scientificMembership)
        {
            if (doctorid != 0)
            {
                DoctorDetail detail = dbcontext.DoctorDetail.FirstOrDefault(x => x.UserId == doctorid);
                scientificMembership.DoctorDetail = detail;
                dbcontext.DoctorScientificMembership.Add(scientificMembership);
                dbcontext.SaveChanges();
                return Json(new { status = 1, name = scientificMembership.Name, date = scientificMembership.BeginDate != null ? scientificMembership.BeginDate.Value.ToShortDateString() : "Belirtilmedi", enddate = scientificMembership.EndDate != null ? scientificMembership.EndDate.Value.ToShortDateString() : "Belirtilmedi" });
            }
            return Json(new { status = -1 });
        }
        [HttpPost]
        public JsonResult RemoveDoctorScientificMembership(int scientificMembershipId)
        {
            if (scientificMembershipId != 0)
            {
                DoctorScientificMembership medicalInterest = dbcontext.DoctorScientificMembership.FirstOrDefault(x => x.Id == scientificMembershipId);
                dbcontext.DoctorScientificMembership.Remove(medicalInterest);
                dbcontext.SaveChanges();
                return Json(new { status = 1 });
            }
            return Json(new { status = -1 });
        }


        #endregion




        #endregion



        public IActionResult Paketler(int Id = 0, string name = "", int page = 1)
        {
            User user = GetUser();
            if (String.IsNullOrEmpty(name) || name == "x")
                name = "";

            List<DailyCheck> dailychecks = new List<DailyCheck>();

            if (Id == 0)
            {
                dailychecks = dbcontext.DailyCheck.Where(x => x.Finish > DateTime.Now).Include(x => x.User).Include(x => x.Nurse).ToList();
            }
            else if (Id == -1)
            {
                dailychecks = dbcontext.DailyCheck.Where(x => x.NurseId == 1 && x.Finish > DateTime.Now).Include(x => x.User).Include(x => x.Nurse).ToList();
            }
            else if (Id == 1)
            {
                dailychecks = dbcontext.DailyCheck.Where(x => x.Finish < DateTime.Now).Include(x => x.User).Include(x => x.Nurse).ToList();
            }
            if (!String.IsNullOrEmpty(name))
                dailychecks = dailychecks.Where(x => (x.User.FullName().ToLower().Contains(name.ToLower()) || x.Nurse.FullName().ToLower().Contains(name.ToLower()))).ToList();

            PagedList<DailyCheck> dailychecksPaged = new PagedList<DailyCheck>(dailychecks.AsQueryable(), page, 10);
            ViewBag.UserName = name;
            var nursedata = dbcontext.User.Include(x => x.UserType).Where(x => x.UserType.Name == "Hemşire" && x.IsActive && !x.IsDeleted).ToList();
            ViewBag.NurseData = nursedata;
            ViewBag.PaketId = Id;
            return View(dailychecksPaged);
        }
        public JsonResult ChangeNurse(int id, int nurseId)
        {
            if (id == 0 || nurseId == 0)
                return Json(new { status = -1, title = "İşlem Hatası", message = "Hemşire veya Paket Bulunamadı" });
            DailyCheck package = dbcontext.DailyCheck.FirstOrDefault(x => x.Id == id);
            package.NurseId = nurseId;
            dbcontext.SaveChanges();
            return Json(new { status = 1, title = "İşlem Başarılı", message = "Hemşire Güncellediniz" });
        }
        public PartialViewResult GetDailyCheckDetail(int Id)
        {
            List<DailyCheckDetail> dailyChecks = dbcontext.DailyCheckDetail.Where(x => x.DailyCheckId == Id).Include(x => x.ValuesTitle).Include(x => x.Values).Include(x => x.DailyCheck).Where(x => x.DailyCheck.Status == 0).ToList();
            return PartialView("~/Views/Shared/_DailyCheckDetail.cshtml", dailyChecks);
        }
        #endregion

        public bool IsAjaxRequest(HttpRequest request)
        {
            return request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }
        public IActionResult GetDailyCheckPackages(int page = 1)
        {
            List<DailyCheckPackagesValues> values = dbcontext.DailyCheckPackagesValues.ToList();

            PagedList<DailyCheckPackages> packages = new PagedList<DailyCheckPackages>(dbcontext.DailyCheckPackages, page, 10);
            foreach (var item in packages)
            {
                item.DailyCheckPackagesValues = new List<DailyCheckPackagesValues>();
                if (item.IsPremium || item.PackageValues == "" || item.PackageValues == null)
                    continue;
                foreach (var valuesid in item.PackageValues.Split(','))
                {

                    item.DailyCheckPackagesValues.Add(values.FirstOrDefault(x => x.Id == Convert.ToInt32(valuesid)));
                }

            }

            return View(packages);
        }
        public JsonResult UpdateDailyCheckPackagesActivity(int packageId)
        {
            DailyCheckPackages dailyCheckPackages = dbcontext.DailyCheckPackages.FirstOrDefault(x => x.Id == packageId);

            dailyCheckPackages.IsActive = !dailyCheckPackages.IsActive;
            dbcontext.SaveChanges();
            return Json(new { status = 1, title = "İşlem Başarılı", message = "Paket Güncellediniz", activeStatus = dailyCheckPackages.IsActive, id = packageId });

        }
        public JsonResult UpdateDailyCheckPackages(int Id, string packageName, string prices)
        {
            DailyCheckPackages dailyCheckPackages = dbcontext.DailyCheckPackages.FirstOrDefault(x => x.Id == Id);

            dailyCheckPackages.Name = packageName;
            dailyCheckPackages.Price = prices;
            dbcontext.SaveChanges();
            return Json(new { status = 1, title = "İşlem Başarılı", message = "Paket Güncellediniz" });

        }
        public PartialViewResult GetPackagesValues(int Id)
        {
            DailyCheckPackages dailyCheckPackages = dbcontext.DailyCheckPackages.FirstOrDefault(x => x.Id == Id);



            ViewBag.PackageValues = dbcontext.DailyCheckPackagesValues.Where(x => !x.IsDefault).ToList();
            return PartialView("~/Views/Shared/_OlcumBelirleAdmin.cshtml", dailyCheckPackages);
        }
        public JsonResult UpdatePackageValues(int Id, string added)
        {
            DailyCheckPackages dailyCheckPackages = dbcontext.DailyCheckPackages.FirstOrDefault(x => x.Id == Id);
            List<DailyCheckPackagesValues> values = dbcontext.DailyCheckPackagesValues.Where(x => x.IsDefault).ToList();
            string packageValues = "";
            foreach (var item in values)
            {
                packageValues += item.Id + ",";
            }
            if (added == "" || added == null)
            {
                packageValues = packageValues.Substring(0, packageValues.Length - 1);

            }
            else
            {
                packageValues += added;

            }
            dailyCheckPackages.PackageValues = packageValues;
            dbcontext.SaveChanges();
            return Json(new { status = 1, title = "İşlem Başarılı", message = "Paket Güncellediniz" });

        }
        public JsonResult AddDailyCheckPackages(string packageName, string prices)
        {
            User user = GetUser();
            List<DailyCheckPackagesValues> values = dbcontext.DailyCheckPackagesValues.Where(x => x.IsDefault).ToList();
            string packageValues = "";
            foreach (var item in values)
            {
                packageValues += item.Id + ",";
            }
            packageValues = packageValues.Substring(0, packageValues.Length - 1);
            DailyCheckPackages newdailyCheckPackages = new DailyCheckPackages()
            {
                Name = packageName,
                Price = prices,
                PackageValues = packageValues,
            };
            dbcontext.DailyCheckPackages.Add(newdailyCheckPackages);
            dbcontext.SaveChanges();
            return Json(new { status = 1, id = newdailyCheckPackages.Id, name = newdailyCheckPackages.Name, prices = newdailyCheckPackages.Price });

        }
        public JsonResult deletePackage(int packageId)
        {
            try
            {
                DailyCheckPackages dailyCheckPackages = dbcontext.DailyCheckPackages.FirstOrDefault(x => x.Id == packageId);

                dbcontext.DailyCheckPackages.Remove(dailyCheckPackages);
                dbcontext.SaveChanges();
                return Json(new { status = 1, title = "İşlem Başarılı", message = "Paket Başarıyla Silindi" });
            }
            catch (Exception)
            {
                return Json(new { status = -1, title = "İşlem Başarısız", message = "Randevu Bilgileriniz Güncellenirken Hata Oluştu.." });
            }
        }
        public IActionResult GetDailyCheckPackagesValues(int page = 1)
        {
            PagedList<DailyCheckPackagesValues> dailyCheckPackagesValues = new PagedList<DailyCheckPackagesValues>(dbcontext.DailyCheckPackagesValues, page, 10);
            return View(dailyCheckPackagesValues);
        }
        public JsonResult UpdateDailyCheckPackagesValuesDefault(int valueId)
        {
            DailyCheckPackagesValues dailyCheckPackagesValues = dbcontext.DailyCheckPackagesValues.FirstOrDefault(x => x.Id == valueId);

            dailyCheckPackagesValues.IsDefault = !dailyCheckPackagesValues.IsDefault;
            dbcontext.SaveChanges();
            return Json(new { status = 1, title = "İşlem Başarılı", message = "Ölçüm Güncellediniz", activeStatus = dailyCheckPackagesValues.IsDefault, id = valueId });
        }



        #region Login - Register ----
        [AllowAnonymous]
        public ActionResult Giris()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Giris(string Email, string Password)
        {
            User user = dbcontext.User.Include(x => x.UserType).Include(x => x.RoleGroup).FirstOrDefault(x => x.Email == Email && x.Password == Password && x.IsDeleted == false);
            if (user != null)
            {
                user.LastLoginDate = DateTime.Now;
                dbcontext.SaveChanges();
                SetIdentity(user);
                string typename = usertypedb.FirstOrDefault(x => x.Id == user.TypeId).Name;
                if (typename == "Hasta")
                    return RedirectToAction("Profilim");
                else if (typename == "Admin")
                {
                    var response = sendNotify.SendNotificationAsync(new NotificationPostData()
                    {
                        FcmTokens = dbcontext.NotifyTokens.Where(x => x.UserId == user.Id).Select(x => x.Token).ToList(),
                        MessageData = new NotificationMessageData() { Title = "Hoşgeldiniz", Message = "Doctorla Admin Hesabıyla Giriş Yaptınız", Link = "", Action = "", Image = "https://www.doctorla.co/images/NotificaitonLogo.png" }
                    });
                    return Redirect("/AdminPanel/Anasayfa");
                }
            }
            return View();
        }


        public ActionResult Cikis()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Giris");
        }

        #endregion




        #region UserSecurity ------

        public User GetUser()
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

        public void SetIdentity(User user) // Kullanıcı Bilgileri Kaydedildi
        {
            string typename = usertypedb.FirstOrDefault(x => x.Id == user.TypeId).Name;
            // Verileri Kullanmak İçin: User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email).Value  - / Email,Name,id,roleid vs ClaimTypes. Koyup Seçilebilir
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name,user.Name + " " + user.SurName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,typename),
                new Claim("id",user.Id.ToString()),
                new Claim("rolename",user.RoleGroup.Name),
                new Claim("typeid",user.TypeId.ToString())
            };
            var userIdentity = new ClaimsIdentity(claims, "user");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            HttpContext.SignInAsync(principal);

        }
        public List<Claim> GetIdentitiy() // User Kimliğini Aldık. Kullanımı Asagidaki gibidir.
        {
            List<Claim> checkuser = User.Claims.ToList();
            if (checkuser != null)
                return checkuser;
            return null;
        }

        #endregion


        public JsonResult UpdateDailyCheckPackagesValues(int Id, string Name, double MinValue, double MaxValue)
        {
            DailyCheckPackagesValues dailyCheckPackagesValues = dbcontext.DailyCheckPackagesValues.FirstOrDefault(x => x.Id == Id);

            dailyCheckPackagesValues.Name = Name;
            dailyCheckPackagesValues.MinValue = MinValue;
            dailyCheckPackagesValues.MaxValue = MaxValue;
            dbcontext.SaveChanges();
            return Json(new { status = 1, title = "İşlem Başarılı", message = "Ölçüm Güncellediniz" });

        }
        public JsonResult deletePackageValues(int Id)
        {
            try
            {
                DailyCheckPackagesValues dailyCheckPackagesValues = dbcontext.DailyCheckPackagesValues.FirstOrDefault(x => x.Id == Id);

                dbcontext.DailyCheckPackagesValues.Remove(dailyCheckPackagesValues);
                dbcontext.SaveChanges();
                return Json(new { status = 1, title = "İşlem Başarılı", message = "Ölçüm Başarıyla Silindi" });
            }
            catch (Exception)
            {
                return Json(new { status = -1, title = "İşlem Başarısız", message = "Randevu Bilgileriniz Güncellenirken Hata Oluştu.." });
            }
        }
        public JsonResult AddDailyCheckPackagesValues(string Name, double MinValue, double MaxValue)
        {
            User user = GetUser();

            DailyCheckPackagesValues newdailyCheckPackagesValues = new DailyCheckPackagesValues()
            {
                Name = Name,
                MinValue = MinValue,
                MaxValue = MaxValue,
            };
            dbcontext.DailyCheckPackagesValues.Add(newdailyCheckPackagesValues);
            dbcontext.SaveChanges();
            return Json(new { status = 1, id = newdailyCheckPackagesValues.Id, name = newdailyCheckPackagesValues.Name, MinValue = newdailyCheckPackagesValues.MinValue, MaxValue = newdailyCheckPackagesValues.MaxValue });

        }

    }

}

