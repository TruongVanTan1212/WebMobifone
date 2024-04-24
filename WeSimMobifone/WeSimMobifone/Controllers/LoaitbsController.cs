using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeSimMobifone.Data;
using WeSimMobifone.Models;

namespace WeSimMobifone.Controllers
{
    public class LoaitbsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoaitbsController(ApplicationDbContext context)
        {
            _context = context;
        }
        void GetInfo()
        {
            ViewBag.cuahang = _context.Cuahang.ToList();
            ViewData["SLChuaDuyet"] = _context.Hoadon.Where(k => k.TrangThai == 0 && k.Daxoa == 0).Count(); // 0 chưa duyệt
            ViewData["SLDaDuyet"] = _context.Hoadon.Where(k => k.TrangThai == 1 && k.Daxoa == 0).Count(); // 1 đã duyệt
            ViewData["SLDaVanChuyen"] = _context.Hoadon.Where(k => k.TrangThai == 2 && k.Daxoa == 0).Count(); // 2 đã vận chuyển
            ViewData["SLDaNhan"] = _context.Hoadon.Where(k => k.TrangThai == 3 && k.Daxoa == 0).Count();  // 3 đã nhận
            ViewData["SLDaHuy"] = _context.Hoadon.Where(k => k.TrangThai == 4 && k.Daxoa == 0).Count();
            ViewData["SLDanhMuc"] = _context.Danhmuc.Count();
            //  ViewBag.tintuc = _context.Danhmuc.ToList();
            if (HttpContext.Session.GetString("Nhanvien") != "")
            {
                ViewBag.Nhanvien = _context.Nhanvien.FirstOrDefault(k => k.Email == HttpContext.Session.GetString("Nhanvien"));
            }
            if (HttpContext.Session.GetString("khachhang") != "")
            {
                ViewBag.khachhang = _context.Khachhang.FirstOrDefault(k => k.MaKh.ToString() == HttpContext.Session.GetString("khachhang"));

            }
            var lstHD = _context.Hoadon.Where(d => d.TrangThai == 3 && d.Daxoa == 0);
            int tongtien = 0;
            foreach (Hoadon hd in lstHD)
            {
                tongtien += hd.TongTien;
            }
            ViewData["tongtien"] = tongtien.ToString("n0");
        }
        // GET: Loaitbs
        public async Task<IActionResult> Index()
        {
            GetInfo();
            return View(await _context.Loaitb.ToListAsync());
        }

        // GET: Loaitbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaitb = await _context.Loaitb
                .FirstOrDefaultAsync(m => m.MaLtb == id);
            if (loaitb == null)
            {
                return NotFound();
            }
            GetInfo();
            return View(loaitb);
        }

        // GET: Loaitbs/Create
        public IActionResult Create()
        {
            GetInfo();
            return View();
        }

        // POST: Loaitbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLtb,TenL")] Loaitb loaitb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaitb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            GetInfo();
            return View(loaitb);
        }

        // GET: Loaitbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaitb = await _context.Loaitb.FindAsync(id);
            if (loaitb == null)
            {
                return NotFound();
            }
            GetInfo();
            return View(loaitb);
        }

        // POST: Loaitbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaLtb,TenL")] Loaitb loaitb)
        {
            if (id != loaitb.MaLtb)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaitb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaitbExists(loaitb.MaLtb))
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
            GetInfo();
            return View(loaitb);
        }

        // GET: Loaitbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaitb = await _context.Loaitb
                .FirstOrDefaultAsync(m => m.MaLtb == id);
            if (loaitb == null)
            {
                return NotFound();
            }
            GetInfo();
            return View(loaitb);
        }

        // POST: Loaitbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaitb = await _context.Loaitb.FindAsync(id);
            _context.Loaitb.Remove(loaitb);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaitbExists(int id)
        {
            return _context.Loaitb.Any(e => e.MaLtb == id);
        }
    }
}
