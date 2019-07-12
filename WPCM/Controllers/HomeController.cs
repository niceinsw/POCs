using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WPCM.Services;

namespace WPCM.Controllers
{
    public class HomeController : Controller
    {
        private WPService _wpService { get; set; }
        public HomeController()
        {
            _wpService = new WPService();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SinglePost(int id)
        {
            var data = _wpService.GetPost(id);
            return View(data);
        }

        public ActionResult Categories()
        {
            var categories = _wpService.GetAllCategories();
            return View(categories);
        }

        public ActionResult CatPosts(int id)
        {
            var categoryPosts = _wpService.GetCategoryPosts(id);
            return View(categoryPosts);
        }
    }
}