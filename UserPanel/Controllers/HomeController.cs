using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserPanel.Models;

namespace UserPanel.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private ApplicationContext _db;
		public HomeController(ILogger<HomeController> logger, ApplicationContext db)
		{
			_logger = logger;
			_db = db;
		}

		public IActionResult Index()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
