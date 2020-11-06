using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                {
                    app.UseDeveloperExceptionPage();
                }
                app.UseDeveloperExceptionPage(); // informacje szczeg�owe o b��dach
                app.UseStatusCodePages(); // Wy�wietla strony ze statusem b��du
                app.UseStaticFiles(); // obs�uga tre�ci statycznych css, images, js
                app.UseRouting();
                app.UseEndpoints(routes => {

                    routes.MapControllerRoute(
                        name: "default",
                        pattern: "{controlller=Product}/{action=List}/{id?}");

                    routes.MapControllerRoute(
                        name: null,
                        pattern: "Product/{category}",
                    defaults: new
                    {
                        controller = "Product",
                        action = "List",
                    });
                });         
                SeedData.EnsurePopulated(app);
            } 

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Product}/{action=List}/{category?}");                  
            });           
        }
    }
}
