using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PqcLession10EFDb.Models;

namespace PqcLession10EFDb.Controllers
{
    public class PqcMembersController : Controller
    {
        private readonly Pqck24cnt1lession10EfdbContext _context;

        public PqcMembersController(Pqck24cnt1lession10EfdbContext context)
        {
            _context = context;
        }

        // GET: PqcMembers
        public async Task<IActionResult> Index()
        {
            return View(await _context.PqcMembers.ToListAsync());
        }

        // GET: PqcMembers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pqcMember = await _context.PqcMembers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pqcMember == null)
            {
                return NotFound();
            }

            return View(pqcMember);
        }

        // GET: PqcMembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PqcMembers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PqcUserName,PqcPassword,PqcFullName,PqcEmail,PqcPhone,PqcStatus")] PqcMember pqcMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pqcMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pqcMember);
        }

        // GET: PqcMembers/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pqcMember = await _context.PqcMembers.FindAsync(id);
            if (pqcMember == null)
            {
                return NotFound();
            }
            return View(pqcMember);
        }

        // POST: PqcMembers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,PqcUserName,PqcPassword,PqcFullName,PqcEmail,PqcPhone,PqcStatus")] PqcMember pqcMember)
        {
            if (id != pqcMember.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pqcMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PqcMemberExists(pqcMember.Id))
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
            return View(pqcMember);
        }

        // GET: PqcMembers/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pqcMember = await _context.PqcMembers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pqcMember == null)
            {
                return NotFound();
            }

            return View(pqcMember);
        }

        // POST: PqcMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var pqcMember = await _context.PqcMembers.FindAsync(id);
            if (pqcMember != null)
            {
                _context.PqcMembers.Remove(pqcMember);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PqcMemberExists(long id)
        {
            return _context.PqcMembers.Any(e => e.Id == id);
        }
    }
}
