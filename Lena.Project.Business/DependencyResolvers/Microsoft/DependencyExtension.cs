using FluentValidation;
using Lena.Project.Business.Interfaces;
using Lena.Project.Business.Services;
using Lena.Project.Business.ValidationRules.AppUserValidation;
using Lena.Project.Business.ValidationRules.FormValidation;
using Lena.Project.DataAccess.Context;
using Lena.Project.DataAccess.UnitOfWork;
using Lena.Project.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lena.Project.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProjectContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });


            services.AddScoped<IUow, Uow>();
            services.AddScoped<IAppUserService,AppUserService>();
            services.AddScoped<IFormService,FormService>();

            services.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();
            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();
            services.AddTransient<IValidator<FormCreateDto>, FormCreateDtoValidator>();
            services.AddTransient<IValidator<FormUpdateDto>, FormUpdateDtoValidator>();
        }
    }
}
