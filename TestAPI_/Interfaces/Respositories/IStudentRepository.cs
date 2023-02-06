using TestAPI_.Entities;
using TestAPI_.Models;
using TestAPI_.Models.Student;

namespace TestAPI_.Interfaces.Respositories
{
    public interface IStudentRepository
    {
        Task<ICollection<StudentViewModel>> GetAll();
        Task<Student> GetById(int id);
        Task<Response> Create(Student student);
        Task<Response> Update(Student student);
        Task<Response> Delete(int id);
    }
}
