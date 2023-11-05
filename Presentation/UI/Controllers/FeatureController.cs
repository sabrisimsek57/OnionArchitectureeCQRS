using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class FeatureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
