using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using System;
using System.Linq;

namespace Portfolio.Web.ViewComponents.Default_Index
{
    public class _DefaultStatsComponent : ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultStatsComponent(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.projectCount = _context.Projects.Count();
            ViewBag.skillAvarege = _context.Skills.Count();

            var startYear = _context.Experiences.Min(x => x.StartYear);
            ViewBag.experienceYear = DateTime.Now.Year - startYear;

            ViewBag.testimonialCount = _context.Testimonials.Count();

            return View();
        }
    }
}
