using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Context;

namespace Portfolio.Web.ViewComponents.Default_Index
{
    public class _DefaultResumeComponent(PortfolioContext context) :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var about = context.Abouts.FirstOrDefault(); 
            return View(about);
        }
    }
}
