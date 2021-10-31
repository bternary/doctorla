using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace Web.Controllers
{
    public class YardimPaketleriController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Bagis()
        {
            return View();
        }

        // public IActionResult Tanitim() // Tek sayfa, içerikler view içinden düzenlenecek
        // {
        //     return View();
        // }
        // public IActionResult Sponsorlarimiz() // Tek sayfa, içerikler view içinden düzenlenecek
        // {
        //     return View();
        // }
        // public IActionResult OdemeSistemi() // Tek sayfa, içerikler view içinden düzenlenecek
        // {
        //     return View();
        // }
        // public IActionResult DayanismaBelgesi() // Tek sayfa, içerikler view içinden düzenlenecek
        // {
        //     return View();
        // }

    }
}
