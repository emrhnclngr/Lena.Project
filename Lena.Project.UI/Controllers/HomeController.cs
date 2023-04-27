using Lena.Project.Business.Interfaces;
using Lena.Project.UI.Extensions;
using Lena.Project.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lena.Project.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFormService _formService;

        public HomeController(IFormService formService)
        {
            _formService = formService;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                ViewData["CurrentFilter"] = searchString; 
                return View(await _formService.GetByForm(searchString));
            }

             return this.ResponseView(await _formService.GetAllAsync());
       
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
