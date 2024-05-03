using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserPanel.Models;

namespace UserPanel.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ApplicationContext _db;
		public HomeController(ILogger<HomeController> logger, ApplicationContext db)
		{
			_logger = logger;
			_db = db;
		}

		public IActionResult Index()
		{
			return View(_db.Users);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
