using Microsoft.AspNetCore.Mvc;

namespace WebApiClient.Areas.Customer.Controllers
{
    public class OrderController : BaseController
    {

        #region Constructors

        public OrderController()
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
