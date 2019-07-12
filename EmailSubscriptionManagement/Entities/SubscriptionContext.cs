namespace EmailSubscriptionManagement.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SubscriptionContext : DbContext
    {
        public SubscriptionContext()
            : base("name=SubscriptionContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<ContactRequest> ContactRequests { get; set; }
        public virtual DbSet<EmailSubscriber> EmailSubscribers { get; set; }
        public virtual DbSet<EmailSubscription> EmailSubscriptions { get; set; }
        public virtual DbSet<EmailType> EmailTypes { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<NotificationType> NotificationTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Visitor> Visitors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailSubscriber>()
                .HasMany(e => e.EmailSubscriptions)
                .WithRequired(e => e.EmailSubscriber)
                .HasForeignKey(e => e.SubscriberId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EmailType>()
                .HasMany(e => e.EmailSubscriptions)
                .WithRequired(e => e.EmailType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NotificationType>()
                .HasMany(e => e.Notifications)
                .WithRequired(e => e.NotificationType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ContactRequests)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.ReceiverUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ContactRequests1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.SenderUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Visitors)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.VisitedUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Visitors1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.VisitorUserId)
                .WillCascadeOnDelete(false);
        }
    }
}
