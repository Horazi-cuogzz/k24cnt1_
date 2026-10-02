using Microsoft.AspNetCore.Mvc;
using PQCLession13.Models;
using System.Diagnostics;

namespace PQCLession13.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Trang Chủ - Demo Lesson 13 Layout";
            return View();
        }

       
        public IActionResult CustomerDemo()
        {
            ViewData["Title"] = "Giao Diện Khách Hàng (Customer Layout Demo)";
            return View(PqcProductData.Products);
        }

        public IActionResult About()
        {
            ViewData["Title"] = "Giới Thiệu Về Cấu Trúc Layout";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Title"] = "Thông Tin Liên Hệ";
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
