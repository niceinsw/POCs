using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace IdentityLayered.IdentityModels.Entities
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public ApplicationDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //DO NOT DELETE. THIS IS USED TO ADD MIGRATIONS AND UPDATE DATABASE LOCALLY
                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
                string connectionString = configuration.GetConnectionString("DefaultConnection");

                //DO NOT DELETE, BELOW LINE IS REQUIRED WHEN WORKING WITH AZURE ENVIRONMENT CONFIGURATIONS
                //string connectionString = Environment.GetEnvironmentVariable("ConnectionStrings:DefaultConnection").ToString();
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        //public DbSet<Tester> Testers { get; set; }
    }
}

//Database first scaffolding command
//Scaffold-DbContext 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=IdentityLayered' -Provider Microsoft.EntityFrameworkCore.SqlServer -context IdentityLayeredContext -Project IdentityLayered.DataAccess -OutputDir EntityModels