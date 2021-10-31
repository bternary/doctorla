using CoreLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Common
{
    public class BaseController : ControllerBase
    {
        internal bool IsAuthenticated;
        internal int CurrentUserId = 0;
        public BaseController()
        {
            using (var serviceScope = ServiceActivator.GetScope())
            {
                IHttpContextAccessor httpContextAccessor = serviceScope.ServiceProvider.GetRequiredService<IHttpContextAccessor>();
                var currentUser = httpContextAccessor.HttpContext.User;
                IsAuthenticated = currentUser == null ? false : currentUser.Identity.IsAuthenticated;
                if (IsAuthenticated)
                    CurrentUserId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Actor).Value);
            }
        }
    }
}
