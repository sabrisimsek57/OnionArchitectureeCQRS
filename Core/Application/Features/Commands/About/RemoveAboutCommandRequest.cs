using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.About
{
    public class RemoveAboutCommandRequest : IRequest
    {
        public RemoveAboutCommandRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
