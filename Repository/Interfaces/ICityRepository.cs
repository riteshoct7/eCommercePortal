using Entities.Models;

namespace Repository.Interfaces
{
    public interface ICityRepository: IRepository<City>
    {

        #region Methods        

        City GetCityDetailsByCityId(int id);
        IEnumerable<City> GetAllCities();
        City GetCityByCityName(string cityName);
        bool IsCityExist(string cityName, int CityId);
        bool IsCityExist(int CityId);

        #endregion

    }
}
