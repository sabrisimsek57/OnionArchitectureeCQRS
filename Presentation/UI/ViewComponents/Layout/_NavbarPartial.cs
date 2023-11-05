using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents.Layout
{
    public class _NavbarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
   
}
