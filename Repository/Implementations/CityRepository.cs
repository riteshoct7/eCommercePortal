using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;

namespace Repository.Implementations
{
    public class CityRepository :Repository<City>,ICityRepository
    {

        #region Fields

        private readonly AppDbContext db;

        #endregion

        #region Constructors

        public CityRepository(AppDbContext db) : base(db)
        {
            this.db = db;
        }

        #endregion

        #region Methods

        #region Sync Methods

        public City GetCityDetailsByCityId(int id)
        {
            var result = db.Cities.Include(x => x.State).ThenInclude(it => it.Country).ToList();
            return result.Where(x => x.CityId == id).FirstOrDefault();
        }

        public IEnumerable<City> GetAllCities()
        {
            return db.Cities.Include(x => x.State).ThenInclude(it => it.Country).ToList();
        }

        public City GetCityByCityName(string cityName)
        {
            return db.Cities.Where(x => x.CityName.ToUpper().Trim() == cityName.ToUpper().Trim()).FirstOrDefault();
        }

        public bool IsCityExist(string cityName, int CityId)
        {
            var result = db.Cities.Any(x => x.CityName.ToUpper().Trim() == cityName.ToUpper().Trim() && x.CityId != CityId);
            return result;
        }

        public bool IsCityExist(int CityId)
        {
            var result = db.Cities.Any(x => x.CityId == CityId);
            return result;
        }

        #endregion

        #region Async Methods
        
        public async Task<City> GetCityDetailsByCityIdAsync(int id)
        {
            dynamic  result = db.Cities.Include(x => x.State).ThenInclude(it => it.Country).ToList().Where(x => x.CityId == id).FirstOrDefault();
            return await result;
        }

        public async Task<IEnumerable<City>> GetAllCitiesAsync()
        {
            dynamic result = db.Cities.Include(x => x.State).ThenInclude(it => it.Country).ToList();
            return await result;
        }

        public async Task<City> GetCityByCityNameAsync(string cityName)
        {
            dynamic result =  db.Cities.Where(x => x.CityName.ToUpper().Trim() == cityName.ToUpper().Trim()).FirstOrDefault();
            return await  result;
        }

        public async Task<bool> IsCityExistAsync(string cityName, int CityId)
        {
            dynamic result = db.Cities.Any(x => x.CityName.ToUpper().Trim() == cityName.ToUpper().Trim() && x.CityId != CityId);
            return await  result;
        }

        public async Task<bool> IsCityExistAsync(int CityId)
        {
            dynamic  result = db.Cities.Any(x => x.CityId == CityId);
            return await result;
        }

        #endregion 

        #endregion 

        

    }
}
