using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoilerPlate.Application.DTOs;
using MediatR;

namespace BoilerPlate.Application.Features.Doctors.Queries.GetDoctorById
{
    public record GetDoctorByIdQuery(int doctorId):IRequest<DoctorListDTO>;
    
}
