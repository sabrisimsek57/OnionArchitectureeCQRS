using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents.Layout
{
    public class _FooterPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
   
}
