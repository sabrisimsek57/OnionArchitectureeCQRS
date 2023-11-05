using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents.Layout
{
    public class _FeaturesPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
   
}
