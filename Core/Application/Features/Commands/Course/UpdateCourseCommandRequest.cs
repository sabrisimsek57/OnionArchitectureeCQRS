using Application.Dtos.CourseDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Course
{
    public class UpdateCourseCommandRequest : IRequest<UpdateCourseDto>
    {
        public int CourseID { get; set; }
        public string CourseTitle { get; set; }
        public string CoursePrice { get; set; }
        public string CourseDescription { get; set; }
        public string CourseGrade { get; set; }
        public string CourseTime { get; set; }

        public string? CoursePhoto { get; set; }
    }
}
