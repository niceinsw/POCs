using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreConfig.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CoreConfig
{
    public static class StaticConfig
    {
        public static string TestConfig { get; set; }
    }
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.Configure<AddressConfig>(Configuration.GetSection("CompanyAddress"));

            //ConnectionString
            services.Configure<IServiceCollection>(Configuration.GetSection("ConnectionString"));

            string configValue = Configuration.GetValue<string>("ConnectionString");

            var newConfigObj = new ConnectionConfig()
            {
                ConnectionString = configValue.ToString()
            };

            StaticConfig.TestConfig = configValue.ToString();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
