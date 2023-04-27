using AutoMapper;
using FluentValidation;
using Lena.Project.Business.DependencyResolvers.Microsoft;
using Lena.Project.Business.Helpers;
using Lena.Project.UI.Mappings.AutoMapper;
using Lena.Project.UI.Models;
using Lena.Project.UI.ValidationRules;
using Microsoft.AspNetCore.Authentication.Cookies;
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

namespace Lena.Project.UI
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
            services.AddDependencies(Configuration);

            services.AddTransient<IValidator<UserCreateModel>, UserCreateModelValidator>();





            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
   .AddCookie(opt =>
   {
       opt.Cookie.Name = "LenaProjectCookie";
       opt.Cookie.HttpOnly = true;
       opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
       opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
       opt.ExpireTimeSpan = TimeSpan.FromDays(20);
       opt.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/SignIn");
       opt.LogoutPath = new Microsoft.AspNetCore.Http.PathString("/Account/LogOut");
       opt.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/AccessDenied");

   });

            services.AddControllersWithViews();

            var profiles = ProfileHelper.GetProfiles();

            profiles.Add(new UserCreateModelProfile());

            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfiles(profiles);
            });
            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);
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
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
