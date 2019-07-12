using EmailSubscriptionManagement.Models;
using EmailSubscriptionManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmailSubscriptionManagement.Controllers
{
    public class SettingsController : Controller
    {
        private readonly IEmailSubscriptionService _emailSubscriptionService;
        public SettingsController(IEmailSubscriptionService emailSubscriptionService)
        {
            this._emailSubscriptionService = emailSubscriptionService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Subscribe()
        {
            if (TempData["UpdateSubscriptionError"]!=null)
            {
                ViewBag.UpdateSubscriptionError = true;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Subscribe(string emailId)
        {
            var res = _emailSubscriptionService.AddSubscriber(emailId, Guid.NewGuid().ToString(), Guid.NewGuid().ToString());

            TempData["SubscriberTemp"] = new SubscriberTemp() {
                Id = res.Id,
                EmailGuid = res.EmailGuid,
                AuthToken = res.AuthToken
            };

            return RedirectToAction("Update");
        }

        public ActionResult UpdateLanding(int id, string guid, string token)
        {
            TempData["SubscriberTemp"] = new SubscriberTemp()
            {
                Id = id,
                EmailGuid = guid,
                AuthToken = token
            };

            return RedirectToAction("Update");            
        }


        public ActionResult Update()
        {
            if (TempData["SubscriberTemp"] == null)
            {
                TempData["UpdateSubscriptionError"] = true;
                return RedirectToAction("Subscribe");
            }

            var tempSubscriber = (SubscriberTemp)TempData["SubscriberTemp"];

            var subscriber = _emailSubscriptionService.GetSubscriptions(tempSubscriber.Id, tempSubscriber.EmailGuid, tempSubscriber.AuthToken);

            if (subscriber == null)
            {
                TempData["UpdateSubscriptionError"] = true;
                return RedirectToAction("Subscribe");
            }


            var model = new SubscriptionRequest() {
                Id = subscriber.Id,
                AuthToken = subscriber.AuthToken,
                EmailGuid = subscriber.EmailGuid,
                SelectedIds = subscriber.EmailSubscriptions.Select(x=>x.EmailTypeId).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(SubscriptionRequest model)
        {
            var res = _emailSubscriptionService.AddOrUpdateSubscription(model);

            var ret = new SubscriptionRequest()
            {
                Id = res.Id,
                AuthToken = res.AuthToken,
                EmailGuid = res.EmailGuid,
                SelectedIds = res.EmailSubscriptions.Select(x => x.EmailTypeId).ToList()
            };

            return View(ret);
        }

    }
}