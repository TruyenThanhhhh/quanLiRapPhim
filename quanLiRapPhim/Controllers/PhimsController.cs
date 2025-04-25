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
    public class PhimsController : Controller
    {
        private readonly quanLiRapPhimContext _context;

        public PhimsController(quanLiRapPhimContext context)
        {
            _context = context;
        }

        // GET: Phims
        public async Task<IActionResult> Index()
        {
            return View(await _context.Phim.ToListAsync());
        }

        // GET: Phims/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phim = await _context.Phim
                .FirstOrDefaultAsync(m => m.PhimID == id);
            if (phim == null)
            {
                return NotFound();
            }

            return View(phim);
        }

        // GET: Phims/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Phims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PhimID,TenPhim,GioiHanDoTuoi,DaoDien,TheLoai,QuocGia")] Phim phim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phim);
        }

        // GET: Phims/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phim = await _context.Phim.FindAsync(id);
            if (phim == null)
            {
                return NotFound();
            }
            return View(phim);
        }

        // POST: Phims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PhimID,TenPhim,GioiHanDoTuoi,DaoDien,TheLoai,QuocGia")] Phim phim)
        {
            if (id != phim.PhimID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhimExists(phim.PhimID))
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
            return View(phim);
        }

        // GET: Phims/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phim = await _context.Phim
                .FirstOrDefaultAsync(m => m.PhimID == id);
            if (phim == null)
            {
                return NotFound();
            }

            return View(phim);
        }

        // POST: Phims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phim = await _context.Phim.FindAsync(id);
            if (phim != null)
            {
                _context.Phim.Remove(phim);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhimExists(int id)
        {
            return _context.Phim.Any(e => e.PhimID == id);
        }
    }
}
