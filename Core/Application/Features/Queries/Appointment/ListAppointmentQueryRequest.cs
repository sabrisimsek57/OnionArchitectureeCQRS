using Application.Dtos.Appointment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Appointment
{
    public class ListAppointmentQueryRequest : IRequest<List<ResultAppointmentDto>>
    {
    }
}
