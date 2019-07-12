using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiscDemo.Controllers
{
    public class FormsController : Controller
    {
        // GET: Forms
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Post(Contact model)
        {
            if (model.CountryId < 10)
            {
                throw new Exception("Id is less than 10");
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }

    public class Contact
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
    }
}