using AutoMapper;
using TestAPI_.Entities;
using TestAPI_.Interfaces.Respositories;
using TestAPI_.Interfaces.Services;
using TestAPI_.Models;

namespace TestAPI_.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityService(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<City>> GetAll()
        {
            return await _cityRepository.GetAll();
        }

        public async Task<City> GetById(int id)
        {
            return await _cityRepository.GetById(id);
        }
        public async Task<Response> Create(CityModel city)
        {
            return await _cityRepository.Create(_mapper.Map<City>(city));
        }

        public async Task<Response> Update(int id, CityModel city)
        {
            var c = await _cityRepository.GetById(id);
            c.Name = city.Name;
            c.CountryId = city.CountryId;
            return await _cityRepository.Update(c);
        }

        public async Task<Response> Delete(int id)
        {
            return await _cityRepository.Delete(id);
        }
    }
}
