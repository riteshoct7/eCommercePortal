using Entities.Models;

namespace Repository.Interfaces
{
    public interface ICategoryRepository :IRepository<Category>
    {

        #region Methods

        #region Sync Methods

        Category GetCategoryByName(string categoryName);
        bool IsCategoryExist(string categoryName, int CategoryId);
        bool IsCategoryExist(int CategoryId);

        #endregion

        #region Async Methods

        Task<bool> CategoryExistAsync(string categoryName, int CategoryId);
        Task<bool> CategoryExistAsync(int CategoryId);
        Task<Category> GetCategoryByCategoryNameAsync(string categoryName);

        #endregion

        #endregion

    }
}
