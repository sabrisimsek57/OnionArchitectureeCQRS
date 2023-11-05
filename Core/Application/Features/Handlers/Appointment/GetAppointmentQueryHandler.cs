using Application.Dtos.Appointment;
using Application.Features.Queries.Appointment;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Appointment
{
    public class GetAppointmentQueryHandler : IRequestHandler<GetAppointmentQueryRequest, ResultAppointmentDto>
    {
        private readonly IRepository<Domain.Entities.Appointment> _repository;
        private readonly IMapper _mapper;

        public GetAppointmentQueryHandler(IRepository<Domain.Entities.Appointment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResultAppointmentDto> Handle(GetAppointmentQueryRequest request, CancellationToken cancellationToken)
        {
           var value =  await _repository.GetByIdAsync(request.Id);
           return  _mapper.Map<ResultAppointmentDto>(value);
          
        }
    }
}
