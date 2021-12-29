using Microsoft.AspNetCore.Mvc;

namespace Api.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        #region Constructors

        public CategoryController()
        {

        }

        #endregion

        #region Methods

        [HttpGet]
        public ActionResult GetAll ()
        {
            return Ok("Ritesh");
        }

        #endregion

    }
}
