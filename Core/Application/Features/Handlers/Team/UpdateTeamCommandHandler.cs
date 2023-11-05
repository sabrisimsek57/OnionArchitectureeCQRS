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
    public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommandRequest, UpdateTeamDto>
    {
        private readonly IRepository<Domain.Entities.Team> _repository;
        private readonly IMapper _mapper;

        public UpdateTeamCommandHandler(IRepository<Domain.Entities.Team> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateTeamDto> Handle(UpdateTeamCommandRequest request, CancellationToken cancellationToken)
        {
            var value = new Domain.Entities.Team
            {
                TeamDescription = request.TeamDescription,
                TeamID = request.TeamID,
                TeamNameSurname = request.TeamNameSurname,
                TeamPhoto = request.TeamPhoto
            };
            await _repository.UpdateAsync(value);
            var result = _mapper.Map<UpdateTeamDto>(value);

            return result;
        }
    }
}
