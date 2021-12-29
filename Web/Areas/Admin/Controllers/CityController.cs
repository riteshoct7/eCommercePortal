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
    public class CityController : BaseController
    {

        #region Fields

        private readonly IUnitOfWorkService unitOfWorkService;
        private readonly INotyfService notyf;

        #endregion

        #region Constructors

        public CityController(IUnitOfWorkService unitOfWorkService, INotyfService notyf)
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
                            notyf.Success(Entity.City + Constants.Space + Constants.InsertedSuccesfully, 10);
                            break;
                        }
                    case CrudOperationType.Update:
                        {
                            notyf.Success(Entity.City + Constants.Space + Constants.UpdatedSuccesfully, 10);
                            break;
                        }
                    case CrudOperationType.Delete:
                        {
                            notyf.Success(Entity.City + Constants.Space + Constants.DeletedSuccesfully, 10);
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
        public IActionResult GetAllCities()
        {
            return Json(new
            {
                data = unitOfWorkService.cityService.GetAllCities()
            });
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<CountryListingDto> lstCountries = unitOfWorkService.countryService.GetAll();

            CreateCountryStateCityViewModel model = new CreateCountryStateCityViewModel()
            {
                Countries = lstCountries.Select(i => new SelectListItem
                {
                    Text = i.CountryName,
                    Value = i.CountryId.ToString()
                }),
                City = new CreateCityDto()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateCountryStateCityViewModel model)
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

            if (unitOfWorkService.cityService.IsCityExist(model.City.CityName, 0))
            {
                ModelState.AddModelError("", model.City.CityName + " Already Exist");
                notyf.Warning(Entity.City + Constants.Space + model.City.CityName + Constants.Space + Constants.AlreadyExist, 10);
                return View(model);
            }

            if (unitOfWorkService.cityService.Add(model.City))
            {
                TempData["ShowMessage"] = CrudOperationType.Insert;
                return RedirectToAction("Index");
            }
            else
            {
                notyf.Error(Constants.SomethingWentWrong + Constants.Space + Constants.Saving + Entity.State + Constants.Space + Constants.Space + model.City.CityName, 10);
                return View(model);
            }                            
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {            
            IEnumerable<CountryListingDto> lstCountries = unitOfWorkService.countryService.GetAll();

            EditCountryStateCityViewModel model = new EditCountryStateCityViewModel()
            {
                Countries = lstCountries.Select(i => new SelectListItem
                {
                    Text = i.CountryName,
                    Value = i.CountryId.ToString()
                })                
            };
            
            UpdateCityDto updateCityDto = unitOfWorkService.cityService.GetCityDetailsByCityId(id.GetValueOrDefault());
            model.UpdateCity = updateCityDto;
            model.States = unitOfWorkService.stateService.GetAll().Where(x => x.CountryId == updateCityDto.CountryId).ToList().Select(i => new SelectListItem
            {
                Text = i.StateName,
                Value = i.StateId.ToString()
            });
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditCountryStateCityViewModel model)
        {
            IEnumerable<CountryListingDto> lstCountries = unitOfWorkService.countryService.GetAll();
            model.Countries = lstCountries.Select(i => new SelectListItem
            {
                Text = i.CountryName,
                Value = i.CountryId.ToString()
            });
            model.States = unitOfWorkService.stateService.GetAll().Where(x => x.CountryId == model.UpdateCity.CountryId).ToList().Select(i => new SelectListItem
            {
                Text = i.StateName,
                Value = i.StateId.ToString()
            });
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (unitOfWorkService.cityService.IsCityExist(model.UpdateCity.CityName, model.UpdateCity.CityId))
            {
                notyf.Warning(Entity.City + Constants.Space + model.UpdateCity.CityName + Constants.Space + Constants.AlreadyExist, 10);
                ModelState.AddModelError("", model.UpdateCity.CityName + " Already Exist");
                return View(model);
            }
            if (!unitOfWorkService.stateService.IsStateExist(model.UpdateCity.CityId))
            {
                notyf.Warning(Entity.City + Constants.Space + model.UpdateCity.CityName + Constants.Space + Constants.NotFound, 10);
                return NotFound();
            }
            if (unitOfWorkService.cityService.Update(model.UpdateCity))
            {
                TempData["ShowMessage"] = CrudOperationType.Update;
                return RedirectToAction("Index");
            }
            else
            {
                notyf.Error(Constants.SomethingWentWrong + Constants.Space + Constants.Updating + Entity.City + Constants.Space + Constants.Space + model.UpdateCity.CityName, 10);
                return View(model);
            }
        }

        public JsonResult GetStatesByCountryId(int CountryId)
        {
            List<StateListingDto> statesList = new List<StateListingDto>();

            //Get States for country from database
            statesList = unitOfWorkService.stateService.GetAll().Where(x => x.CountryId == CountryId).ToList();

            //Insert Selct Item in List
            statesList.Insert(0, new StateListingDto { StateName = "Select State" });
            return Json(new SelectList(statesList, "StateId", "StateName"));
        }
        
        [HttpDelete]
        public IActionResult DeleteCities(int id)
        {
            bool status = unitOfWorkService.cityService.Remove(id);
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
