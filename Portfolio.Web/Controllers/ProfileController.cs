using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly PortfolioContext _context;

        public ProfileController(PortfolioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Edit()
        {
            var userName = HttpContext.User.Identity?.Name;
            var user = _context.Users.FirstOrDefault(u => u.UserName == userName);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(string userName, string currentPassword, string newPassword)
        {
            var loggedUserName = HttpContext.User.Identity?.Name;
            var user = _context.Users.FirstOrDefault(u => u.UserName == loggedUserName);
            if (user == null) return NotFound();

            // Kullanıcı adı güncelleme
            if (!string.IsNullOrEmpty(userName))
            {
                user.UserName = userName;
            }

            // Şifre güncelleme isteği varsa
            if (!string.IsNullOrEmpty(newPassword))
            {
                if (user.Password == currentPassword) // mevcut şifre doğru
                {
                    user.Password = newPassword;
                }
                else
                {
                    ViewBag.Error = "Mevcut şifre yanlış!";
                    return View(user);
                }
            }

            _context.Users.Update(user);
            _context.SaveChanges();

            ViewBag.Success = "Profil başarıyla güncellendi.";
            return View(user);
        }
    }
}
