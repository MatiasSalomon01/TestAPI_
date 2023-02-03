using Microsoft.AspNetCore.Mvc;
using TestAPI_.Entities;
using TestAPI_.Interfaces.Services;
using TestAPI_.Models;

namespace TestAPI_.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryService _services;

        public CountryController(ICountryService services)
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
                return NotFound(new Response(1, "Unable to Retrieve Country " + id, DateTime.Now));
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CountryModel country)
        {
           var result =  await _services.Create(country);
            if (0.Equals(result.Status))
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, CountryModel country)
        {
            var result = await _services.Update(id, country);
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
