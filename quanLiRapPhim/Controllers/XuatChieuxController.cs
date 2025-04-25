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
    public class XuatChieuxController : Controller
    {
        private readonly quanLiRapPhimContext _context;

        public XuatChieuxController(quanLiRapPhimContext context)
        {
            _context = context;
        }

        // GET: XuatChieux
        public async Task<IActionResult> Index()
        {
            var quanLiRapPhimContext = _context.XuatChieu.Include(x => x.PhongChieu);
            return View(await quanLiRapPhimContext.ToListAsync());
        }

        // GET: XuatChieux/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var xuatChieu = await _context.XuatChieu
                .Include(x => x.PhongChieu)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (xuatChieu == null)
            {
                return NotFound();
            }

            return View(xuatChieu);
        }

        // GET: XuatChieux/Create
        public IActionResult Create()
        {
            ViewData["PhongID"] = new SelectList(_context.PhongChieu, "PhongID", "PhongID");
            return View();
        }

        // POST: XuatChieux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PhongID,GioChieu,KhuyenMai")] XuatChieu xuatChieu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(xuatChieu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PhongID"] = new SelectList(_context.PhongChieu, "PhongID", "PhongID", xuatChieu.PhongID);
            return View(xuatChieu);
        }

        // GET: XuatChieux/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var xuatChieu = await _context.XuatChieu.FindAsync(id);
            if (xuatChieu == null)
            {
                return NotFound();
            }
            ViewData["PhongID"] = new SelectList(_context.PhongChieu, "PhongID", "PhongID", xuatChieu.PhongID);
            return View(xuatChieu);
        }

        // POST: XuatChieux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PhongID,GioChieu,KhuyenMai")] XuatChieu xuatChieu)
        {
            if (id != xuatChieu.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(xuatChieu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!XuatChieuExists(xuatChieu.ID))
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
            ViewData["PhongID"] = new SelectList(_context.PhongChieu, "PhongID", "PhongID", xuatChieu.PhongID);
            return View(xuatChieu);
        }

        // GET: XuatChieux/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var xuatChieu = await _context.XuatChieu
                .Include(x => x.PhongChieu)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (xuatChieu == null)
            {
                return NotFound();
            }

            return View(xuatChieu);
        }

        // POST: XuatChieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var xuatChieu = await _context.XuatChieu.FindAsync(id);
            if (xuatChieu != null)
            {
                _context.XuatChieu.Remove(xuatChieu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool XuatChieuExists(int id)
        {
            return _context.XuatChieu.Any(e => e.ID == id);
        }
    }
}
