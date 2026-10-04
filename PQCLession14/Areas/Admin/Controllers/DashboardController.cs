using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PQCLession14.Models;

namespace PQCLession14.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly PqcAppDbContext _context;

        public DashboardController(PqcAppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.CategoryCount = await _context.Categories.CountAsync();
            ViewBag.ProductCount = await _context.Products.CountAsync();
            ViewBag.BannerCount = await _context.Banners.CountAsync();
            ViewBag.BlogCount = await _context.Blogs.CountAsync();

            var recentProducts = await _context.Products
                .Include(p => p.Category)
                .OrderByDescending(p => p.Id)
                .Take(5)
                .ToListAsync();

            return View(recentProducts);
        }
    }
}
