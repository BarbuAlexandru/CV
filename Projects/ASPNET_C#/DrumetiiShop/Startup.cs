using DrumetiiShop.Repository;
using DrumetiiShop.Services;
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

namespace DrumetiiShop
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
            services.AddRazorPages();

            var connection = @"Server=(localdb)\mssqllocaldb;Database=DrumetiiShop_Db;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<DrumetiiShopDbContext>
                (options => options.UseSqlServer(connection));

            //Add Repositories
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<ICartProductConnectionRepository, CartProductConnectionRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();

            //Add Services
            services.AddScoped<MainService>();

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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Main}/{action=Home}/{id?}");
            });
        }
    }
}
