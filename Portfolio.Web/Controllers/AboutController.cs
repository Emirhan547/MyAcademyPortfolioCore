using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class AboutController : Controller
    {
        private readonly PortfolioContext _context;

        public AboutController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var abouts = _context.Abouts.ToList();
            return View(abouts);
        }
        [HttpGet]
        public IActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAbout(About about)
        {
            _context.Abouts.Add(about);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteAbout (int id)
        {
            var about = _context.Abouts.Find(id);
            _context.Abouts.Remove(about);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }   
        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var about = _context.Abouts.Find(id);
            return View(about);
        }

        [HttpPost]
        public IActionResult UpdateAbout(About about)
        {
            var existingAbout = _context.Abouts.Find(about.AboutId);
            if (existingAbout == null)
                return NotFound();

            // Formdaki değerlerle güncelle
            existingAbout.Title = about.Title;
            existingAbout.Description = about.Description;
            existingAbout.BirthDate = about.BirthDate;
            existingAbout.PhoneNumber = about.PhoneNumber;
            existingAbout.City = about.City;
            existingAbout.Graduation = about.Graduation;
            existingAbout.Email = about.Email;
            existingAbout.ImageUrl = about.ImageUrl;
            existingAbout.IsAvailable = about.IsAvailable;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}   
