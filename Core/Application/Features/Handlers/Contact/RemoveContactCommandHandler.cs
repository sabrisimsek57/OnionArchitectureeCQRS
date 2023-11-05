using Application.Features.Commands.Contact;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Contact
{
    public class RemoveContactCommandHandler : IRequestHandler<RemoveContactCommandRequest>
    {
        private readonly IRepository<Domain.Entities.Contact> _repository;

        public RemoveContactCommandHandler(IRepository<Domain.Entities.Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveContactCommandRequest request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            if (values != null)
            {
                return;
            }
            else
            {
                await _repository.DeleteAsync(values);
            }
        }
    }
}
