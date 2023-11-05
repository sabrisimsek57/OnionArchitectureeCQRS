using Application.Features.Commands.Appointment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.FluentValidation
{
    public class UpdateAppointmentCommandRequestValidator : AbstractValidator<UpdateAppointmentCommandRequest>
    {
        public UpdateAppointmentCommandRequestValidator()
        {
            RuleFor(x => x.AppointmentNameSurname).MinimumLength(5).WithMessage("Ad soyad en az 5 karakter olmalıdır.");
            RuleFor(x => x.Message).MinimumLength(10).WithMessage("Mesaj en az 10 karakter olmalıdır.");
            RuleFor(x => x.CarType).MinimumLength(2).WithMessage("Araba tipi en az 2 karkter olmalıdır.");
            RuleFor(x => x.AppointmentMail).MinimumLength(7).WithMessage("Mail en az 7 karkter olmalıdır.");

        }
    }
   
}
