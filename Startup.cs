using Assignment5.Models;
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

namespace Assignment5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //Passes the configuration of the connection string made in appsettings.json to the sql server
            services.AddDbContext<BookstoreDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:OnlineBookstoreConnection"]);
            });

            //Provides scoped version of database to user
            services.AddScoped<IBookstoreRepository, EFBookstoreRepository>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //Endpoint for if the user types in a category and page number into the URL
                endpoints.MapControllerRoute("catpage",
                    "{category}/{page:int}",
                    new { Controller = "Home", action = "Index" });

                //Endpoint for if the user types in page number into the URL
                endpoints.MapControllerRoute("page",
                    "{page:int}",
                    new { Controller = "Home", action = "Index" });

                //Endpoint for if the user types in a category  into the URL
                endpoints.MapControllerRoute("category",
                    "{category}",
                    new { Controller = "Home", action = "Index", page = 1 });

                //I ADDED AN ENDPOINT AT LINE 68 THAT DEALS WITH JUST A PAGE NUMBER BEING ENTERED SO I HAVE COMMENTED THIS PART OF THE CODE OUT BECAUSE IT DOES BASICALLY THE SAME THING
                //This changes the URL so that the user can type /P2 to access the second page and /P3 to access the third page and so on
                //endpoints.MapControllerRoute(
                //    "pagination",
                //    "P{page}",
                //    new { Controller = "Home", action = "Index" });

                //This is the default endpoint if the user doesn't enter anything into the URL
                endpoints.MapDefaultControllerRoute();
            });

            //SeedData is static so we don't have to call it again
            //We could technically delete this and the SeedData.cs file because the entries are added to the database 
            //and do not need to be added every time the program is started
            SeedData.EnsurePopulated(app);
        }
    }
}
