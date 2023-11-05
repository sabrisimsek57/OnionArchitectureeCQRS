using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Testimonial
{
    public class RemoveTestimonialCommandRequest : IRequest
    {
        public RemoveTestimonialCommandRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
