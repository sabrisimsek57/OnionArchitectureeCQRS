using Application.Features.Commands.Course;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Course
{
    public class RemoveCourseCommandHandler : IRequestHandler<RemoveCourseCommandRequest>
    {
        private readonly IRepository<Domain.Entities.Course> _repository;

        public RemoveCourseCommandHandler(IRepository<Domain.Entities.Course> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCourseCommandRequest request, CancellationToken cancellationToken)
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
