namespace EmailSubscriptionManagement.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EmailSubscriber
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmailSubscriber()
        {
            EmailSubscriptions = new HashSet<EmailSubscription>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string EmailId { get; set; }

        [Required]
        [StringLength(100)]
        public string EmailGuid { get; set; }

        [Required]
        [StringLength(500)]
        public string AuthToken { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmailSubscription> EmailSubscriptions { get; set; }
    }
}
