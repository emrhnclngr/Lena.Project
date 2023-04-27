using AutoMapper;
using Lena.Project.Dtos;
using Lena.Project.UI.Models;

namespace Lena.Project.UI.Mappings.AutoMapper
{
    public class UserCreateModelProfile : Profile
    {
        public UserCreateModelProfile()
        {
            CreateMap<UserCreateModel, AppUserCreateDto>();
        }
    }
}
