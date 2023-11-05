using Application.Dtos.AboutDto;
using Application.Features.Commands.About;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.About
{
    public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommandRequest, UpdateAboutDto>
    {
        private readonly IRepository<Domain.Entities.About> _repository;
        private readonly IMapper _mapper;

        public UpdateAboutCommandHandler(IRepository<Domain.Entities.About> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateAboutDto> Handle(UpdateAboutCommandRequest request, CancellationToken cancellationToken)
        {
            var value = new Domain.Entities.About
            {
                AboutDescription = request.AboutDescription,
                Aboutfeature1 = request.Aboutfeature1,
                Aboutfeature2 = request.Aboutfeature2,
                Aboutfeature3 = request.Aboutfeature3,
                Aboutfeature4 = request.Aboutfeature4,
                AboutPhoto1 = request.Aboutfeature1,
                AboutPhoto2 = request.Aboutfeature2,
                AboutTitle = request.AboutTitle,
                AboutID = request.AboutID,
            };
            await _repository.UpdateAsync(value);   
            var result = _mapper.Map<UpdateAboutDto>(value);
            return result;
        }
    }
}
