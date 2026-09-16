using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PQCLesson08Models.Models;

namespace PQCLesson08Models.Controllers
{
    public class PqcHomeController : Controller
    {
        private readonly ILogger<PqcHomeController> _logger;

        public PqcHomeController(ILogger<PqcHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult PqcIndex()
        {
            return View();
        }

        public IActionResult PqcPrivacy()
        {
            return View();
        }

        public IActionResult PqcAbout()
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
