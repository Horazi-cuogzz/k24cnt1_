using Microsoft.AspNetCore.Mvc;
using PQCLession13.Models;

namespace PQCLession13.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Quản Lý Danh Sách Sản Phẩm";
            return View(PqcProductData.Products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Title"] = "Thêm Sản Phẩm Mới (Demo Layout Form)";
            return View(new PqcProduct());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PqcProduct product)
        {
            if (ModelState.IsValid)
            {
                product.Id = PqcProductData.Products.Count > 0 ? PqcProductData.Products.Max(p => p.Id) + 1 : 1;
                if (string.IsNullOrWhiteSpace(product.PqcImageUrl))
                {
                    product.PqcImageUrl = "https://images.unsplash.com/photo-1526170375885-4d8ecf77b99f?w=500&q=80";
                }
                PqcProductData.Products.Add(product);
                TempData["SuccessMessage"] = $"Đã thêm thành công sản phẩm: {product.PqcName}";
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            var product = PqcProductData.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                PqcProductData.Products.Remove(product);
                TempData["SuccessMessage"] = $"Đã xóa sản phẩm #{id}: {product.PqcName}";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
