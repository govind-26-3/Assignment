using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace BoilerPlate.Api.Controllers
{
   
    [ApiController]
    [ApiVersion("1")]
   [Route("api/v{version:apiVersion}/[controller]")]

    public class AppointmentController : Controller
    {
        [HttpGet("{id}")]
        public IActionResult GetV1(int id)
        {
            return Ok(new { Message = "This is version 1.0" });
        }
    }
}
