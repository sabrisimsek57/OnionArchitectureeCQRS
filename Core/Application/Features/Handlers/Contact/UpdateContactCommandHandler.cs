using Application.Dtos.ContactDto;
using Application.Features.Commands.Contact;
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
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommandRequest, UpdateContactDto>
    {
        private readonly IRepository<Domain.Entities.Contact> _repository;
        private readonly IMapper _mapper;

        public UpdateContactCommandHandler(IRepository<Domain.Entities.Contact> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateContactDto> Handle(UpdateContactCommandRequest request, CancellationToken cancellationToken)
        {
            var values = new Domain.Entities.Contact
            {
                ContactID = request.ContactID,
                ContactMail = request.ContactMail,
                ContactMessage = request.ContactMessage,
                ContactNameSurname = request.ContactNameSurname,
                ContactSubject = request.ContactSubject
            };
            await _repository.UpdateAsync(values);
            var result = _mapper.Map<UpdateContactDto>(values);
            return result;
        }
    }
}
