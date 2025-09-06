using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.ViewComponents.Default_Index
{
    public class _DefaultEducationComponent(PortfolioContext context):ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var educations = context.Educations.FirstOrDefault();
            return View(educations);
        }
    }
}
