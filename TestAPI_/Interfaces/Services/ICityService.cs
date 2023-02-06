using TestAPI_.Entities;
using TestAPI_.Models;
using TestAPI_.Models.CIty;

namespace TestAPI_.Interfaces.Services
{
    public interface ICityService
    {
        Task<ICollection<City>> GetAll();
        Task<City> GetById(int id);
        Task<Response> Create(CityModel city);
        Task<Response> Update(int id, CityModel city);
        Task<Response> Delete(int id);
    }
}
