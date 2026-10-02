using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PQCLession12.Models;

namespace PQCLession12.Controllers
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
            ViewBag.TotalCategories = await _context.PqcCategories.CountAsync();
            ViewBag.TotalProducts = await _context.PqcProducts.CountAsync();

            var recentProducts = await _context.PqcProducts
                .Include(p => p.PqcCategory)
                .Where(p => p.PqcStatus == 1)
                .OrderByDescending(p => p.PqcCreatedDate)
                .Take(8)
                .ToListAsync();

            return View(recentProducts);
        }

        // BÀI TẬP 2 LAB 06: IActionResult Product cho HomeController hiển thị sản phẩm dạng cột (Grid/Card)
        public async Task<IActionResult> Product(int? categoryId)
        {
            var query = _context.PqcProducts
                .Include(p => p.PqcCategory)
                .Where(p => p.PqcStatus == 1)
                .AsQueryable();

            if (categoryId.HasValue && categoryId.Value > 0)
            {
                query = query.Where(p => p.PqcCategoryId == categoryId.Value);
                ViewBag.CurrentCategory = await _context.PqcCategories.FindAsync(categoryId.Value);
            }

            ViewBag.Categories = await _context.PqcCategories.Where(c => c.PqcStatus == 1).ToListAsync();
            var products = await query.OrderByDescending(p => p.PqcCreatedDate).ToListAsync();
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
