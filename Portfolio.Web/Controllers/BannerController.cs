using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.Controllers
{
    public class BannerController : Controller
    {
        private readonly PortfolioContext _context;

        public BannerController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var banners = _context.Banners.ToList();
            return View(banners);
        }
        [HttpGet]
        public IActionResult AddBanner()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBanner(Entities.Banner banner)
        {
            _context.Banners.Add(banner);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteBanner(int id)
        {
            var banner = _context.Banners.Find(id);
            _context.Banners.Remove(banner);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateBanner(int id)
        {
            var banner = _context.Banners.Find(id);
            return View(banner);
        }
        [HttpPost]
        public IActionResult UpdateBanner(Entities.Banner banner)
        {
            _context.Banners.Update(banner);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
