using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeSimMobifone.Data;
using WeSimMobifone.Models;

namespace WeSimMobifone.Controllers
{
    public class HomeHDController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeHDController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HomeHD
        public async Task<IActionResult> Index()
        {
            return View(await _context.Huongdan.ToListAsync());
        }

        // GET: HomeHD/Details/5
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

            return View(huongdan);
        }

        // GET: HomeHD/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HomeHD/Create
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
            return View(huongdan);
        }

        // GET: HomeHD/Edit/5
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
            return View(huongdan);
        }

        // POST: HomeHD/Edit/5
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
            return View(huongdan);
        }

        // GET: HomeHD/Delete/5
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

            return View(huongdan);
        }

        // POST: HomeHD/Delete/5
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
    }
}
