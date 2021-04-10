using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PublicApi.Controllers
{
    [ApiController]
    public class PictureController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PictureController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        [Route("/api/pictures/{fileName}")]
        public IActionResult GetPicture([FromRoute][Required] string fileName)
        {
            string filePath = _webHostEnvironment.ContentRootPath + $"/Content/{fileName}";

            if (!System.IO.File.Exists(filePath))
                return NotFound("File not found.");

            return PhysicalFile(filePath, "image/png");
        }
    }
}
