using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS4200AndrewGolik.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "More About The Author.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Andrew Golik contact page.";

            return View();
        }
    }
}