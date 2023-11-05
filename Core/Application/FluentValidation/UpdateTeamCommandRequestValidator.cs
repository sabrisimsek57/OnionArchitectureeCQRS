using Application.Features.Commands.Team;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.FluentValidation
{
    public class UpdateTeamCommandRequestValidator : AbstractValidator<UpdateTeamCommandRequest>
    {
        public UpdateTeamCommandRequestValidator()
        {
            RuleFor(x => x.TeamNameSurname).MinimumLength(5).WithMessage("Ad soyad en az 5 karakter olmalıdır.");
            RuleFor(x => x.TeamDescription).MinimumLength(10).WithMessage("Açıklama en az 10 karakter olmalıdır.");

        }
    }
}
