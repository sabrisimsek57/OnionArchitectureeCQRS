using Application.Dtos.ContactDto;
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
    public class ListContactQueryHandler : IRequestHandler<ListContactQueryRequest, List<ResultContactDto>>
    {
        private readonly IRepository<Domain.Entities.Contact> _repository;
        private readonly IMapper _mapper;

        public ListContactQueryHandler(IRepository<Domain.Entities.Contact> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ResultContactDto>> Handle(ListContactQueryRequest request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<ResultContactDto>>(values);
        }
    }
}
