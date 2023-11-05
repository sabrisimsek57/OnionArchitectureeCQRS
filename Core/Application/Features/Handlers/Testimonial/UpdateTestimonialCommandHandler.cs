using Application.Dtos.TeamDto;
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
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommandRequest, UpdateTestimonialDto>
    {

        private readonly IRepository<Domain.Entities.Testimonial> _repository;
        private readonly IMapper _mapper;

        public UpdateTestimonialCommandHandler(IRepository<Domain.Entities.Testimonial> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateTestimonialDto> Handle(UpdateTestimonialCommandRequest request, CancellationToken cancellationToken)
        {
            var value = new Domain.Entities.Testimonial
            {
                TestimonialDescription = request.TestimonialDescription,
                TestimonialImage = request.TestimonialImage,
                TestimonialNamesurname = request.TestimonialNamesurname,
                TestimonialProfession = request.TestimonialProfession,
                TestimonialID = request.TestimonialID
            };
            await _repository.UpdateAsync(value);
            var result = _mapper.Map<UpdateTestimonialDto>(value);
            return result;
        }
    }
}
