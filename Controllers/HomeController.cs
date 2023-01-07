using Microsoft.AspNetCore.Mvc;
using SpotifyPlus.Models;
using SpotifyPlus.Services;
using System.Diagnostics;

namespace SpotifyPlus.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SpotifyService _spotifyService = new SpotifyService();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _spotifyService.spotifyAuth.RefreshAuthToken();
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