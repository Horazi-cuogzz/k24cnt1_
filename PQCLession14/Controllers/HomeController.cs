using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PQCLession14.Models;
using System.Diagnostics;

namespace PQCLession14.Controllers
{
    public class HomeController : Controller
    {
        private readonly PqcAppDbContext _context;

        public HomeController(PqcAppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.Include(p => p.Category).ToListAsync();
            return View(products);
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
