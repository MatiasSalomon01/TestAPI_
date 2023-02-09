using TestAPI_.Entities;
using TestAPI_.Models;
using TestAPI_.Models.Student;

namespace TestAPI_.Interfaces.Services
{
    public interface IStudentService
    {
        Task<ICollection<StudentViewModel>> GetAll();
        Task<StudentViewModel> GetById(int id);
        Task<Response> Create(StudentModel student);
        Task<Response> Update(int id, StudentModel student);
        Task<Response> Delete(int id);
    }
}
