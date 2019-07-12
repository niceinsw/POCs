using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Templating.Models;

namespace Templating.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Employee = new Employee() {
                Company = "Smoothwall",
                Name = "Jani"
            };
            //UpdateView();
            //UpdateWebConfig();
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

        private void UpdateView()
        {
            string text = "This is sample text";
            string newLine = "This is a new line";
            //string path = Server.MapPath("~/Templates/Blue/Files/sample.txt");
            string path = Server.MapPath("~/Templates/Blue/Views/Home/Index.cshtml");
            //string path = Server.MapPath("~/Web.config");


            //System.IO.File.WriteAllText(path, text);

            System.IO.File.AppendAllText(path, newLine + Environment.NewLine);
        }

        private void UpdateWebConfig()
        {
            //var configuration = WebConfigurationManager.OpenWebConfiguration("~");
            //var section = (ConnectionStringsSection)configuration.GetSection("connectionStrings");
            //section.ConnectionStrings["MyConnectionString"].ConnectionString = "Data Source=...";
            //configuration.Save();

            NameValueCollection section = (NameValueCollection)ConfigurationManager.GetSection("appSettings");
            string userName = section["ClientValidationEnabled"];
            string userPassword = section["webpages:Enabled"];


            //var configuration = WebConfigurationManager.OpenWebConfiguration("~");
            //var section = (AppSettingsSection)configuration.GetSection("appSettings");
        }
    }
}