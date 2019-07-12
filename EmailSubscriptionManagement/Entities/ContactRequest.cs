namespace EmailSubscriptionManagement.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ContactRequest
    {
        public int Id { get; set; }

        public int SenderUserId { get; set; }

        public int ReceiverUserId { get; set; }

        public DateTime DateTime { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
