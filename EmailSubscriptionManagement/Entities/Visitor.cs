namespace EmailSubscriptionManagement.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Visitor
    {
        public int Id { get; set; }

        public int VisitorUserId { get; set; }

        public int VisitedUserId { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
