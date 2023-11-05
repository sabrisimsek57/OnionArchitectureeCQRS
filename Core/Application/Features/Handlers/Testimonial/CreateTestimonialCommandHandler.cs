using Application.Dtos.TestimonialDto;
using Application.Features.Commands.Testimonial;
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
    public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommandRequest, CreateTestimonialDto>
    {

        private readonly IRepository<Domain.Entities.Testimonial> _repository;
        private readonly IMapper _mapper;

        public CreateTestimonialCommandHandler(IRepository<Domain.Entities.Testimonial> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateTestimonialDto> Handle(CreateTestimonialCommandRequest request, CancellationToken cancellationToken)
        {
            var values = new Domain.Entities.Testimonial
            {
                TestimonialDescription = request.TestimonialDescription,
                TestimonialImage = request.TestimonialImage,
                TestimonialNamesurname = request.TestimonialNamesurname,
                TestimonialProfession = request.TestimonialProfession
            };

            await _repository.CreateAsync(values);
            var valuess = _mapper.Map<CreateTestimonialDto>(values);
            return valuess;
        }
    }
}
