using AutoMapper;
using TestAPI_.Entities;
using TestAPI_.Models.Country;

namespace TestAPI_.Mapping
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryModel>();
            CreateMap<CountryModel, Country>();

            CreateMap<Country, CountryViewModel>();
        }
    }
}
