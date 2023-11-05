using Application.Features.Commands.Appointment;
using Application.Features.Commands.Contact;
using Application.Features.Commands.Course;
using Application.Features.Queries.About;
using Application.Features.Queries.Contact;
using Application.FluentValidation;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await _mediator.Send(new ListContactQueryRequest());
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommandRequest createContactCommand)
        {
            var validator = new CreateContactCommandRequestValidator();
            var validationResult = await validator.ValidateAsync(createContactCommand);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                return BadRequest(errors);
            }


            await _mediator.Send(createContactCommand);
            return Ok("Başarılı Oluşturuldu");




        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var values = await _mediator.Send(new GetContactQueryRequest(id));
            return Ok(values);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContact(int id)
        {
           await _mediator.Send(new RemoveContactCommandRequest(id));
            return Ok("Başarıyla silindi");
        }
        [HttpPut ]
        public async Task<IActionResult> UpdateContact(UpdateContactCommandRequest updateContactCommand)
        {
            var validator = new UpdateContactCommandRequestValidator();
            var validationResult = await validator.ValidateAsync(updateContactCommand);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                return BadRequest(errors);
            }
            await _mediator.Send(new UpdateContactCommandRequest());
            return Ok("başarıyla güncellendi");
        }
    }

}
