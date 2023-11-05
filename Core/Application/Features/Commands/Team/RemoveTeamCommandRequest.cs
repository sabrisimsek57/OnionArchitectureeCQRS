using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Team
{
    public class RemoveTeamCommandRequest : IRequest
    {
        public RemoveTeamCommandRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
