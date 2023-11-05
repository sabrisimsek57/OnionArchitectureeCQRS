using Application.Dtos.TeamDto;
using Application.Features.Queries.Team;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Team
{
    public class ListTeamQueryHandler : IRequestHandler<ListTeamQueryRequest, List<ResultTeamDto>>
    {
        private readonly IRepository<Domain.Entities.Team> _repository;
        private readonly IMapper _mapper;

        public ListTeamQueryHandler(IRepository<Domain.Entities.Team> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ResultTeamDto>> Handle(ListTeamQueryRequest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();
            return _mapper.Map<List<ResultTeamDto>>(value);
        }
    }
}
