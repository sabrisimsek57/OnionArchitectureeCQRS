﻿using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Course
{
    public class RemoveCourseCommandRequest : IRequest  
    {
        public RemoveCourseCommandRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
