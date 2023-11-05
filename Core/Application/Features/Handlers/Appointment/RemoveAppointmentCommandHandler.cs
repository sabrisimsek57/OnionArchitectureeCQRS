using Application.Features.Commands.Appointment;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Appointment
{
    public class RemoveAppointmentCommandHandler : IRequestHandler<RemoveAppointmentCommandRequest>
    {
        private readonly IRepository<Domain.Entities.Appointment> _repository;

        public RemoveAppointmentCommandHandler(IRepository<Domain.Entities.Appointment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAppointmentCommandRequest request, CancellationToken cancellationToken)
        {
          var value = await _repository.GetByIdAsync(request.Id);
            if (value != null)
            {
                return;
            }
            else
            {
                await _repository.DeleteAsync(value);
            }
            
        }
    }
}
