using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApiClient.Models;

namespace WebApiClient.Controllers
{
    public class HomeController : Controller
    {

        #region Fields

        private readonly ILogger<HomeController> _logger; 

        #endregion

        #region Constructors

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Methods

        public IActionResult Index()
        {
            return View();
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