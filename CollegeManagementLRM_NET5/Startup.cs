using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeManagementLRM_NET5.Data;
using CollegeManagementLRM_NET5.HubConfig;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace CollegeManagementLRM_NET5
{
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
            services.AddControllersWithViews();

            // ----- DbContext ----- //
            string startupPath = Environment.CurrentDirectory;
            var ConectionStringLocal = Configuration.GetConnectionString("LocalConnection");

            //Replace Content Root Path To User Content
            if (ConectionStringLocal.Contains("%CONTENTROOTPATH%"))
            {
                ConectionStringLocal = ConectionStringLocal.Replace("%CONTENTROOTPATH%", startupPath);
            }

            services.AddDbContext<CollegeManagementLRM_NET5.Data.COLLEGE_MANAGEMENT_DBContext>(options =>
                                options.UseSqlServer(ConectionStringLocal));

            services.AddDbContext<global::CollegeManagementLRM_NET5.Data.COLLEGE_MANAGEMENT_DBContext>((global::Microsoft.EntityFrameworkCore.DbContextOptionsBuilder options) =>
                options.UseSqlServer(ConectionStringLocal));

            // ---- SignalR ---- //
            services.AddSignalR();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
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
                endpoints.MapHub<DashboardHub>("/RealTimeInfo");
            });
        }
    }
}
