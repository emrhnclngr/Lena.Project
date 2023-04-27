﻿using FluentValidation;
using Lena.Project.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lena.Project.Business.ValidationRules.AppUserValidation
{
    public class AppUserCreateDtoValidator : AbstractValidator<AppUserCreateDto>
    {
        public AppUserCreateDtoValidator()
        {
            RuleFor(x => x.Firstname).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Gender).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.BirthDate).NotEmpty();
        }
    }
}
