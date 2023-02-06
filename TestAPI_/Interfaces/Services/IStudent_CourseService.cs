using TestAPI_.Entities;
using TestAPI_.Models.Student;
using TestAPI_.Models;
using TestAPI_.Models.Student_Course;

namespace TestAPI_.Interfaces.Services
{
    public interface IStudent_CourseService
    {
        Task<ICollection<StudentCourseViewModel>> GetAll();
        Task<StudentCourseViewModel> GetById(int id);
        Task<Response> Create(StudentCourseModel studentCourse);
        Task<Response> Update(StudentCourseModel studentCourse);
        Task<Response> Delete(int id);
    }
}
