using Application.Dtos.AboutDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.About
{
    public class GetAboutQueryRequest : IRequest<ResultAboutDto>
    {
        public GetAboutQueryRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
