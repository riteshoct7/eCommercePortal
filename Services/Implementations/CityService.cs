using Dtos.Models;
using Entities.Models;
using Repository.Interfaces;
using Services.Helpers;
using Services.Interfaces;

namespace Services.Implementations
{
    public class CityService : ICityService
    {

        #region Fields

        private readonly IUnitOfWorkRepository unitOfWorkRepository;

        #endregion

        #region Constructors

        public CityService(IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
        }

        #endregion

        #region Methods

        public bool Add(CreateCityDto model)
        {
            City objCity = ObjectMapper.Mapper.Map<City>(model);
            unitOfWorkRepository.cityRepository.Add(objCity);
            return unitOfWorkRepository.SaveChanges();
        }

        public bool Update(UpdateCityDto model)
        {
            City objCity = ObjectMapper.Mapper.Map<City>(model);
            unitOfWorkRepository.cityRepository.Update(objCity);
            return unitOfWorkRepository.SaveChanges();
        }

        public bool Remove(CityListingDto obj)
        {
            City objCity = ObjectMapper.Mapper.Map<City>(obj);
            unitOfWorkRepository.cityRepository.Remove(objCity);
            return unitOfWorkRepository.SaveChanges();
        }

        public bool Remove(object id)
        {
            unitOfWorkRepository.cityRepository.Remove(id);
            return unitOfWorkRepository.SaveChanges();
        }

        public UpdateCityDto GetById(object id)
        {
            var city = unitOfWorkRepository.cityRepository.GetById(id);
            var cityDto = ObjectMapper.Mapper.Map<UpdateCityDto>(city);
            return cityDto;
        }

        public IEnumerable<CityListingDto> GetAll()
        {
            var city = unitOfWorkRepository.cityRepository.GetAll();
            List<CityListingDto> lst = new List<CityListingDto>();
            foreach (var item in city)
            {
                lst.Add(ObjectMapper.Mapper.Map<CityListingDto>(item));
            }
            return lst;
        }

        public IEnumerable<CityListingDto> GetAllCities()
        {
            var cities = unitOfWorkRepository.cityRepository.GetAllCities();
            var lstCitiesDTO = new List<CityListingDto>();
            foreach (var item in cities)
            {
                lstCitiesDTO.Add(ObjectMapper.Mapper.Map<CityListingDto>(item));
            }
            return lstCitiesDTO;
        }

        public CityListingDto GetCityByCityName(string cityName)
        {
            var city = unitOfWorkRepository.cityRepository.GetCityByCityName(cityName);
            var cityDto = ObjectMapper.Mapper.Map<CityListingDto>(city);
            return cityDto;
        }

        public bool IsCityExist(string cityName, int CityId)
        {
            return unitOfWorkRepository.cityRepository.IsCityExist(cityName, CityId);
        }

        public bool IsCityExist(int CityId)
        {
            return unitOfWorkRepository.cityRepository.IsCityExist(CityId);
        }

        public UpdateCityDto GetCityDetailsByCityId(int id)
        {
            var city =  unitOfWorkRepository.cityRepository.GetCityDetailsByCityId(id);
            var cityDto = ObjectMapper.Mapper.Map<UpdateCityDto>(city);
            cityDto.CountryId = city.State.CountryId;
            return cityDto;
        }

        #endregion

    }
}
