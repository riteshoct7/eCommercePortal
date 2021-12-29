using Dtos.Models;

namespace Services.Interfaces
{
    public interface ICityService
    {

        #region Methods

        bool Add(CreateCityDto model);
        bool Update(UpdateCityDto model);
        bool Remove(CityListingDto obj);
        bool Remove(object id);
        UpdateCityDto GetCityDetailsByCityId(int id);
        UpdateCityDto GetById(object id);
        IEnumerable<CityListingDto> GetAll();
        IEnumerable<CityListingDto> GetAllCities();
        CityListingDto GetCityByCityName(string cityName);
        bool IsCityExist(string cityName, int CityId);
        bool IsCityExist(int CityId);
        
        #endregion  

    }
}
