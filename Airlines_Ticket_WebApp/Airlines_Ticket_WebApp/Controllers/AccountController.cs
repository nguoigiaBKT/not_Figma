using Microsoft.AspNetCore.Mvc;
using Airlines_Ticket_WebApp.Models;

namespace Airlines_Ticket_WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly FlightDBContext _context;

        public AccountController(FlightDBContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // TODO: Implement login logic
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Register(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // TODO: Implement registration logic
                return RedirectToAction("Login");
            }
            return View("Login", model);
        }
    }
} 