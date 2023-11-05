using Application.Features.Commands.Team;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Team
{
    public class RemoveTeamCommandHandler : IRequestHandler<RemoveTeamCommandRequest>
    {
        private readonly IRepository<Domain.Entities.Team> _repository;

        public RemoveTeamCommandHandler(IRepository<Domain.Entities.Team> repository)
        { 
            _repository = repository;
        }

        public async Task Handle(RemoveTeamCommandRequest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value != null)
            {
                return;
            }
            else
            {
                await _repository.DeleteAsync(value);
            }

        }
    }
}
