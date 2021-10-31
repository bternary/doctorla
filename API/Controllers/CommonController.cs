using Api.Common.Helpers;
using API.Common;
using API.Common.Extentions;
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
    public class CommonController : BaseController
    {
        private readonly ISliderService _sliderService;
        private readonly IBlogService _blogService;
        public CommonController(ISliderService sliderService, IBlogService blogService)
        {
            _sliderService = sliderService;
            _blogService = blogService;
        }

        [HttpGet]
        public IActionResult SliderList()
        {
            var list = _sliderService.GetMobileSliders().Select(p => { p.Photo = p.Photo.AddBasePathToImage(); return p; }).ToList();
            return Ok(ResponseHelper.GetSuccessResponseMessage(list));
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult BlogList(string postCategory, string postTag, [FromQuery] SortingPagingInfo page)
        {
            var list = _blogService.GetBlogs(postCategory, postTag, page);
            if (list.Items != null)
                foreach (var p in list.Items)
                {
                    p.CoverPhotoMobile = p.CoverPhotoMobile != null ? p.CoverPhotoMobile.AddBasePathToImage() : "";
                    p.Description = p.Description != null ? p.Description.PrepareHtmlToMobile() : "";
                    p.ThumbnailPhoto = p.ThumbnailPhoto != null ? p.ThumbnailPhoto.AddBasePathToImage() : "";
                }
            return Ok(ResponseHelper.GetSuccessResponseMessage(list));
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetTagsInBlogs()
        {
            var list = _blogService.GetTagsInBlogs();
            return Ok(ResponseHelper.GetSuccessResponseMessage(list));
        }
    }
}
