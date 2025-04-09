using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BoilerPlate.Application.Interfaces.Persistence;
using MediatR;

namespace BoilerPlate.Application.Features.Doctors.Command.Delete
{
    public class DeleteDoctorByIdCommandHandler : IRequestHandler<DeleteDoctorByIdCommand, int>
    {
        readonly IDoctorRepository _doctorRepository;
        readonly IMapper _mapper;

        public DeleteDoctorByIdCommandHandler(IMapper mapper,IDoctorRepository doctorRepository)
        {
            _mapper = mapper;
            _doctorRepository = doctorRepository;
        }
        public Task<int> Handle(DeleteDoctorByIdCommand request, CancellationToken cancellationToken)
        {
            return _doctorRepository.DeleteDoctorAsync(request.id);
        }
    }
}
