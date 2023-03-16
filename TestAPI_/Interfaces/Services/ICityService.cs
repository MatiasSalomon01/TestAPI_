using TestAPI_.Entities;
using TestAPI_.Models;
using TestAPI_.Models.CIty;

namespace TestAPI_.Interfaces.Services
{
    public interface ICityService
    {
        Task<ICollection<CityViewModel>> GetAll();
        Task<CityViewModel> GetById(int id);
        Task<Response> Create(CityModel city);
        Task<Response> Update(int id, CityModel city);
        Task<Response> Delete(int id);
        Task<List<City>> PruebaDeInclude();
    }
}
