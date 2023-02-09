using TestAPI_.Entities;
using TestAPI_.Models;
using TestAPI_.Models.Student;

namespace TestAPI_.Interfaces.Respositories
{
    public interface IStudentRepository
    {
        Task<ICollection<StudentViewModel>> GetAll();
        Task<StudentViewModel> GetById(int id);
        Task<Response> Create(Student student);
        Task<Response> Update(int id, Student student);
        Task<Response> Delete(int id);
    }
}
