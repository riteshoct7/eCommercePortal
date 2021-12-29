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

        #endregion

        #endregion

    }
}
