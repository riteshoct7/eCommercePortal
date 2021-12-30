using Entities.Models;

namespace Repository.Interfaces
{
    public interface ICityRepository: IRepository<City>
    {
        #region Methods

        #region Sync Methods        

        City GetCityDetailsByCityId(int id);
        IEnumerable<City> GetAllCities();
        City GetCityByCityName(string cityName);
        bool IsCityExist(string cityName, int CityId);
        bool IsCityExist(int CityId);

        #endregion

        #region AsyncMethods        

        Task<City> GetCityDetailsByCityIdAsync(int id);
        Task<IEnumerable<City>> GetAllCitiesAsync();
        Task<City> GetCityByCityNameAsync(string cityName);
        Task<bool> IsCityExistAsync(string cityName, int CityId);
        Task<bool> IsCityExistAsync(int CityId);

        #endregion 

        #endregion

    }
}
