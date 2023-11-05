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
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommandRequest, UpdateCourseDto>
    {
        private readonly IRepository<Domain.Entities.Course> _repository;
        private readonly IMapper _mapper;

        public UpdateCourseCommandHandler(IRepository<Domain.Entities.Course> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateCourseDto> Handle(UpdateCourseCommandRequest request, CancellationToken cancellationToken)
        {
            var value = new Domain.Entities.Course
            {
                CourseTime = request.CourseTime,
                CourseID = request.CourseID,
                CourseDescription = request.CourseDescription,
                CourseGrade = request.CourseGrade,
                CoursePhoto = request.CoursePhoto,
                CoursePrice = request.CoursePrice,
                CourseTitle = request.CourseTitle
            };
             await _repository.UpdateAsync(value);
            var result = _mapper.Map<UpdateCourseDto>(value);
            return result;
        }
    }
}
