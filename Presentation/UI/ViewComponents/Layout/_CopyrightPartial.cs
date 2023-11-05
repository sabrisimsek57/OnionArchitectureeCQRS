using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents.Layout
{
    public class _CopyrightPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
  
}
