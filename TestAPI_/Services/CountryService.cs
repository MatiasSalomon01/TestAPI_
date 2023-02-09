using AutoMapper;
using TestAPI_.Entities;
using TestAPI_.Interfaces.Respositories;
using TestAPI_.Interfaces.Services;
using TestAPI_.Models;
using TestAPI_.Models.Country;
using TestAPI_.Repositories;

namespace TestAPI_.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<CountryViewModel>> GetAll()
        {
            return await _countryRepository.GetAll();
        }

        public async Task<CountryViewModel> GetById(int id)
        {
            return await _countryRepository.GetById(id);
        }
        public async Task<Response> Create(CountryModel country)
        {
            return await _countryRepository.Create(_mapper.Map<Country>(country));
        }

        public async Task<Response> Update(int id, CountryModel country)
        {
            return await _countryRepository.Update(id, _mapper.Map<Country>(country));  
        }

        public async Task<Response> Delete(int id)
        {
            return await _countryRepository.Delete(id);
        }
    }
}
