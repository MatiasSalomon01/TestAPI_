using TestAPI_.Entities;
using TestAPI_.Models;
using TestAPI_.Models.Course;

namespace TestAPI_.Interfaces.Respositories
{
    public interface ICourseRepository
    {
        Task<ICollection<CourseViewModel>> GetAll();
        Task<Course> GetById(int id);
        Task<Response> Create(Course course);
        Task<Response> Update(Course course);
        Task<Response> Delete(int id);
    }
}
