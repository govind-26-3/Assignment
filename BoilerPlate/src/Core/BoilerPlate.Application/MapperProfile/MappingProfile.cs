using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BoilerPlate.Application.DTOs;
using BoilerPlate.Application.Features.Doctors.Command.AddDoctor;
using BoilerPlate.Application.Features.Doctors.Command.UpdateDoctor;
using BoilerPlate.Domain.Entities;

namespace BoilerPlate.Application.MapperProfile
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Doctor, DoctorListDTO>().ReverseMap();
            //reverseMap for validation disabled and Allows Two way Mapping
            CreateMap<Doctor, AddDoctorCommand>().ReverseMap();
            CreateMap<Doctor, UpdateDoctorCommand>().ReverseMap();
                
        }
    }
}
