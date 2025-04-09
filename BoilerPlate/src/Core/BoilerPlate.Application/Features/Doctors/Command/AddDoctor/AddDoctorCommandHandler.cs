using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BoilerPlate.Application.DTOs;
using BoilerPlate.Application.Interfaces.Persistence;
using BoilerPlate.Domain.Entities;
using MediatR;

namespace BoilerPlate.Application.Features.Doctors.Command.AddDoctor
{
    public class AddDoctorCommandHandler : IRequestHandler<AddDoctorCommand, int>
    {
        readonly IDoctorRepository _doctorRepository;
        readonly IMapper _mapper;
        public AddDoctorCommandHandler(IDoctorRepository doctorRepository, IMapper mapper)
        {

            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }


        public Task<int> Handle(AddDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = _mapper.Map<Doctor>(request);
            return _doctorRepository.AddDoctorAsync(doctor);


        }
    }
}
