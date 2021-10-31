using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using Api.Common.Helpers;
using API.Common.Helpers;
using API.Models;
using CoreLibrary;
using Data.Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Services.Interfaces;
using API.Common.Extentions;
using Domain.Models;
using API.Common;
using System.Net;
using System.IO;
using Data;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;

        public UserController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginReqModel req)
        {
            var userValidation = _userService.ValidateUser(req.UserName, req.Password);
            if (userValidation.Item1)
            {
                var tokenResponce = new TokenModel { tokenExpiryTime = DateTime.Now.AddMinutes(120) };
                var user = _userService.GetItem(userValidation.Item2, "UserType");
                var refreshToken = _userService.GenerateRefreshToken(userValidation.Item2);
                user.RefreshTokenMobile = refreshToken.Token;
                user.RefreshTokenEndTimeMobile = refreshToken.Expiration;
                _userService.Save(user);
                tokenResponce.refreshToken = refreshToken.Token;
                user.Password = "";
                user.PhotoUrl = user.PhotoUrl.AddBasePathToImage();
                tokenResponce.profile = user;
                tokenResponce.accessToken = TokenHelper.GenerateJSONWebToken(user);
                return Ok(ResponseHelper.GetSuccessResponseMessage(tokenResponce));
            }
            else
                return Unauthorized(ResponseHelper.GetResponseMessage(400, "Unauthorized"));
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult RefreshToken(RefreshTokenReqModel req)
        {
            try
            {
                var principal = TokenHelper.GetPrincipalFromExpiredToken(req.AccessToken);
                var userClaim = principal.Claims.Where(p => p.Type == ClaimTypes.Actor).FirstOrDefault();
                if (userClaim != null)
                {
                    var userid = Convert.ToInt32(userClaim.Value);
                    if (_userService.ValidateRefreshToken(userid, req.RefreshToken))
                    {
                        var tokenResponce = new TokenModel { tokenExpiryTime = DateTime.Now.AddMinutes(120) };
                        var user = _userService.GetItem(userid, "UserType");
                        var refreshToken = _userService.GenerateRefreshToken(userid);
                        tokenResponce.refreshToken = refreshToken.Token;
                        user.RefreshTokenMobile = refreshToken.Token;
                        user.RefreshTokenEndTimeMobile = refreshToken.Expiration;
                        _userService.Save(user);
                        user.Password = "";
                        user.PhotoUrl = user.PhotoUrl.AddBasePathToImage();
                        tokenResponce.profile = user;
                        tokenResponce.accessToken = TokenHelper.GenerateJSONWebToken(user);
                        return Ok(ResponseHelper.GetSuccessResponseMessage(tokenResponce));
                    }
                }
                else
                    return Unauthorized(ResponseHelper.GetResponseMessage(400, "Unauthorized"));
            }
            catch (Exception ex)
            {
                LogsServices.Log("Refresh token", ex.Message.ToString(), 3);
            }
            return Unauthorized(ResponseHelper.GetResponseMessage(400, "Unauthorized"));
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(RegisterReqModel req)
        {
            if (req.User == null)
                return BadRequest();
            var validationResult = _userService.ValidateUserData(req.User);
            if (validationResult)
            {
                if (!req.IsUser)
                {
                    if (string.IsNullOrEmpty(req.DoctorTitle))
                        if (req.IsDoctor)
                            ModelState.AddModelError("DoctorTitle", "Lütfen Ünvan Seçiniz!");
                    if (string.IsNullOrEmpty(req.DoctorUniversity))
                        ModelState.AddModelError("DoctorUniversity", "Lütfen Üniversite Seçiniz!");
                    if (req.DoctorDepartment <= 0)
                        ModelState.AddModelError("DoctorDepartment", "Lütfen Uzmanlık Seçiniz!");
                }
                if (ModelState.IsValid)
                {
                    req.User.UserDetail = new UserDetail() { };
                    if (!req.IsUser)
                    {
                        if (req.IsDoctor)
                            req.User.TypeId = (int)UserTypesEnum.Doctor;
                        else
                            req.User.TypeId = (int)UserTypesEnum.Nurse;
                        req.User.DoctorDetail = new DoctorDetail();
                        req.User.DoctorDetail.DoctorUniqueId = _userService.GenerateDoctorRandomCode();
                        req.User.DoctorDetail.UniverstyName = req.DoctorUniversity;
                        
                        req.User.DoctorDetail.Title = String.IsNullOrEmpty(req.DoctorTitle) || req.DoctorTitle == "0" || req.DoctorTitle=="-1" ? "Odyoloji" : req.DoctorTitle; // Test edilmeli
                        List<RelUserDepartment> departmns = new List<RelUserDepartment>() { new RelUserDepartment() { DepartmentId = req.DoctorDepartment, UserId = req.User.Id } };
                        req.User.RelUserDepartments = departmns;
                        req.User.IsActive = false;
                        if (req.User.Gender == "M")
                            req.User.PhotoUrl = "/images/Users/erkekdoktor.png";
                        else if (req.User.Gender == "F")
                            req.User.PhotoUrl = "/images/Users/kadindoktor.png";
                    }
                    else
                    {
                        req.User.IsActive = false;
                        req.User.TypeId = (int)UserTypesEnum.Patient;
                    }
                    List<Address> adress = new List<Address>();
                    adress.Add(new Address() { TypeId = 1, CityId = req.City, CountryId = req.Country, CountyId = req.County, AddressDetail = req.AddressDetail });
                    req.User.Address = adress;
                    req.User.RoleGroupId = (int)RoleGroupsEnum.User;
                    req.User.IDate = DateTime.Now;
                    req.User.LastLoginDate = DateTime.Now;
                    req.User.UUDate = DateTime.Now;
                    req.User.Password = req.Password;
                    if (_userService.Save(req.User))
                    {
                        var tokenResponce = new TokenModel { tokenExpiryTime = DateTime.Now.AddMinutes(120) };
                        var user = _userService.GetItem(req.User.Id, "UserType");
                        var refreshToken = _userService.GenerateRefreshToken(req.User.Id);
                        user.RefreshTokenMobile = refreshToken.Token;
                        user.RefreshTokenEndTimeMobile = refreshToken.Expiration;
                        _userService.Save(req.User);
                        tokenResponce.refreshToken = refreshToken.Token;
                        user.PhotoUrl = user.PhotoUrl.AddBasePathToImage();
                        //user.Password = "";
                        tokenResponce.profile = user;
                        tokenResponce.accessToken = TokenHelper.GenerateJSONWebToken(user); 
                        var code = _userService.GenerateActivationCode(user.Id);
                        user.RefreshToken = code.Item3;
                        user.UUDate = DateTime.Now;
                        _userService.Save(req.User);
                        if (code.Item1) // hep Item1 true : send sms
                        {
                            SmsServices.SendSms(user.Phone, code.Item2);  // Item2 random bir kod
                            if (!string.IsNullOrEmpty(_config["DefaultCampaign"])) // settings ten neden dolu olmasına rağmen girmiyor içine?
                            {
                                string smsStr = _config["DefaultCampaignText"].Replace("XXX", _config["DefaultCampaign"]);
                                SmsServices.SendSms(user.Phone, $"{ smsStr }");
                                //SmsServices.SendSms(user.Phone, $"{_config["DefaultCampaignText"]} {_config["DefaultCampaign"]}");
                            }
                        }
                        return Ok(ResponseHelper.GetSuccessResponseMessage(tokenResponce));
                    }
                    else
                        return Ok(ResponseHelper.GetResponseMessage(500, "Intenal Server Error"));
                }
                else
                    return ValidationProblem(ModelState);
            }
            else
                ModelState.AddModelError("User.Email", "Kullanıcı Eposta veya Telefonu Kayıtlı!");
            return ValidationProblem(ModelState);
        }

        [HttpPost]
        public IActionResult ActivateUser(string activationCode)
        {
            var currentUser = User.Claims.Where(p => p.Type == ClaimTypes.Actor).FirstOrDefault();
            var userid = Convert.ToInt32(currentUser.Value);
            var result = _userService.ActivateUser(userid, activationCode);
            if (result)
                return Ok(ResponseHelper.GetSuccessResponseMessage());
            else
                return Ok(ResponseHelper.GetResponseMessage(403, "Aktivaston Başarısız!"));
        }
        [HttpGet]
        public IActionResult GetUser(int Id, [FromQuery] string includes = "")
        {
            var user = _userService.GetItem(Id, includes);
            user.PhotoUrl = user.PhotoUrl.AddBasePathToImage();
            return Ok(ResponseHelper.GetSuccessResponseMessage(user));
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult GetAllUserSmsPush(int type, int year, int month, int day, string message)
        {
            return Ok(_userService.GetAllUserSmsPush(type, year, month, day, message));
        }


        [HttpPut]
        public ActionResult ChangePassword(string oldPassword, string newPassword)
        {
            var result = _userService.ChangePassword(CurrentUserId, oldPassword, newPassword);
            if (result)
                return Ok(ResponseHelper.GetSuccessResponseMessage());
            else
                return Ok(ResponseHelper.GetResponseMessage(403, "İşlem Başarısız!"));
        }
        [HttpPut]
        public ActionResult UpdateUser(UserUpdateReqModel user)
        {
            user.User.Id = CurrentUserId;
            var validationResult = _userService.ValidateUserData(user.User);
            if (validationResult)
            {
                var result = _userService.UpdateUser(CurrentUserId, user.User, user.UserImage);
                if (result)
                    return Ok(ResponseHelper.GetSuccessResponseMessage());
                else
                    return Ok(ResponseHelper.GetResponseMessage(403, "İşlem Başarısız!"));
            }
            else
                ModelState.AddModelError("User.Email", "Kullanıcı Eposta veya Telefonu Kayıtlı!");
            return ValidationProblem(ModelState);
        }
        [HttpPut]
        public ActionResult UpdateDocotorDepartmentPrice(int relUserDepartmentId, int price, int sessionTime)
        {
            var result = _userService.UpdateDocotorDepartmentPrice(relUserDepartmentId, price, sessionTime);
            if (result)
                return Ok(ResponseHelper.GetSuccessResponseMessage());
            else
                return Ok(ResponseHelper.GetResponseMessage(403, "İşlem Başarısız!"));
        }
        [HttpGet]
        public ActionResult GenerateActivationCode()
        {
            var code = _userService.GenerateActivationCode(CurrentUserId);
            var user = _userService.GetItem(CurrentUserId);
            if (code.Item1)
            {
                SmsServices.SendSms(user.Phone, code.Item2);
                return Ok(ResponseHelper.GetSuccessResponseMessage());
            }
            else
                return Ok(ResponseHelper.GetResponseMessage(403, "İşlem Başarısız!"));
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult GenerateResetPasswordCode(string phone)
        {
            var result = _userService.GenerateResetPasswordCode(phone);
            if (result.Item1)
            {
                SmsServices.SendSms(result.Item3, result.Item4);
                return Ok(ResponseHelper.GetSuccessResponseMessage(result.Item2));
            }
            else
                return Ok(ResponseHelper.GetResponseMessage(403, result.Item2));
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult ValidateResetPasswordCode(string phone, string code)
        {
            var result = _userService.ValidateResetPasswordCode(phone, code);
            if (result.Item1)
                return Ok(ResponseHelper.GetSuccessResponseMessage(result.Item2));
            else
                return Ok(ResponseHelper.GetResponseMessage(403, result.Item2));
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult ResetPassword(string code, string password)
        {
            var result = _userService.ResetPassword(code, password);
            if (result.Item1)
                return Ok(ResponseHelper.GetSuccessResponseMessage());
            else
                return Ok(ResponseHelper.GetResponseMessage(403, result.Item2));
        }
    }
}
