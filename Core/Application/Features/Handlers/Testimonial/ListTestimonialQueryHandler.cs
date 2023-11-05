using Application.Dtos.TeamDto;

using Application.Features.Queries.Testimonial;
using Application.Interfaces;
using Application.Dtos.TestimonialDto;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Testimonial
{
    public class ListTestimonialQueryHandler : IRequestHandler<ListTestimonialQueryRequest , List<ResultTestimonialDto>>
        
    {
        private readonly IRepository<Domain.Entities.Testimonial> _repository;
        private readonly IMapper _mapper;

        public ListTestimonialQueryHandler(IRepository<Domain.Entities.Testimonial> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ResultTestimonialDto>> Handle(ListTestimonialQueryRequest request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<ResultTestimonialDto>>(values);
        }
    }
}
