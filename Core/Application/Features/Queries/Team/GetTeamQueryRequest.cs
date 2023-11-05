using Application.Dtos.TeamDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Team
{
    public class GetTeamQueryRequest : IRequest<ResultTeamDto>
    {
        public GetTeamQueryRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
