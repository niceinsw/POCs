namespace EmailSubscriptionManagement.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EmailSubscription
    {
        public int Id { get; set; }

        public int SubscriberId { get; set; }

        public int EmailTypeId { get; set; }

        public bool IsSubscribed { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime SubscriptionDate { get; set; }

        [StringLength(4000)]
        public string Details { get; set; }

        public virtual EmailSubscriber EmailSubscriber { get; set; }

        public virtual EmailType EmailType { get; set; }
    }
}
