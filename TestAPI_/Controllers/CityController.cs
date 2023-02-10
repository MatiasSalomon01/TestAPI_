using Microsoft.AspNetCore.Mvc;
using TestAPI_.Interfaces.Services;
using TestAPI_.Models;
using TestAPI_.Models.CIty;

namespace TestAPI_.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CityController : Controller
    {
        private readonly ICityService _services;

        public CityController(ICityService services)
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
                return NotFound(new Response(1, "Unable to Retrieve City " + id, DateTime.Now));
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CityModel city)
        {
            var result = await _services.Create(city);
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
        public async Task<IActionResult> Update(int id, CityModel city)
        {
            var result = await _services.Update(id, city);
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
        [HttpGet("get-prueba2")]
        public async Task<string> GetPrueba2()
        {
            return "Funciona 2";
        }
    }
}
