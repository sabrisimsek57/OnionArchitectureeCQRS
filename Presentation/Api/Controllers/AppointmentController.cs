using Application.Features.Commands.About;
using Application.Features.Commands.Appointment;
using Application.Features.Queries.About;
using Application.Features.Queries.Appointment;
using Application.FluentValidation;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> AppointmentList()
        {
            var value = await _mediator.Send(new ListAppointmentQueryRequest());
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAppointment(CreateAppointmentCommandRequest createAppointmentCommandRequest)
        {
            var validator = new CreateAppointmentCommandRequestValidator();
            var validationResult = await validator.ValidateAsync(createAppointmentCommandRequest);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                return BadRequest(errors);
            }

            await _mediator.Send(createAppointmentCommandRequest);
            return Ok("Başarıyla Kaydedildi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentById(int id)
        {
            var value = await _mediator.Send(new GetAppointmentQueryRequest(id));
            return Ok(value);

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            await _mediator.Send(new RemoveAppointmentCommandRequest(id));
            return Ok("başarıyla silinde");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAppointment(UpdateAppointmentCommandRequest updateAppointmentCommandRequest)
        {
            var validator = new UpdateAppointmentCommandRequestValidator();
            var validationResult = await validator.ValidateAsync(updateAppointmentCommandRequest);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                return BadRequest(errors);
            }
            var value = _mediator.Send(updateAppointmentCommandRequest);
            return Ok(value);
        }
    }
}
