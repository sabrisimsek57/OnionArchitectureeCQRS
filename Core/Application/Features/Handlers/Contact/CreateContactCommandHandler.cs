using Application.Dtos.ContactDto;
using Application.Dtos.CourseDto;
using Application.Features.Commands.Contact;
using Application.Features.Commands.Course;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Contact
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommandRequest, CreateContactDto>
    {
        private readonly IRepository<Domain.Entities.Contact> _repository;
        private readonly IMapper _mapper;

        public CreateContactCommandHandler(IRepository<Domain.Entities.Contact> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateContactDto> Handle(CreateContactCommandRequest request, CancellationToken cancellationToken)
        {
            var value = new Domain.Entities.Contact
            {
                ContactMail = request.ContactMail,
                ContactMessage = request.ContactMessage,
                ContactNameSurname = request.ContactNameSurname,
                ContactSubject = request.ContactSubject
            };
            await _repository.CreateAsync(value);
            var result = _mapper.Map<CreateContactDto>(value);
            return result;
        }
    }
}
