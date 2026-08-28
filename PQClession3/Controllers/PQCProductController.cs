using Microsoft.AspNetCore.Mvc;
using PQClession3.Models;

namespace PQClession3.Controllers
{
    public class PQCProductController : Controller
    {
        // Dữ liệu mô phỏng phục vụ bài học, chưa sử dụng cơ sở dữ liệu.
        private readonly List<PQCProduct> _products =
        [
            new PQCProduct
            {
                PQCProductId = "PQC-001",
                PQCProductName = "Điện thoại Google Pixel 9 Pro",
                PQCYearRelease = 2024,
                PQCPrice = 28_990_000m
            },
            new PQCProduct
            {
                PQCProductId = "PQC-002",
                PQCProductName = "Điện thoại Samsung Galaxy Z Flip6",
                PQCYearRelease = 2024,
                PQCPrice = 25_990_000m
            },
            new PQCProduct
            {
                PQCProductId = "PQC-003",
                PQCProductName = "Điện thoại Xiaomi 14T Pro",
                PQCYearRelease = 2024,
                PQCPrice = 18_990_000m
            },
            new PQCProduct
            {
                PQCProductId = "PQC-004",
                PQCProductName = "Điện thoại OPPO Reno13 5G",
                PQCYearRelease = 2025,
                PQCPrice = 15_990_000m
            },
            new PQCProduct
            {
                PQCProductId = "PQC-005",
                PQCProductName = "Tai nghe Sony WF-1000XM5",
                PQCYearRelease = 2023,
                PQCPrice = 5_490_000m
            },
            new PQCProduct
            {
                PQCProductId = "PQC-006",
                PQCProductName = "Tai nghe Nothing Ear (2)",
                PQCYearRelease = 2023,
                PQCPrice = 3_990_000m
            },
            new PQCProduct
            {
                PQCProductId = "PQC-007",
                PQCProductName = "Đồng hồ Garmin Venu 3",
                PQCYearRelease = 2023,
                PQCPrice = 10_990_000m
            },
            new PQCProduct
            {
                PQCProductId = "PQC-008",
                PQCProductName = "Sạc dự phòng Anker Prime 20000mAh",
                PQCYearRelease = 2024,
                PQCPrice = 3_290_000m
            },
            new PQCProduct
            {
                PQCProductId = "PQC-009",
                PQCProductName = "Bàn phím Logitech Keys-To-Go 2",
                PQCYearRelease = 2024,
                PQCPrice = 2_190_000m
            },
            new PQCProduct
            {
                PQCProductId = "PQC-010",
                PQCProductName = "Ốp lưng Spigen Ultra Hybrid",
                PQCYearRelease = 2025,
                PQCPrice = 690_000m
            }
        ];

        // Trả dữ liệu trực tiếp dưới dạng JSON.
        public IActionResult Index()
        {
            return Json(_products);
        }

        // Truyền danh sách sang View bằng ViewData.
        public IActionResult PQCGetAllProduct()
        {
            ViewData["products"] = _products;
            return View();
        }

        // Truyền danh sách sang strongly typed View bằng Model.
        public IActionResult PQCGetListProduct()
        {
            return View(_products);
        }
    }
}
