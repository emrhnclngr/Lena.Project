using FluentValidation;
using Lena.Project.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lena.Project.Business.ValidationRules.FormValidation
{
    public class FormUpdateDtoValidator : AbstractValidator<FormUpdateDto>
    {
        public FormUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Content).NotEmpty();
        }
    }
}
