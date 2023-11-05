using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/Error/Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
