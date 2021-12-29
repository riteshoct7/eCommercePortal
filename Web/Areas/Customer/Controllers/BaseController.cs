using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Customer.Controllers
{
    [Area(Constants.CustomerRoleTitle)]
    [Authorize]
    public class BaseController : Controller
    {        
    }
}
