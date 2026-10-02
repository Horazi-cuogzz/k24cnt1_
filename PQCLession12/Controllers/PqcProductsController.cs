using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PQCLession12.Models;

namespace PQCLession12.Controllers
{
    public class PqcProductsController : Controller
    {
        private readonly PqcAppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public PqcProductsController(PqcAppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: PqcProducts
        public async Task<IActionResult> Index(string? search, int? categoryId)
        {
            var query = _context.PqcProducts.Include(p => p.PqcCategory).AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(p => p.PqcName.Contains(search) || (p.PqcDescriptions != null && p.PqcDescriptions.Contains(search)));
                ViewBag.CurrentSearch = search;
            }

            if (categoryId.HasValue && categoryId.Value > 0)
            {
                query = query.Where(p => p.PqcCategoryId == categoryId.Value);
                ViewBag.CurrentCategoryId = categoryId.Value;
            }

            ViewData["CategoryId"] = new SelectList(await _context.PqcCategories.OrderBy(c => c.PqcName).ToListAsync(), "Id", "PqcName", categoryId);

            var list = await query.OrderByDescending(p => p.PqcCreatedDate).ToListAsync();
            return View(list);
        }

        // GET: PqcProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.PqcProducts
                .Include(p => p.PqcCategory)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: PqcProducts/Create
        public async Task<IActionResult> Create()
        {
            ViewData["PqcCategoryId"] = new SelectList(await _context.PqcCategories.OrderBy(c => c.PqcName).ToListAsync(), "Id", "PqcName");
            var product = new PqcProduct
            {
                PqcStatus = 1,
                PqcPrice = 0,
                PqcSalePrice = 0,
                PqcCreatedDate = DateTime.Now
            };
            return View(product);
        }

        // POST: PqcProducts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PqcName,PqcPrice,PqcSalePrice,PqcStatus,PqcDescriptions,PqcCategoryId")] PqcProduct product, IFormFile? imageFile)
        {
            // Bỏ qua validate navigation property
            ModelState.Remove("PqcCategory");
            ModelState.Remove("PqcImage");

            if (ModelState.IsValid)
            {
                // Xử lý upload ảnh theo hướng dẫn Lab 06
                if (imageFile != null && imageFile.Length > 0)
                {
                    string uploadFolder = Path.Combine(_environment.WebRootPath, "Product");
                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }

                    // Đổi tên file để tránh trùng lặp: pqc_{timestamp}_{filename}
                    string fileName = $"pqc_{DateTime.Now.Ticks}_{Path.GetFileName(imageFile.FileName)}";
                    string filePath = Path.Combine(uploadFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    product.PqcImage = fileName;
                }

                product.PqcCreatedDate = DateTime.Now;
                _context.Add(product);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Thêm sản phẩm '{product.PqcName}' thành công!";
                return RedirectToAction(nameof(Index));
            }

            ViewData["PqcCategoryId"] = new SelectList(await _context.PqcCategories.OrderBy(c => c.PqcName).ToListAsync(), "Id", "PqcName", product.PqcCategoryId);
            return View(product);
        }

        // GET: PqcProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.PqcProducts.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            ViewData["PqcCategoryId"] = new SelectList(await _context.PqcCategories.OrderBy(c => c.PqcName).ToListAsync(), "Id", "PqcName", product.PqcCategoryId);
            return View(product);
        }

        // POST: PqcProducts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PqcName,PqcImage,PqcPrice,PqcSalePrice,PqcStatus,PqcDescriptions,PqcCategoryId")] PqcProduct product, IFormFile? imageFile)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            ModelState.Remove("PqcCategory");
            ModelState.Remove("PqcImage");

            if (ModelState.IsValid)
            {
                try
                {
                    var existing = await _context.PqcProducts.FindAsync(id);
                    if (existing == null)
                    {
                        return NotFound();
                    }

                    // Nếu có tải ảnh mới lên thì thay thế ảnh cũ
                    if (imageFile != null && imageFile.Length > 0)
                    {
                        string uploadFolder = Path.Combine(_environment.WebRootPath, "Product");
                        if (!Directory.Exists(uploadFolder))
                        {
                            Directory.CreateDirectory(uploadFolder);
                        }

                        string fileName = $"pqc_{DateTime.Now.Ticks}_{Path.GetFileName(imageFile.FileName)}";
                        string filePath = Path.Combine(uploadFolder, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await imageFile.CopyToAsync(stream);
                        }

                        // Xóa ảnh cũ nếu có
                        if (!string.IsNullOrEmpty(existing.PqcImage))
                        {
                            string oldPath = Path.Combine(uploadFolder, existing.PqcImage);
                            if (System.IO.File.Exists(oldPath))
                            {
                                System.IO.File.Delete(oldPath);
                            }
                        }

                        existing.PqcImage = fileName;
                    }

                    existing.PqcName = product.PqcName;
                    existing.PqcPrice = product.PqcPrice;
                    existing.PqcSalePrice = product.PqcSalePrice;
                    existing.PqcStatus = product.PqcStatus;
                    existing.PqcDescriptions = product.PqcDescriptions;
                    existing.PqcCategoryId = product.PqcCategoryId;

                    _context.Update(existing);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = $"Cập nhật sản phẩm '{product.PqcName}' thành công!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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

            ViewData["PqcCategoryId"] = new SelectList(await _context.PqcCategories.OrderBy(c => c.PqcName).ToListAsync(), "Id", "PqcName", product.PqcCategoryId);
            return View(product);
        }

        // GET: PqcProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.PqcProducts
                .Include(p => p.PqcCategory)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: PqcProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.PqcProducts.FindAsync(id);
            if (product != null)
            {
                // Xóa file ảnh trong thư mục wwwroot/Product nếu có
                if (!string.IsNullOrEmpty(product.PqcImage))
                {
                    string filePath = Path.Combine(_environment.WebRootPath, "Product", product.PqcImage);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }

                _context.PqcProducts.Remove(product);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Xóa sản phẩm '{product.PqcName}' thành công!";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.PqcProducts.Any(e => e.Id == id);
        }
    }
}
