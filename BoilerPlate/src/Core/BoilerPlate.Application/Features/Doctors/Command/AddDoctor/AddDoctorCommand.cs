using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoilerPlate.Application.DTOs;
using MediatR;

namespace BoilerPlate.Application.Features.Doctors.Command.AddDoctor
{
    public class AddDoctorCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Speciality { get; set; }

        public override string ToString()
        {
            return $"Doctor Added Successfully";
        }
    }
}
