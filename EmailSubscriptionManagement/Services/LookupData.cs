using EmailSubscriptionManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmailSubscriptionManagement.Services
{
    public static class LookupData
    {
        public static List<EmailType> EmailTypes { get; set; } = GetEmailTypes();
        static LookupData()
        {
            using (var db = new SubscriptionContext())
            {
                EmailTypes = db.EmailTypes.ToList();
            }
        }

        public static List<EmailType> GetEmailTypes()
        {
            using (var db = new SubscriptionContext())
            {
                return EmailTypes = db.EmailTypes.ToList();
            }
        }

        public static EmailType GetEmailType(int id)
        {
            return EmailTypes.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}