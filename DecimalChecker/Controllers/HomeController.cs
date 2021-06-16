using DecimalChecker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DecimalChecker.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private static readonly List<DecimalNumber> numbers = new();

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View("IndexNumbers", numbers);
		}

		public IActionResult Create()
		{
			return View(new DecimalNumber());
		}

		[HttpPost]
		public IActionResult Create(DecimalNumber model)
		{
			if (string.IsNullOrEmpty(model.ErrorMessage))
			{
				numbers.Add(model);
			}
			return string.IsNullOrEmpty(model.ErrorMessage) ? RedirectToAction("Index") : View(model);
		}

		public IActionResult Privacy()
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
