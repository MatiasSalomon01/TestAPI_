using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TestAPI_.Interfaces.Services;

namespace TestAPI_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _service;

        public FilesController(IFileService service)
        {
            _service = service;
        }

        [HttpPost("upload-file")]
        public async Task<IActionResult> UploadFile(IFormFile file, CancellationToken cancellationToken)
        {
            var result = await _service.UploadFile(file, cancellationToken);
            if (result.Status is (int) HttpStatusCode.BadRequest) return BadRequest(result);
            return Ok(result);
        }
    }
}
