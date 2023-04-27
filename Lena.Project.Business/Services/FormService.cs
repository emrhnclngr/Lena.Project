using AutoMapper;
using FluentValidation;
using Lena.Project.Business.Interfaces;
using Lena.Project.Common;
using Lena.Project.DataAccess.UnitOfWork;
using Lena.Project.Dtos;
using Lena.Project.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lena.Project.Business.Services
{
    public class FormService : Service<FormCreateDto, FormUpdateDto, FormListDto, Form>, IFormService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public FormService(IMapper mapper, IValidator<FormCreateDto> createDtoValidator, IValidator<FormUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
            _mapper = mapper;

        }

        public async Task<List<FormListDto>> GetByForm(string searchString)
        {
            var query = _uow.GetRepository<Form>().GetQuery();
            var forms = await query.Where(x => x.Title.Contains(searchString)).ToListAsync();
            return _mapper.Map<List<FormListDto>>(forms);
        }
    }
}
