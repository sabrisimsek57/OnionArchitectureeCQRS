using Application.Dtos.AboutDto;
using Application.Dtos.ContactDto;
using Application.Features.Commands.About;
using Application.Features.Commands.Contact;
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
    public class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommandRequest, CreateAboutDto>
    {
        private readonly IRepository<Domain.Entities.About> _repository;
        private readonly IMapper _mapper;

        public CreateAboutCommandHandler(IRepository<Domain.Entities.About> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateAboutDto> Handle(CreateAboutCommandRequest request, CancellationToken cancellationToken)
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
                AboutTitle = request.AboutTitle
            };
            await _repository.CreateAsync(value);
            var result = _mapper.Map<CreateAboutDto>(value);
            return result;
        }
    }
}
