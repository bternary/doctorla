using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Domain;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using PagedList.Core;
using CoreLibrary.MethodExtensions;
using Microsoft.Extensions.Configuration;
using Domain.Interfaces.Base;

namespace Web.Controllers
{
    public class AcilDurumController : Controller
    {
        private readonly IRepository<Blog> _postRepostroy;
        private readonly IConfiguration _configuration;
        public AcilDurumController(IRepository<Blog> postRepostroy,IConfiguration configuration)
        {
            _postRepostroy = postRepostroy;
            _configuration = configuration;
        }

        public IActionResult PaketDetay(string Durum)
        {
            return View();
        }
        public IActionResult Blog(string postCategory, string postTag)
        {
            var postsList = _postRepostroy.Where(x => x.IsActive).OrderByDescending(x => x.IDate).ToList();
            List<Blog> posts = new List<Blog>();
            if (postCategory != null)
            {
                posts.AddRange(postsList.Where(post => post.Category.Split(",").Contains(postCategory) == true).ToList());
            }
            else if (postTag != null)
            {
                posts.AddRange(postsList.Where(post => post.Tags.Split(",").Contains(postTag) == true).ToList());
            }
            else
                posts = postsList;
            return View(posts);
        }

        public IActionResult Post(string seoUrl)
        {
            Blog post = _postRepostroy.FirstOrDefault(x => x.SeoUrl == seoUrl);
            return View(post);
        }
    }
}