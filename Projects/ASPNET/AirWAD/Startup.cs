using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirWAD.Models.DataBase;
using AirWAD.Repository.Abstraction;
using AirWAD.Repository.Implementation;
using AirWAD.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AirWAD
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

            var connection = @"Server=(localdb)\mssqllocaldb;Database=AirWAD_DB;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<AirWADContext>
                (options => options.UseSqlServer(connection));

            //Add Repositories
            services.AddTransient<IListingRepository, ListingRepository>();
            services.AddTransient<IListingStatisticsRepository, ListingStatisticsRepository>();
            services.AddTransient<INewsRepository, NewsRepository>();
            services.AddTransient<IRentalRepository, RentalRepository>();
            services.AddTransient<IReservationRepository, ReservationRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserStatisticsRepository, UserStatisticsRepository>();

            //Add Services
            services.AddScoped<AdminService>();
            services.AddScoped<ClientService>();

            //Identity
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AirWADContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 5;
                options.User.RequireUniqueEmail = true;
                
                
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
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
                    pattern: "{controller=Client}/{action=Welcome}/{id?}");
                endpoints.MapRazorPages();
            });
            CreateUserRoles(services).Wait();
        }

        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            IdentityResult roleResult;
            //Adding Admin Role
            var roleCheck = await RoleManager.RoleExistsAsync("Client");
            if (!roleCheck)
            {
                //create the roles and seed them to the database
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Client"));
            }

            var roleCheck1 = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck1)
            {
                //create the roles and seed them to the database
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
            }

            //Assign Admin role to the main User here we have given our newly registered 
            //login id for Admin management
            //IdentityUser user1 = await UserManager.FindByEmailAsync("syedshanumcain@gmail.com");
            //var User = new IdentityUser();
            //await UserManager.AddToRoleAsync(user1, "Admin");
        }
    }
}
