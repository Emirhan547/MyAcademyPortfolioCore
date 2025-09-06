using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly PortfolioContext _context;

        public SocialMediaController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var socialMedias = _context.SocialMedias.ToList();
            return View(socialMedias);
        }
        public IActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia socialMedia)
        {
                _context.SocialMedias.Add(socialMedia);
                _context.SaveChanges();
                return RedirectToAction("Index");
        }
        public IActionResult DeleteSocialMedia(int id)
        {
            var socialMedia = _context.SocialMedias.Find(id);
            _context.SocialMedias.Remove(socialMedia);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var socialMedia = _context.SocialMedias.Find(id);
            return View(socialMedia);
        }
        [HttpPost]
        public IActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            _context.SocialMedias.Update(socialMedia);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
