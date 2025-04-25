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
    public class ThongKesController : Controller
    {
        private readonly quanLiRapPhimContext _context;

        public ThongKesController(quanLiRapPhimContext context)
        {
            _context = context;
        }

        // GET: ThongKes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ThongKe.ToListAsync());
        }

        // GET: ThongKes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thongKe = await _context.ThongKe
                .FirstOrDefaultAsync(m => m.IDThongKe == id);
            if (thongKe == null)
            {
                return NotFound();
            }

            return View(thongKe);
        }

        // GET: ThongKes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ThongKes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDThongKe,NgayTK,ThangTK,QuyTK,DoanhThu")] ThongKe thongKe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thongKe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thongKe);
        }

        // GET: ThongKes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thongKe = await _context.ThongKe.FindAsync(id);
            if (thongKe == null)
            {
                return NotFound();
            }
            return View(thongKe);
        }

        // POST: ThongKes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDThongKe,NgayTK,ThangTK,QuyTK,DoanhThu")] ThongKe thongKe)
        {
            if (id != thongKe.IDThongKe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thongKe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThongKeExists(thongKe.IDThongKe))
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
            return View(thongKe);
        }

        // GET: ThongKes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thongKe = await _context.ThongKe
                .FirstOrDefaultAsync(m => m.IDThongKe == id);
            if (thongKe == null)
            {
                return NotFound();
            }

            return View(thongKe);
        }

        // POST: ThongKes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thongKe = await _context.ThongKe.FindAsync(id);
            if (thongKe != null)
            {
                _context.ThongKe.Remove(thongKe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThongKeExists(int id)
        {
            return _context.ThongKe.Any(e => e.IDThongKe == id);
        }
    }
}
