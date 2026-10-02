using Microsoft.AspNetCore.Mvc;
using PQCLession13.Models;

namespace PQCLession13.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Bảng Điều Khiển Quản Trị (Admin Dashboard)";
            ViewBag.TotalProducts = PqcProductData.Products.Count;
            ViewBag.ActiveProducts = PqcProductData.Products.Count(p => p.PqcStatus);
            ViewBag.TotalValue = PqcProductData.Products.Sum(p => p.PqcPrice);

            return View(PqcProductData.Products.Take(4).ToList());
        }
    }
}
