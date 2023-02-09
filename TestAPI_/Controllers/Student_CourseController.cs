using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestAPI_.Interfaces.Services;
using TestAPI_.Models;
using TestAPI_.Models.Student_Course;

namespace TestAPI_.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Student_CourseController : Controller
    {
        private readonly IStudent_CourseService _student_CourseService;
        public Student_CourseController(IMapper mapper, IStudent_CourseService student_CourseService)
        {
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
            var result = await _student_CourseService.GetById(id);
            if (result == null)
            {
                return NotFound(new Response(1, "Unable to Retrieve Student_Course " + id, DateTime.Now));
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] StudentCourseModel studentCourse)
        {
            var result = await _student_CourseService.Create(studentCourse);
            if (0.Equals(result.Status))
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> Update(int id, StudentCourseModel studentCourse)
        {
            var result = await _student_CourseService.Update(id, studentCourse);

            if (0.Equals(result.Status))
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _student_CourseService.Delete(id);
            if (0.Equals(result.Status))
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
