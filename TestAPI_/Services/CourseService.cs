using AutoMapper;
using TestAPI_.Entities;
using TestAPI_.Interfaces.Respositories;
using TestAPI_.Interfaces.Services;
using TestAPI_.Models;
using TestAPI_.Models.Course;

namespace TestAPI_.Services
{
    public class CourseService : ICourseService
    {

        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        public async Task<ICollection<CourseViewModel>> GetAll()
        {
            return await _courseRepository.GetAll();
        }

        public async Task<CourseViewModel> GetById(int id)
        {
           return await _courseRepository.GetById(id);
        }

        public async Task<Response> Create(CourseModel course)
        {
            return await _courseRepository.Create(_mapper.Map<Course>(course));
        }

        public async Task<Response> Update(int id, CourseModel course)
        {
            var c = await _courseRepository.GetById(id);
            c.Description = course.Description;
            c.Id = id;
            return await _courseRepository.Update(_mapper.Map<Course>(c));
        }

        public async Task<Response> Delete(int id)
        {
            return await _courseRepository.Delete(id);
        }
    }
}
