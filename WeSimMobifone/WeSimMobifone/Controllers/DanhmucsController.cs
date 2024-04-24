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
    public class DanhmucsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DanhmucsController(ApplicationDbContext context)
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
        // GET: Danhmucs
        public async Task<IActionResult> Index()
        {
            GetInfo();
            return View(await _context.Danhmuc.ToListAsync());
        }

        // GET: Danhmucs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhmuc = await _context.Danhmuc
                .FirstOrDefaultAsync(m => m.MaDm == id);
            if (danhmuc == null)
            {
                return NotFound();
            }
            GetInfo();
            return View(danhmuc);
        }

        // GET: Danhmucs/Create
        public IActionResult Create()
        {
            GetInfo();
            return View();
        }

        // POST: Danhmucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDm,TenDm")] Danhmuc danhmuc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danhmuc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            GetInfo();
            return View(danhmuc);
        }

        // GET: Danhmucs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhmuc = await _context.Danhmuc.FindAsync(id);
            if (danhmuc == null)
            {
                return NotFound();
            }
            GetInfo();
            return View(danhmuc);
        }

        // POST: Danhmucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaDm,TenDm")] Danhmuc danhmuc)
        {
            if (id != danhmuc.MaDm)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danhmuc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhmucExists(danhmuc.MaDm))
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
            return View(danhmuc);
        }

        // GET: Danhmucs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhmuc = await _context.Danhmuc
                .FirstOrDefaultAsync(m => m.MaDm == id);
            if (danhmuc == null)
            {
                return NotFound();
            }
            GetInfo();
            return View(danhmuc);
        }

        // POST: Danhmucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var danhmuc = await _context.Danhmuc.FindAsync(id);
            _context.Danhmuc.Remove(danhmuc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhmucExists(int id)
        {
            return _context.Danhmuc.Any(e => e.MaDm == id);
        }
    }
}
