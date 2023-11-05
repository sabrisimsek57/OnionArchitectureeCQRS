using Application.Dtos.TestimonialDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace UI.ViewComponents.Layout
{
    public class _TestimonialPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _TestimonialPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7257/api/Testimonial");
            if(responsemessage.IsSuccessStatusCode)
            {
                var jsondata  = await responsemessage.Content.ReadAsStringAsync();
                var value =  JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsondata);

                
                return View(value);

            }
           
            return View();
        }
    }
    
}
