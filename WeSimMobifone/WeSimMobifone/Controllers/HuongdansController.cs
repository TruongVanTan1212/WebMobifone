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
    public class HuongdansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HuongdansController(ApplicationDbContext context)
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
        // GET: Huongdans
        public async Task<IActionResult> Index()
        {
            GetInfo();
            return View(await _context.Huongdan.ToListAsync());
        }

        // GET: Huongdans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var huongdan = await _context.Huongdan
                .FirstOrDefaultAsync(m => m.MaHdan == id);
            if (huongdan == null)
            {
                return NotFound();
            }
            GetInfo();
            return View(huongdan);
        }

        // GET: Huongdans/Create
        public IActionResult Create()
        {
            GetInfo();
            return View();
        }

        // POST: Huongdans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHdan,CauHoi,TraLoi,NgayDang")] Huongdan huongdan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(huongdan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            GetInfo();
            return View(huongdan);
        }

        // GET: Huongdans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var huongdan = await _context.Huongdan.FindAsync(id);
            if (huongdan == null)
            {
                return NotFound();
            }
            GetInfo();
            return View(huongdan);
        }

        // POST: Huongdans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaHdan,CauHoi,TraLoi,NgayDang")] Huongdan huongdan)
        {
            if (id != huongdan.MaHdan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(huongdan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HuongdanExists(huongdan.MaHdan))
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
            return View(huongdan);
        }

        // GET: Huongdans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var huongdan = await _context.Huongdan
                .FirstOrDefaultAsync(m => m.MaHdan == id);
            if (huongdan == null)
            {
                return NotFound();
            }
            GetInfo();
            return View(huongdan);
        }

        // POST: Huongdans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var huongdan = await _context.Huongdan.FindAsync(id);
            _context.Huongdan.Remove(huongdan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HuongdanExists(int id)
        {
            return _context.Huongdan.Any(e => e.MaHdan == id);
        }

        public async Task<IActionResult> SearchHDan(string searchHuongDan)
        {
            var lstHDan = await _context.Huongdan.Where(k => k.CauHoi.Contains(searchHuongDan)).ToListAsync();
            GetInfo();
            return View(lstHDan);
        }
    }
}
