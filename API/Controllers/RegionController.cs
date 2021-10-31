using Api.Common.Helpers;
using API.Common;
using Data.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [Authorize]
    public class RegionsController : BaseController
    {
        IRegionService _regionService;
        public RegionsController(IRegionService regionService)
        {
            _regionService = regionService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult CountriesList()
        {
            IEnumerable<Country> list = _regionService.GetAll();
            return Ok(ResponseHelper.GetSuccessResponseMessage(list));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult CitiesList(int countryId)
        {
            IEnumerable<City> list = _regionService.GetCities(countryId);
            return Ok(ResponseHelper.GetSuccessResponseMessage(list));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult CountiesList(int cityId)
        {
            IEnumerable<County> list = _regionService.GetCounties(cityId);
            return Ok(ResponseHelper.GetSuccessResponseMessage(list));
        }
    }
}
