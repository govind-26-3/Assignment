using Microsoft.AspNetCore.Mvc;
using MediatR;
using BoilerPlate.Application.Features.Doctors.Queries.GetAllDoctors;
using BoilerPlate.Application.DTOs;
using BoilerPlate.Application.Features.Doctors.Command.AddDoctor;
using BoilerPlate.Application.Features.Doctors.Command.UpdateDoctor;
namespace BoilerPlate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : Controller
    {
        readonly IMediator _mediatR;
        public DoctorController(IMediator mediatr)
        {
            _mediatR = mediatr;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllDoctors()
        {
            var allDoctors = await _mediatR.Send(new GetAllDoctorQuery());
            return Ok(allDoctors);
        }

        [HttpPost]
        public async Task<ActionResult> AddDoctor(AddDoctorCommand command)
        {
          var doctor =   await _mediatR.Send(command);
            return Ok(doctor);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDoctor(int id  ,DoctorListDTO command)
        {
            var doctor = await _mediatR.Send(new UpdateDoctorCommand(id,command));
            return Ok(doctor);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteDoctor(int id)
        {
            var doctor = await _mediatR.Send(id);
            return Ok(doctor);
        }
    }
}
