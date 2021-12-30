using Entities.Models;

namespace Repository.Interfaces
{
    public interface ICountryRepository :IRepository<Country>
    {

        #region Methods

        #region Sync Methods

        Country GetCountryByCountryName(string countryName);
        bool IsCountryExist(string countryName, int CountryId);
        bool IsCountryExist(int CountryId);

        #endregion

        #region Async Methods

        Task<Country> GetCountryByCountryNameAsync(string countryName);
        Task<bool> IsCountryExistAsync(string countryName, int CountryId);
        Task<bool> IsCountryExistAsync(int CountryId);

        #endregion




        #endregion

    }
}
