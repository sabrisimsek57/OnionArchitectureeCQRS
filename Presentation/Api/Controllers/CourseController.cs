using Application.Features.Commands.Course;
using Application.Features.Commands.Team;
using Application.Features.Queries.Course;
using Application.FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> CourseList()
        {
            var values = await _mediator.Send(new ListCourseQueryRequest());
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreateCourseCommandRequest  createCourseCommandRequest)
        {
            var validator = new CreateCourseCommandRequestValidator();
            var validationResult = await validator.ValidateAsync(createCourseCommandRequest);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                return BadRequest(errors);
            }

            await _mediator.Send(createCourseCommandRequest);
           return Ok("Başarılı Oluşturuldu");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var values = await _mediator.Send(new GetCourseQueryRequest(id));
            return Ok(values);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _mediator.Send(new RemoveCourseCommandRequest(id));
            return Ok("başarılı silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCourse(UpdateCourseCommandRequest updateCourseCommandRequest)
        {
            var validator = new UpdateCourseCommandRequestValidator();
            var validationResult = await validator.ValidateAsync(updateCourseCommandRequest);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                return BadRequest(errors);
            }
            var values = await _mediator.Send(updateCourseCommandRequest);
            return Ok(values);
        }
    }
}
