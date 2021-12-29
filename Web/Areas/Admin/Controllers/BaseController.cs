using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleTitle)]
    [Authorize]
    public class BaseController : Controller
    {                
    }
}
