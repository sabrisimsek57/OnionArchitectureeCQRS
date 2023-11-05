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
    public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommandRequest, UpdateAppointmentDto>
    {
        private readonly IRepository<Domain.Entities.Appointment> _repository;
        private readonly IMapper _mapper;

        public UpdateAppointmentCommandHandler(IRepository<Domain.Entities.Appointment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateAppointmentDto> Handle(UpdateAppointmentCommandRequest request, CancellationToken cancellationToken)
        {
            var value = new Domain.Entities.Appointment
            {
                AppointmentID = request.AppointmentID,
                AppointmentMail = request.AppointmentMail,
                AppointmentNameSurname = request.AppointmentNameSurname,
                CarType = request.CarType,
                CourseID = request.CourseID,
              
                Date = request.Date,
                Message = request.Message

            };
            await _repository.UpdateAsync(value);
            var result = _mapper.Map<UpdateAppointmentDto>(value);
            return result;
        }
    }
}
