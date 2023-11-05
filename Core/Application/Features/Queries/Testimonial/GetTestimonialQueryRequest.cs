using Application.Dtos.TestimonialDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Testimonial
{
    public class GetTestimonialQueryRequest : IRequest<ResultTestimonialDto>
    {
        public GetTestimonialQueryRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
