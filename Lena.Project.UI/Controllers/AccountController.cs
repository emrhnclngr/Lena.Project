using AutoMapper;
using FluentValidation;
using Lena.Project.Business.Interfaces;
using Lena.Project.DataAccess.UnitOfWork;
using Lena.Project.Dtos;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using Lena.Project.UI.Models;
using Lena.Project.Common.Enums;
using Lena.Project.UI.Extensions;

namespace Lena.Project.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IValidator<UserCreateModel> _userCreateModelValidator;
        private readonly IMapper _mapper;
        

        public AccountController(IAppUserService appUserService, IMapper mapper, IValidator<UserCreateModel> userCreateModelValidator)
        {
            _appUserService = appUserService;
            _mapper = mapper;
            _userCreateModelValidator = userCreateModelValidator;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignUp()
        {

            var genders = new List<SelectListItem>
            {
              new SelectListItem { Value = GenderType.Erkek.ToString(), Text = "Male" },
              new SelectListItem { Value = GenderType.Kadın.ToString(), Text = "Female" },
            };

            ViewBag.Genders = genders;
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateModel model)
        {
            var result = _userCreateModelValidator.Validate(model);
            if (result.IsValid)
            {

                var userDTO = _mapper.Map<AppUserCreateDto>(model);

                var createResponse = await _appUserService.CreateUserAsync(userDTO);
                return this.ResponseRedirectAction(createResponse, "SignIn");

            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            return View(model);

        }

        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLoginDto dto)
        {
            var result = await _appUserService.CheckUserAsync(dto);
            if (result.ResponseType == Common.ResponseType.Success)
            {
                
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,dto.Username)

                };

                
                claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Data.Id.ToString()));



                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = dto.RememberMe,
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("Index","Home");

                
            }

            ModelState.AddModelError("Username or password is wrong!", result.Message);
            return View(dto);

        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(
           CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

    }
}

