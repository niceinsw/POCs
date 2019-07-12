using MiscDemo.ClientServices;
using MiscDemo.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MiscDemo.Controllers
{
    public class LicenseTestController : Controller
    {
        // GET: LicenseTest
        public ActionResult Index()
        {
            UpdateLicenseConfig("UNCL0CC1ECOR98OO", "http://www.site.com", "?testtoken=test", "blocklist123");

            //UpdateLicenseConfigRestSharp("UNCL0CC1ECOR98OO", "http://www.site.com", "?testtoken=test", "blocklist123");


            return View();
        }

        private static void UpdateLicenseConfig(string serial, string endpoint, string sasToken, string blockListVersion)
        {
            var licenseUpdateRequest = new LicenseUpdateRequest()
            {
                Serial = serial,
                Key = "properties.desired.cldflt.configuration.config",
                Data = new
                {
                    resource = endpoint,
                    sas = sasToken,
                    name = blockListVersion
                }
            };

            var headers = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Ocp-Apim-Subscription-Key", "key")
            };
            //https://localhost:44374/
            //var client = new RestClientService().Post<LicenseUpdateRequest>("url",
            //    "/Licence/update", licenseUpdateRequest, headers);

            var client = new RestClientService().Post<LicenseUpdateRequest>("https://localhost:44374/",
                "/Licence/update", licenseUpdateRequest, headers);
        }


        //private static void UpdateLicenseConfigRestSharp(string serial, string endpoint, string sasToken, string blockListVersion)
        //{
        //    var licenseUpdateRequest = new LicenseUpdateRequest()
        //    {
        //        Serial = serial,
        //        Key = "properties.desired.cldflt.configuration.config",
        //        Data = new
        //        {
        //            resource = endpoint,
        //            sas = sasToken,
        //            name = blockListVersion
        //        }
        //    };


        //    var headers = new List<KeyValuePair<string, string>>()
        //    {
        //        new KeyValuePair<string, string>("Ocp-Apim-Subscription-Key", "key")
        //    };
        //    //https://localhost:44374/
        //    //var client = new RestClientService().Post<LicenseUpdateRequest>("url",
        //    //    "/Licence/update", licenseUpdateRequest, headers);

        //    //var client = new RestClientService().Post<LicenseUpdateRequest>("https://localhost:44374/",
        //    //    "/Licence/update", licenseUpdateRequest, headers);

        //    var client = new RestClientService().PostRestSharp<LicenseUpdateRequest>("https://localhost:44374/",
        //            "/Licence/update", licenseUpdateRequest, headers);


        //}



    }

}