using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.Controllers
{
    public class UserMessageController : Controller
    {
        private readonly PortfolioContext _context;

        public UserMessageController(PortfolioContext context)
        {
            _context = context;
        }

        // Listeleme (hepsi)
        public IActionResult Index(string filter)
        {
            var messages = _context.UserMessages.AsQueryable();

            if (filter == "read")
                messages = messages.Where(m => m.IsRead == true);
            else if (filter == "unread")
                messages = messages.Where(m => m.IsRead == false);

            return View(messages.ToList());
        }

        // Mesaj Detayı
        public IActionResult Details(int id)
        {
            var message = _context.UserMessages.Find(id);

            if (message == null)
                return NotFound();

            // Okundu işaretle
            if (!message.IsRead)
            {
                message.IsRead = true;
                _context.UserMessages.Update(message);
                _context.SaveChanges();
            }

            return View(message);
        }

        // Mesaj Sil
        public IActionResult DeleteMessage(int id)
        {
            var message = _context.UserMessages.Find(id);

            if (message == null)
                return NotFound();

            _context.UserMessages.Remove(message);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
