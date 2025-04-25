using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using quanLiRapPhim.Data;
using quanLiRapPhim.Models;

namespace quanLiRapPhim.Controllers
{
    public class QuanLiesController : Controller
    {
        private readonly quanLiRapPhimContext _context;

        public QuanLiesController(quanLiRapPhimContext context)
        {
            _context = context;
        }

        // GET: QuanLies
        public async Task<IActionResult> Index()
        {
            var quanLiRapPhimContext = _context.QuanLy.Include(q => q.TaiKhoan);
            return View(await quanLiRapPhimContext.ToListAsync());
        }

        // GET: QuanLies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanLy = await _context.QuanLy
                .Include(q => q.TaiKhoan)
                .FirstOrDefaultAsync(m => m.IDQuanLy == id);
            if (quanLy == null)
            {
                return NotFound();
            }

            return View(quanLy);
        }

        // GET: QuanLies/Create
        public IActionResult Create()
        {
            ViewData["Username"] = new SelectList(_context.Set<TaiKhoan>(), "Username", "Username");
            return View();
        }

        // POST: QuanLies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDQuanLy,Username")] QuanLy quanLy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quanLy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Username"] = new SelectList(_context.Set<TaiKhoan>(), "Username", "Username", quanLy.Username);
            return View(quanLy);
        }

        // GET: QuanLies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanLy = await _context.QuanLy.FindAsync(id);
            if (quanLy == null)
            {
                return NotFound();
            }
            ViewData["Username"] = new SelectList(_context.Set<TaiKhoan>(), "Username", "Username", quanLy.Username);
            return View(quanLy);
        }

        // POST: QuanLies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDQuanLy,Username")] QuanLy quanLy)
        {
            if (id != quanLy.IDQuanLy)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quanLy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuanLyExists(quanLy.IDQuanLy))
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
            ViewData["Username"] = new SelectList(_context.Set<TaiKhoan>(), "Username", "Username", quanLy.Username);
            return View(quanLy);
        }

        // GET: QuanLies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanLy = await _context.QuanLy
                .Include(q => q.TaiKhoan)
                .FirstOrDefaultAsync(m => m.IDQuanLy == id);
            if (quanLy == null)
            {
                return NotFound();
            }

            return View(quanLy);
        }

        // POST: QuanLies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quanLy = await _context.QuanLy.FindAsync(id);
            if (quanLy != null)
            {
                _context.QuanLy.Remove(quanLy);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuanLyExists(int id)
        {
            return _context.QuanLy.Any(e => e.IDQuanLy == id);
        }
    }
}
