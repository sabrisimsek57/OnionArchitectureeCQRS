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
    public class GetCourseQueryHandler : IRequestHandler<GetCourseQueryRequest, ResultCourseDto>
    {
        private readonly IRepository<Domain.Entities.Course> _repository;
        private readonly IMapper _mapper;

        public GetCourseQueryHandler(IRepository<Domain.Entities.Course> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResultCourseDto> Handle(GetCourseQueryRequest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<ResultCourseDto>(value); 
        }
    }
}
