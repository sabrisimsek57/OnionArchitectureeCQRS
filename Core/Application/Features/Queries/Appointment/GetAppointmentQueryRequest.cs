using Application.Dtos.Appointment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Appointment
{
    public class GetAppointmentQueryRequest : IRequest<ResultAppointmentDto>
    {
        public GetAppointmentQueryRequest(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
