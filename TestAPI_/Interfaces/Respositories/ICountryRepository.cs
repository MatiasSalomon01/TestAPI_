using TestAPI_.Entities;
using TestAPI_.Models;
using TestAPI_.Models.Country;

namespace TestAPI_.Interfaces.Respositories
{
    public interface ICountryRepository
    {
        Task<ICollection<CountryViewModel>> GetAll();
        Task<CountryViewModel> GetById(int id);
        Task<Response> Create(Country country);
        Task<Response> Update(int id, Country country);
        Task<Response> Delete(int id);
    }
}
