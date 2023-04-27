using FluentValidation;
using Lena.Project.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lena.Project.Business.ValidationRules.AppUserValidation
{
    public class AppUserLoginDtoValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginDtoValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username cannot be empty.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty.");
        }
    }
}
