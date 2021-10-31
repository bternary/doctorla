using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Data.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly IMenuRepository menu;
        public BaseController(IHttpClientFactory httpClientFactory, IMenuRepository menu)
        {
            _httpClientFactory = httpClientFactory;
            this.menu = menu;
        }
        public List<Data.Domain.Menu> HeaderMenu
        {
            get
            {
                return menu.Search(0, 0);
            }
        }

        private async Task<string> _getRequest(string uri)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("API");
                string result = await client.GetStringAsync(uri);
                return result;
            }
            catch (System.Exception ex)
            {
                var data = ex;
                return ex.Message;
            }
        }

        public string GetRequest(string uri)
        {
            return _getRequest(uri).Result;
        }
        public JsonResult GetDepartments()
        {
            var data = GetRequest("Department");
            return new JsonResult(data);
        }

        public JsonResult GetDoctors(int DepartmentId = 0)
        {
            var data = GetRequest("Doctor");
            return new JsonResult(data);
        }


    }
}