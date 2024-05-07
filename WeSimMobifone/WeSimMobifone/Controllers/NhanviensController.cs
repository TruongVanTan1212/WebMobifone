using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeSimMobifone.Data;
using WeSimMobifone.Models;

namespace WeSimMobifone.Controllers
{
    public class NhanviensController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<Nhanvien> _nvpasswordHasher;

        public NhanviensController(ApplicationDbContext context, IPasswordHasher<Nhanvien> nvpasswordHasher)
        {
            _context = context;
            _nvpasswordHasher = nvpasswordHasher;
        }

        void GetInfo()
        {

            //  ViewBag.tintuc = _context.Danhmuc.ToList();
            if (HttpContext.Session.GetString("Nhanvien") != "")
            {
                ViewBag.Nhanvien = _context.Nhanvien.FirstOrDefault(k => k.Email == HttpContext.Session.GetString("Nhanvien"));
            }
        }

        public async Task<IActionResult> SearchNV(string searchNhanVien)
        {
            var lstNhanVien = await _context.Nhanvien
                .Include(n => n.MaCvNavigation)
                .OrderByDescending(t => t.MaNv)
                .Where(k => k.Ten.Contains(searchNhanVien) && k.Daxoa == 0).ToListAsync();
            GetInfo();
            return View(lstNhanVien);
        }
        // GET: Nhanviens
        public async Task<IActionResult> Index()
        {
            GetInfo();
            var applicationDbContext = _context.Nhanvien
                .Include(n => n.MaCvNavigation)
                .OrderByDescending(t => t.MaNv);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Nhanviens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanvien
                .Include(n => n.MaCvNavigation)
                .FirstOrDefaultAsync(m => m.MaNv == id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            GetInfo();
            return View(nhanvien);
        }

        // GET: Nhanviens/Create
        public IActionResult Create()
        {
            GetInfo();
            ViewData["MaCv"] = new SelectList(_context.Chucvu, "MaCv", "Ten");
            return View();
        }

        // POST: Nhanviens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNv,Ten,MaCv,DienThoai,Email")] Nhanvien nhanvien, string matkhau)
        {
            if (ModelState.IsValid)
            {
                nhanvien.MatKhau = _nvpasswordHasher.HashPassword(nhanvien, matkhau);
                nhanvien.Daxoa = 0;
                _context.Add(nhanvien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            GetInfo();
            ViewData["MaCv"] = new SelectList(_context.Chucvu, "MaCv", "Ten", nhanvien.MaCv);
            return View(nhanvien);
        }

        // GET: Nhanviens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanvien.FindAsync(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            GetInfo();
            ViewData["MaCv"] = new SelectList(_context.Chucvu, "MaCv", "Ten", nhanvien.MaCv);
            return View(nhanvien);
        }

        // POST: Nhanviens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaNv,Ten,MaCv,DienThoai,Email")] Nhanvien nhanvien, string matkhau)
        {
            if (id != nhanvien.MaNv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(matkhau != null)
                    {
                        nhanvien.MatKhau = _nvpasswordHasher.HashPassword(nhanvien, matkhau);
                    }
                    nhanvien.Daxoa = 0;
                    _context.Update(nhanvien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanvienExists(nhanvien.MaNv))
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
            ViewData["MaCv"] = new SelectList(_context.Chucvu, "MaCv", "Ten", nhanvien.MaCv);
            return View(nhanvien);
        }

        // GET: Nhanviens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanvien
                .Include(n => n.MaCvNavigation)
                .FirstOrDefaultAsync(m => m.MaNv == id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            GetInfo();
            return View(nhanvien);
        }

        // POST: Nhanviens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhanvien = await _context.Nhanvien.FindAsync(id);
            nhanvien.Daxoa = 2;
            _context.Nhanvien.Update(nhanvien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanvienExists(int id)
        {
            return _context.Nhanvien.Any(e => e.MaNv == id);
        }

        public async Task<IActionResult> LockNV(int? id)
        {
            Nhanvien kh = await _context.Nhanvien.FirstOrDefaultAsync(d => d.MaNv == id && d.Daxoa == 0);
            kh.Daxoa = 1;
            _context.Update(kh);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // mở khóa tài khoản
        public async Task<IActionResult> UnlockNV(int? id)
        {
            Nhanvien kh = await _context.Nhanvien.FirstOrDefaultAsync(d => d.MaNv == id && d.Daxoa == 1);
            kh.Daxoa = 0;
            _context.Update(kh);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
