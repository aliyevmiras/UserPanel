using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserPanel.Models;

namespace UserPanel.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public AccountController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            Debug.WriteLine($"User email: {user.Email}");
            Debug.WriteLine($"User password: {user.Password}");
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

    }
}
