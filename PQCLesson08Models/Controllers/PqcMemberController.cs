using Microsoft.AspNetCore.Mvc;
using PQCLesson08Models.Models;

namespace PQCLesson08Models.Controllers
{
    public class PqcMemberController : Controller
    {
        // Mock data - PqcMember
        private static List<PqcMember> _members = new List<PqcMember>()
        {
            new PqcMember
            {
                PqcMemberId = Guid.NewGuid().ToString(),
                PqcUserName = "cuongpqc",
                PqcPassword = "Password123!",
                PqcFullName = "Phùng Quang Cường",
                PqcEmail = "phungquangcuong@gmail.com"
            },
            new PqcMember
            {
                PqcMemberId = Guid.NewGuid().ToString(),
                PqcUserName = "tranthib",
                PqcPassword = "SecurePass456#",
                PqcFullName = "Trần Thị B",
                PqcEmail = "tranthib@outlook.com"
            },
            new PqcMember
            {
                PqcMemberId = Guid.NewGuid().ToString(),
                PqcUserName = "levanc",
                PqcPassword = "MyPassword789$",
                PqcFullName = "Lê Văn C",
                PqcEmail = "levanc@company.com"
            }
        };

        // GET: Danh sách thành viên
        public IActionResult Index()
        {
            return View(_members);
        }

        [HttpGet]
        public IActionResult PqcCreate()
        {
            var member = new PqcMember();
            return View(member);
        }

        [HttpPost]
        public IActionResult PqcCreate(PqcMember pqcMember)
        {
            pqcMember.PqcMemberId = Guid.NewGuid().ToString();
            _members.Add(pqcMember);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult PqcEdit(string id)
        {
            var member = _members.FirstOrDefault(x => x.PqcMemberId.Equals(id));
            return View(member);
        }

        [HttpPost]
        public IActionResult PqcEdit(string id, PqcMember pqcMember)
        {
            for (int i = 0; i < _members.Count; i++)
            {
                if (_members[i].PqcMemberId == id)
                {
                    _members[i].PqcUserName = pqcMember.PqcUserName;
                    _members[i].PqcPassword = pqcMember.PqcPassword;
                    _members[i].PqcFullName = pqcMember.PqcFullName;
                    _members[i].PqcEmail = pqcMember.PqcEmail;

                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult PqcDetails(string id)
        {
            var member = _members.FirstOrDefault(x => x.PqcMemberId.Equals(id));
            return View(member);
        }

        [HttpGet]
        public IActionResult PqcDelete(string id)
        {
            var member = _members.FirstOrDefault(x => x.PqcMemberId.Equals(id));
            return View(member);
        }

        [HttpPost]
        public IActionResult PqcDeleted(string id)
        {
            foreach (var item in _members)
            {
                if (item.PqcMemberId.Equals(id))
                {
                    _members.Remove(item);
                    return RedirectToAction("Index");
                }
            }
            return View("PqcDelete");
        }
    }
}
