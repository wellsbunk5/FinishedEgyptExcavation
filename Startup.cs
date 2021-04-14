using Amazon.S3;
using EgyptExcavation.Models;
using EgyptExcavation.Providers.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavation
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
            //var connection = "Server=aa1m9irdqzu4ek2.ccdo9rv8zndw.us-east-1.rds.amazonaws.com;Database=ebdb;User ID=Team12;Password=IlovetoExcatvate!;Trusted_Connection=True;";

            services.AddIdentity<User, Role>(options =>
            {
                options.User.RequireUniqueEmail = false;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 1;
            }).AddEntityFrameworkStores<ExcavationDbContext>();

            services.AddDbContext<ExcavationDbContext>(options =>
            {
                //method for Helpers.cs
                //options.UseSqlServer(Helpers.GetRDSConnectionString());
                //Method for appsettings.json
                options.UseSqlServer(Configuration["ConnectionStrings:Default"]);
            });

            /*attempting to use the appsettings.json directly
            services.AddDbContext<ExcavationDbContext>(options => options.UseSqlServer(connection));
            services.AddScoped<ExcavationDbContext, ExcavationDbContext>();*/

            services.AddControllersWithViews();

            services.AddSingleton<IStorageService, S3StorageService>();

            services.AddDefaultAWSOptions(Configuration.GetAWSOptions());
            services.AddAWSService<IAmazonS3>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            SeedData.EnsurePopulated(app);
        }
    }
}
