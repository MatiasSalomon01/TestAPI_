using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using TestAPI_.Entities;
using TestAPI_.Interfaces.Respositories;
using TestAPI_.Models;
using TestAPI_.Models.Course;

namespace TestAPI_.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CourseRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ICollection<CourseViewModel>> GetAll()
        {
            return _mapper.Map<ICollection<CourseViewModel>>(await _context.Course.ToListAsync());
        }

        public async Task<Course> GetById(int id)
        {
            return await _context.Course.Where(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Response> Create(Course course)
        {
            await _context.Course.AddAsync(course);
            await _context.SaveChangesAsync();
            return new Response(0, "Course Created Successfully", DateTime.Now);
        }

        public async Task<Response> Update(Course course)
        {
            _context.Course.Update(course);
            await _context.SaveChangesAsync();
            return new Response(0, "Course Updated Successfully", DateTime.Now);
        }

        public async Task<Response> Delete(int id)
        {
            var result = await _context.Course.FindAsync(id);
            if (result != null)
            {
                _context.Course.Remove(result);
                await _context.SaveChangesAsync();
                return new Response(0, "Course Deleted Successfully", DateTime.Now);
            }
            else
            {
                return new Response(1, "Unable to Delete Course", DateTime.Now);
            }
        }
    }
}
