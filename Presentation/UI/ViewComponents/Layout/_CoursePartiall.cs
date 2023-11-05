using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents.Layout
{
    public class _CoursePartiall : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
