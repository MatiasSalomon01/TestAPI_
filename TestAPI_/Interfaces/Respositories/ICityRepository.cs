using TestAPI_.Entities;
using TestAPI_.Models;
using TestAPI_.Models.CIty;

namespace TestAPI_.Interfaces.Respositories
{
    public interface ICityRepository
    {
        Task<ICollection<CityViewModel>> GetAll();
        Task<CityViewModel> GetById(int id);
        Task<Response> Create(City city);
        Task<Response> Update(int id, City city);
        Task<Response> Delete(int id);
    }
}
