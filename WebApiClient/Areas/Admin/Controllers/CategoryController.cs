using Microsoft.AspNetCore.Mvc;

namespace WebApiClient.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {

        #region Constructors

        public CategoryController()
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
