using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
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
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public AccountController(ILogger<HomeController> logger, UserManager<User> userManager, SignInManager<User> signinManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signinManager = signinManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if(!ModelState.IsValid)
            {
                return View(user);
            }

            var userFound = await _userManager.FindByEmailAsync(user.Email);

            if(userFound == null)
            {
                ModelState.AddModelError("Email or password", "The email address or password you entered is incorrect. Please try again, or use the \"Forgot Password\" link to reset your password.");
            }

            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var signinResult = await _signinManager.PasswordSignInAsync(userFound.UserName, user.Password, true, false);

            if (!signinResult.Succeeded)
            {
                ModelState.AddModelError("Email or password", "The email address or password you entered is incorrect. Please try again, or use the \"Forgot Password\" link to reset your password.");
                return View(user);
            }

            userFound.LastLoginDate = DateTime.UtcNow;
            await _userManager.UpdateAsync(userFound);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel newUser)
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

            var defaultRole = await _roleManager.FindByNameAsync("User");

            if (defaultRole == null)
            {
                // TODO: add logging to this error because we don't want to expose error about missing default role in the view
                ModelState.AddModelError(string.Empty, "An error occurred while creating your account. Please try again later.");
                return View(newUser);
            }

            var roleResult = await _userManager.AddToRoleAsync(user, defaultRole.Name);

            await _signinManager.SignInAsync(user, isPersistent: false);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Info(string userName)
        {
            // TODO: rewrite this method using as argument the userId instead of the username although username is unique too. 

            var user = await _userManager.FindByNameAsync(userName);
            var roles = await _userManager.GetRolesAsync(user);

            var userinfo = new UserInfoViewModel()
            {
                Email = user.Email,
                UserName = user.UserName,
                RegistrationDate = user.RegistrationDate,
                LastLoginDate = user.LastLoginDate,
                Status = user.Status,
                Roles = roles.ToArray()
            };

            return View(userinfo);
        }
    }
}
