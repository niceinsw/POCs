using MiscDemo.Models.HandlebarModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiscDemo.Controllers
{
    public class HandlebarController : Controller
    {
        // GET: Handlebar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Address()
        {
            return View();
        }
        public ActionResult GetContact()
        {
            var address = new HBAddress() {
                Id = new Random().Next(1,1000),
                city = "Leeds",
                number = "22",
                street = "Pasture Mound"
            };

            //return Json(JsonConvert.SerializeObject(address), JsonRequestBehavior.AllowGet);
            return Json(address, JsonRequestBehavior.AllowGet);
        }

    }
}