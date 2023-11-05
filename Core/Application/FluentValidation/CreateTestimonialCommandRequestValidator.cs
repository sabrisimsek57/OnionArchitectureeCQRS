using Application.Features.Commands.Team;
using Application.Features.Commands.Testimonial;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.FluentValidation
{
    public class CreateTestimonialCommandRequestValidator : AbstractValidator<CreateTestimonialCommandRequest>
    {
        public CreateTestimonialCommandRequestValidator()
        {
            RuleFor(x => x.TestimonialNamesurname).MinimumLength(5).WithMessage("Ad soyad en az 5 karakter olmalıdır.");
            RuleFor(x => x.TestimonialDescription).MinimumLength(10).WithMessage("Açıklama en az 10 karakter olmalıdır.");

        }
    }
}
