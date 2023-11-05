using Application.Dtos.TestimonialDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Testimonial
{
    public class CreateTestimonialCommandRequest : IRequest<CreateTestimonialDto>
    {
        public string TestimonialNamesurname { get; set; }
        public string TestimonialDescription { get; set; }
        public string TestimonialProfession { get; set; }
        public string? TestimonialImage { get; set; }
    }
}
