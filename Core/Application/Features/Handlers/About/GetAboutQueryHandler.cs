using Application.Dtos.AboutDto;
using Application.Features.Commands.About;
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
    public class GetAboutQueryHandler : IRequestHandler<GetAboutQueryRequest, ResultAboutDto>
    {
        private readonly IRepository<Domain.Entities.About> _repository;
        private readonly IMapper _mapper;

        public GetAboutQueryHandler(IRepository<Domain.Entities.About> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResultAboutDto> Handle(GetAboutQueryRequest request, CancellationToken cancellationToken)
        {
            var value =  await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<ResultAboutDto>(value);
        }
    }
}
