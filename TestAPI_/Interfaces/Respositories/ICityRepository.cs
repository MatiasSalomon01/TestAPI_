using TestAPI_.Entities;
using TestAPI_.Models;

namespace TestAPI_.Interfaces.Respositories
{
    public interface ICityRepository
    {
        Task<ICollection<City>> GetAll();
        Task<City> GetById(int id);
        Task<Response> Create(City city);
        Task<Response> Update(City city);
        Task<Response> Delete(int id);
    }
}
