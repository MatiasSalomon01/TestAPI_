using AutoMapper;
using TestAPI_.Entities;
using TestAPI_.Interfaces.Respositories;
using TestAPI_.Interfaces.Services;
using TestAPI_.Models;
using TestAPI_.Models.CIty;

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

        public async Task<ICollection<CityViewModel>> GetAll()
        {
            return await _cityRepository.GetAll();
        }

        public async Task<CityViewModel> GetById(int id)
        {
            return await _cityRepository.GetById(id);
        }
        public async Task<Response> Create(CityModel city)
        {
            return await _cityRepository.Create(_mapper.Map<City>(city));
        }

        public async Task<Response> Update(int id, CityModel city)
        {
            return await _cityRepository.Update(id, _mapper.Map<City>(city));
        }

        public async Task<Response> Delete(int id)
        {
            return await _cityRepository.Delete(id);
        }
        public async Task<List<City>> PruebaDeInclude()
        {
            return await _cityRepository.PruebaDeInclude();
        }

        
    }
}
