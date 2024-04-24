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
    public class CuahangsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CuahangsController(ApplicationDbContext context)
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
        // GET: Cuahangs
        public async Task<IActionResult> Index()
        {
            GetInfo();
            return View(await _context.Cuahang.ToListAsync());
        }

        // GET: Cuahangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuahang = await _context.Cuahang
                .FirstOrDefaultAsync(m => m.MaCh == id);
            if (cuahang == null)
            {
                return NotFound();
            }
            GetInfo();
            return View(cuahang);
        }

        // GET: Cuahangs/Create
        public IActionResult Create()
        {
            GetInfo();
            return View();
        }

        // POST: Cuahangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaCh,Ten,DienThoai,Email,DiaChi")] Cuahang cuahang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuahang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            GetInfo();
            return View(cuahang);
        }

        // GET: Cuahangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuahang = await _context.Cuahang.FindAsync(id);
            if (cuahang == null)
            {
                return NotFound();
            }
            GetInfo();
            return View(cuahang);
        }

        // POST: Cuahangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaCh,Ten,DienThoai,Email,DiaChi")] Cuahang cuahang)
        {
            if (id != cuahang.MaCh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuahang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuahangExists(cuahang.MaCh))
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
            return View(cuahang);
        }

        // GET: Cuahangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuahang = await _context.Cuahang
                .FirstOrDefaultAsync(m => m.MaCh == id);
            if (cuahang == null)
            {
                return NotFound();
            }
            GetInfo();
            return View(cuahang);
        }

        // POST: Cuahangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cuahang = await _context.Cuahang.FindAsync(id);
            _context.Cuahang.Remove(cuahang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuahangExists(int id)
        {
            return _context.Cuahang.Any(e => e.MaCh == id);
        }
    }
}
