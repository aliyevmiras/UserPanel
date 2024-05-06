using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using UserPanel.Models;

namespace UserPanel.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> _userManager;
        public AccountController(ILogger<HomeController> logger, UserManager<User> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel user)
        {
            Debug.WriteLine($"User email: {user.Email}");
            Debug.WriteLine($"User password: {user.Password}");

            if(!ModelState.IsValid)
            {
                return View(user);
            }


            //var userFound = _userManager.Users.Where(u => u.Email == user.Email).FirstOrDefault();

            //if(userFound != null && userFound.Password == user.Password)
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            return View();
        }

    }
}
