using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataAccess.Factories
{
    public class ProjectContextFactory : IDesignTimeDbContextFactory<ProjectDbContext>
    {
        public ProjectDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            var optionBuilder = new DbContextOptionsBuilder<ProjectDbContext>();
            optionBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new ProjectDbContext(optionBuilder.Options);
        }
    }
}
