using AutoMapper;
using Lena.Project.Dtos;
using Lena.Project.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lena.Project.Business.Mappings.AutoMapper
{
    public class FormProfile : Profile
    {
        public FormProfile()
        {
            CreateMap<Form, FormListDto>().ReverseMap();
            CreateMap<Form, FormCreateDto>().ReverseMap();
            CreateMap<Form, FormUpdateDto>().ReverseMap();
        }
    }
}
