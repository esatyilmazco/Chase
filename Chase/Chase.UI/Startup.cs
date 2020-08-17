using System;
using AutoMapper;
using Chase.Business.Notional;
using Chase.Business.Tangible;
using Chase.Business.ValidationRules.FluentValidation;
using Chase.DataAccess.Notional;
using Chase.DataAccess.Tangible;
using Chase.DataAccess.Tangible.EntityFrameworkCore.ContextFile;
using Chase.Entities.DTOs;
using Chase.Entities.Tangible;
using Chase.UI.Identity;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Chase.UI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddFluentValidation();
            services.AddScoped<IDutyDal, EfDutyDal>();
            services.AddScoped<IDutyService, DutyManager>();
            services.AddScoped<IUrgencyDal, EfUrgencyDal>();
            services.AddScoped<IUrgencyService, UrgencyManager>();
            services.AddScoped<IUserDal, EfUserDal>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IFileService, FileManager>();
            services.AddScoped<IReportService, ReportManager>();
            services.AddScoped<IReportDal, EfReportDal>();
            services.AddScoped<IDeclarationDal, EfDeclarationDal>();
            services.AddScoped<IDeclarationService, DeclarationManager>();
            services.AddTransient<IValidator<DutyDto>, DutyAddValidator>();
            services.AddScoped<IMessageDal, EfMessageDal>();
            services.AddScoped<IMessageService, MessageManager>();
            services.AddDbContext<ChaseContext>();
            services.AddAutoMapper(typeof(Startup));
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 10;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<ChaseContext>();
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "ChaseSystem";
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(20);
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                options.LoginPath = "/Home/Index";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            IdentityInitializer.SeedData(userManager, roleManager).Wait();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                //Area için.
                 endpoints.MapControllerRoute(
                     name: "areas",
                     pattern: "{area}/{controller=Home}/{action=Index}/{id?}"
                 );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{Controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}