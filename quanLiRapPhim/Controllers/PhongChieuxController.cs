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
    public class PhongChieuxController : Controller
    {
        private readonly quanLiRapPhimContext _context;

        public PhongChieuxController(quanLiRapPhimContext context)
        {
            _context = context;
        }

        // GET: PhongChieux
        public async Task<IActionResult> Index()
        {
            return View(await _context.PhongChieu.ToListAsync());
        }

        // GET: PhongChieux/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phongChieu = await _context.PhongChieu
                .FirstOrDefaultAsync(m => m.PhongID == id);
            if (phongChieu == null)
            {
                return NotFound();
            }

            return View(phongChieu);
        }

        // GET: PhongChieux/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhongChieux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PhongID,SoGhe")] PhongChieu phongChieu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phongChieu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phongChieu);
        }

        // GET: PhongChieux/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phongChieu = await _context.PhongChieu.FindAsync(id);
            if (phongChieu == null)
            {
                return NotFound();
            }
            return View(phongChieu);
        }

        // POST: PhongChieux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PhongID,SoGhe")] PhongChieu phongChieu)
        {
            if (id != phongChieu.PhongID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phongChieu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhongChieuExists(phongChieu.PhongID))
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
            return View(phongChieu);
        }

        // GET: PhongChieux/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phongChieu = await _context.PhongChieu
                .FirstOrDefaultAsync(m => m.PhongID == id);
            if (phongChieu == null)
            {
                return NotFound();
            }

            return View(phongChieu);
        }

        // POST: PhongChieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phongChieu = await _context.PhongChieu.FindAsync(id);
            if (phongChieu != null)
            {
                _context.PhongChieu.Remove(phongChieu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhongChieuExists(int id)
        {
            return _context.PhongChieu.Any(e => e.PhongID == id);
        }
    }
}
