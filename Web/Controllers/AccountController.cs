using Common;
using Dtos.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Web.Controllers
{
    public class AccountController : Controller
    {

        #region Fields

        private readonly IUnitOfWorkService unitOfWorkService; 

        #endregion

        #region Constructors

        public AccountController(IUnitOfWorkService unitOfWorkService)
        {
            this.unitOfWorkService = unitOfWorkService;
        }

        #endregion

        #region Methods

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string? returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            RegisterViewModel model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public IActionResult Register(RegisterViewModel model, string? returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            returnurl = returnurl ?? Url.Content("~/");
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            bool result = unitOfWorkService.accountService.Register(model, model.Password);
            if (result)
            {
                return RedirectToAction("Login");
                ////return LocalRedirect(returnurl);
            }
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string? returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginViewModel model, string? returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            returnurl = returnurl ?? Url.Content("~/");

            var user = unitOfWorkService.accountService.Login(model.Email, model.Password, model.RememberMe, false);
            if (user != null)
            {
                if (!string.IsNullOrEmpty(returnurl) && Url.IsLocalUrl(returnurl))
                {
                    //    return Redirect(returnUrl);
                }

                if (user.Roles.Contains(Constants.AdminRoleTitle))
                {
                    return RedirectToAction("Index", "Dashboard", new { area = Constants.AdminRoleTitle });
                }
                else if (user.Roles.Contains(Constants.CustomerRoleTitle))
                {
                    return RedirectToAction("Index", "Dashboard", new { area = Constants.CustomerRoleTitle });
                }
                else
                {
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            ForgotPasswordViewModel model = new ForgotPasswordViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await unitOfWorkService.accountService.SignOut();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        } 

        #endregion

    }
}
