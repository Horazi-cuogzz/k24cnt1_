using Microsoft.AspNetCore.Mvc;
using PQCLession7Models.Models.DataModels;

namespace PQCLession7Models.Controllers
{
    public class PqcMemberController : Controller
    {
        // Mock Data
        protected static List<PqcMember> _members = new List<PqcMember>
        {
            new PqcMember
            {
                PqcMemberId = Guid.NewGuid().ToString(),
                PqcUserName = "cuongpqc",
                PqcPassword = "123456",
                PqcFullName = "Phùng Quang Cường",
                PqcEmail = "phungquangcuong@gmail.com"
            },
            new PqcMember
            {
                PqcMemberId = Guid.NewGuid().ToString(),
                PqcUserName = "tranthibinh",
                PqcPassword = "123456",
                PqcFullName = "Trần Thị Bình",
                PqcEmail = "tranthibinh@example.com"
            },
            new PqcMember
            {
                PqcMemberId = Guid.NewGuid().ToString(),
                PqcUserName = "levancuong",
                PqcPassword = "123456",
                PqcFullName = "Lê Văn Cường",
                PqcEmail = "levancuong@example.com"
            },
            new PqcMember
            {
                PqcMemberId = Guid.NewGuid().ToString(),
                PqcUserName = "phamthiduyen",
                PqcPassword = "123456",
                PqcFullName = "Phạm Thị Duyên",
                PqcEmail = "phamthiduyen@example.com"
            },
            new PqcMember
            {
                PqcMemberId = Guid.NewGuid().ToString(),
                PqcUserName = "hoangminhduc",
                PqcPassword = "123456",
                PqcFullName = "Hoàng Minh Đức",
                PqcEmail = "hoangminhduc@example.com"
            }
        };

        public IActionResult Index()
        {
            return View(_members);
        }

        public IActionResult GetMember()
        {
            var member = new PqcMember
            {
                PqcMemberId = Guid.NewGuid().ToString(),
                PqcUserName = "cuongpqc",
                PqcPassword = "password123",
                PqcFullName = "Phùng Quang Cường",
                PqcEmail = "phungquangcuong@gmail.com"
            };
            return View(member);
        }

        // Đưa dữ liệu dạng List ra View
        public IActionResult GetMembers()
        {
            ViewBag.Members = _members;
            return View();
        }

        // GET: Create member
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create member
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PqcMember member)
        {
            if (ModelState.IsValid)
            {
                member.PqcMemberId = Guid.NewGuid().ToString();
                _members.Add(member);
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }
    }
}
