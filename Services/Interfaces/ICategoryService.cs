using Dtos.Models;

namespace Services.Interfaces
{
    public interface ICategoryService  
    {

        #region Methods

        #region Sync Methods

        IEnumerable<CategoryListingDto> GetAll();
        UpdateCategoryDto GetById(object id);
        bool Add(CreateCategoryDto obj);
        bool Update(UpdateCategoryDto obj);
        bool Remove(CategoryListingDto obj);
        bool Remove(object id);
        CategoryListingDto GetCategoryByName(string cateoryName);
        bool IsCategoryExist(string categoryName, int CategoryId);
        bool IsCategoryExist(int CategoryId); 

        #endregion

        #region Async Methods

        Task<IEnumerable<CategoryListingDto>> GetAllAsync();
        Task<bool> CategoryExistAsync(string categoryName, int CategoryId);
        Task<bool> CategoryExistAsync(int CategoryId);
        Task<CategoryListingDto> GetCategoryByCategoryNameAsync(string categoryName);

        #endregion

        #endregion

    }
}
