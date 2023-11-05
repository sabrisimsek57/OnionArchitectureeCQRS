using Application.Dtos.TeamDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace UI.ViewComponents.Layout
{
    public class _TeamPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _TeamPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            var client =  _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7257/api/Team");
            if(responsemessage.IsSuccessStatusCode)
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var valıe = JsonConvert.DeserializeObject<List<ResultTeamDto>>(jsondata);
                
                var v4 = valıe.Take(4).ToList();    
                return View (v4);

            }
            return View ();
        }
    }
   
}
