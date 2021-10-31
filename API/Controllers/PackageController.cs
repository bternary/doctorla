using Api.Common.Helpers;
using API.Common;
using API.Common.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class PackageController : BaseController
    {
        private readonly IPackageService _packageService;
        private readonly IPaymentHelper _paymentHelper;
        public PackageController(IPackageService packageService, IPaymentHelper paymentHelper)
        {
            _packageService = packageService;
            _paymentHelper = paymentHelper;
        }
        [HttpGet]
        public ActionResult GetPackages(bool onlyFree)
        {
            var result = _packageService.GetPackages(onlyFree);
            return Ok(ResponseHelper.GetSuccessResponseMessage(result));
        }

        [HttpPost]
        public ActionResult BuyPackage(int packageId, int offerId, int doctorId)
        {
            var baseResult = _packageService.BuyPackage(CurrentUserId, packageId, offerId, doctorId);
            BuyResult result = baseResult;
            if (baseResult.Status == BuyStatus.PaymentRedirect)
            {
                var remoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString() != "::1" ? HttpContext.Connection.RemoteIpAddress.Address.ToString() : "127.0.0.1";
                result = _paymentHelper.BuyPackage(baseResult, remoteIpAddress);
            }
            return Ok(ResponseHelper.GetSuccessResponseMessage(result));
        }

        [HttpPost]
        public ActionResult ValidateCampaignCode(string code)
        {
            var result = _packageService.ValidateCampaignCode(CurrentUserId, code);
            if (result.Item1)
                return Ok(ResponseHelper.GetSuccessResponseMessage());
            else
                return Ok(ResponseHelper.GetResponseMessage(403, result.Item2));
        }

    }
}
