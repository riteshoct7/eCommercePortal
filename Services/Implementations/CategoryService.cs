using Dtos.Models;
using Entities.Models;
using Repository.Interfaces;
using Services.Helpers;
using Services.Interfaces;

namespace Services.Implementations
{
    public class CategoryService : ICategoryService 
    {

        #region Fields

        private readonly IUnitOfWorkRepository unitOfWorkRepository; 

        #endregion

        #region Constructors

        public CategoryService(IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
        }

        #endregion

        #region Methods

        #region Sync Methods

        public bool Add(CreateCategoryDto obj)
        {
            Category category = ObjectMapper.Mapper.Map<Category>(obj);
            category.CreatedDate = DateTime.UtcNow;
            category.ModifiedDate = DateTime.UtcNow;
            unitOfWorkRepository.categoryRepository.Add(category);
            return unitOfWorkRepository.SaveChanges();
        }

        public bool Update(UpdateCategoryDto obj)
        {
            Category category = ObjectMapper.Mapper.Map<Category>(obj);
            category.CreatedDate = category.CreatedDate;
            category.ModifiedDate = DateTime.UtcNow;
            unitOfWorkRepository.categoryRepository.Update(category);
            return unitOfWorkRepository.SaveChanges();
        }

        public bool Remove(CategoryListingDto obj)
        {
            var category = ObjectMapper.Mapper.Map<Category>(obj);
            unitOfWorkRepository.categoryRepository.Remove(category);
            return unitOfWorkRepository.SaveChanges();
        }

        public bool Remove(object id)
        {
            unitOfWorkRepository.categoryRepository.Remove(id);
            return unitOfWorkRepository.SaveChanges();
        }

        public IEnumerable<CategoryListingDto> GetAll()
        {
            var category = unitOfWorkRepository.categoryRepository.GetAll();
            List<CategoryListingDto> lst = new List<CategoryListingDto>();
            foreach (var item in category)
            {
                lst.Add(ObjectMapper.Mapper.Map<CategoryListingDto>(item));
            }
            return lst;
        }

        public UpdateCategoryDto GetById(object id)
        {
            var category = unitOfWorkRepository.categoryRepository.GetById(id);
            var categoryDto = ObjectMapper.Mapper.Map<UpdateCategoryDto>(category);
            return categoryDto;
        }

        public CategoryListingDto GetCategoryByName(string categoryName)
        {
            var category = unitOfWorkRepository.categoryRepository.GetCategoryByName(categoryName);
            var categoryDto = ObjectMapper.Mapper.Map<CategoryListingDto>(category);
            return categoryDto;
        }

        public bool IsCategoryExist(string categoryName, int CategoryId)
        {
            return unitOfWorkRepository.categoryRepository.IsCategoryExist(categoryName, CategoryId);
        }

        public bool IsCategoryExist(int CategoryId)
        {
            return unitOfWorkRepository.categoryRepository.IsCategoryExist(CategoryId);
        }

        #endregion

        #region Async Methods

        public async Task<IEnumerable<CategoryListingDto>> GetAllAsync()
        {

            var category = await unitOfWorkRepository.categoryRepository.GetAllAsync();
            List<CategoryListingDto> lst = new List<CategoryListingDto>();
            foreach (var item in category)
            {
                lst.Add(ObjectMapper.Mapper.Map<CategoryListingDto>(item));
            }
            return lst;
        } 

        #endregion

        #endregion

    }
}
