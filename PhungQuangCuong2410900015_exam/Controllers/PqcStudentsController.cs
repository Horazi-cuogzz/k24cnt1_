using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhungQuangCuong2410900015_exam.Models;

namespace PhungQuangCuong2410900015_exam.Controllers
{
    public class PqcStudentsController : Controller
    {
        private readonly Pqcstudent2410900015DbContext _context;

        public PqcStudentsController(Pqcstudent2410900015DbContext context)
        {
            _context = context;
        }

        // GET: PqcStudents
        public async Task<IActionResult> Index()
        {
            return View(await _context.PqcStudents.ToListAsync());
        }

        // GET: PqcStudents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pqcStudent = await _context.PqcStudents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pqcStudent == null)
            {
                return NotFound();
            }

            return View(pqcStudent);
        }

        // GET: PqcStudents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PqcStudents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PqcName,PqcGender,PqcBirthDay,PqcEmail,PqcPhone,PqcActive")] PqcStudent pqcStudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pqcStudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pqcStudent);
        }

        // GET: PqcStudents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pqcStudent = await _context.PqcStudents.FindAsync(id);
            if (pqcStudent == null)
            {
                return NotFound();
            }
            return View(pqcStudent);
        }

        // POST: PqcStudents/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PqcName,PqcGender,PqcBirthDay,PqcEmail,PqcPhone,PqcActive")] PqcStudent pqcStudent)
        {
            if (id != pqcStudent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pqcStudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PqcStudentExists(pqcStudent.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pqcStudent);
        }

        // GET: PqcStudents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pqcStudent = await _context.PqcStudents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pqcStudent == null)
            {
                return NotFound();
            }

            return View(pqcStudent);
        }

        // POST: PqcStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pqcStudent = await _context.PqcStudents.FindAsync(id);
            if (pqcStudent != null)
            {
                _context.PqcStudents.Remove(pqcStudent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PqcStudentExists(int id)
        {
            return _context.PqcStudents.Any(e => e.Id == id);
        }
    }
}
