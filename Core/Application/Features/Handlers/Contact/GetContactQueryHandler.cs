using Application.Dtos.ContactDto;
using Application.Features.Commands.Contact;
using Application.Features.Queries.Appointment;
using Application.Features.Queries.Contact;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Contact
{
    public class GetContactQueryHandler : IRequestHandler<GetContactQueryRequest, ResultContactDto>
    {
        private readonly IRepository<Domain.Entities.Contact> _repository;
        private readonly IMapper _mapper;

        public GetContactQueryHandler(IRepository<Domain.Entities.Contact> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResultContactDto> Handle(GetContactQueryRequest request, CancellationToken cancellationToken)
        {
           var value = await _repository.GetByIdAsync(request.Id);
           return _mapper.Map<ResultContactDto>(value);

        }
    }
}
