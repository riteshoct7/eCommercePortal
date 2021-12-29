using Microsoft.AspNetCore.Mvc;

namespace WebApiClient.Areas.Customer.Controllers
{
    public class DashboardController : BaseController
    {

        #region Constructors

        public DashboardController()
        {

        }

        #endregion

        #region Methods

        public IActionResult Index()
        {
            return View();
        }

        #endregion

    }
}
