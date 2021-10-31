using Api.Common.Helpers;
using API.Common;
using API.Common.Interfaces;
using CoreLibrary;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AppointmentController : BaseController
    {
        private readonly IPaymentHelper _paymentHelper;
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IPaymentHelper paymentHelper, IAppointmentService appointmentService)
        {
            _paymentHelper = paymentHelper;
            _appointmentService = appointmentService;
        }
        [HttpGet]
        public ActionResult GetUserAppointments([FromQuery] SortingPagingInfo page)
        {
            var result = _appointmentService.GetAppointments(CurrentUserId, false, page);
            return Ok(ResponseHelper.GetSuccessResponseMessage(result));
        }
        [HttpGet]
        public ActionResult GetDoctorAppointments([FromQuery] SortingPagingInfo page)
        {
            var result = _appointmentService.GetAppointments(CurrentUserId, true, page);
            return Ok(ResponseHelper.GetSuccessResponseMessage(result));
        }
        [HttpGet]
        public ActionResult GetAppointmentDetails(int appointmentId)
        {
            var result = _appointmentService.GetDetail(appointmentId);
            return Ok(ResponseHelper.GetSuccessResponseMessage(result));
        }
        [HttpDelete]
        public ActionResult DeleteAppointment(int appointmentId, string reason)
        {
            var result = _appointmentService.DeleteAppointment(CurrentUserId, appointmentId, reason);
            if (result.Item1)
                return Ok(ResponseHelper.GetSuccessResponseMessage());
            else
                return Ok(ResponseHelper.GetResponseMessage(403, result.Item2));
        }
        [HttpDelete]
        public ActionResult DeleteFile(int fileId, string reason)
        {
            var result = _appointmentService.DeleteFile(fileId);
            if (result)
                return Ok(ResponseHelper.GetSuccessResponseMessage());
            else
                return Ok(ResponseHelper.GetResponseMessage(403, "İşlem Başarısız!"));
        }
        [HttpPut]
        public ActionResult UpdateApointmentDetail(int appointmentId, List<FileReqModel> files, string appointmentNote, string appointmentDoctorNote, bool isDoctor = false)
        {
            var result = _appointmentService.UpdateApointmentDetail(CurrentUserId, appointmentId, files, appointmentNote, appointmentDoctorNote, isDoctor);
            if (result.Item1)
                return Ok(ResponseHelper.GetSuccessResponseMessage());
            else
                return Ok(ResponseHelper.GetResponseMessage(403, result.Item2));
        }
        [HttpPut]
        public ActionResult AppointmentSetPrivateStatus(int appointmentId, bool isPrivate)
        {
            var result = _appointmentService.AppointmentSetPrivateStatus(appointmentId, isPrivate);
            if (result)
                return Ok(ResponseHelper.GetSuccessResponseMessage());
            else
                return Ok(ResponseHelper.GetResponseMessage(403, "İşlem Başarısız!"));
        }
        [HttpGet]
        public ActionResult GetDoctorAvailableAppointments(int doctorId, int departmentId, DateTime appointmentDate)
        {
            var result = _appointmentService.GetDoctorAvailableAppointments(doctorId, departmentId, appointmentDate);
            return Ok(ResponseHelper.GetSuccessResponseMessage(result));
        }
        [HttpPost]
        public ActionResult RequestAppointment(int doctorId, int departmentId, DateTime reqDate, string note, short requestType)
        {
            var result = _appointmentService.RequestAppointment(CurrentUserId, doctorId, departmentId, reqDate, note, requestType);
            if (result.Item1)
            {
                SmsServices.SendSms(result.Item3, "Randevu Talebi Aldınız. Lütfen Yönetim Panelinizi Kontrol Edin.. Doctorla ");

                // TODO : Dilber
                return Ok(ResponseHelper.GetSuccessResponseMessage());
            }
            else
                return Ok(ResponseHelper.GetResponseMessage(403, result.Item2));
        }
        [HttpGet]
        public ActionResult GetAppointmentRequests([FromQuery] SortingPagingInfo sorting, bool isDoctor = false)
        {
            var result = _appointmentService.GetAppointmentRequests(CurrentUserId, sorting, isDoctor);
            return Ok(ResponseHelper.GetSuccessResponseMessage(result));
        }
        [HttpPost]
        public ActionResult CreateSession(int departmentId, DateTime startdate, DateTime? multienddate, int Price = 0, int sessionTime = 0, bool isMultiAppointment = false, int breakCount = 0, bool isPreview = false)
        {
            var result = _appointmentService.CreateSession(CurrentUserId, departmentId, startdate, multienddate, Price, sessionTime, isMultiAppointment, breakCount, isPreview);
            if (result.Item1)
                return Ok(ResponseHelper.GetSuccessResponseMessage());
            else
                return Ok(ResponseHelper.GetResponseMessage(403, result.Item2));
        }
        [HttpPost]
        public ActionResult SetAppointmentRequestStatus(int notifyWarningId, bool isApprove)
        {
            var result = _appointmentService.SetAppointmentRequestStatus(CurrentUserId, notifyWarningId, isApprove);
            if (result.Item1)
            {
                string message = "Randevu Talebiniz Olumlu Sonuçlandı. Hemen Randevunuzu Alabilirsiniz.. Doctorla ";
                if (!isApprove)
                    message = "Randevu Talebiniz Olumsuz Sonuçlandı. Diğer Doktorlarımızdan Randevu Alabilir veya Talep Açabilirsiniz.. Doctorla ";
                SmsServices.SendSms(result.Item3, message);
                return Ok(ResponseHelper.GetSuccessResponseMessage(result.Item2));
            }
            else
                return Ok(ResponseHelper.GetResponseMessage(403, result.Item2));
        }
        [HttpGet]
        public ActionResult ValidateCampaignCode(string code, int appointmentId)
        {
            var result = _appointmentService.ValidateCampaignCode(CurrentUserId, code, appointmentId);
            if (result.Item1)
                return Ok(ResponseHelper.GetSuccessResponseMessage(result.Item2));
            else
                return Ok(ResponseHelper.GetResponseMessage(403, result.Item2));
        }
        [HttpPost]
        public ActionResult BuyAppointment(int appointmentId, string campaigneCode = "")
        {
            var baseResult = _appointmentService.BuyAppointment(CurrentUserId, appointmentId, campaigneCode);
            BuyResult result = baseResult;

          //  string myIp = "24.133.136.96";

            if (baseResult.Status == BuyStatus.PaymentRedirect)
            {
                var remoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString() != "::1" ? HttpContext.Connection.RemoteIpAddress.Address.ToString() : "127.0.0.1";
                result = _paymentHelper.BuyAppointment(baseResult, remoteIpAddress);
            }
            return Ok(ResponseHelper.GetSuccessResponseMessage(result));
        }


        

    }
}
