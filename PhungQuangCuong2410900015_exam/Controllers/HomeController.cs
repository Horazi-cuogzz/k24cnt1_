using Microsoft.AspNetCore.Mvc;
using PhungQuangCuong2410900015_exam.Models;
using System.Diagnostics;

namespace PhungQuangCuong2410900015_exam.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Action hiển thị thông tin sinh viên theo yêu cầu đề bài (Mục 3)
        public IActionResult PqcAbout()
        {
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
