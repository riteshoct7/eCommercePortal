using Entities.Models;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class CountryRepository :Repository<Country>,ICountryRepository
    {

        #region Fields

        private readonly AppDbContext db;

        #endregion

        #region Constructors

        public CountryRepository(AppDbContext db) : base(db)
        {
            this.db = db;
        }

        #endregion

        #region Methods

        #region Sync Methods

        public Country GetCountryByCountryName(string countryName)
        {
            return db.Countries.Where(x => x.CountryName.ToUpper().Trim() == countryName.ToUpper().Trim()).FirstOrDefault();
        }

        public bool IsCountryExist(string countryName, int CountryId)
        {
            var result = db.Countries.Any(x => x.CountryName.ToUpper().Trim() == countryName.ToUpper().Trim() && x.CountryId != CountryId);
            return result;
        }

        public bool IsCountryExist(int CountryId)
        {
            var result = db.Countries.Any(x => x.CountryId == CountryId);
            return result;
        }

        #endregion

        #region Async Methods

        public async Task<Country> GetCountryByCountryNameAsync(string countryName)
        {
            dynamic result = db.Countries.Where(x => x.CountryName.ToUpper().Trim() == countryName.ToUpper().Trim()).FirstOrDefault();
            return await result;
        }

        public async Task<bool> IsCountryExistAsync(string countryName, int CountryId)
        {
            dynamic result = db.Countries.Any(x => x.CountryName.ToUpper().Trim() == countryName.ToUpper().Trim() && x.CountryId != CountryId);
            return await result;
        }

        public async Task<bool> IsCountryExistAsync(int CountryId)
        {
            dynamic result = db.Countries.Any(x => x.CountryId == CountryId);
            return await result;
        }

        #endregion

        #endregion

    }
}
