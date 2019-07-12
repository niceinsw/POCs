using System.Web.Mvc;

namespace DemoFrontend.Controllers
{
    public class HomeController : Controller
    {
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

        [HttpPost]
        public ActionResult AddUser(string userName, string password)
        {
            var request = HttpContext.Request;

            var apiVal = request.Headers["ApiKey"].ToString();
            return View("Index");
        }
    }
}