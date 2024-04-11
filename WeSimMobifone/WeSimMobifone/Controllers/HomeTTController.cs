using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WeSimMobifone.Data;
using WeSimMobifone.Models;

namespace WeSimMobifone.Controllers
{
    public class HomeTTController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeTTController(ApplicationDbContext context)
        {
            _context = context;
        }

        void GetInfo()
        {
            // lấy dữ liệu bảng danh mục
            ViewBag.danhmuc = _context.Danhmuc.ToList();
            // lấy dữ liệu của hàng
            ViewBag.cuahang = _context.Cuahang.ToList();
            // đếm số lượng sp trong giỏ hàng
            ViewData["solg"] = GetCartItems().Count();

            if (HttpContext.Session.GetString("khachhang") != "")
            {
                ViewBag.khachhang = _context.Khachhang.FirstOrDefault(k => k.Email == HttpContext.Session.GetString("khachhang"));
            }
            if (HttpContext.Session.GetString("Nhanvien") != "")
            {
                ViewBag.Nhanvien = _context.Nhanvien.FirstOrDefault(k => k.Email == HttpContext.Session.GetString("Nhanvien"));
            }
        }
        List<CartItem> GetCartItems()
        {
            var session = HttpContext.Session;
            string jsoncart = session.GetString("Mobifone");
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem>();
        }
        // GET: HomeTT
        public async Task<IActionResult> Index()
        {
            GetInfo();
            return View(await _context.Tintuc.ToListAsync());
        }

        // GET: HomeTT/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tintuc = await _context.Tintuc
                .FirstOrDefaultAsync(m => m.MaTin == id);
            if (tintuc == null)
            {
                return NotFound();
            }
            GetInfo();
            return View(tintuc);
        }
        /*
        // GET: HomeTT/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HomeTT/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaTin,TieuDe,TomTat,NoiDung,HinhAnh,NgayDang")] Tintuc tintuc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tintuc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tintuc);
        }

        // GET: HomeTT/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tintuc = await _context.Tintuc.FindAsync(id);
            if (tintuc == null)
            {
                return NotFound();
            }
            return View(tintuc);
        }

        // POST: HomeTT/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaTin,TieuDe,TomTat,NoiDung,HinhAnh,NgayDang")] Tintuc tintuc)
        {
            if (id != tintuc.MaTin)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tintuc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TintucExists(tintuc.MaTin))
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
            return View(tintuc);
        }

        // GET: HomeTT/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tintuc = await _context.Tintuc
                .FirstOrDefaultAsync(m => m.MaTin == id);
            if (tintuc == null)
            {
                return NotFound();
            }

            return View(tintuc);
        }

        // POST: HomeTT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tintuc = await _context.Tintuc.FindAsync(id);
            _context.Tintuc.Remove(tintuc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TintucExists(int id)
        {
            return _context.Tintuc.Any(e => e.MaTin == id);
        }*/
    }
}
