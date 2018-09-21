using SwinSoftwareLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SwinSoftwareLab.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        MyContext context = new MyContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = context.Modules.Add(new Module());

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}