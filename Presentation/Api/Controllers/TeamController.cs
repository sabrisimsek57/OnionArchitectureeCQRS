using Application.Features.Commands.Course;
using Application.Features.Commands.Team;
using Application.Features.Queries.Team;
using Application.FluentValidation;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> TeamList()
        {
            var values = await _mediator.Send(new ListTeamQueryRequest());
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTeam(CreateTeamCommandRequest createTeamCommandRequest)
        {
            var validator = new CreateTeamCommandRequestValidator();
            var validationResult = await validator.ValidateAsync(createTeamCommandRequest);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                return BadRequest(errors);
            }
            await _mediator.Send(createTeamCommandRequest);
            return Ok("Başarıyla Eklendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamById(int id)
        {
            var value = await _mediator.Send(new GetTeamQueryRequest(id));
            return Ok(value);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            await _mediator.Send(new RemoveTeamCommandRequest(id));
            return Ok("Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTeam(UpdateTeamCommandRequest updateTeamCommandRequest)
        {
            var validator = new UpdateTeamCommandRequestValidator();
            var validationResult = await validator.ValidateAsync(updateTeamCommandRequest);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                return BadRequest(errors);
            }

            var values = await _mediator.Send(updateTeamCommandRequest);
            return Ok(values);
        }
    }
}
