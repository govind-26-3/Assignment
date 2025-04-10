using Microsoft.AspNetCore.Mvc;
using MediatR;
using BoilerPlate.Application.Features.Doctors.Queries.GetAllDoctors;
using BoilerPlate.Application.DTOs;
using BoilerPlate.Application.Features.Doctors.Command.AddDoctor;
using BoilerPlate.Application.Features.Doctors.Command.UpdateDoctor;
using BoilerPlate.Application.Features.Doctors.Command.Delete;
using Asp.Versioning;
namespace BoilerPlate.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class DoctorController : Controller
    {
        readonly IMediator _mediatR;
        readonly ILogger _logger;
        public DoctorController(IMediator mediatr, ILogger<DoctorController> logger)
        {
            _mediatR = mediatr;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllDoctors()
        {
            _logger.LogInformation("get all method is called.");
            var allDoctors = await _mediatR.Send(new GetAllDoctorQuery());
            _logger.LogInformation("get all method is completed.");
            return Ok(allDoctors);
        }

        [HttpPost]
        public async Task<ActionResult> AddDoctor(AddDoctorCommand command)
        {
            var doctor = await _mediatR.Send(command);
            return Ok(doctor);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDoctor(int id, DoctorListDTO command)
        {
            var doctor = await _mediatR.Send(new UpdateDoctorCommand(id, command));
            return Ok(doctor);

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteDoctor(int id)
        {
            var doctor = await _mediatR.Send(new DeleteDoctorByIdCommand(id));
            return Ok(doctor);
        }
    }
}
