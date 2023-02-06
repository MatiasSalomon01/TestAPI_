using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using TestAPI_.Entities;
using TestAPI_.Interfaces.Respositories;
using TestAPI_.Models;
using TestAPI_.Models.Student;

namespace TestAPI_.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public StudentRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ICollection<StudentViewModel>> GetAll()
        {
            /*return await _context.Student
                .OrderBy(c => c.Id)
                .Include(c => c.City)
                .Include(c => c.Student_Course)
                .ToListAsync();*/
            return await _context.Student.ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            return await _context.Student.Where(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Response> Create(Student student)
        {
            await _context.Student.AddAsync(student);
            await _context.SaveChangesAsync();
            return new Response(0, "Student Created Successfully", DateTime.Now);
        }

        public async Task<Response> Update(Student student)
        {
            _context.Student.Update(student);
            await _context.SaveChangesAsync();
            return new Response(0, "Student Updated Successfully", DateTime.Now);
        }

        public async Task<Response> Delete(int id)
        {
            var result = await _context.Student.FindAsync(id);
            if (result != null)
            {
                _context.Student.Remove(result);
                await _context.SaveChangesAsync();
                return new Response(0, "Student Deleted Successfully", DateTime.Now);
            }
            else
            {
                return new Response(1, "Unable to Student Country", DateTime.Now);
            }
        }
    }
}
