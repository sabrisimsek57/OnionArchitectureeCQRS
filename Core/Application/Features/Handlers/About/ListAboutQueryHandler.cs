using Application.Dtos.AboutDto;
using Application.Features.Queries.About;
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
    public class ListAboutQueryHandler : IRequestHandler<ListAboutQueryRequest, List<ResultAboutDto>>
    {
        private readonly IRepository<Domain.Entities.About> _repository;
        private readonly IMapper _mapper;

        public ListAboutQueryHandler(IRepository<Domain.Entities.About> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ResultAboutDto>> Handle(ListAboutQueryRequest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();
            return _mapper.Map<List<ResultAboutDto>>(value);
        }
    }
}
