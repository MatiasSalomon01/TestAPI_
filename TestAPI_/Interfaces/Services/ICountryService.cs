using TestAPI_.Entities;
using TestAPI_.Models;
using TestAPI_.Models.Country;

namespace TestAPI_.Interfaces.Services
{
    public interface ICountryService
    {
        Task<ICollection<CountryViewModel>> GetAll();
        Task<CountryViewModel> GetById(int id);
        Task<Response> Create(CountryModel country);
        Task<Response> Update(int id, CountryModel country);
        Task<Response> Delete(int id);
    }
}
