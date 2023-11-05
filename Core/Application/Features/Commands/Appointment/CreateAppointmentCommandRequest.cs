using Application.Dtos.Appointment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Appointment
{
    public class CreateAppointmentCommandRequest : IRequest<CreateAppointmentDto>
    {
        public string AppointmentNameSurname { get; set; }
        public string AppointmentMail { get; set; }
       
        public string CarType { get; set; }
        public string Message { get; set; }
        public DateTime? Date { get; set; }

        public int CourseID { get; set; }
    }
}
