using Application.Dtos.CourseDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace UI.ViewComponents.Layout
{
    public class _CourseePartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CourseePartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async  Task< IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7257/api/Course");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultCourseDto>>(jsondata);
               ;
                return View(value);
            }
            return View();
    }
    }


}
