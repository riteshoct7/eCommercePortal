using Dtos.Models;

namespace Services.Interfaces
{
    public interface ICountryService
    {

        #region Methods

        bool Add(CreateCountryDto model);
        bool Update(UpdateCountryDto model);
        bool Remove(CountryListingDto obj);        
        bool Remove(object id);        
        IEnumerable<CountryListingDto> GetAll();
        UpdateCountryDto GetById(object id);        
        CountryListingDto GetCountryByName(string countryName);        
        bool IsCountryExist(string countryName, int CountryId);        
        bool IsCountryExist(int CountryId);
        
        #endregion

    }
}
