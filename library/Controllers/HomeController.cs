using library.Data;
using library.Models;
using library.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace library.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISeedService _seedService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ISeedService seedService, ILogger<HomeController> logger)
        {
            _logger = logger;
            _seedService = seedService;
            _seedService.Seed();
        }

        public IActionResult Index()
        {
            return View();
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
