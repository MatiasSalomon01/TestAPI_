using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using TestAPI_.Entities;
using TestAPI_.Interfaces.Services;
using TestAPI_.Models.Student_Course;

namespace TestAPI_.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Student_CourseController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper; 
        private readonly IStudent_CourseService _student_CourseService;
        public Student_CourseController(ApplicationDbContext context, IMapper mapper, IStudent_CourseService student_CourseService)
        {
            _context = context;
            _mapper = mapper;
            _student_CourseService = student_CourseService;
        }
        [HttpGet("get_all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _student_CourseService.GetAll());
        }

        [HttpGet("get/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _student_CourseService.GetById(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] StudentCourseModel studentCourse)
        {
            return Ok(await _student_CourseService.Create(studentCourse));
        }

        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> Update(int id, StudentCourseModel studentCourse)
        {
            /*var sc = await _context.Student_Course.FindAsync(id);
            sc.StudentId = studentCourse.StudentId;
            sc.CourseId = studentCourse.CourseId;
            _context.Student_Course.Update(sc);
            await _context.SaveChangesAsync();*/
            return Ok();
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sc = await _context.Student_Course.FindAsync(id);
            _context.Student_Course.Remove(sc);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
