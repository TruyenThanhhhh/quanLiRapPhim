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
    public class DonHangsController : Controller
    {
        private readonly quanLiRapPhimContext _context;

        public DonHangsController(quanLiRapPhimContext context)
        {
            _context = context;
        }

        // GET: DonHangs
        public async Task<IActionResult> Index()
        {
            var quanLiRapPhimContext = _context.DonHang.Include(d => d.NhanVien).Include(d => d.Phim).Include(d => d.PhongChieu).Include(d => d.ThongKe).Include(d => d.XuatChieu);
            return View(await quanLiRapPhimContext.ToListAsync());
        }

        // GET: DonHangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHang
                .Include(d => d.NhanVien)
                .Include(d => d.Phim)
                .Include(d => d.PhongChieu)
                .Include(d => d.ThongKe)
                .Include(d => d.XuatChieu)
                .FirstOrDefaultAsync(m => m.MaVe == id);
            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }

        // GET: DonHangs/Create
        public IActionResult Create()
        {
            ViewData["IDNhanVien"] = new SelectList(_context.NhanVien, "IDNhanVien", "Username");
            ViewData["PhimId"] = new SelectList(_context.Set<Phim>(), "PhimID", "DaoDien");
            ViewData["PhongChieuId"] = new SelectList(_context.Set<PhongChieu>(), "PhongID", "PhongID");
            ViewData["IDThongKe"] = new SelectList(_context.Set<ThongKe>(), "IDThongKe", "IDThongKe");
            ViewData["XuatChieuId"] = new SelectList(_context.Set<XuatChieu>(), "ID", "ID");
            return View();
        }

        // POST: DonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaVe,PhongChieuId,XuatChieuId,MaGhe,GiaVe,NgayDat,PhimId,IDThongKe,IDNhanVien")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDNhanVien"] = new SelectList(_context.NhanVien, "IDNhanVien", "Username", donHang.IDNhanVien);
            ViewData["PhimId"] = new SelectList(_context.Set<Phim>(), "PhimID", "DaoDien", donHang.PhimId);
            ViewData["PhongChieuId"] = new SelectList(_context.Set<PhongChieu>(), "PhongID", "PhongID", donHang.PhongChieuId);
            ViewData["IDThongKe"] = new SelectList(_context.Set<ThongKe>(), "IDThongKe", "IDThongKe", donHang.IDThongKe);
            ViewData["XuatChieuId"] = new SelectList(_context.Set<XuatChieu>(), "ID", "ID", donHang.XuatChieuId);
            return View(donHang);
        }

        // GET: DonHangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHang.FindAsync(id);
            if (donHang == null)
            {
                return NotFound();
            }
            ViewData["IDNhanVien"] = new SelectList(_context.NhanVien, "IDNhanVien", "Username", donHang.IDNhanVien);
            ViewData["PhimId"] = new SelectList(_context.Set<Phim>(), "PhimID", "DaoDien", donHang.PhimId);
            ViewData["PhongChieuId"] = new SelectList(_context.Set<PhongChieu>(), "PhongID", "PhongID", donHang.PhongChieuId);
            ViewData["IDThongKe"] = new SelectList(_context.Set<ThongKe>(), "IDThongKe", "IDThongKe", donHang.IDThongKe);
            ViewData["XuatChieuId"] = new SelectList(_context.Set<XuatChieu>(), "ID", "ID", donHang.XuatChieuId);
            return View(donHang);
        }

        // POST: DonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaVe,PhongChieuId,XuatChieuId,MaGhe,GiaVe,NgayDat,PhimId,IDThongKe,IDNhanVien")] DonHang donHang)
        {
            if (id != donHang.MaVe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonHangExists(donHang.MaVe))
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
            ViewData["IDNhanVien"] = new SelectList(_context.NhanVien, "IDNhanVien", "Username", donHang.IDNhanVien);
            ViewData["PhimId"] = new SelectList(_context.Set<Phim>(), "PhimID", "DaoDien", donHang.PhimId);
            ViewData["PhongChieuId"] = new SelectList(_context.Set<PhongChieu>(), "PhongID", "PhongID", donHang.PhongChieuId);
            ViewData["IDThongKe"] = new SelectList(_context.Set<ThongKe>(), "IDThongKe", "IDThongKe", donHang.IDThongKe);
            ViewData["XuatChieuId"] = new SelectList(_context.Set<XuatChieu>(), "ID", "ID", donHang.XuatChieuId);
            return View(donHang);
        }

        // GET: DonHangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHang
                .Include(d => d.NhanVien)
                .Include(d => d.Phim)
                .Include(d => d.PhongChieu)
                .Include(d => d.ThongKe)
                .Include(d => d.XuatChieu)
                .FirstOrDefaultAsync(m => m.MaVe == id);
            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }

        // POST: DonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donHang = await _context.DonHang.FindAsync(id);
            if (donHang != null)
            {
                _context.DonHang.Remove(donHang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonHangExists(int id)
        {
            return _context.DonHang.Any(e => e.MaVe == id);
        }
    }
}
