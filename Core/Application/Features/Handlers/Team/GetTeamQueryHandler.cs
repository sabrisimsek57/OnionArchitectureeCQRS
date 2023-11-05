using Application.Dtos.TeamDto;
using Application.Features.Queries.Team;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Team
{
    public class GetTeamQueryHandler : IRequestHandler<GetTeamQueryRequest, ResultTeamDto>
    {
        private readonly IRepository<Domain.Entities.Team> _repository;
        private readonly IMapper _mapper;

        public GetTeamQueryHandler(IRepository<Domain.Entities.Team> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResultTeamDto> Handle(GetTeamQueryRequest request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<ResultTeamDto>(values);
        }
    }
}
