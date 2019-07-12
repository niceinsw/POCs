using DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ReportingContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(s => s.Id);
            modelBuilder.Entity<User>().Property(s => s.Id);
            modelBuilder.Entity<User>().Property(s => s.UserName);
            modelBuilder.Entity<User>().Property(s => s.DateCreated);
        }
    }
}
