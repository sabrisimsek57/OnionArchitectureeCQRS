using Application.Dtos.TeamDto;
using Application.Features.Commands.Team;
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
    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommandRequest, CreateTeamDto>
    {
        private readonly IRepository<Domain.Entities.Team> _repository;
        private readonly IMapper _mapper;

        public CreateTeamCommandHandler(IRepository<Domain.Entities.Team> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateTeamDto> Handle(CreateTeamCommandRequest request, CancellationToken cancellationToken)
        {

            var value = new Domain.Entities.Team
            {
                TeamDescription = request.TeamDescription,
                TeamNameSurname = request.TeamNameSurname,
                TeamPhoto = request.TeamPhoto
            };
            await _repository.CreateAsync(value);
            var values = _mapper.Map<CreateTeamDto>(value);
            return values;
        }
    }
}
