using Application.Dtos.AboutDto;
using Application.Dtos.TeamDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace UI.ViewComponents.Layout
{
    public class _AboutPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7257/api/About");
            if (responsemessage.IsSuccessStatusCode) 
            { 
                var jsonData= await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                
                var v4 = values.Take(1).ToList();
                return View(v4);

            }
            return View();
        }
    }
   
}
