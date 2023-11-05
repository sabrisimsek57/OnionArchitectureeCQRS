using Application.Dtos.AboutDto;
using Application.Features.Commands.About;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.About
{
    public class RemoveAboutCommandHandler : IRequestHandler<RemoveAboutCommandRequest>
    {
        private readonly IRepository<Domain.Entities.About> _repository;

        public RemoveAboutCommandHandler(IRepository<Domain.Entities.About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAboutCommandRequest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id); 
            if (value == null)
            {
                return;
            }
            else
            {
             await  _repository.DeleteAsync(value);
            }
        }
    }
}
