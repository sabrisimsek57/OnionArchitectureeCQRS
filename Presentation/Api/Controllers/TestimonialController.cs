using Application.Features.Commands.Team;
using Application.Features.Commands.Testimonial;

using Application.Features.Queries.Testimonial;
using Application.FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestimonialController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> TestimonialList()
        {
            var values = await _mediator.Send(new ListTestimonialQueryRequest());
            return Ok(values);

        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialCommandRequest createTeamCommandRequest)
        {
            var validator = new CreateTestimonialCommandRequestValidator();
            var validationResult = await validator.ValidateAsync(createTeamCommandRequest);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                return BadRequest(errors);
            }
            await _mediator.Send(createTeamCommandRequest); 
            return Ok("başarı ile eklendi");
           
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonialById(int id)
        {
            var values = _mediator.Send(GetTestimonialById(id));
            return Ok(values);
         
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _mediator.Send(new RemoveTestimonialCommandRequest(id));
            return Ok("başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommandRequest updateTeamCommandRequest)
        {
            var validator = new UpdateTestimonialCommandRequestValidator();
            var validationResult = await validator.ValidateAsync(updateTeamCommandRequest);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                return BadRequest(errors);
            }
            await _mediator.Send(updateTeamCommandRequest);
            return Ok("başarıyla güncellendi");
        }
    }
}
