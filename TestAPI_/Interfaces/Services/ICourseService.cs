using TestAPI_.Entities;
using TestAPI_.Models;
using TestAPI_.Models.Course;

namespace TestAPI_.Interfaces.Services
{
    public interface ICourseService
    {
        Task<ICollection<CourseViewModel>> GetAll();
        Task<Course> GetById(int id);
        Task<Response> Create(CourseModel course);
        Task<Response> Update(int id, CourseModel course);
        Task<Response> Delete(int id);
    }
}
