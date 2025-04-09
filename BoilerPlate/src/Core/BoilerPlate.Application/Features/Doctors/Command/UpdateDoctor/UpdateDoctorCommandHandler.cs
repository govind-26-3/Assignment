using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BoilerPlate.Application.Exceptions;
using BoilerPlate.Application.Interfaces.Persistence;
using BoilerPlate.Domain.Entities;
using MediatR;

namespace BoilerPlate.Application.Features.Doctors.Command.UpdateDoctor
{
    public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, int>
    {
        readonly IDoctorRepository _repository;
        readonly IMapper _mapper;

        public UpdateDoctorCommandHandler(IDoctorRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public Task<int> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {

            var findStatus = _mapper.Map<Doctor>(request.updateDoctor);
            return _repository.UpdateDoctorAsync(request.id,findStatus);
            
        }
    }
}
