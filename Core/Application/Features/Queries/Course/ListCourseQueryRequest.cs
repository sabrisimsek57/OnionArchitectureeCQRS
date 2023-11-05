using Application.Dtos.CourseDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Course
{
    public class ListCourseQueryRequest : IRequest<List<ResultCourseDto>>
    {



    }
}
