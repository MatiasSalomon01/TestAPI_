using AutoMapper;
using TestAPI_.Entities;
using TestAPI_.Models;

namespace TestAPI_.Mapping
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityModel>();
            CreateMap<CityModel, City>();
        }
    }
}
