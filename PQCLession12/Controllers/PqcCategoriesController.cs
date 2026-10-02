using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PQCLession12.Models;

namespace PQCLession12.Controllers
{
    public class PqcCategoriesController : Controller
    {
        private readonly PqcAppDbContext _context;

        public PqcCategoriesController(PqcAppDbContext context)
        {
            _context = context;
        }

        // GET: PqcCategories
        public async Task<IActionResult> Index(string? search)
        {
            var query = _context.PqcCategories.Include(c => c.PqcProducts).AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(c => c.PqcName.Contains(search));
                ViewBag.CurrentSearch = search;
            }

            var list = await query.OrderByDescending(c => c.PqcCreatedDate).ToListAsync();
            return View(list);
        }

        // GET: PqcCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.PqcCategories
                .Include(c => c.PqcProducts)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: PqcCategories/Create
        public IActionResult Create()
        {
            var category = new PqcCategory
            {
                PqcStatus = 1,
                PqcCreatedDate = DateTime.Now
            };
            return View(category);
        }

        // POST: PqcCategories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PqcName,PqcStatus")] PqcCategory category)
        {
            if (ModelState.IsValid)
            {
                category.PqcCreatedDate = DateTime.Now;
                _context.Add(category);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Thêm danh mục '{category.PqcName}' thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: PqcCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.PqcCategories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: PqcCategories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PqcName,PqcStatus")] PqcCategory category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existing = await _context.PqcCategories.FindAsync(id);
                    if (existing == null)
                    {
                        return NotFound();
                    }

                    existing.PqcName = category.PqcName;
                    existing.PqcStatus = category.PqcStatus;
                    // Giữ nguyên ngày tạo ban đầu hoặc cập nhật
                    _context.Update(existing);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = $"Cập nhật danh mục '{category.PqcName}' thành công!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
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
            return View(category);
        }

        // GET: PqcCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.PqcCategories
                .Include(c => c.PqcProducts)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: PqcCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.PqcCategories
                .Include(c => c.PqcProducts)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category != null)
            {
                _context.PqcCategories.Remove(category);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Xóa danh mục '{category.PqcName}' thành công!";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.PqcCategories.Any(e => e.Id == id);
        }
    }
}
