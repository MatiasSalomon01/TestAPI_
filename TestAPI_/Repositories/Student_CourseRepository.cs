using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TestAPI_.Entities;
using TestAPI_.Interfaces.Respositories;
using TestAPI_.Models;
using TestAPI_.Models.Student;
using TestAPI_.Models.Student_Course;

namespace TestAPI_.Repositories
{
    public class Student_CourseRepository : IStudent_CourseRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public Student_CourseRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context; 
            _mapper = mapper;
        }

        public async Task<ICollection<StudentCourseViewModel>> GetAll()
        {
            return await _context.Student_Course
                .ProjectTo<StudentCourseViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<StudentCourseViewModel> GetById(int id)
        {
            return await _context.Student_Course
                .Where(c => c.Id == id)
                .ProjectTo<StudentCourseViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
           
        public async Task<Response> Create(Student_Course studentCourse)
        {
            await _context.Student_Course.AddAsync(studentCourse);
            await _context.SaveChangesAsync();
            return new Response(0, "Student_Course Created Successfully", DateTime.Now);
        }

        public async Task<Response> Update(Student_Course studentCourse)
        {
            return new Response(0, "Student_Course Updated Successfully", DateTime.Now);
        }

        public async Task<Response> Delete(int id)
        {
            return new Response(0, "Student_Course Deleted Successfully", DateTime.Now);
        }
    }
}
