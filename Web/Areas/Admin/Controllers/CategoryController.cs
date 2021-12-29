using AspNetCoreHero.ToastNotification.Abstractions;
using Common;
using Dtos.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using static Common.Constants;

namespace Web.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {

        #region Fields

        private readonly IUnitOfWorkService unitOfWorkService;
        private readonly INotyfService notyf;

        #endregion

        #region Constructors

        public CategoryController(IUnitOfWorkService unitOfWorkService, INotyfService notyf)
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
        public  async Task<IActionResult> GetAllCategories()
        {
            return Json(new
            {
                data = await unitOfWorkService.categoryService.GetAllAsync()
            });
        }

        public IActionResult List()
        {            
            return View(unitOfWorkService.categoryService.GetAll());
        }

        [HttpGet]
        public IActionResult Create ()
        {
            CreateCategoryDto createCategoryDto = new CreateCategoryDto();
            return View(createCategoryDto);
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryDto model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            if(unitOfWorkService.categoryService.IsCategoryExist(model.CategoryName,0 ))
            {
                ModelState.AddModelError("", model.CategoryName + " Already Exist");
                notyf.Warning(Entity.Category + Constants.Space+ model.CategoryName + Constants.Space + Constants.AlreadyExist, 10);
                return View(model);
            }
            if(unitOfWorkService.categoryService.Add(model))
            {
                TempData["ShowMessage"] = CrudOperationType.Insert;
                return RedirectToAction("Index");
            }
            else
            {
                notyf.Error(Constants.SomethingWentWrong + Constants.Space + Constants.Saving + Entity.Category + Constants.Space + Constants.Space + model.CategoryName, 10);
                return View(model);
            }            
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            UpdateCategoryDto createCategoryDto = unitOfWorkService.categoryService.GetById(id.GetValueOrDefault());
            if (createCategoryDto == null)
            {
                return NotFound();
            }
            return View(createCategoryDto);
        }

        [HttpPost]
        public IActionResult Edit(UpdateCategoryDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (unitOfWorkService.categoryService.IsCategoryExist(model.CategoryName, model.CategoryId))
            {
                notyf.Warning(Entity.Category + Constants.Space + model.CategoryName + Constants.Space + Constants.AlreadyExist, 10);
                ModelState.AddModelError("", model.CategoryName + " Already Exist");
                return View(model);
            }
            if (!unitOfWorkService.categoryService.IsCategoryExist(model.CategoryId))
            {
                notyf.Warning(Entity.Category + Constants.Space + model.CategoryName + Constants.Space + Constants.NotFound, 10);
                return NotFound();
            }

            if (unitOfWorkService.categoryService.Update(model))
            {
                TempData["ShowMessage"] = CrudOperationType.Update;
                return RedirectToAction("Index");
            }
            else
            {
                notyf.Error(Constants.SomethingWentWrong + Constants.Space+ Constants.Updating+ Entity.Category+ Constants.Space + Constants.Space + model.CategoryName , 10);
                return View(model);
            }            
        }

        [HttpDelete]
        public IActionResult DeleteCategories(int id)
        {
            bool status = unitOfWorkService.categoryService.Remove(id);
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
