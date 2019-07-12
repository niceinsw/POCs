using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmailSubscriptionManagement.Models
{
    public class SubscriptionRequest
    {
        public int Id { get; set; }
        //public int EmailId { get; set; }        
        public string EmailGuid { get; set; }
        public string AuthToken { get; set; }
        public List<int> SelectedIds { get; set; }

    }
}