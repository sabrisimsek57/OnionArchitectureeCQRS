using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents.Layout
{
    public class _CarouselPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
   
}
