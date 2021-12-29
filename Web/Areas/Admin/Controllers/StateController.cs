using AspNetCoreHero.ToastNotification.Abstractions;
using Common;
using Dtos.Models;
using Dtos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Interfaces;
using static Common.Constants;

namespace Web.Areas.Admin.Controllers
{
    public class StateController : BaseController
    {

        #region Fields

        private readonly IUnitOfWorkService unitOfWorkService;
        private readonly INotyfService notyf;

        #endregion

        #region Constructors

        public StateController(IUnitOfWorkService unitOfWorkService, INotyfService notyf)
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
                            notyf.Success(Entity.State + Constants.Space + Constants.InsertedSuccesfully, 10);
                            break;
                        }
                    case CrudOperationType.Update:
                        {
                            notyf.Success(Entity.State + Constants.Space + Constants.UpdatedSuccesfully, 10);
                            break;
                        }
                    case CrudOperationType.Delete:
                        {
                            notyf.Success(Entity.State + Constants.Space + Constants.DeletedSuccesfully, 10);
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
        public IActionResult GetAllStates()
        {            
            return Json(new
            {
                data = unitOfWorkService.stateService.GetAllStates()
            });
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<CountryListingDto> lstCountries = unitOfWorkService.countryService.GetAll();
            CreateCountryStateViewModel model = new CreateCountryStateViewModel()
            {
                Countries = lstCountries.Select(i=> new SelectListItem { 
                    Text = i.CountryName, 
                    Value =   i.CountryId.ToString()
                }),
                State = new CreateStateDto()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateCountryStateViewModel model)        
        {            
            IEnumerable<CountryListingDto> lstCountries = unitOfWorkService.countryService.GetAll();
            model.Countries = lstCountries.Select(i => new SelectListItem
            {
                Text = i.CountryName,
                Value = i.CountryId.ToString()
            });
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (unitOfWorkService.stateService.IsStateExist(model.State.StateName, 0))
            {
                ModelState.AddModelError("", model.State.StateName + " Already Exist");
                notyf.Warning(Entity.State + Constants.Space + model.State.StateName + Constants.Space + Constants.AlreadyExist, 10);
                return View(model);
            }
            if (unitOfWorkService.stateService.Add(model.State))
            {
                TempData["ShowMessage"] = CrudOperationType.Insert;
                return RedirectToAction("Index");
            }
            else
            {
                notyf.Error(Constants.SomethingWentWrong + Constants.Space + Constants.Saving + Entity.State + Constants.Space + Constants.Space + model.State.StateName, 10);
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            IEnumerable<CountryListingDto> lstCountries = unitOfWorkService.countryService.GetAll();
            UpdateCountryStateViewModel model = new UpdateCountryStateViewModel();
            UpdateStateDto updateStateDto = unitOfWorkService.stateService.GetById(id.GetValueOrDefault());
            if (updateStateDto == null)
            {
                return NotFound();
            }
            model.Countries = lstCountries.Select(i => new SelectListItem
            {
                Text = i.CountryName,
                Value = i.CountryId.ToString()
            });
            model.UpdateState = updateStateDto;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UpdateCountryStateViewModel model)
        {
            IEnumerable<CountryListingDto> lstCountries = unitOfWorkService.countryService.GetAll();
            model.Countries = lstCountries.Select(i => new SelectListItem
            {
                Text = i.CountryName,
                Value = i.CountryId.ToString()
            });
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (unitOfWorkService.stateService.IsStateExist(model.UpdateState.StateName, model.UpdateState.StateId))
            {
                notyf.Warning(Entity.State + Constants.Space + model.UpdateState.StateName + Constants.Space + Constants.AlreadyExist, 10);
                ModelState.AddModelError("", model.UpdateState.StateName + " Already Exist");
                return View(model);
            }
            if (!unitOfWorkService.stateService.IsStateExist(model.UpdateState.StateId))
            {
                notyf.Warning(Entity.State + Constants.Space + model.UpdateState.StateName + Constants.Space + Constants.NotFound, 10);
                return NotFound();
            }
            if (unitOfWorkService.stateService.Update(model.UpdateState))
            {
                TempData["ShowMessage"] = CrudOperationType.Update;
                return RedirectToAction("Index");
            }
            else
            {
                notyf.Error(Constants.SomethingWentWrong + Constants.Space + Constants.Updating + Entity.State + Constants.Space + Constants.Space + model.UpdateState.StateName, 10);
                return View(model);
            }
        }

        [HttpDelete]
        public IActionResult DeleteStates(int id)
        {
            bool status = unitOfWorkService.stateService.Remove(id);
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
