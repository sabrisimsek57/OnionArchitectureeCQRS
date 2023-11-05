using Application.Dtos.Appointment;
using Application.Dtos.ContactDto;
using Application.Dtos.CourseDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace UI.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AppointmentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        
        public async Task<IActionResult> Index() 
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7257/api/Course");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCourseDto>>(jsonData);
            List<SelectListItem> value2 = (from x in values
                                           select new SelectListItem
                                           {
                                               Text = x.CourseTitle,
                                            
                                               Value = x.CourseID.ToString() 
                                           }).ToList();
            ViewBag.v = value2;

            return View();
        
        }



        [HttpGet]
        public PartialViewResult Indexx()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> Indexx(CreateAppointmentDto createAppointmentDto, string selectedCourseTitle)
        {
            createAppointmentDto.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createAppointmentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7257/api/Appointment", stringContent);
            return RedirectToAction("Index", "Appointment");

        }
    }
}
