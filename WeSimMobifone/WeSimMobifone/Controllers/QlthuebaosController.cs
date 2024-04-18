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
    public class QlthuebaosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QlthuebaosController(ApplicationDbContext context)
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

        // GET: Qlthuebaos
        public async Task<IActionResult> Index()
        {
            GetInfo();
            var applicationDbContext = _context.Qlthuebao.Include(q => q.MaKhNavigation).Include(q => q.MaTbNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Qlthuebaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qlthuebao = await _context.Qlthuebao
                .Include(q => q.MaKhNavigation)
                .Include(q => q.MaTbNavigation)
                .FirstOrDefaultAsync(m => m.MaQl == id);
            if (qlthuebao == null)
            {
                return NotFound();
            }
            GetInfo();
            return View(qlthuebao);
        }

        // GET: Qlthuebaos/Create
        public IActionResult Create()
        {
            ViewData["MaKh"] = new SelectList(_context.Khachhang, "MaKh", "Ten");
            ViewData["MaTb"] = new SelectList(_context.Thuebao, "MaTb", "SoThueBao");
            GetInfo();
            return View();
        }

        // POST: Qlthuebaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaQl,MaTb,MaKh,NgayKichHoat,TrangThai,Daxoa")] Qlthuebao qlthuebao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qlthuebao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKh"] = new SelectList(_context.Khachhang, "MaKh", "Ten", qlthuebao.MaKh);
            ViewData["MaTb"] = new SelectList(_context.Thuebao, "MaTb", "SoThueBao", qlthuebao.MaTb);
            GetInfo();
            return View(qlthuebao);
        }

        // GET: Qlthuebaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qlthuebao = await _context.Qlthuebao.FindAsync(id);
            if (qlthuebao == null)
            {
                return NotFound();
            }
            ViewData["MaKh"] = new SelectList(_context.Khachhang, "MaKh", "Ten", qlthuebao.MaKh);
            ViewData["MaTb"] = new SelectList(_context.Thuebao, "MaTb", "SoThueBao", qlthuebao.MaTb);
            GetInfo();
            return View(qlthuebao);
        }

        // POST: Qlthuebaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaQl,MaTb,MaKh,NgayKichHoat,TrangThai,Daxoa")] Qlthuebao qlthuebao)
        {
            if (id != qlthuebao.MaQl)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qlthuebao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QlthuebaoExists(qlthuebao.MaQl))
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
            ViewData["MaKh"] = new SelectList(_context.Khachhang, "MaKh", "Ten", qlthuebao.MaKh);
            ViewData["MaTb"] = new SelectList(_context.Thuebao, "MaTb", "SoThueBao", qlthuebao.MaTb);
            return View(qlthuebao);
        }

        // GET: Qlthuebaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qlthuebao = await _context.Qlthuebao
                .Include(q => q.MaKhNavigation)
                .Include(q => q.MaTbNavigation)
                .FirstOrDefaultAsync(m => m.MaQl == id);
            if (qlthuebao == null)
            {
                return NotFound();
            }
            GetInfo();
            return View(qlthuebao);
        }

        // POST: Qlthuebaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var qlthuebao = await _context.Qlthuebao.FindAsync(id);
            _context.Qlthuebao.Remove(qlthuebao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QlthuebaoExists(int id)
        {
            return _context.Qlthuebao.Any(e => e.MaQl == id);
        }
    }
}
