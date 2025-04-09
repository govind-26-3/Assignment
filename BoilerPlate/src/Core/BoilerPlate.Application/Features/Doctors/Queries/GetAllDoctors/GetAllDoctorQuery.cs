using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoilerPlate.Application.DTOs;
using MediatR;

namespace BoilerPlate.Application.Features.Doctors.Queries.GetAllDoctors
{
    public record GetAllDoctorQuery : IRequest<IEnumerable<DoctorListDTO>>;
    
}
