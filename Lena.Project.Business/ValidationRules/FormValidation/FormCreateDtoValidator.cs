using FluentValidation;
using Lena.Project.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lena.Project.Business.ValidationRules.FormValidation
{
    public class FormCreateDtoValidator  : AbstractValidator<FormCreateDto>
    {
        public FormCreateDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title field cannot be empty!");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content field cannot be empty!");
        }
    }
}
