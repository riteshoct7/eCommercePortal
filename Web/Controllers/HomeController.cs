using Dtos.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Diagnostics;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        #region Fields

        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWorkService unitOfWorkService;

        #endregion

        #region Constructors

        public HomeController(ILogger<HomeController> logger, IUnitOfWorkService unitOfWorkService)
        {
            _logger = logger;
            this.unitOfWorkService = unitOfWorkService;
        } 

        #endregion

        #region Methods

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ContactUs()
        {
            CreateContactUsDto model = new CreateContactUsDto();
            return View(model);
        }

        [HttpPost]
        public IActionResult ContactUs(CreateContactUsDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (unitOfWorkService.contactUsService.Add(model))
            {
                return RedirectToAction("Index");
            }
            return View(model);
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

        #endregion

    }
}