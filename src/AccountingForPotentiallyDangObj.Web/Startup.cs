using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AccountingForPotentiallyDangObj.DataAccess.Infrastructure;

namespace AccountingForPotentiallyDangObj.Web
{
    public class Startup
    {
        private readonly string _connectionString;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddControllersWithViews();
            services.AddControllersWithViews()
                .AddDataAnnotationsLocalization()
                .AddViewLocalization();
            services.AddOptions();
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new DataAccessModule(_connectionString));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
