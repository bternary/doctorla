using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Data.Domain;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Data.Interfaces.Repositories;

namespace Web.Controllers
{
    [Authorize(Roles = "Doktor,Hemşire")]
    public class DoctorController : BaseController
    {
        public DoctorController(IHttpClientFactory httpClientFactory, IMenuRepository menu) : base(httpClientFactory, menu) { }

        public IActionResult Index(int DepartmentId = 0)
        {
            var _doctors = GetRequest("Doctor");
            var doctors = JsonConvert.DeserializeObject<List<User>>(_doctors);
            return View(doctors);
        }
        public IActionResult Detail(int DoctorId)
        {
            var _doctor = GetRequest("Doctor/" + DoctorId);
            var doctor = JsonConvert.DeserializeObject<User>(_doctor);
            return View(doctor);
        }
    }
}