using Application.Features.Commands.Testimonial;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Testimonial
{
    public class RemoveTestimonialCommandHandler : IRequestHandler<RemoveTestimonialCommandRequest>
    {
        private readonly IRepository<Domain.Entities.Testimonial> _repository;

        public RemoveTestimonialCommandHandler(IRepository<Domain.Entities.Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveTestimonialCommandRequest request, CancellationToken cancellationToken)
        {
            var valuex = await _repository.GetByIdAsync(request.Id);
            if (valuex != null)
            {
                return;
            }
            else
            {
              await _repository.DeleteAsync(valuex);
            }
        }
    }
}
