using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.TestimonialDto
{
    public class CreateTestimonialDto
    {
        
        public string TestimonialNamesurname { get; set; }
        public string TestimonialDescription { get; set; }
        public string TestimonialProfession { get; set; }
        public string? TestimonialImage { get; set; }
    }
}
