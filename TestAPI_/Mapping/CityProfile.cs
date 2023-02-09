using AutoMapper;
using TestAPI_.Entities;
using TestAPI_.Models.CIty;

namespace TestAPI_.Mapping
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityModel>();
            CreateMap<CityModel, City>();

            CreateMap<City, CityViewModel>();
        }
    }
}
