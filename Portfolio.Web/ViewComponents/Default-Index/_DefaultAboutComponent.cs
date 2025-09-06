using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Context;

namespace Portfolio.Web.ViewComponents.Default_Index
{
    public class _DefaultAboutComponent(PortfolioContext context) : ViewComponent
    {
         public IViewComponentResult Invoke()
        {
            var about = context.Abouts.FirstOrDefault(x => x.IsAvailable);
            return View(about);
        }
    }
}
