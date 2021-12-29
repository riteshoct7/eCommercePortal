using Microsoft.AspNetCore.Mvc;

namespace WebApiClient.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {

        #region Constructors

        public ProductController()
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
