using Api.Common.Helpers;
using API.Common;
using API.Common.Extentions;
using Data.Domain;
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
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [Authorize]
    public class DoctorController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IAppointmentService _appointmentService;
        public DoctorController(IUserService userService, IAppointmentService appointmentService)
        {
            _userService = userService;
            _appointmentService = appointmentService;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult DepartmentsList()
        {
            return Ok(ResponseHelper.GetSuccessResponseMessage(_userService.GetDepartments()));
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult DoctorsList([FromQuery] SortingPagingInfo page, [FromQuery] int departmentId=0, [FromQuery] string doctorname="")
        {
            var items = _userService.GetDoctorList(page, departmentId, doctorname);
            if (items.Items != null)
                foreach (var p in items.Items)
                {
                    p.PhotoUrl = p.PhotoUrl.AddBasePathToImage();
                }
            return Ok(ResponseHelper.GetSuccessResponseMessage(items));
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetDoctorsAvailableInDay([FromQuery] SortingPagingInfo page, [FromQuery] int givenDay = 1)
        {
            var result = new GenericServiceListModel<User>();

            var appointments = _appointmentService.GetDoctorsHavingAppointmentsInGivenDay(givenDay);
            if (appointments == null || !appointments.Any())
            {
                return Ok(ResponseHelper.GetSuccessResponseMessage(result));
            }

            var doctorIds = appointments.Select(x => x.DoctorId).Distinct();
            if (doctorIds == null || !doctorIds.Any())
            {
                return Ok(ResponseHelper.GetSuccessResponseMessage(result));
            }

            result = _userService.GetDoctors(page, doctorIds);
            if (result.Items != null)
            {
                foreach (var p in result.Items)
                {
                    p.PhotoUrl = p.PhotoUrl.AddBasePathToImage();
                }
            }                

            return Ok(ResponseHelper.GetSuccessResponseMessage(result));
        }
    }
}
