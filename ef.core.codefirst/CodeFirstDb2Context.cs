using ef.core.codefirst.Configurations;
using ef.core.codefirst.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace ef.core.codefirst
{
    public class CodeFirstDb2Context : DbContext
    {
        public CodeFirstDb2Context(DbContextOptions<CodeFirstDb2Context> options) :base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=SWLT2214;Database=CodeFirstDb;Trusted_Connection=True;ConnectRetryCount=0;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
        }

        public virtual DbSet<User> Users { get; set; }

    }
}
