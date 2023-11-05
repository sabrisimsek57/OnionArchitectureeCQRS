using Application.Dtos.ContactDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Contact
{
    public class GetContactQueryRequest : IRequest<ResultContactDto>
    {
        public GetContactQueryRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
