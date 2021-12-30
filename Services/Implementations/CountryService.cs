using Dtos.Models;
using Entities.Models;
using Repository.Interfaces;
using Services.Helpers;
using Services.Interfaces;

namespace Services.Implementations
{
    public class CountryService : ICountryService
    {

        #region Fields

        private readonly IUnitOfWorkRepository unitOfWorkRepository;

        #endregion

        #region Constructors

        public CountryService(IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
        }

        #endregion

        #region Methods

        #region Sync Methods

        public bool Add(CreateCountryDto model)
        {
            Country objCountry = ObjectMapper.Mapper.Map<Country>(model);
            objCountry.CreatedDate = DateTime.UtcNow;
            objCountry.ModifiedDate = DateTime.UtcNow;
            unitOfWorkRepository.countryRepository.Add(objCountry);
            return unitOfWorkRepository.SaveChanges();
        }

        public bool Update(UpdateCountryDto model)
        {
            Country objCountry = ObjectMapper.Mapper.Map<Country>(model);
            objCountry.CreatedDate = objCountry.CreatedDate;
            objCountry.ModifiedDate = DateTime.UtcNow;
            unitOfWorkRepository.countryRepository.Update(objCountry);
            return unitOfWorkRepository.SaveChanges();
        }

        public bool Remove(CountryListingDto obj)
        {
            var country = ObjectMapper.Mapper.Map<Country>(obj);
            unitOfWorkRepository.countryRepository.Remove(country);
            return unitOfWorkRepository.SaveChanges();
        }

        public bool Remove(object id)
        {
            unitOfWorkRepository.countryRepository.Remove(id);
            return unitOfWorkRepository.SaveChanges();
        }

        public IEnumerable<CountryListingDto> GetAll()
        {
            var category = unitOfWorkRepository.countryRepository.GetAll();
            List<CountryListingDto> lst = new List<CountryListingDto>();
            foreach (var item in category)
            {
                lst.Add(ObjectMapper.Mapper.Map<CountryListingDto>(item));
            }
            return lst;
        }

        public UpdateCountryDto GetById(object id)
        {
            var country = unitOfWorkRepository.countryRepository.GetById(id);
            var countryDto = ObjectMapper.Mapper.Map<UpdateCountryDto>(country);
            return countryDto;
        }

        public CountryListingDto GetCountryByName(string countryName)
        {
            var country = unitOfWorkRepository.countryRepository.GetCountryByCountryName(countryName);
            var countryDto = ObjectMapper.Mapper.Map<CountryListingDto>(country);
            return countryDto;
        }

        public bool IsCountryExist(string countryName, int CountryId)
        {
            return unitOfWorkRepository.countryRepository.IsCountryExist(countryName, CountryId);
        }

        public bool IsCountryExist(int CountryId)
        {
            return unitOfWorkRepository.countryRepository.IsCountryExist(CountryId);
        }

        #endregion
        
        #region Async Methods

        public async Task<CountryListingDto> GetCountryByCountryNameAsync(string countryName)
        {                     
            var country = await unitOfWorkRepository.countryRepository.GetCountryByCountryNameAsync(countryName);
            var countryDto = ObjectMapper.Mapper.Map<CountryListingDto>(country);
            return countryDto;
        }

        public async Task<bool> IsCountryExistAsync(string countryName, int CountryId)
        {
            var result = await unitOfWorkRepository.countryRepository.IsCountryExistAsync(countryName, CountryId);
            return result;
        }

        public async Task<bool> IsCountryExistAsync(int CountryId)
        {
            var result = await unitOfWorkRepository.countryRepository.IsCountryExistAsync(CountryId);
            return result;
        }

        #endregion
        
        #endregion

    }
}
