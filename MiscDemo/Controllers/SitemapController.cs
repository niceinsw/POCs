using MiscDemo.Models.SitemapModels;
using SimpleMvcSitemap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MiscDemo.Controllers
{
    public class SitemapController : Controller
    {
        // GET: Sitemap
        public ActionResult Index()
        {
            List<SimpleMvcSitemap.SitemapNode> nodes = new List<SimpleMvcSitemap.SitemapNode>()
            {
                new SimpleMvcSitemap.SitemapNode(Url.Action("Index", "Home")),
                new SimpleMvcSitemap.SitemapNode(Url.Action("About", "Home")),
                new SimpleMvcSitemap.SitemapNode(Url.Action("Contact", "Home")),
                new SimpleMvcSitemap.SitemapNode("http://www.google.com")
            };

            return new SimpleMvcSitemap.SitemapProvider().CreateSitemap(new SitemapModel(nodes));
        }

        public ContentResult Custom()
        {
            XNamespace ns = "http://www.sitemaps.org/schemas/sitemap/0.9";

            var items = GetArticleUrls();
            var sitemap = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement(ns + "urlset",
                    from i in items
                    select
                    //Add ns to every element.
                    new XElement(ns + "url",
                      new XElement(ns + "loc", string.Format(i.Url)),
                          new XElement(ns + "lastmod", String.Format("{0:yyyy-MM-dd}", DateTime.UtcNow)),
                      new XElement(ns + "changefreq", "monthly"),
                      new XElement(ns + "priority", "0.5")
                      )
                    )
                  );

            //return Content(sitemap.ToString(), "text/xml");

            using (StreamWriter sw = new StreamWriter(Server.MapPath("~/sitemap.xml"), false))
            {
                sw.WriteLine(sitemap);
            }

            var xmlString = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            xmlString = xmlString + sitemap.ToString();
            return Content(xmlString, "text/xml");


        }

        private List<ArticleSummary> GetArticleUrls()
        {
            List<ArticleSummary> articleSummaries = new List<ArticleSummary>()
            {
                new ArticleSummary(){Url = Url.Action("Index", "Home")},
                new ArticleSummary(){Url = Url.Action("About", "Home")},
                new ArticleSummary(){Url = Url.Action("Contact", "Home")},
                new ArticleSummary(){Url = "http://www.google.com"},
            };

            return articleSummaries;
        }
    }
}