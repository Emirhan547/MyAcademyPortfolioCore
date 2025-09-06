using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using System;
using System.Linq;

namespace Portfolio.Web.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly PortfolioContext _context;

        public StatisticsController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Mevcut kodlar
            ViewBag.projectCount = _context.Projects.Count();
            ViewBag.skillAverage = _context.Skills.Any() ? _context.Skills.Average(x => x.Percentage).ToString("0.00") : "0.00";
            ViewBag.unreadMessageCount = _context.UserMessages.Count(x => x.IsRead == false);
            ViewBag.lastMessageOwner = _context.UserMessages.OrderByDescending(x => x.UserMessageId).Select(y => y.Name).FirstOrDefault() ?? "Mesaj Yok";

            var startYear = _context.Experiences.Any() ? _context.Experiences.Min(x => x.StartYear) : DateTime.Now.Year;
            ViewBag.experienceYear = DateTime.Now.Year - startYear;

            ViewBag.companyCount = _context.Experiences.Select(x => x.Company).Distinct().Count();

            ViewBag.reviewAverage = _context.Testimonials.Any() ? _context.Testimonials.Average(x => x.Review).ToString("0.0") : "Değerlendirme Yapılmadı";
            var maxReview = _context.Testimonials.Any() ? _context.Testimonials.Max(x => x.Review) : 0;
            ViewBag.maxReviewOwner = _context.Testimonials.Any() ? _context.Testimonials.Where(x => x.Review == maxReview).Select(x => x.Name).FirstOrDefault() : "Henüz Değerlendirme Yok";

            // Yeni eklenecek count değerleri
            ViewBag.skillCount = _context.Skills.Count();                // Yetenek sayısı
            ViewBag.experienceCount = _context.Experiences.Count();      // Deneyim sayısı
            ViewBag.messageCount = _context.UserMessages.Count();        // Gelen mesaj sayısı
            ViewBag.categoryCount = _context.Categories.Count();

            return View();
        }

    }
}
