using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents.Layout
{
    public class _ScriptPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
    
   
}
