using Microsoft.AspNetCore.Mvc;
using PQClession2demo.Models;

namespace PQClession2demo.Controllers
{
    public class PQCProductController : Controller
    {
        public IActionResult Index()
        {
            // Đưa dữ liệu ra View
            ViewBag.name = "Phùng Quang Cường";
            ViewData["address"] = "Fit NTU";
            TempData["UNI"] = "Trường Đại Học Nguyễn Trãi";

            return View();
        }

        // Chi tiết sản phẩm
        public IActionResult GetProduct()
        {
            // Mock data
            PQCProduct pqcProduct = new PQCProduct
            {
                ProductId = "P003",
                ProductName = "Laptop Lenovo ",
                YearRelease = 2024,
                Price = 18000000
            };

            ViewData["productVD"] = pqcProduct;
            ViewBag.productVB = pqcProduct;

            return View();
        }
    }
}
