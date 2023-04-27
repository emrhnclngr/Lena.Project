using FluentValidation;
using Lena.Project.Business.Interfaces;
using Lena.Project.Dtos;
using Lena.Project.UI.Extensions;
using Lena.Project.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Lena.Project.UI.Controllers
{
    public class FormController : Controller
    {
        private readonly IFormService _formService;
        private readonly IValidator<FormCreateDto> _formCreateDtoValidator;

        public FormController(IFormService formService, IValidator<FormCreateDto> formCreateDtoValidator)
        {
            _formService = formService;
            _formCreateDtoValidator = formCreateDtoValidator;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            
            var dto = new FormCreateDto();
            
            return PartialView("_FormCreatePartialView",dto);


        }
        [HttpPost]
        public async Task<IActionResult> Create(FormCreateDto dto)
        {
            var result = _formCreateDtoValidator.Validate(dto);
            if(result.IsValid)
            {
                var userId = int.Parse((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
                dto.AppUserId = userId;
                var form = await _formService.CreateAsync(dto);
                return this.ResponseRedirectAction(form, "Index", "Home");
            }
            foreach (var error in result.Errors)
            {
                TempData["info"] = result.ToString();
            }
            return RedirectToAction("Index","Home");

        }
    }
}
