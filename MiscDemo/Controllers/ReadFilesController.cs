using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace MiscDemo.Controllers
{
    public class ReadFilesController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Articles = GetArticleList();
            return View();
        }

        public ActionResult Article(string name)
        {
            string fileName = name.Replace(" - ", "_");

            var path = @"~/Views/Files/Articles/" + fileName + ".cshtml";

            var filePath = HttpContext.Server.MapPath(path);

            if (System.IO.File.Exists(filePath))
            {
                ViewBag.Articles = GetArticleList();

                ViewBag.FileName = $"{fileName}.cshtml";
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        private List<string> GetArticleList()
        {
            var path = @"~/Views/Files/Excerpts/";
            var folderPath = HttpContext.Server.MapPath(path);

            DirectoryInfo dirInfo = new DirectoryInfo(folderPath);

            var files = dirInfo.GetFiles().ToList();

            return files.Select(x => x.Name).ToList();
        }
    }
}