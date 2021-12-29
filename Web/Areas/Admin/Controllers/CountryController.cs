using AspNetCoreHero.ToastNotification.Abstractions;
using Common;
using Dtos.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using static Common.Constants;

namespace Web.Areas.Admin.Controllers
{
    public class CountryController : BaseController
    {

        #region Fields

        private readonly IUnitOfWorkService unitOfWorkService;
        private readonly INotyfService notyf;

        #endregion

        #region Constructors

        public CountryController(IUnitOfWorkService unitOfWorkService, INotyfService notyf)
        {
            this.unitOfWorkService = unitOfWorkService;
            this.notyf = notyf;
        }

        #endregion

        #region Methods

        public void ShowMessage()
        {
            if (TempData.ContainsKey("ShowMessage"))
            {
                CrudOperationType tempDataShowMessage = (CrudOperationType)TempData["ShowMessage"]; // returns "Bill" 
                switch (tempDataShowMessage)
                {
                    case CrudOperationType.Insert:
                        {
                            notyf.Success(Entity.Category + Constants.Space + Constants.InsertedSuccesfully, 10);
                            break;
                        }
                    case CrudOperationType.Update:
                        {
                            notyf.Success(Entity.Category + Constants.Space + Constants.UpdatedSuccesfully, 10);
                            break;
                        }
                    case CrudOperationType.Delete:
                        {
                            notyf.Success(Entity.Category + Constants.Space + Constants.DeletedSuccesfully, 10);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        public IActionResult Index()
        {
            ShowMessage();
            return View();
        }

        [HttpGet]
        public IActionResult GetAllCountries()
        {
            return Json(new
            {
                data = unitOfWorkService.countryService.GetAll()
            });
        }

        public IActionResult Create()
        {
            CreateCountryDto model = new CreateCountryDto();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateCountryDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (unitOfWorkService.countryService.IsCountryExist(model.CountryName, 0))
            {
                ModelState.AddModelError("", model.CountryName + " Already Exist");
                notyf.Warning(Entity.Country + Constants.Space + model.CountryName + Constants.Space + Constants.AlreadyExist, 10);
                return View(model);
            }
            if (unitOfWorkService.countryService.Add(model))
            {
                TempData["ShowMessage"] = CrudOperationType.Insert;
                return RedirectToAction("Index");
            }
            else
            {
                notyf.Error(Constants.SomethingWentWrong + Constants.Space + Constants.Saving + Entity.Category + Constants.Space + Constants.Space + model.CountryName, 10);
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            UpdateCountryDto updateCategoryDto = unitOfWorkService.countryService.GetById(id.GetValueOrDefault());
            if (updateCategoryDto == null)
            {
                return NotFound();
            }
            return View(updateCategoryDto);            
        }

        [HttpPost]
        public IActionResult Edit(UpdateCountryDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (unitOfWorkService.countryService.IsCountryExist(model.CountryName, model.CountryId))
            {
                notyf.Warning(Entity.Country + Constants.Space + model.CountryName + Constants.Space + Constants.AlreadyExist, 10);
                ModelState.AddModelError("", model.CountryName + " Already Exist");
                return View(model);
            }
            if (!unitOfWorkService.countryService.IsCountryExist(model.CountryId))
            {
                notyf.Warning(Entity.Category + Constants.Space + model.CountryName + Constants.Space + Constants.NotFound, 10);
                return NotFound();
            }

            if (unitOfWorkService.countryService.Update(model))
            {
                TempData["ShowMessage"] = CrudOperationType.Update;
                return RedirectToAction("Index");
            }
            else
            {
                notyf.Error(Constants.SomethingWentWrong + Constants.Space + Constants.Updating + Entity.Category + Constants.Space + Constants.Space + model.CountryName, 10);
                return View(model);
            }
        }

        [HttpDelete]
        public IActionResult DeleteCountries(int id)
        {
            bool status = unitOfWorkService.countryService.Remove(id);
            if (status)
            {
                TempData["ShowMessage"] = CrudOperationType.Delete;
                return Json(new { success = true, message = "Delete Successful" });
            }
            return Json(new { success = false, message = "Delete not Successful" });
        }

        #endregion

    }
}
