using Dtos.Models;

namespace Services.Interfaces
{
    public interface ICityService
    {

        #region Methods

        #region  Sync Methods

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

        #region AsyncMethods        

        Task<UpdateCityDto> GetCityDetailsByCityIdAsync(int id);
        Task<IEnumerable<CityListingDto>> GetAllCitiesAsync();
        Task<CityListingDto> GetCityByCityNameAsync(string cityName);
        Task<bool> IsCityExistAsync(string cityName, int CityId);
        Task<bool> IsCityExistAsync(int CityId);

        #endregion 

        #endregion

    }
}
