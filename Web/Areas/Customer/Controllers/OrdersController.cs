using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Customer.Controllers
{
    public class OrdersController : BaseController
    {

        #region Constructors

        public OrdersController()
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
