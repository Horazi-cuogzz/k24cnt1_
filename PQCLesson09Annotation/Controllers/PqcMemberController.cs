using Microsoft.AspNetCore.Mvc;
using PQCLesson09Annotation.Models.DataModels;
using PQCLesson09Annotation.Models.DataViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PQCLesson09Annotation.Controllers
{
    public class PqcMemberController : Controller
    {
        // Danh sách mẫu ban đầu với thông tin sinh viên
        private static List<PqcMember> _members = new List<PqcMember>
        {
            new PqcMember
            {
                PqcMemberId = 1,
                PqcUserName = "cuongpqc",
                PqcPassword = "Password123!",
                PqcFullName = "Phùng Quang Cường",
                PqcEmail = "phungquangcuong@gmail.com",
                PqcPhoneNumber = "0987654321",
                PqcBirthday = new DateTime(2004, 5, 15)
            },
            new PqcMember
            {
                PqcMemberId = 2,
                PqcUserName = "tranthib",
                PqcPassword = "SecurePass456#",
                PqcFullName = "Trần Thị B",
                PqcEmail = "tranthib@outlook.com",
                PqcPhoneNumber = "0912345678",
                PqcBirthday = new DateTime(2004, 8, 20)
            },
            new PqcMember
            {
                PqcMemberId = 3,
                PqcUserName = "levanc",
                PqcPassword = "MyPassword789$",
                PqcFullName = "Lê Văn C",
                PqcEmail = "levanc@company.com",
                PqcPhoneNumber = "0909876543",
                PqcBirthday = new DateTime(2003, 12, 10)
            }
        };

        // GET: Hiển thị danh sách thành viên
        public IActionResult Index()
        {
            return View(_members);
        }

        // GET: Xem chi tiết thành viên
        public IActionResult Details(int id)
        {
            var member = _members.FirstOrDefault(m => m.PqcMemberId == id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // GET: Form thêm mới thành viên
        public IActionResult Create()
        {
            return View();
        }

        // POST: Xử lý thêm mới
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PqcMemberRegister model)
        {
            // Bỏ qua validate các trường không bắt buộc nhập khi đăng ký
            ModelState.Remove("PqcMemberId");
            ModelState.Remove("PqcFullName");
            ModelState.Remove("PqcBirthday");

            if (ModelState.IsValid)
            {
                var newMember = new PqcMember
                {
                    PqcMemberId = _members.Any() ? _members.Max(m => m.PqcMemberId) + 1 : 1,
                    PqcUserName = model.PqcUserName,
                    PqcPassword = model.PqcPassword,
                    PqcEmail = model.PqcEmail,
                    PqcPhoneNumber = model.PqcPhoneNumber,
                    PqcFullName = string.IsNullOrWhiteSpace(model.PqcFullName) ? "Chưa cập nhật" : model.PqcFullName,
                    PqcBirthday = model.PqcBirthday ?? DateTime.Now
                };

                _members.Add(newMember);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Form cập nhật
        public IActionResult Edit(int id)
        {
            var member = _members.FirstOrDefault(m => m.PqcMemberId == id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: Xử lý cập nhật
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PqcMember model)
        {
            var existingMember = _members.FirstOrDefault(m => m.PqcMemberId == id);
            if (existingMember != null)
            {
                existingMember.PqcUserName = model.PqcUserName;
                existingMember.PqcPassword = model.PqcPassword;
                existingMember.PqcEmail = model.PqcEmail;
                existingMember.PqcPhoneNumber = model.PqcPhoneNumber;
                existingMember.PqcFullName = model.PqcFullName;
                existingMember.PqcBirthday = model.PqcBirthday;

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Form xác nhận xóa
        public IActionResult Delete(int id)
        {
            var member = _members.FirstOrDefault(m => m.PqcMemberId == id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: Xử lý xóa
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var member = _members.FirstOrDefault(m => m.PqcMemberId == id);
            if (member != null)
            {
                _members.Remove(member);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
