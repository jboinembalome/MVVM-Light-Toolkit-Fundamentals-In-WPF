using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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

        /// <summary>
        /// Get a picture in Content folder.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/pictures/{fileName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status206PartialContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status416RangeNotSatisfiable)]
        public IActionResult GetPicture([FromRoute][Required] string fileName)
        {
            string filePath = _webHostEnvironment.ContentRootPath + $"/Content/{fileName}";

            if (!System.IO.File.Exists(filePath))
                return NotFound("File not found.");

            return PhysicalFile(filePath, "image/png");
        }
    }
}
