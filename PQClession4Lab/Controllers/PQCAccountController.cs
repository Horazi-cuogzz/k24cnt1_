using Microsoft.AspNetCore.Mvc;
using PQClession4Lab.Models;

namespace PQClession4Lab.Controllers
{
    [Route("PQCAccount")]
    public class PQCAccountController : Controller
    {
        private readonly List<PQCAccount> _accounts =
        [
            new PQCAccount
            {
                Id = 1,
                Name = "Phùng Quang Cường",
                Email = "pqc.student@demo.local",
                Phone = "0900000001",
                Avatar = "/images/EUYJ4890.jpg",
                Address = "Hà Nội",
                Bio = "Sinh viên K24CNT1, học phần Phát triển ứng dụng WEB với công nghệ .NET.",
                Gender = 1
            },
            new PQCAccount
            {
                Id = 2,
                Name = "Nguyễn Minh Khôi",
                Email = "minhkhoi@demo.local",
                Phone = "0900000002",
                Avatar = "/images/IMG_4781.jpg",
                Address = "Quận Hà Đông, Hà Nội",
                Bio = "Yêu thích lập trình web, điện toán đám mây và đọc sách công nghệ.",
                Gender = 1,
                Birthday = new DateTime(2002, 4, 18)
            },
            new PQCAccount
            {
                Id = 3,
                Name = "Trần Ngọc Mai",
                Email = "ngocmai@demo.local",
                Phone = "0900000003",
                Avatar = "/images/IMG_3518.PNG",
                Address = "Quận Thanh Xuân, Hà Nội",
                Bio = "Quan tâm đến thiết kế giao diện, trải nghiệm người dùng và nhiếp ảnh.",
                Gender = 0,
                Birthday = new DateTime(2001, 9, 12)
            },
            new PQCAccount
            {
                Id = 4,
                Name = "Lê Gia Hân",
                Email = "giahan@demo.local",
                Phone = "0900000004",
                Avatar = "/images/IMG_20240901_162804_191.jpg",
                Address = "Thành phố Hải Phòng",
                Bio = "Thích sáng tạo nội dung số, truyền thông và khám phá những vùng đất mới.",
                Gender = 0,
                Birthday = new DateTime(2003, 2, 25)
            },
            new PQCAccount
            {
                Id = 5,
                Name = "Đỗ Hoàng Long",
                Email = "hoanglong@demo.local",
                Phone = "0900000005",
                Avatar = "/images/IMG_20240811_160805_957.jpg",
                Address = "Thành phố Đà Nẵng",
                Bio = "Đam mê dữ liệu, thể thao và đóng góp cho các dự án mã nguồn mở.",
                Gender = 1,
                Birthday = new DateTime(2000, 11, 7)
            }
        ];

        [HttpGet("", Name = "account")]
        public IActionResult PQCIndex()
        {
            ViewBag.PQCAccounts = _accounts;
            return View();
        }

        [HttpGet("ho-so-cua-toi", Name = "pqcprofile")]
        public IActionResult PQCProfile(int? id)
        {
            var account = _accounts.FirstOrDefault(item => item.Id == (id ?? 1));

            if (account is null)
            {
                return NotFound();
            }

            ViewBag.PQCAccount = account;
            return View();
        }
    }
}
