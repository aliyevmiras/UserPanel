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
        private readonly SignInManager<User> _signinManager;
        public AccountController(ILogger<HomeController> logger, UserManager<User> userManager, SignInManager<User> signinManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signinManager = signinManager;
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

            //if (userFound != null && userFound.PasswordHash == user.Password)
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>  Register(RegisterViewModel newUser)
        {
            if (!ModelState.IsValid)
            {
                return View(newUser);
            }

            var isEmailTaken = await _userManager.FindByEmailAsync(newUser.Email);
            var isUsernameTaken = await _userManager.FindByNameAsync(newUser.UserName);

            if(isEmailTaken != null)
            {
                ModelState.AddModelError("Email", "The email address you entered is already associated with another account. Please try logging in or use a different email address.");
            }

            if(isUsernameTaken != null)
            {
                ModelState.AddModelError("UserName", "The username you entered is already associated with another account. Please try logging in or use a different username.");
            }

            if (!ModelState.IsValid)
            {
                return View(newUser);
            }

            User user = new User() { UserName = newUser.UserName, Email = newUser.Email };
            var signupResult = await _userManager.CreateAsync(user, newUser.Password);

            if (!signupResult.Succeeded)
            {
                foreach (var error in signupResult.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View(newUser);
            }

            await _signinManager.SignInAsync(user, isPersistent: false);

            // Update last login date?

            return RedirectToAction("Index", "Home");
        }

    }
}
