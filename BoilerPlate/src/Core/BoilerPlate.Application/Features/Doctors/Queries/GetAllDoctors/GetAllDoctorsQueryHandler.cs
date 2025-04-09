using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BoilerPlate.Application.DTOs;
using BoilerPlate.Application.Interfaces.Persistence;
using MediatR;

namespace BoilerPlate.Application.Features.Doctors.Queries.GetAllDoctors
{
    public class GetAllDoctorsQueryHandler : IRequestHandler<GetAllDoctorQuery, IEnumerable<DoctorListDTO>>
    {
        readonly IDoctorRepository _doctorRepository;
        readonly IMapper _mapper;

        public GetAllDoctorsQueryHandler(IDoctorRepository doctorRepository,IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<DoctorListDTO>> Handle(GetAllDoctorQuery request, CancellationToken cancellationToken)
        {
            var allDoctors =  await _doctorRepository.GetAllDoctorsAsync();

            var allDoctorsDto = _mapper.Map<IEnumerable<DoctorListDTO>>(allDoctors);
            return allDoctorsDto;
        }
    }
}
