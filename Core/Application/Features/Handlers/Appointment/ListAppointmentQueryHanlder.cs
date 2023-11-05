using Application.Dtos.Appointment;
using Application.Features.Queries.Appointment;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Handlers.Appointment
{
    public class ListAppointmentQueryHanlder : IRequestHandler<ListAppointmentQueryRequest, List<ResultAppointmentDto>>
    {
        private readonly IRepository<Domain.Entities.Appointment> _repository;
        private readonly IMapper _mapper;

        public ListAppointmentQueryHanlder(IRepository<Domain.Entities.Appointment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ResultAppointmentDto>> Handle(ListAppointmentQueryRequest request, CancellationToken cancellationToken)
        {

            var values = await _repository.GetAllIncluding(Appointment => Appointment.Course).ToListAsync();
            return _mapper.Map<List<ResultAppointmentDto>>(values);
            //var values = await _repository.GetAllIncluding(Menu => Menu.Category).ToListAsync();
            //return _mapper.Map<List<ResultMenuDto>>(values);
        }
    }
}
