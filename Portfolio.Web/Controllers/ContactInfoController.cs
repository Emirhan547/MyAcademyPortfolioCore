using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class ContactInfoController : Controller
    {
        private readonly PortfolioContext _context;

        public ContactInfoController(PortfolioContext portfolioContext)
        {
            _context = portfolioContext;
        }

        public IActionResult Index()
        {
            var contactInfos = _context.ContactInfos.ToList();
            return View(contactInfos);
        }
        [HttpGet]
        public IActionResult AddContactInfo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddContactInfo(ContactInfo contactInfo)
        {
            _context.Add(contactInfo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteContactInfo(int id)
        {
            var contactInfo = _context.ContactInfos.Find(id);
            _context.ContactInfos.Remove(contactInfo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateContactInfo(int id)
        {
            var contactInfo = _context.ContactInfos.Find(id);
            return View(contactInfo);
        }
        [HttpPost]
        public IActionResult UpdateContactInfo(ContactInfo contactInfo)
        {
            _context.Update(contactInfo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
