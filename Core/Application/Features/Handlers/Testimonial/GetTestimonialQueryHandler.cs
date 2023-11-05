using Application.Dtos.TestimonialDto;
using Application.Features.Queries.Testimonial;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Testimonial
{
    public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQueryRequest, ResultTestimonialDto>
    {

        private readonly IRepository<Domain.Entities.Testimonial> _repository;
        private readonly IMapper _mapper;

        public GetTestimonialQueryHandler(IRepository<Domain.Entities.Testimonial> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResultTestimonialDto> Handle(GetTestimonialQueryRequest request, CancellationToken cancellationToken)
        {
           var values = await _repository.GetByIdAsync(request.Id);
           return _mapper.Map<ResultTestimonialDto>(values);
        }
    }
}
