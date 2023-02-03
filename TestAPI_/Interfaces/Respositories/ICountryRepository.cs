using TestAPI_.Entities;
using TestAPI_.Models;

namespace TestAPI_.Interfaces.Respositories
{
    public interface ICountryRepository
    {
        Task<ICollection<Country>> GetAll();
        Task<Country> GetById(int id);
        Task<Response> Create(Country country);
        Task<Response> Update(Country country);
        Task<Response> Delete(int id);
    }
}
