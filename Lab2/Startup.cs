using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2.Models;
using Lab2.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Lab2
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration["Data:SportStoreProducts:ConnectionString"]));
            services.AddControllers();
            services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                {
                    app.UseDeveloperExceptionPage();
                }
                app.UseDeveloperExceptionPage(); // informacje szczegó³owe o b³êdach
                //app.UseElapsedTimeMiddleWare();
                app.UseStatusCodePages(); // Wyœwietla strony ze statusem b³êdu
                app.UseStaticFiles(); // obs³uga treœci statycznych css, images, js
                app.UseRouting();
                app.UseAuthentication();
                app.UseAuthorization();
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Product}/{action=List}/{id?}");

                    endpoints.MapControllerRoute(
                       name: null,
                       pattern: "Product/{category}",
                   defaults: new
                   {
                       controller = "Product",
                       action = "List",
                   });

                    endpoints.MapControllerRoute(
                        name: null,
                        pattern: "Admin/{action=Index}",
                    defaults: new
                    {
                        controller = "Admin",
                    });

                    endpoints.MapControllerRoute(
                     name: "Admin panel edit",
                    pattern: "{controller=Admin}/{action=Edit}/{id?}");

                    endpoints.MapControllerRoute(
                         name: "Admin panel Delete",
                        pattern: "{controller=Admin}/{action=Delete}/{id?}");

                });
                SeedData.EnsurePopulated(app); 
               
            }
        }
    }
}
