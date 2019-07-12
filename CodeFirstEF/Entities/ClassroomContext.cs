using CodeFirstEF.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstEF.Entities
{
    public class ClassroomContext : DbContext
    {
        //public ClassroomContext():base()
        //{

        //}
        //public ClassroomContext(DbContextOptions<ClassroomContext> options) : base(options)
        //{

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=SWLT2214;Database=ClassroomCodeFirst2;Trusted_Connection=True;ConnectRetryCount=0";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SchoolConfiguration());
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<School> Schools { get; set; }



        public DbSet<User> Users { get; set; }
        public DbSet<Block> Blocks { get; set; }



    }
}
