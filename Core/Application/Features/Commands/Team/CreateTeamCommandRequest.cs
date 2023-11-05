using Application.Dtos.TeamDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Team
{
    public class CreateTeamCommandRequest : IRequest<CreateTeamDto> 
    {
        public string TeamNameSurname { get; set; }
        public string TeamDescription { get; set; }

        public string? TeamPhoto { get; set; }
    }
}
