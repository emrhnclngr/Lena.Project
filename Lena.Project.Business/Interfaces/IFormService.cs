using Lena.Project.Dtos;
using Lena.Project.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lena.Project.Business.Interfaces
{
    public interface IFormService : IService<FormCreateDto, FormUpdateDto, FormListDto, Form>
    {
        Task<List<FormListDto>> GetByForm(string searchString);
    }
}
