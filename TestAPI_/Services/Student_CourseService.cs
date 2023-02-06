using AutoMapper;
using TestAPI_.Entities;
using TestAPI_.Interfaces.Respositories;
using TestAPI_.Interfaces.Services;
using TestAPI_.Models;
using TestAPI_.Models.Student_Course;

namespace TestAPI_.Services
{
    public class Student_CourseService : IStudent_CourseService
    {
        private readonly IStudent_CourseRepository _studentCourseRepository;
        private readonly IMapper _mapper;

        public Student_CourseService(IStudent_CourseRepository studentCourseRepository, IMapper mapper)
        {
            _studentCourseRepository = studentCourseRepository;
            _mapper = mapper;
        }
        public async Task<ICollection<StudentCourseViewModel>> GetAll()
        {
            return await _studentCourseRepository.GetAll();
        }

        public async Task<StudentCourseViewModel> GetById(int id)
        {
            return await _studentCourseRepository.GetById(id);
        }
        public async Task<Response> Create(StudentCourseModel studentCourse)
        {
            return await _studentCourseRepository.Create(_mapper.Map<Student_Course>(studentCourse));
        }

        public async Task<Response> Update(StudentCourseModel studentCourse)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
