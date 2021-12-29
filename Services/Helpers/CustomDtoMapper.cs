using AutoMapper;
using Dtos.Models;
using Dtos.ViewModels;
using Entities.Models;

namespace Services.Helpers
{
    public class CustomDtoMapper : Profile
    {

        #region Constuctors

        public CustomDtoMapper()
        {
            CreateMap<Category, CategoryListingDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<ApplicationUser, RegisterViewModel>().ReverseMap();
            CreateMap<ContactUs, ContactUsListingDto>().ReverseMap();
            CreateMap<ContactUs, CreateContactUsDto>().ReverseMap();
            CreateMap<ContactUs, UpdateContactUsDto>().ReverseMap();
            CreateMap<Country, CountryListingDto>().ReverseMap();
            CreateMap<Country, CreateCountryDto>().ReverseMap();
            CreateMap<Country, UpdateCountryDto>().ReverseMap();
            CreateMap<State, StateListingDto>().ReverseMap();
            CreateMap<State, CreateStateDto>().ReverseMap();
            CreateMap<State, UpdateStateDto>().ReverseMap();
            CreateMap<City, CityListingDto>().ReverseMap();
            CreateMap<City, CreateCityDto>().ReverseMap();
            CreateMap<City, UpdateCityDto>().ReverseMap();
        } 

        #endregion

    }
}
