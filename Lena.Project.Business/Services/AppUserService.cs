using AutoMapper;
using FluentValidation;
using Lena.Project.Business.Extensions;
using Lena.Project.Business.Interfaces;
using Lena.Project.Common;
using Lena.Project.DataAccess.UnitOfWork;
using Lena.Project.Dtos;
using Lena.Project.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lena.Project.Business.Services.AppUserService;

namespace Lena.Project.Business.Services
{
    public class AppUserService : Service<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>, IAppUserService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<AppUserCreateDto> _createDtoValidator;
        private readonly IValidator<AppUserLoginDto> _loginDtoValidator;
        public AppUserService(IMapper mapper, IValidator<AppUserCreateDto> createDtoValidator, IValidator<AppUserUpdateDto> updateDtoValidator, IUow uow, IValidator<AppUserLoginDto> loginDtoValidator) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _loginDtoValidator = loginDtoValidator;
        }
        public async Task<IResponse<AppUserCreateDto>> CreateUserAsync(AppUserCreateDto dto)
        {
            var validationResult = _createDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var user = _mapper.Map<AppUser>(dto);

                await _uow.GetRepository<AppUser>().CreateAsync(user);

                await _uow.SaveChangesAsync();
                return new Response<AppUserCreateDto>(ResponseType.Success, dto);

            }
            return new Response<AppUserCreateDto>(dto, validationResult.ConvertToCustomValidationError());
        }
        public async Task<IResponse<AppUserListDto>> CheckUserAsync(AppUserLoginDto dto)
        {
            var validationResult = _loginDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var user = await _uow.GetRepository<AppUser>().GetByFilterAsync(x => x.Username == dto.Username && x.Password == dto.Password);
                if (user != null)
                {
                    var appUserDto = _mapper.Map<AppUserListDto>(user);
                    return new Response<AppUserListDto>(ResponseType.Success, appUserDto);
                }
                return new Response<AppUserListDto>(ResponseType.NotFound, "Username or password is wrong!");
            }
            return new Response<AppUserListDto>(ResponseType.ValidationError, "Username or password cannot be empty!");
        }
       
        public async Task<IResponse<List<AppUserLoginDto>>> GeyByLoginUserId(int id)
        {
            var query = await _uow.GetRepository<AppUser>().FindAsync(id);

            var dto = _mapper.Map<List<AppUserLoginDto>>(query);

            return new Response<List<AppUserLoginDto>>(ResponseType.Success, dto);
        }
    }
}
