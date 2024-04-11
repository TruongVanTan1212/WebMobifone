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
    public class ThuebaosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ThuebaosController(ApplicationDbContext context)
        {
            _context = context;
        }
        void GetInfo()
        {

            //  ViewBag.tintuc = _context.Danhmuc.ToList();
            if (HttpContext.Session.GetString("Nhanvien") != "")
            {
                ViewBag.Nhanvien = _context.Nhanvien.FirstOrDefault(k => k.Email == HttpContext.Session.GetString("Nhanvien"));
            }
        }

        // GET: Thuebaos
        public async Task<IActionResult> Index()
        {
            GetInfo();
            var applicationDbContext = _context.Thuebao.Include(t => t.MaDmNavigation).Include(t => t.MaLtbNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Thuebaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuebao = await _context.Thuebao
                .Include(t => t.MaDmNavigation)
                .Include(t => t.MaLtbNavigation)
                .FirstOrDefaultAsync(m => m.MaTb == id);
            if (thuebao == null)
            {
                return NotFound();
            }
            GetInfo();
            return View(thuebao);
        }

        // GET: Thuebaos/Create
        public IActionResult Create()
        {
            GetInfo();
            ViewData["MaDm"] = new SelectList(_context.Danhmuc, "MaDm", "TenDm");
            ViewData["MaLtb"] = new SelectList(_context.Loaitb, "MaLtb", "TenL");
            return View();
        }

        // POST: Thuebaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaTb,SoThueBao,PhiHoaMang,MaDm,MaLtb,LoaiSo,DiaDiemHm,TrangThai")] Thuebao thuebao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thuebao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            GetInfo();
            ViewData["MaDm"] = new SelectList(_context.Danhmuc, "MaDm", "TenDm", thuebao.MaDm);
            ViewData["MaLtb"] = new SelectList(_context.Loaitb, "MaLtb", "TenL", thuebao.MaLtb);
            return View(thuebao);
        }

        // GET: Thuebaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuebao = await _context.Thuebao.FindAsync(id);
            if (thuebao == null)
            {
                return NotFound();
            }
            GetInfo();
            ViewData["MaDm"] = new SelectList(_context.Danhmuc, "MaDm", "TenDm", thuebao.MaDm);
            ViewData["MaLtb"] = new SelectList(_context.Loaitb, "MaLtb", "TenL", thuebao.MaLtb);
            return View(thuebao);
        }

        // POST: Thuebaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaTb,SoThueBao,PhiHoaMang,MaDm,MaLtb,LoaiSo,DiaDiemHm,TrangThai")] Thuebao thuebao)
        {
            if (id != thuebao.MaTb)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thuebao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThuebaoExists(thuebao.MaTb))
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
            ViewData["MaDm"] = new SelectList(_context.Danhmuc, "MaDm", "TenDm", thuebao.MaDm);
            ViewData["MaLtb"] = new SelectList(_context.Loaitb, "MaLtb", "TenL", thuebao.MaLtb);
            return View(thuebao);
        }

        // GET: Thuebaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuebao = await _context.Thuebao
                .Include(t => t.MaDmNavigation)
                .Include(t => t.MaLtbNavigation)
                .FirstOrDefaultAsync(m => m.MaTb == id);
            if (thuebao == null)
            {
                return NotFound();
            }
            GetInfo();
            return View(thuebao);
        }

        // POST: Thuebaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thuebao = await _context.Thuebao.FindAsync(id);
            _context.Thuebao.Remove(thuebao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThuebaoExists(int id)
        {
            return _context.Thuebao.Any(e => e.MaTb == id);
        }

        public async Task<IActionResult> SearchThueBao(string searchThueBao)
        {
            var lstThueBao = await _context.Thuebao.Include(t => t.MaDmNavigation).Include(t => t.MaLtbNavigation)
                            .Where(k => k.SoThueBao.Contains(searchThueBao)).ToListAsync();
            GetInfo();
            return View(lstThueBao);
        }
    }
}
