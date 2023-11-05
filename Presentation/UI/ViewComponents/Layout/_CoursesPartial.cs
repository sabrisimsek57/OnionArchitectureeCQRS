using Application.Dtos.CourseDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace UI.ViewComponents.Layout
{
    public class _CoursesPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
          
            return View();
        }
    }
   
}
