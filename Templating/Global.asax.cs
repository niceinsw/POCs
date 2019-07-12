using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Templating.Models;

namespace Templating
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //ViewEngines.Engines.Clear();
            var viewLocationFormats = new string[]
                {
                    "~/Templates/"+SiteSettings.Theme+"/Views/{1}/{0}.cshtml",
                    "~/Templates/"+SiteSettings.Theme+"/Views/{1}/{0}.vbhtml",
                    "~/Templates/"+SiteSettings.Theme+"/Views/Shared/{0}.cshtml",
                    "~/Templates/"+SiteSettings.Theme+"/Views/Shared/{0}.vbhtml"
                };

            // Allow looking up views in ~/Features/ directory
            var razorEngine = ViewEngines.Engines.OfType<RazorViewEngine>().First();
            razorEngine.ViewLocationFormats = viewLocationFormats;
            razorEngine.PartialViewLocationFormats = viewLocationFormats;

            // also: razorEngine.PartialViewLocationFormats if required


        }


    }
}
