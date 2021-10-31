using Data.Domain;
using Domain.Interfaces;
using Domain.Interfaces.Base;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Data.Extensions;
using Domain.Enums;

namespace Services
{
    public class AppointmentService : Service<Appointment>, IAppointmentService
    {
        private readonly IRepository<AppointmentProcess> _appointmentProcessRepository;
        private readonly IUserService _userService;
        private readonly IRepository<Donations> _donationsRepository;
        private readonly ISettingsHelper _settingsHelper;
        private readonly IRepository<AppointmentFiles> _appointmentFilesRepository;
        private readonly IRepository<NotifyWarning> _notifyWarningRepository;
        private readonly IRepository<Campaign> _campaignRepository;
        private readonly IRepository<UsedCampaign> _usedCampaignRepository;
        public AppointmentService(IRepository<Appointment> repository
            , IRepository<AppointmentProcess> appointmentProcessRepository
            , IUserService userService
            , IRepository<Donations> donationsRepository
            , ISettingsHelper settingsHelper
            , IRepository<AppointmentFiles> appointmentFilesRepository
            , IRepository<NotifyWarning> notifyWarningRepository
            , IRepository<Campaign> campaignRepository
            , IRepository<UsedCampaign> usedCampaignRepository) : base(repository)
        {
            _appointmentProcessRepository = appointmentProcessRepository;
            _userService = userService;
            _donationsRepository = donationsRepository;
            _settingsHelper = settingsHelper;
            _appointmentFilesRepository = appointmentFilesRepository;
            _notifyWarningRepository = notifyWarningRepository;
            _campaignRepository = campaignRepository;
            _usedCampaignRepository = usedCampaignRepository;
        }
        public GenericServiceListModel<Appointment> GetAppointments(int userId, bool isDoctor, SortingPagingInfo sorting)
        {
            if (!isDoctor)
                return GetItems(sorting, "Department", p => p.UserId == userId);
            else
                return GetItems(sorting, "Department", p => p.DoctorId == userId && (p.Status != 0 || (p.Status == 0 && p.UserId != 1)));

        }
        public Appointment GetDetail(int appointmentId)
        {
            return GetItem(appointmentId, "AppointmentFiles");
        }
        public (bool, string) DeleteAppointment(int userId, int appointmentId, string reason)
        {
            var result = (false, "İşlem Sırasında Hata Oluştu!");
            try
            {
                Appointment appointment = _repository.Where(x => !x.IsDeleted && x.Status == 0 && x.UserId == userId && x.Id == appointmentId).FirstOrDefault();
                if (appointment == null)
                    result.Item2 = "Randevu Silinmiş veya Bu Randevuya Yetkiniz Bulunmuyor..";
                else
                {
                    if (appointment.AppointmentDate < DateTime.Now.AddHours(1))
                        result.Item2 = "Randevu Başlama Saatine 1 Saat Kaldıktan Sonra Randevuyu İptal Edemezsiniz!";
                    else
                    {
                        Appointment appointmentlog = new Appointment()
                        {
                            IsDeleted = true,
                            UserCancelReason = reason,
                            Status = -2,
                            SessionKey = "",
                            UserId = userId,
                            DoctorId = appointment.DoctorId,
                            DepartmentId = appointment.DepartmentId,
                            AppointmentDate = appointment.AppointmentDate,
                            AppointmentFinishDate = appointment.AppointmentFinishDate,
                            SessionPrice = appointment.SessionPrice,
                            SessionCode = appointment.SessionCode,
                            Sick = new Sick() { Name = "" },
                            IsPrivate = true,
                            IDate = DateTime.Now
                        };
                        _repository.Add(appointmentlog);
                        Random rnd = new Random();
                        string sessioncode = rnd.Next(100000, 999999).ToString();
                        appointment.SessionCode = sessioncode;
                        appointment.Status = 0;
                        appointment.IsDeleted = false;
                        appointment.UserId = 1;
                        User user = _userService.GetItem(userId);
                        _appointmentProcessRepository.Add(new AppointmentProcess() { Appointment = appointment, IDate = DateTime.Now, IsDoctor = false, User = user, ProcessMessage = user.UserType.Name + " " + user.Name + " " + user.SurName + " Randevu İptali, Kullanıcı Tarafından Gerçekleştirildi.. Silme Sebebi:" + reason });
                        Donations donation = _donationsRepository.FirstOrDefault(x => x.AppointmentId == appointment.Id);
                        if (donation != null)
                            _donationsRepository.Remove(donation);
                        user.AccountBalance += appointment.SessionPrice;
                        _userService.Save(user);
                        result.Item1 = true;
                        result.Item2 = "Tebrikler! Randevu İptali İle" + appointment.SessionPrice + " TL Kredi Kazandınız. Krediniz Sonraki İşleminizde Otomatik Olarak Kullanılacaktır";
                    }
                }
            }
            catch (Exception)
            {
            }
            return result;
        }
        public (bool, string) UpdateApointmentDetail(int userId, int appointmentId, List<FileReqModel> files, string appointmentNote, string appointmentDoctorNote, bool isDoctor = false)
        {
            var result = (false, "İşlem Sırasında Hata Oluştu!");
            var appointment = _repository.Where(x => !x.IsDeleted && ((!isDoctor && x.UserId == userId) || (isDoctor && x.DoctorId == userId)) && x.Id == appointmentId).FirstOrDefault();
            if (appointment != null)
            {
                if (files != null || files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        if (string.IsNullOrEmpty(file.FileName))
                        {
                            string filename = Guid.NewGuid().ToString();
                            if (file.FileName.Contains("pdf"))
                                filename += ".pdf";
                            else if (file.FileName.Contains("word"))
                                filename += ".docx";
                            else if (file.FileName.Contains("sheet"))
                                filename += ".xlsx";
                            else if (file.FileName.Contains("png") || file.FileName.Contains("jpg") || file.FileName.Contains("jpeg"))
                                filename += ".png";
                            else
                                continue;
                            var basePath = Path.Combine(_settingsHelper.GetSetting("BaseFileDirectory"), "AppointmentFiles");
                            var filePath = Path.Combine(basePath, filename);
                            var bytes = Convert.FromBase64String(file.FileData);
                            using (var File = new FileStream(filePath, FileMode.Create))
                            {
                                File.Write(bytes, 0, bytes.Length);
                                File.Flush();
                            }
                            _appointmentFilesRepository.Add(new AppointmentFiles() { FileName = filename, AppointmentId = appointment.Id, IsDoctor = isDoctor });
                        }
                    }
                }
                if (isDoctor)
                    appointment.AppointmentDoctorNote = appointmentNote;
                else
                    appointment.AppointmentNote = appointmentNote;
                _repository.Update(appointment);
                result.Item1 = true;
                result.Item2 = "Randevu Bilgileriniz Güncellenmiştir..";
            }
            else
                result.Item2 = "Randevu Bilgilerinize ulaşılmıyor..";
            return result;
        }
        public bool DeleteFile(int fileId)
        {
            var file = _appointmentFilesRepository.Find(fileId);
            var basePath = Path.Combine(_settingsHelper.GetSetting("BaseFileDirectory"), "AppointmentFiles");
            var filePath = Path.Combine(basePath, file.FileName);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            return _appointmentFilesRepository.Remove(file);
        }
        public bool AppointmentSetPrivateStatus(int appointmentId, bool isPrivate)
        {
            var appointment = GetItem(appointmentId);
            appointment.IsPrivate = isPrivate;
            return _repository.Update(appointment);
        }
        public IEnumerable<Appointment> GetDoctorAvailableAppointments(int doctorId, int departmentId, DateTime appointmentDate)
        {
            var fileterEndDate = new DateTime(appointmentDate.Year, appointmentDate.Month, appointmentDate.Day).AddDays(1);
            return _repository
                .Where(p => p.IsActive && p.Status == 0 && p.UserId == 1 && !p.IsDeleted && p.DoctorId == doctorId && p.DepartmentId == departmentId && p.AppointmentDate >= appointmentDate && p.AppointmentDate <= fileterEndDate)
                .OrderBy(p => p.AppointmentDate).ToList();
        }

        public IEnumerable<Appointment> GetDoctorsHavingAppointmentsInGivenDay(int givenDay)
        {
            var nowGivenDayAdded = DateTime.Now.AddDays(givenDay);
            var endAppointmentDate = new DateTime(nowGivenDayAdded.Year, nowGivenDayAdded.Month, nowGivenDayAdded.Day, 23, 59, 59);

            return _repository
                .Where(p => p.IsActive && p.Status == 0 && !p.IsDeleted && p.AppointmentDate >= DateTime.Now && p.AppointmentDate <= endAppointmentDate)
                .ToList();
        }

        public AppointmentBuyResult BuyAppointment(int userId, int appointmentId, string campaigneCode = "")
        {
            var result = new AppointmentBuyResult();
            result.Status = BuyStatus.Error;
            result.Description = "İşlem Sırasında Bir Hata Oluştu!";
            User user = _userService.GetItem(userId, "Address");
            if (!user.IsActive)
                result.Description = "Hesabınız onaylı değil! Lütfen önce hesabınızı onaylayın!";
            else
            {
                Appointment appointment = _repository
                    .Where(x => x.IsActive && !x.IsDeleted && x.AppointmentDate >= DateTime.Now && x.UserId == 1 && x.Id == appointmentId)
                    .Include(x => x.Department).FirstOrDefault();
                if (appointment == null || appointment.Id == 0)
                    result.Description = "Randevu Kayıtı Artık Bulunamıyor. Lütfen Başka Randevu Seçiniz.";
                else
                {
                    bool flag = true;
                    if (appointment.InProcessDates != null && appointment.InProcess)
                    {
                        TimeSpan processdate = DateTime.Now - appointment.InProcessDates.Value;
                        if (appointment.InProcessUserId != userId && processdate.TotalSeconds < 135)
                        {
                            result.Description = "Bu Randevu İşlem Aşamasındadır. Lütfen 2 Dakika Sonra Tekrar Deneyiniz";
                            flag = false;
                        }
                    }
                    if (flag)
                    {
                        if (!string.IsNullOrEmpty(campaigneCode))
                        {
                            var val = ValidateCampaignCode(userId, campaigneCode, appointmentId);
                            if (val.Item1)
                            {
                                var addcreditAmount = appointment.SessionPrice - Convert.ToDecimal(val.Item2);
                                user.AccountBalance += addcreditAmount;
                                if (_userService.Save(user))
                                {
                                    var used = new UsedCampaign
                                    {
                                        CampaignId = val.Item3,
                                        UserId = user.Id,
                                        UsedAmount = addcreditAmount
                                    };
                                    if (!_usedCampaignRepository.Add(used))
                                    {
                                        user.AccountBalance -= addcreditAmount;
                                        user.UsedCampaigns = null;
                                        _userService.Save(user);
                                        result.Description = "Kampanya tanımlanırken bir hata oluştu!";
                                    }


                                    #region Ödeme Sayfası
                                    result.Status = BuyStatus.Success;
                                    result.Description = "İşlem Başarılı !";


                                    User doctorCampaign = _userService.GetItem(appointment.DoctorId);
                                    appointment.DoctorName = doctorCampaign.Name + " " + doctorCampaign.SurName;
                                    decimal discountAmountCampaign = 0;
                                    if (user.AccountBalance >= appointment.SessionPrice)
                                    {
                                        appointment.UserId = user.Id;
                                        appointment.SessionKey = Guid.NewGuid().ToString();
                                        //Donations donation = new Donations() { IsActive = true, Price = (double)appointment.SessionPrice * 0.02, IDate = DateTime.Now, DonationType = 0, AppointmentId = appointment.Id, UserId = user.Id, Name = user.Name + " " + user.SurName, Email = user.Email, Phone = user.Phone, DonationCompany = appointment.DonationCompanys };
                                        //_donationsRepository.Add(donation);
                                        _appointmentProcessRepository.Add(new AppointmentProcess() { Appointment = appointment, IDate = DateTime.Now, IsDoctor = false, User = user, ProcessMessage = "Ödeme Kredi Kullanılarak Başarılı Bir Şekilde Gerçekleştirildi" });
                                        user.AccountBalance -= appointment.SessionPrice;
                                        _repository.Update(appointment);
                                        result.Description = "Bu Randevu Hesap Krediniz Kullanılarak Satın Alınmıştır.";
                                        result.Status = BuyStatus.Success;
                                    }
                                    else
                                    {
                                        discountAmountCampaign = user.AccountBalance;
                                        result.Status = BuyStatus.PaymentRedirect;
                                    }
                                    result.User = user;
                                    result.Appointment = appointment;
                                    result.DiscountAmount = (double)discountAmountCampaign;
                                    appointment.InProcess = true;
                                    appointment.DonationCompanys = "";
                                    appointment.InProcessUserId = user.Id;
                                    appointment.InProcessDates = DateTime.Now;
                                    _repository.Update(appointment);


                                    #endregion
                                    return result;
                                }
                                else
                                {
                                    result.Description = "Kampanya tanımlanırken bir hata oluştu!";
                                    return result;
                                }
                            }
                            else
                            {
                                result.Description = val.Item2;
                                return result;
                            }
                        }
                        User doctor = _userService.GetItem(appointment.DoctorId);
                        appointment.DoctorName = doctor.Name + " " + doctor.SurName;
                        decimal discountAmount = 0;
                        if (user.AccountBalance >= appointment.SessionPrice)
                        {
                            appointment.UserId = user.Id;
                            appointment.SessionKey = Guid.NewGuid().ToString();
                            Donations donation = new Donations() { IsActive = true, Price = (double)appointment.SessionPrice * 0.02, IDate = DateTime.Now, DonationType = 0, AppointmentId = appointment.Id, UserId = user.Id, Name = user.Name + " " + user.SurName, Email = user.Email, Phone = user.Phone, DonationCompany = appointment.DonationCompanys };
                            _donationsRepository.Add(donation);
                            _appointmentProcessRepository.Add(new AppointmentProcess() { Appointment = appointment, IDate = DateTime.Now, IsDoctor = false, User = user, ProcessMessage = "Ödeme Kredi Kullanılarak Başarılı Bir Şekilde Gerçekleştirildi" });
                            user.AccountBalance -= appointment.SessionPrice;
                            _repository.Update(appointment);
                            result.Description = "Bu Randevu Hesap Krediniz Kullanılarak Satın Alınmıştır.";
                            result.Status = BuyStatus.Success;
                        }
                        else
                        {
                            discountAmount = user.AccountBalance;
                            result.Status = BuyStatus.PaymentRedirect;
                        }
                        result.User = user;
                        result.Appointment = appointment;
                        result.DiscountAmount = (double)discountAmount;
                        appointment.InProcess = true;
                        appointment.DonationCompanys = "";
                        appointment.InProcessUserId = user.Id;
                        appointment.InProcessDates = DateTime.Now;
                        _repository.Update(appointment);
                    }
                }
            }
            return result;
        }
        public (bool, string, string) RequestAppointment(int userId, int doctorId, int departmentId, DateTime reqDate, string note, short requestType)
        {

            var result = (false, "İşlem Sırasında Hata Oluştu!", "");
            User user = _userService.GetItem(userId);
            User doctor = _userService.GetItem(doctorId, "RelUserDepartments");

            if (!user.IsActive)
                result.Item2 = "Hesabınız onaylı değil! Lütfen önce hesabınızı onaylayın!";
            else if (reqDate < DateTime.Now)
                result.Item2 = "Geçmiş Zamanda Talep Oluşturamazsınız.";
            else if (_repository.Where(x => x.DoctorId == doctorId && x.AppointmentDate <= reqDate && x.AppointmentFinishDate > reqDate).FirstOrDefault() != null)
                result.Item2 = "Talep Ettiğiniz Tarihte Bir Randevu Mevcut";
            else if (_notifyWarningRepository.Where(x => x.DoctorId == doctorId && x.UserId == user.Id && x.Date >= DateTime.Now && x.Status == 0).ToList().Count >= 3)
                result.Item2 = "Aynı Doktordan Üçten Fazla Talepte Bulunamazsınız";
            else if (_notifyWarningRepository.Where(x => x.DoctorId == doctorId && x.UserId == user.Id && x.Date == reqDate && x.Status == 0).ToList().Count != 0)
                result.Item2 = "Aynı Doktordan Aynı Tarih ve Saatte Talepte Bulunamazsınız";
            else
            {
                _notifyWarningRepository.Add(new NotifyWarning() { UserId = user.Id, DepartmentId = departmentId, DoctorId = doctorId, Date = reqDate, Note = note, Status = 0, RequestType = requestType });
                result.Item1 = true;
                result.Item2 = "Randevu Talebiniz Alınmıştır.";
                result.Item3 = doctor.Phone;
            }
            return result;
        }
        public GenericServiceListModel<NotifyWarning> GetAppointmentRequests(int userId, SortingPagingInfo sorting, bool isDoctor = false)
        {
            var result = new GenericServiceListModel<NotifyWarning>();
            var query = _notifyWarningRepository.Includes("User;Department;Department.RelUserDepartments;Department.RelUserDepartments.User");
            if (!isDoctor)
                query = query.Where(x => x.UserId == userId && x.Date >= DateTime.Now);
            else
                query = query.Where(x => x.Date >= DateTime.Now.AddDays(-3) && x.DoctorId == userId);
            query = query.OrderBy(!string.IsNullOrEmpty(sorting.SortField) ? sorting.SortField : "Status", sorting.SortDirection);

            result.TotalCount = query.Count();
            result.CurrentPage = sorting.PageIndex;
            if (sorting.PageIndex == 0)
            {
                result.PageSize = result.TotalCount;
                result.Items = query.ToList();
            }
            else
            {
                result.PageSize = sorting.PageSize;
                result.Items = query.Skip(sorting.PageSize * (sorting.PageIndex - 1))
              .Take(sorting.PageSize);
            }
            return result;
        }
        public (bool, string) CreateSession(int userId, int departmentId, DateTime startdate, DateTime? multienddate, int Price = 0, int sessionTime = 0, bool isMultiAppointment = false, int breakCount = 0, bool isPreview = false)
        {
            var result = (false, "İşlem Sırasında Hata Oluştu!");
            try
            {
                User user = _userService.GetItem(userId, "RelUserDepartments");
                if (!user.IsActive)
                    result.Item2 = "Hesabınız Henüz Onaylanmamıştır. Onaylandıktan Sonra Randevu Açabilirsiniz. Anlayışınız İçin Teşekkür Ederiz..";
                else if (startdate < DateTime.Now)
                    result.Item2 = "Geçmiş Tarihlere Kayıt Açamazsınız!";
                else
                {
                    RelUserDepartment userdepartment = user.RelUserDepartments.FirstOrDefault(x => x.DepartmentId == departmentId);
                    if (!isMultiAppointment)
                    {
                        DateTime finishdate = startdate.AddMinutes(sessionTime == 0 ? userdepartment.SessionTime : sessionTime);
                        Appointment appointcheck = _repository.FirstOrDefault(x => x.DoctorId == user.Id && x.IsActive && x.Status != -1 && x.Status != -2 && x.Status != -3 && !x.IsDeleted && ((x.AppointmentDate <= startdate && startdate < x.AppointmentFinishDate) || (x.AppointmentDate < finishdate && finishdate < x.AppointmentFinishDate) || (startdate < x.AppointmentDate && finishdate > x.AppointmentFinishDate)));
                        if (appointcheck != null)
                            result.Item2 = "Bu zaman aralığıyla çakışan randevunuz mevcut! Lütfen başka saat dilimi seçiniz..";
                        else
                        {
                            Random rnd = new Random();
                            string sessioncode = rnd.Next(100000, 999999).ToString();
                            Appointment newappointment = new Appointment()
                            {
                                IDate = DateTime.Now,
                                DoctorId = user.Id,
                                DepartmentId = departmentId,
                                AppointmentDate = startdate,
                                AppointmentFinishDate = finishdate,
                                DoctorName = user.Name + " " + user.SurName,
                                IsPreview = isPreview,
                                Sick = new Sick() { Name = "" },
                                SessionKey = Guid.NewGuid().ToString(),
                                SessionPrice = Price == 0 ? userdepartment.Price : Price,
                                SessionTime = sessionTime == 0 ? userdepartment.SessionTime : sessionTime,
                                SessionCode = sessioncode,
                                UserId = 1,
                                IsActive = true,
                                IsDeleted = false
                            };
                            _repository.Add(newappointment);
                            _appointmentProcessRepository.Add(new AppointmentProcess() { Appointment = newappointment, IDate = DateTime.Now, IsDoctor = true, User = user, ProcessMessage = "Doktor Yeni Randevu Oluşturdu" });
                        }
                    }
                    else
                    {
                        DateTime multidate = startdate;
                        DateTime finishdate;
                        while (multidate.AddMinutes((sessionTime == 0 ? userdepartment.SessionTime : sessionTime) + breakCount) <= multienddate)
                        {
                            finishdate = multidate.AddMinutes(sessionTime == 0 ? userdepartment.SessionTime : sessionTime);
                            Appointment appointcheck = _repository
                                .FirstOrDefault(x => x.DoctorId == user.Id && x.IsActive && x.Status != -1 && x.Status != -2 && x.Status != -3 && !x.IsDeleted &&
                                    (
                                        (x.AppointmentDate <= multidate && multidate < x.AppointmentFinishDate) ||
                                        (x.AppointmentDate < finishdate && finishdate < x.AppointmentFinishDate) ||
                                        (multidate < x.AppointmentDate && finishdate > x.AppointmentFinishDate)
                                    )
                                );
                            if (appointcheck == null)
                            {
                                Random rnd = new Random();
                                string sessioncode = rnd.Next(100000, 999999).ToString();
                                Appointment newappointment = new Appointment()
                                {
                                    IDate = DateTime.Now,
                                    DoctorId = user.Id,
                                    DepartmentId = departmentId,
                                    AppointmentDate = multidate,
                                    AppointmentFinishDate = finishdate,
                                    Sick = new Sick() { Name = "" },
                                    IsPreview = isPreview,
                                    SessionKey = Guid.NewGuid().ToString(),
                                    SessionPrice = Price == 0 ? userdepartment.Price : Price,
                                    SessionTime = sessionTime == 0 ? userdepartment.SessionTime : sessionTime,
                                    SessionCode = sessioncode,
                                    UserId = 1,
                                    IsActive = true,
                                    IsDeleted = false
                                };
                                _repository.Add(newappointment);
                                _appointmentProcessRepository.Add(new AppointmentProcess() { Appointment = newappointment, IDate = DateTime.Now, IsDoctor = true, User = user, ProcessMessage = "Doktor Yeni Randevu Oluşturdu" });
                            }
                            multidate = finishdate.AddMinutes(breakCount);
                        }
                    }

                    List<int> usertokens = _notifyWarningRepository.Where(x => x.DepartmentId == departmentId && x.DoctorId == user.Id).Select(x => x.UserId).ToList();
                    if (usertokens.Count == 0)
                    {
                        _notifyWarningRepository.RemoveRange(x => x.DepartmentId == departmentId && x.DoctorId == user.Id);
                    }
                    result.Item1 = true;
                    result.Item2 = "Randevu Kayıtınız Başarılı Bir Şekilde Oluşturulmuştur.";
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public (bool, string, string) SetAppointmentRequestStatus(int userId, int notifyWarningId, bool isApprove)
        {
            var result = (false, "İşlem Sırasında Hata Oluştu!", "");
            try
            {
                User user = _userService.GetItem(userId);
                NotifyWarning notifyWarning = _notifyWarningRepository.Where(x => x.Id == notifyWarningId && x.DoctorId == user.Id).Include(x => x.User).Include(x => x.Department).FirstOrDefault();
                (bool, string) opstatus = (true, "");
                if (isApprove)
                {
                    var isPreview = notifyWarning.RequestType == 1;
                    opstatus = CreateSession(userId, notifyWarning.DepartmentId, notifyWarning.Date, null, isPreview ? 10 : 0, isPreview ? 2 : 0, false, 0, isPreview);
                    if (opstatus.Item1)
                    {
                        notifyWarning.Status = 2;
                        _notifyWarningRepository.Update(notifyWarning);
                        result.Item1 = true;
                        result.Item3 = notifyWarning.User.Phone;
                    }
                    result.Item2 = opstatus.Item2;
                }
                else
                {
                    notifyWarning.Status = 1;
                    _notifyWarningRepository.Update(notifyWarning);
                    result.Item1 = true;
                    result.Item2 = "Randevuyu Reddettiniz";
                    result.Item3 = notifyWarning.User.Phone;
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public (bool, string, int) ValidateCampaignCode(int userId, string code, int appointmentId)
        {
            var result = (false, "İşlem Sırasında Hata Oluştu!", 0);
            try
            {
                //var isused = !_campaignRepository.Where(p => p.IsActive && !p.IsDeleted && p.Code == code && !p.UsedCampaigns.Any(x => x.UserId == userId && x.IsActive && !x.IsDeleted) && (p.StartDate <= DateTime.Now && p.EndDate >= DateTime.Now) && p.CampaignType == CampaignType.Percentage).Include(p => p.UsedCampaigns).Any();
                var _campaigns = _campaignRepository.Where(p => p.IsActive && !p.IsDeleted && (p.StartDate <= DateTime.Now && p.EndDate >= DateTime.Now) && p.CampaignType == CampaignType.Percentage).Include(p => p.UsedCampaigns).ToList();
                var isused = !_campaigns.Where(p => p.Code.ToUpperInvariant() == code.ToUpperInvariant() && !p.UsedCampaigns.Any(x => x.UserId == userId && x.IsActive && !x.IsDeleted)).Any();
                if (isused)
                    result.Item2 = "Kampanya kodu bulunamadı yada daha önce kullanılmıştır!";
                else
                {
                    Appointment appointment = _repository
                   .Where(x => x.IsActive && !x.IsDeleted && x.AppointmentDate >= DateTime.Now && x.UserId == 1 && x.Id == appointmentId)
                   .Include(x => x.Department).FirstOrDefault();
                    if (appointment == null || appointment.Id == 0)
                        result.Item2 = "Randevu Kayıtı Artık Bulunamıyor. Lütfen Başka Randevu Seçiniz.";
                    else
                    {
                        var campaigne = _campaignRepository.Where(p => p.IsActive && !p.IsDeleted && p.Code == code && (p.StartDate <= DateTime.Now && p.EndDate >= DateTime.Now) && p.CampaignType == CampaignType.Percentage).FirstOrDefault();
                        if (campaigne != null)
                        {
                            result.Item2 = (appointment.SessionPrice - (appointment.SessionPrice * (campaigne.Value / 100))).ToString();
                            result.Item1 = true;
                            result.Item3 = campaigne.Id;
                        }
                        else
                            result.Item2 = "Kampanya kodunun geçerlilik süresi bitmiştir!";
                    }
                }
            }
            catch (Exception)
            {
            }
            return result;
        }
    }
}
