using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using TestAPI_.Interfaces.Services;
using TestAPI_.Models;
using TestAPI_.Models.Course;

namespace TestAPI_.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly ICourseService _services;

        public CourseController(ICourseService services)
        {
            _services = services;
        }
        [HttpGet("get_all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _services.GetAll());
        }

        [HttpGet("get/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _services.GetById(id);

            if (result == null)
            {
                return NotFound(new Response(1, "Unable to Retrieve COurse " + id, DateTime.Now));
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CourseModel course)
        {
            var result = await _services.Create(course);
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
        public async Task<IActionResult> Update(int id, CourseModel course)
        {
            var result = await _services.Update(id, course);
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
            var result = await _services.Delete(id);
            if (0.Equals(result.Status))
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
    }
}
