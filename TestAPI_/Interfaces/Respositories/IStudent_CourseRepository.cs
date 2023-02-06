using TestAPI_.Entities;
using TestAPI_.Models.Student;
using TestAPI_.Models;
using TestAPI_.Models.Student_Course;

namespace TestAPI_.Interfaces.Respositories
{
    public interface IStudent_CourseRepository
    {
        Task<ICollection<StudentCourseViewModel>> GetAll();
        Task<StudentCourseViewModel> GetById(int id);
        Task<Response> Create(Student_Course student);
        Task<Response> Update(Student_Course student);
        Task<Response> Delete(int id);
    }
}
