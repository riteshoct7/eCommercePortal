using Entities.Models;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class CategoryRepository :Repository<Category>,ICategoryRepository
    {

        #region Fields

        private readonly AppDbContext db;

        #endregion

        #region Constructors

        public CategoryRepository(AppDbContext db) : base(db)
        {
            this.db = db;
        }

        #endregion

        #region Methods

        #region Sync Methods

        public Category GetCategoryByName(string categoryName)
        {
            return db.Categories.Where(x => x.CategoryName.ToUpper().Trim() == categoryName.ToUpper().Trim()).FirstOrDefault();
        }

        public bool IsCategoryExist(string categoryName, int CategoryId)
        {
            var result = db.Categories.Any(x => x.CategoryName.ToUpper().Trim() == categoryName.ToUpper().Trim() && x.CategoryId != CategoryId);
            return result;
        }

        public bool IsCategoryExist(int CategoryId)
        {
            var result = db.Categories.Any(x => x.CategoryId == CategoryId);
            return result;
        } 

        #endregion

        #region Async Methods

        public async Task<bool> CatgeoryExistAsync(string categoryName, int CategoryId)
        {
            dynamic result = db.Categories.Any(x => x.CategoryName.ToUpper().Trim() == categoryName.ToUpper().Trim() && x.CategoryId != CategoryId);
            return await result;
        }

        public async Task<bool> CatgeoryExistAsync(int CategoryId)
        {
            dynamic result = db.Categories.Any(x => x.CategoryId == CategoryId);
            return await result;
        }

        public async Task<Category> GetCatgeoryByCategoryNameAsync(string categoryName)
        {
            dynamic result = db.Categories.Where(x => x.CategoryName.ToUpper().Trim() == categoryName.ToUpper().Trim()).FirstOrDefault();
            return await result;
        }

        #endregion

        #endregion

    }
}
