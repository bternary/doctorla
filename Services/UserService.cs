using Data.Domain;
using Data.Interfaces.Repositories;
using Domain.Interfaces.Base;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Data.Interfaces;
using Domain.Enums;
using Domain.Models;
using System.Linq.Expressions;
using Data.Extensions;
using Domain.Interfaces;
using System.IO;
using System.Net;

namespace Services
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IRepository<DoctorDetail> _ddetail;
        private readonly IRepository<Department> _department;
        private readonly ISettingsHelper _settingsHelper;
        private readonly IRepository<RelUserDepartment> _relUserDepartment;
        
        public UserService(IUserRepository userRepository
            , IRepository<DoctorDetail> ddetail
            , IRepository<Department> department
            , ISettingsHelper settingsHelper
            , IRepository<RelUserDepartment> relUserDepartment
            ) : base(userRepository)
        {
            _ddetail = ddetail;
            _department = department;
            _settingsHelper = settingsHelper;
            _relUserDepartment = relUserDepartment;
        }
        public bool Save(User item)
        {
            
            var result = false;
            try
            {
                if (item.Id > 0)
                    result = _repository.Update(item);
                else
                    result = _repository.Add(item);
            }
            catch (Exception)
            { }
            return result;
        }
        public User GetItem(int Id)
        {
            return _repository.Where(p => p.Id == Id && p.IsActive && !p.IsDeleted)
                .Include(p => p.UserType)
                .Include(p => p.UserDetail)
                .Include(p => p.UserType)
                .Include(p => p.Appointment.Where(x => x.IsActive && !x.IsDeleted).OrderBy(x => x.AppointmentDate).Take(10))
                .Include(p => p.DailyCheck.OrderBy(p => p.Start).Take(10))
                .Include(p => p.Address)
                .Include(p => ((Address)p.Address).City)
                .Include(p => ((Address)p.Address).County)
                .Include(p => ((Address)p.Address).Country)
                .FirstOrDefault();
        }

       

        public RefreshToken GenerateRefreshToken(int userId)
        {
            RefreshToken refreshToken = new RefreshToken()
            {
                Token = GenerateRefreshToken(),
                Expiration = DateTime.UtcNow.AddDays(7)
            };
            //var user = GetItem(userId);
            //user.RefreshTokenMobile = refreshToken.Token;
            //user.RefreshTokenEndTimeMobile = refreshToken.Expiration;
            //Save(user);
            return refreshToken;
        }
        public bool ValidateRefreshToken(int userId, string refreshToken)
        {
            var user = GetItem(userId);
            var result = user != null && (user.RefreshTokenMobile == refreshToken && user.RefreshTokenEndTimeMobile >= DateTime.Now);
            return result;
        }
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
        public (bool, int) ValidateUser(string username, string password)
        {
            var result = (false, 0);
            var user = _repository.Where(p => p.Email == username && p.Password == password).FirstOrDefault();
            if (user != null && user != default)
            {
                result.Item1 = true;
                result.Item2 = user.Id;
            }
            return result;
        }
        public bool ValidateUserData(User user)
        {
            return !_repository.Where(x => (x.Email == user.Email || x.Phone == user.Phone) && x.Id != user.Id).Any();
        }
        public int GenerateDoctorRandomCode()
        {
            Random rnd = new Random();
            int random = rnd.Next(1000000, 9999999);
            while (_ddetail.Where(x => x.DoctorUniqueId == random).Any())
                random = rnd.Next(1000000, 9999999);
            return random;
        }
        public IEnumerable<Department> GetDepartments()
        {
            return _department.Where(x => x.RelUserDepartments.Any(p => p.IsActive && !p.IsDeleted && p.User.IsActive && !p.User.IsDeleted && p.User.TypeId == (int)UserTypesEnum.Doctor) && x.IsActive && !x.IsDeleted)
                    .Include(x => x.RelUserDepartments)
                    .ThenInclude(x => x.User)
                    .OrderBy(x => x.Name)
                    .ToList();
        }
        public (bool, string, string) GenerateActivationCode(int userId)
        {
            var result = (false, "", "");
            var user = _repository.Find(userId);
            if (user != null)
            {
                Random rnd = new Random();
                int random = rnd.Next(100000, 999999);
                result.Item3 = random.ToString();
                user.RefreshToken = result.Item3;
                user.UUDate = DateTime.Now;
                _repository.Update(user);
                result.Item1 = true;
                result.Item2 = $"Onay kodunuz: {result.Item3 }  Sağlıklı Günler Dileriz... Doctorla.";
            }
            return result;
        }
        public bool ActivateUser(int userId, string activationCode)
        {
            var result = false;
            var user = _repository.Find(userId);

            if (user.RefreshToken == activationCode)
            {
                user.IsActive = true;
                user.UUDate = DateTime.Now;
                user.RefreshToken = null;
                result = true;
                Save(user);
            }
            return result;
        }
        public GenericServiceListModel<User> GetDoctorList(SortingPagingInfo sorting, int depatmentId, string doctorName)
        {
            Expression<Func<User, bool>> Filter = (p => p.UserType.Id == (int)UserTypesEnum.Doctor && p.IsActive && !p.IsDeleted);
            if (depatmentId > 0)
                Filter = Filter.AndAlso(p => p.RelUserDepartments.Any(x => x.DepartmentId == depatmentId && x.IsActive && !x.IsDeleted && x.Department.IsActive && !x.Department.IsDeleted));
            if (!string.IsNullOrEmpty(doctorName))
                Filter = Filter.AndAlso(p => (p.Name + " " + p.SurName).Contains(doctorName));
            return GetItems(sorting, "DoctorDetail;RelUserDepartments;RelUserDepartments.Department", Filter);
        }

        public GenericServiceListModel<User> GetDoctors(SortingPagingInfo sorting, IEnumerable<int> doctorIds)
        {
            Expression<Func<User, bool>> filter = (p => doctorIds.Contains(p.Id) && p.UserType.Id == (int)UserTypesEnum.Doctor && p.IsActive && !p.IsDeleted);
            return GetItems(sorting, "", filter);
        }        

        public bool ChangePassword(int userId, string oldPassword, string newPassword)
        {
            var result = false;
            var user = GetItem(userId);
            if (user.Password == oldPassword)
            {
                user.Password = newPassword;
                result = true;
                Save(user);
            }
            return result;
        }
        public bool UpdateUser(int userId, User updateuser, FileReqModel profilephoto)
        {
            var result = true;
            try
            {
                var user = GetItem(userId, "Address;UserDetail");
                if (profilephoto != null && !string.IsNullOrEmpty(profilephoto.FileName))
                {
                    var basePath = Path.Combine(_settingsHelper.GetSetting("BaseFileDirectory"), "UserImages");
                    var photoName = "";
                    if (user.PhotoUrl.EndsWith("defaultuser.png") || user.PhotoUrl.EndsWith("doktor.png"))
                    {
                        photoName = Guid.NewGuid().ToString() + ".png";
                        user.PhotoUrl = _settingsHelper.GetSetting("BaseFileSharePath") + "/UserImages/" + photoName;
                    }
                    else
                    {
                        var splited = user.PhotoUrl.Split('/');
                        photoName = splited[splited.Length - 1];
                    }
                    var filePath = Path.Combine(basePath, photoName);
                    try
                    {
                        var bytes = Convert.FromBase64String(profilephoto.FileData);
                        using (var File = new FileStream(filePath, FileMode.Create))
                        {
                            File.Write(bytes, 0, bytes.Length);
                            File.Flush();
                        }
                    }
                    catch
                    {


                    }
                    finally
                    {

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
                user.UserDetail.Bloodtype = updateuser.UserDetail.Bloodtype;
                user.UserDetail.ChronicDiseases = updateuser.UserDetail.ChronicDiseases;
                user.UserDetail.FamilyDiseases = updateuser.UserDetail.FamilyDiseases;
                user.UserDetail.RegularlyMedicines = updateuser.UserDetail.RegularlyMedicines;
                user.UserDetail.HearUs = updateuser.UserDetail.HearUs;
                user.UserDetail.SurgicalHistory = updateuser.UserDetail.SurgicalHistory;
                if (updateuser.Address != null)
                {
                    user.Address.FirstOrDefault().CountryId = updateuser.Address.FirstOrDefault().CountryId;
                    user.Address.FirstOrDefault().CityId = updateuser.Address.FirstOrDefault().CityId;
                    user.Address.FirstOrDefault().CountyId = updateuser.Address.FirstOrDefault().CountyId;
                    user.Address.FirstOrDefault().AddressDetail = updateuser.Address.FirstOrDefault().AddressDetail;
                }

                Save(user);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
        public bool UpdateDocotorDepartmentPrice(int relUserDepartmentId, int price, int sessionTime)
        {
            var userDepartment = _relUserDepartment.Find(relUserDepartmentId);
            userDepartment.SessionTime = sessionTime;
            userDepartment.Price = price;
            return _relUserDepartment.Update(userDepartment);
        }
        public (bool, string, string, string) GenerateResetPasswordCode(string phone)
        {
            var result = (false, "İşlem Sırasında Hata Oluştu!", "", "");
            User user = _repository.FirstOrDefault(x => x.Phone == phone && !x.IsDeleted);
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
                    _repository.Update(user);
                    result.Item4 = ("Şifre Değiştirme Onay kodunuz: " + user.RefreshToken + "   Sağlıklı Günler Dileriz... Doctorla.");
                }
                result.Item1 = true;
                result.Item2 = "Şifre sıfırlama onay kodunuz telefon numaranıza gönderilmiştir!";
                result.Item3 = user.Phone;
            }
            else result.Item2 = "Girdiğiniz Telefon numarasına kayıtlı bir hesap bulunmamaktadır!";
            return result;
        }
        public (bool, string) ValidateResetPasswordCode(string phone, string code)
        {
            var result = (false, "İşlem Sırasında Hata Oluştu!");
            User user = _repository.FirstOrDefault(x => x.Phone == phone && !x.IsDeleted && x.RefreshToken == code);
            if (user != null)
            {
                user.RefreshToken = Guid.NewGuid().ToString() + "usr" + user.Id;
                _repository.Update(user);
                result.Item1 = true;
                result.Item2 = user.RefreshToken;
            }
            else
                result.Item2 = "Geçersiz Onay Kodu";
            return result;
        }
        public (bool, string) ResetPassword(string code, string password)
        {
            var result = (false, "İşlem Sırasında Hata Oluştu. Şifreniz sıfırlanamadı!");
            User user = _repository.Where(x => x.RefreshToken == code).FirstOrDefault();
            if (user != null)
            {
                user.Password = password;
                user.RefreshToken = "";
                _repository.Update(user);
                result.Item1 = true;
                result.Item2 = "";
            }
            return result;
        }

        public string GetAllUserSmsPush(int type, int year, int month, int day, string message)
        {
            string smsData = $"<?xml version='1.0' encoding='UTF-8'?><mainbody><header><company dil='TR'>Netgsm</company><usercode>8503059424</usercode><password>Md87eDtR8fi78Xr</password><type>1:n</type><msgheader>08503059424</msgheader></header><body><msg><![CDATA[{message}]]></msg>";
            var users = _repository.Where(p => p.TypeId == type && p.IDate >= new DateTime(year, month, day)).ToList();
            if (users != null)
            {
                foreach (User user in users)
                {
                    user.Phone = user.Phone.Replace("+", "");
                    user.Phone = user.Phone.Replace("(", "");
                    user.Phone = user.Phone.Replace(")", "");
                    user.Phone = user.Phone.Replace(" ", "");
                    user.Phone = user.Phone.Replace("-", "");
                    user.Phone = user.Phone.Replace("-", "");
                    smsData += $"<no>{user.Phone.Substring(2, user.Phone.Length - 2)}</no>";
                }
            }
            smsData += "</body></mainbody>";

            string sWebPage = "";
            try
            {
                WebClient wUpload = new WebClient();
                HttpWebRequest request = WebRequest.Create("https://api.netgsm.com.tr/sms/send/xml") as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                Byte[] bPostArray = Encoding.UTF8.GetBytes(smsData);
                Byte[] bResponse = wUpload.UploadData("https://api.netgsm.com.tr/sms/send/xml", "POST", bPostArray);
                Char[] sReturnChars = Encoding.UTF8.GetChars(bResponse);
                sWebPage = new string(sReturnChars);
            }
            catch
            {

            }

            return sWebPage;
        }
    }
}
