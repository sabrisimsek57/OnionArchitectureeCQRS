using Application.Dtos.Appointment;
using Application.Features.Commands.Appointment;
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
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommandRequest, CreateAppointmentDto>
    {
        private readonly IRepository<Domain.Entities.Appointment> _repository;
        private readonly IMapper _mapper;

        public CreateAppointmentCommandHandler(IRepository<Domain.Entities.Appointment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateAppointmentDto> Handle(CreateAppointmentCommandRequest request, CancellationToken cancellationToken)
        {
            var value = new Domain.Entities.Appointment
            {
                AppointmentMail = request.AppointmentMail,
                CarType = request.CarType,
                CourseID = request.CourseID,
               
                AppointmentNameSurname = request.AppointmentNameSurname,
                Date = request.Date,
                Message = request.Message
            };
           await  _repository.CreateAsync(value);
            var result = _mapper.Map<CreateAppointmentDto>(value); 
            return result;
        }
    }
}
