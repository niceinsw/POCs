using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MiscDemo.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            await CheckResponse();
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

        public JavaScriptResult JSResult()
        {
            string strJs = @"console.log('hello from js result')";
            return JavaScript(strJs);
        }

        public ActionResult JsonDates()
        {
            //gmt utc to local time
            //TimeZone.CurrentTimeZone.ToLocalTime(date);
            //https://stackoverflow.com/questions/179940/convert-utc-gmt-time-to-local-time

            var data = new
            {
                name = "Muhammad",
                city = "Leeds",
                dateCreated = DateTime.Now
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        private async Task CheckResponse()
        {
            var Url = "https://www.google.com/";
            Uri urlCheck = new Uri(Url);
            var client = new HttpClient();
            var res = client.GetAsync(urlCheck).Result;
            var statusCode = res.StatusCode;
        }
    }
}