using Api.Common.Helpers;
using API.Common;
using API.Models;
using Data.Domain;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [Authorize]
    public class DailyCheckController : BaseController
    {
        private readonly IDailyCheckService _dailyCheckAlerts;
        private readonly IConfiguration _config;
        public DailyCheckController(IDailyCheckService dailyCheckAlerts, IConfiguration config)
        {
            _dailyCheckAlerts = dailyCheckAlerts;
            _config = config;
        }

        [HttpGet]
        public ActionResult GetAlerts(int dailyCheckId, [FromQuery] SortingPagingInfo page)
        {
            var result = _dailyCheckAlerts.GetAlerts(CurrentUserId, dailyCheckId, page);
            return Ok(ResponseHelper.GetSuccessResponseMessage(result));
        }
        [HttpPut]
        public ActionResult UpdateAlert(DailyCheckAlerts alert)
        {
            var result = _dailyCheckAlerts.Save(alert);
            if (result)
                return Ok(ResponseHelper.GetSuccessResponseMessage());
            else
                return Ok(ResponseHelper.GetResponseMessage(403, "İşlem Başarısız!"));
        }
        [HttpPost]
        public ActionResult AddAlert(DailyCheckAlerts alert)
        {
            alert.Id = 0;
            var result = _dailyCheckAlerts.Save(alert);
            if (result)
                return Ok(ResponseHelper.GetSuccessResponseMessage());
            else
                return Ok(ResponseHelper.GetResponseMessage(403, "İşlem Başarısız!"));
        }
        [HttpDelete]
        public ActionResult DeleteAlert(int alertId)
        {
            var result = _dailyCheckAlerts.Delete(alertId);
            if (result)
                return Ok(ResponseHelper.GetSuccessResponseMessage());
            else
                return Ok(ResponseHelper.GetResponseMessage(403, "İşlem Başarısız!"));
        }
        [HttpPost]
        public ActionResult CreateDailyCheckDetail(DailyCheckDetailReqModel data)
        {
            var result = _dailyCheckAlerts.CreateDailyCheckDetail(CurrentUserId, data.DailyCheckId, data.Values, data.Files);
            if (result.Item1)
                return Ok(ResponseHelper.GetSuccessResponseMessage(result.Item2));
            else
                return Ok(ResponseHelper.GetResponseMessage(403, result.Item2));
        }
        [HttpGet]
        public ActionResult GetDailyCheckDetails(int dailyCheckId, string filter = "")
        {
            var result = _dailyCheckAlerts.GetDailyCheckDetails(CurrentUserId, dailyCheckId, filter);
            return Ok(ResponseHelper.GetSuccessResponseMessage(result));
        }
        [HttpGet]
        public ActionResult GetChatList(int dailyCheckId)
        {
            var result = _dailyCheckAlerts.GetChatList(dailyCheckId);
            result = result.Select(p => { p.Message = p.IsFile ? $"{_config["BaseImgPath"]}{_config["BaseFileSharePath"]}/DailyCheckFiles/{p.Message}" : p.Message; return p; }).ToList();
            return Ok(ResponseHelper.GetSuccessResponseMessage(result));
        }
        [HttpPost]
        public ActionResult SendChat(int dailyCheckId, string message, FileReqModel file, bool isDoctor = false)
        {
            var result = _dailyCheckAlerts.SendChat(dailyCheckId, message, file, isDoctor);
            if (result)
                return Ok(ResponseHelper.GetSuccessResponseMessage());
            else
                return Ok(ResponseHelper.GetResponseMessage(403, "Sistemsel bir hata oluştu"));
        }
        [HttpGet]
        public ActionResult GetUserDailyChecks([FromQuery] SortingPagingInfo sorting)
        {
            var result = _dailyCheckAlerts.GetUserDailyChecks(CurrentUserId, sorting);
            return Ok(ResponseHelper.GetSuccessResponseMessage(result));
        }
    }
}
