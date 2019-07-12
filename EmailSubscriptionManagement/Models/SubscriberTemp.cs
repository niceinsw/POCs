using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmailSubscriptionManagement.Models
{
    public class SubscriberTemp
    {
        public int Id { get; set; }        
        public string EmailGuid { get; set; }
        public string AuthToken { get; set; }

    }
}