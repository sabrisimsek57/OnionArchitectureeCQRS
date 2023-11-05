using Application.Dtos.CourseDto;
using Application.Features.Commands.Course;
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
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommandRequest, CreateCourseDto>
    {
        private readonly IRepository<Domain.Entities.Course> _repository;
        private readonly IMapper _mapper;

        public CreateCourseCommandHandler(IRepository<Domain.Entities.Course> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateCourseDto> Handle(CreateCourseCommandRequest request, CancellationToken cancellationToken)
        {
            var value = new Domain.Entities.Course
            {
                CourseTime = request.CourseTime,
                CourseGrade = request.CourseGrade,
                CoursePhoto = request.CoursePhoto,
                CoursePrice = request.CoursePrice,
                CourseTitle = request.CourseTitle,
                CourseDescription = request.CourseDescription
            };
             await _repository.CreateAsync(value);
            var result = _mapper.Map<CreateCourseDto>(value);
            return result;

        }
    }
}
