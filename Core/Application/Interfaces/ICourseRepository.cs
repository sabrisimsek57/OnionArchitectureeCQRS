using Application.Dtos.CourseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<ResultCourseDto>> GetCourseList();
      
    }
}
