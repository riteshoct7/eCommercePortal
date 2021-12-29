using Entities.Models;

namespace Repository.Interfaces
{
    public interface ICountryRepository :IRepository<Country>
    {

        #region Methods

        Country GetCountryByCountryName(string countryName);        
        bool IsCountryExist(string countryName, int CountryId);                            
        bool IsCountryExist(int CountryId);
        
        #endregion

    }
}
