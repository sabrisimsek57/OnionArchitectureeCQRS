using Application.Dtos.CourseDto;
using Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class EfCourseRepository : ICourseRepository
    {
        private readonly DriverContext _driverContext;
        private readonly IMapper _mapper;

        public EfCourseRepository(DriverContext driverContext, IMapper mapper)
        {
            _driverContext = driverContext;
            _mapper = mapper;
        }

        public async Task<List<ResultCourseDto>> GetCourseList()
        {
            var values = await _driverContext.Appointments.Include(x => x.Course).ToListAsync();
            return _mapper.Map<List<ResultCourseDto>>(values);
        }
    }
}
