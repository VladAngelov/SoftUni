namespace RentACarWeb
{
    using CloudinaryDotNet;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Cors.Infrastructure;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using RentACar.Data;
    using RentACar.Data.Models.Car;
    using RentACar.Data.Models.Rent;
    using RentACar.Data.Models.User;
    using RentACar.Service.Mapping;
    using RentACar.Services;
    using RentACar.Services.Models;
    using RentACar.Web.BindingModels;
    using RentACar.Web.ViewModels.Home.Index;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var dbConnection = Configuration.GetConnectionString("AzureConnection");

            //var dbConnection = Configuration.GetConnectionString("DefaultConnection");


            services.AddDbContext<RentACarDbContext>(options =>
                options.UseSqlServer(dbConnection));

            services.AddIdentity<RentACarUser, IdentityRole>()
                .AddEntityFrameworkStores<RentACarDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;
                options.User.RequireUniqueEmail = true;
            });

            //services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<IRentService, RentService>();
            services.AddCors(d => d.AddPolicy("IsUserAdmin", new CorsPolicy() { }));

            Account cloudinaryCredentials = new Account(
                this.Configuration["Cloudinary:CloudName"],
                this.Configuration["Cloudinary:ApiKey"],
                this.Configuration["Cloudinary:ApiSecret"]);

            Cloudinary cloudinaryUtility = new Cloudinary(cloudinaryCredentials);

            services.AddSingleton(cloudinaryUtility);

            services.AddTransient<ICloudinaryService, CloudinaryService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(
                typeof(CarCreateBindingModel).GetTypeInfo().Assembly,
                typeof(CarHomeViewModel).GetTypeInfo().Assembly,
                typeof(CarServiceModel).GetTypeInfo().Assembly,
                typeof(RentServiceModel).GetTypeInfo().Assembly);

            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

            //using (var serviceScope = app.ApplicationServices.CreateScope())
            //{
            //    using (var context = serviceScope.ServiceProvider.GetRequiredService<RentACarDbContext>())
            //    {
            //        context.Database.EnsureCreated();

            //        if (!context.Roles.Any())
            //        {
            //            context.Roles.Add(new IdentityRole
            //            {
            //                Name = "Admin",
            //                NormalizedName = "ADMIN"
            //            });

            //            context.Roles.Add(new IdentityRole
            //            {
            //                Name = "User",
            //                NormalizedName = "USER"
            //            });

            //            context.SaveChanges();
            //        }

            //        if (!context.RentStatuses.Any())
            //        {
            //            context.RentStatuses.Add(new RentStatus
            //            {
            //                Name = "Active"
            //            });

            //            context.RentStatuses.Add(new RentStatus
            //            {
            //                Name = "Ended"
            //            });

            //            context.SaveChanges();
            //        }

            //        if (!context.CarStatuses.Any())
            //        {
            //            context.CarStatuses.Add(new CarStatus
            //            {
            //                Name = "Free"
            //            });

            //            context.SaveChanges();

            //            context.CarStatuses.Add(new CarStatus
            //            {
            //                Name = "Booked"
            //            });

            //            context.SaveChanges();
            //        }
            //    }
            //}

            app.UseCors();
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "default",
                   template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}