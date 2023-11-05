using Application.Dtos.CourseDto;
using Application.Features.Queries.Course;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Course
{
    public class ListCourseQueryHandler : IRequestHandler<ListCourseQueryRequest, List<ResultCourseDto>>
    {
        private readonly IRepository<Domain.Entities.Course> _repository;
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;

        public ListCourseQueryHandler(IRepository<Domain.Entities.Course> repository, IMapper mapper, ICourseRepository courseRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _courseRepository = courseRepository;
        }

        public async Task<List<ResultCourseDto>> Handle(ListCourseQueryRequest request, CancellationToken cancellationToken)
        {


            var value = await _repository.GetAllAsync();
            return _mapper.Map<List<ResultCourseDto>>(value);
        }
    }
}
