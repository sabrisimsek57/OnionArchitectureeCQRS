using Application.Features.Commands.About;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.FluentValidation
{
    public class CreateAboutCommandRequestValidator : AbstractValidator<CreateAboutCommandRequest>
    {
        public CreateAboutCommandRequestValidator()
        {
            RuleFor(x => x.AboutTitle).MinimumLength(5).WithMessage("Başlık en az 5 karakter olmalıdır.");
            RuleFor(x => x.AboutDescription).MinimumLength(10).WithMessage("Açıklama en az 10 karakter olmalıdır.");
            RuleFor(x => x.Aboutfeature1).MinimumLength(5).WithMessage("Özellik en az 5 karkter olmalıdır.");
            RuleFor(x => x.Aboutfeature2).MinimumLength(5).WithMessage("Özellik en az 5 karkter olmalıdır.");
            RuleFor(x => x.Aboutfeature3).MinimumLength(5).WithMessage("Özellik en az 5 karkter olmalıdır.");
            RuleFor(x => x.Aboutfeature4).MinimumLength(5).WithMessage("Özellik en az 5 karkter olmalıdır.");
        }
    }
}
