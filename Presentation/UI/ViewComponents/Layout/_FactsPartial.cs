using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents.Layout
{
    public class _FactsPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
   
}
