namespace EmailSubscriptionManagement.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Notification
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string NotificationGuid { get; set; }

        public int NotificationTypeId { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(4000)]
        public string NotificationText { get; set; }

        public DateTime DateTime { get; set; }

        public bool IsSeen { get; set; }

        public virtual NotificationType NotificationType { get; set; }
    }
}
