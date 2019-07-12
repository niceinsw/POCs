using EmailSubscriptionManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EmailSubscriptionManagement.Models;

namespace EmailSubscriptionManagement.Services
{
    public interface IEmailSubscriptionService
    {
        EmailSubscriber AddSubscriber(string emailId, string emailGuid, string token);
        List<EmailType> GetEmailTypes();
        EmailSubscriber GetSubscriptions(int id, string emailGuid, string token);
        EmailSubscriber AddOrUpdateSubscription(SubscriptionRequest model);
        EmailSubscriber UnSubscribeToAll(int id, string emailGuid, string token);


    }
    public class EmailSubscriptionService : IEmailSubscriptionService
    {

        public List<EmailType> GetEmailTypes()
        {
            return LookupData.EmailTypes;
        }

        public EmailSubscriber GetSubscriptions(int id, string emailGuid, string token)
        {
            using (var db = new SubscriptionContext())
            {
                return db.EmailSubscribers
                    .Include(e => e.EmailSubscriptions)
                    .Where(x => x.Id == id
                        && x.EmailGuid.Equals(emailGuid, StringComparison.OrdinalIgnoreCase)
                        && x.AuthToken.Equals(token, StringComparison.Ordinal))
                    .FirstOrDefault();
            }
        }

        //public EmailSubscriber AddOrUpdateSubscription(int id, string emailId, string emailGuid, string token, List<int> newSubIds, string description)
        public EmailSubscriber AddOrUpdateSubscription(SubscriptionRequest model)
        {
            using (var db = new SubscriptionContext())
            {
                var subscriber = db.EmailSubscribers
                    .Include(e => e.EmailSubscriptions)
                    .Where(x => x.Id == model.Id
                        && x.EmailGuid.Equals(model.EmailGuid, StringComparison.OrdinalIgnoreCase)
                        && x.AuthToken.Equals(model.AuthToken, StringComparison.Ordinal))
                    .FirstOrDefault();

                if (subscriber == null)
                    return null;

                var dbSubscriptions = subscriber.EmailSubscriptions.ToList();

                var dbIds = db.EmailSubscriptions.Where(x => x.SubscriberId == subscriber.Id).Select(s => s.EmailTypeId).ToList();

                //check saved in new
                foreach (var newId in model.SelectedIds)
                {
                    if (dbIds.Contains(newId) == false)
                    {
                        db.EmailSubscriptions.Add(new EmailSubscription()
                        {
                            IsSubscribed = true,
                            Details = "Test details",
                            EmailTypeId = newId,
                            SubscriberId = model.Id,
                            SubscriptionDate = DateTime.Now
                        });
                        db.SaveChanges();
                    }
                }

                //check new in saved
                foreach (var dbId in dbIds)
                {
                    if (model.SelectedIds.Contains(dbId) == false)
                    {
                        var dbSub = dbSubscriptions.Where(x => x.EmailTypeId == dbId).FirstOrDefault();
                        db.EmailSubscriptions.Remove(dbSub);
                        db.SaveChanges();
                    }
                }


                return db.EmailSubscribers
                    .Include(e => e.EmailSubscriptions)
                    .Where(x => x.Id == model.Id
                        && x.EmailGuid.Equals(model.EmailGuid, StringComparison.OrdinalIgnoreCase)
                        && x.AuthToken.Equals(model.AuthToken, StringComparison.Ordinal))
                    .FirstOrDefault();
            }
        }


        public EmailSubscriber AddSubscriber(string emailId, string emailGuid, string token)
        {
            using (var db = new SubscriptionContext())
            {
                var dbSubscriber = db.EmailSubscribers
                    .Include(s => s.EmailSubscriptions)
                    .Where(x => x.EmailId.Equals(emailId, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                if (dbSubscriber != null)                
                    return dbSubscriber;
                
                var subscriber = new EmailSubscriber()
                {
                    AuthToken = token,
                    EmailGuid = emailGuid,
                    EmailId = emailId
                };

                subscriber.EmailSubscriptions = new List<EmailSubscription>();

                foreach (var type in GetEmailTypes())
                {
                    subscriber.EmailSubscriptions.Add(new EmailSubscription()
                    {
                        EmailTypeId = type.Id,
                        IsSubscribed = true,
                        SubscriptionDate = DateTime.Now,
                        Details = "Initial subscription"
                    });
                }

                db.EmailSubscribers.Add(subscriber);
                db.SaveChanges();
                return subscriber;
            }
        }
        public EmailSubscriber UnSubscribeToAll(int id, string emailGuid, string token)
        {
            using (var db = new SubscriptionContext())
            {
                var subscriber = db.EmailSubscribers.Where(x => x.Id == id).FirstOrDefault();
                if (subscriber == null)
                    return null;

                db.EmailSubscribers.Remove(subscriber);
                db.SaveChanges();

                return db.EmailSubscribers
                    .Include(e => e.EmailSubscriptions)
                    .Where(x => x.Id == id
                        && x.EmailGuid.Equals(emailGuid, StringComparison.OrdinalIgnoreCase)
                        && x.AuthToken.Equals(token, StringComparison.Ordinal))
                    .FirstOrDefault();
            }
        }
    }
}