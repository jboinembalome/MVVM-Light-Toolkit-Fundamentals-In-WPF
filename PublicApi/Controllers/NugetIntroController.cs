using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace PublicApi.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class NugetIntroController : ControllerBase
    {
        /// <summary>
        /// Get a sample json data for the NugetIntro project.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/nugetintro")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public object Get()
        {
            return new { Property1="This is property's value", Property2=42 };
        }
    }
}
