using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNetCompressedHtml.Filters;

namespace AspNetCompressedHtml.Controllers
{
    public class HomeController : Controller
    {
        [CompressFilter]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}