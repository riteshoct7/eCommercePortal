using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Web.Areas.Admin.Controllers
{
    public class ContactUsController : BaseController
    {

        #region Fields

        private readonly IUnitOfWorkService unitOfWorkService; 

        #endregion

        #region Constructors

        public ContactUsController(IUnitOfWorkService unitOfWorkService)
        {
            this.unitOfWorkService = unitOfWorkService;
        }

        #endregion

        #region Methods

        public IActionResult Index()
        {
            var result = unitOfWorkService.contactUsService.GetAll();
            return View();
        } 

        #endregion

    }
}
