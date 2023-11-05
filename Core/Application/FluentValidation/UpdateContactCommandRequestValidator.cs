using Application.Features.Commands.Contact;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.FluentValidation
{
    public class UpdateContactCommandRequestValidator : AbstractValidator<UpdateContactCommandRequest>
    {
        public UpdateContactCommandRequestValidator()
        {
            RuleFor(x => x.ContactNameSurname).MinimumLength(5).WithMessage("Ad soyad en az 5 karakter olmalıdır.");
            RuleFor(x => x.ContactMessage).MinimumLength(10).WithMessage("Mesaj en az 10 karakter olmalıdır.");
            RuleFor(x => x.ContactMail).MinimumLength(10).WithMessage("Mail en az 10 karakter olmalıdır.");
            RuleFor(x => x.ContactSubject).MinimumLength(4).WithMessage("Başlık en az 4 karakter olmalıdır.");


        }
    }
    
}
