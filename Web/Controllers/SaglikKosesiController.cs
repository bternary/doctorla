using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace Web.Controllers
{
    public class SaglikKosesiController : Controller
    {
        
        public ActionResult TıbbiKategoriler() 
        {
            return View();
        }
        public ActionResult Makaleler() 
        {
            return View();
        }
        public ActionResult SosyalMedya() 
        {
            return View();
        }
        public ActionResult MakaleYorumlari() 
        {
            return View();
        }

    }
}
