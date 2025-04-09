using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BoilerPlate.Application.DTOs;
using BoilerPlate.Application.Exceptions;
using BoilerPlate.Application.Interfaces.Persistence;
using BoilerPlate.Domain.Entities;
using MediatR;

namespace BoilerPlate.Application.Features.Doctors.Queries.GetDoctorById
{
    public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, DoctorListDTO>
    {
        readonly IDoctorRepository _repository;
        readonly IMapper _mapper;

        public GetDoctorByIdQueryHandler(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _repository = doctorRepository;
            _mapper = mapper;

        }

        public async Task<DoctorListDTO> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
        {
            var doctorStatus =await _repository.GetDoctorsByIdAsync(request.doctorId);
            if (doctorStatus == null)
            {
                throw new NotFoundException("Doctor not Found");
            }
            var doctor = _mapper.Map<DoctorListDTO>(doctorStatus);
            return doctor;
        }
    }
}
