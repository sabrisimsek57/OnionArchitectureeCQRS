using Application.Features.Commands.About;
using Application.Features.Queries.About;
using Application.FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AboutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _mediator.Send(new ListAboutQueryRequest());
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommandRequest createAboutCommandRequest)
        {
            var validator = new CreateAboutCommandRequestValidator();
            var validationResult = await validator.ValidateAsync(createAboutCommandRequest);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                return BadRequest(errors);
            }

            await _mediator.Send(createAboutCommandRequest);
            return Ok("Başarıyla Eklendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(int id)
        {
            var value = await _mediator.Send(new GetAboutQueryRequest(id));
            return Ok(value);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _mediator.Send(new RemoveAboutCommandRequest(id));
            return Ok("Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommandRequest updateAboutCommandRequest)
        {
            var validator = new UpdateAboutCommandRequestValidator();
            var validationResult = await validator.ValidateAsync(updateAboutCommandRequest);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                return BadRequest(errors);
            }
            await _mediator.Send(updateAboutCommandRequest);
            return Ok("Başarıyla Güncellendi");
        }
    }
}
