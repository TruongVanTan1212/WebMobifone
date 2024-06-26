﻿using System;
using System.Collections.Generic;
using System.IO;
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
    public class TintucsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TintucsController(ApplicationDbContext context)
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
        // GET: Tintucs
        public async Task<IActionResult> Index()
        {
            GetInfo();
            return View(await _context.Tintuc.OrderByDescending(t => t.MaTin).ToListAsync());
        }

        // GET: Tintucs/Details/5
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

        // GET: Tintucs/Create
        public IActionResult Create()
        {
            GetInfo();
            return View();
        }

        // POST: Tintucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaTin,TieuDe,TomTat,NoiDung,HinhAnh,NgayDang")] Tintuc tintuc, IFormFile file)
        {
            if (ModelState.IsValid)
            {

                tintuc.HinhAnh = Upload(file);
                _context.Add(tintuc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            GetInfo();

            return View(tintuc);
        }

        // GET: Tintucs/Edit/5
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
            GetInfo();
            return View(tintuc);
        }

        // POST: Tintucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaTin,TieuDe,TomTat,NoiDung,HinhAnh,NgayDang")] Tintuc tintuc, IFormFile file)
        {
            if (id != tintuc.MaTin)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(tintuc.Hot == 1)
                    {
                        tintuc.Hot = 1;
                    }
                    else
                    {
                        tintuc.Hot = 0;
                    }
                    if(file != null)
                    {
                        tintuc.HinhAnh = Upload(file);
                    }
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
            GetInfo();
            return View(tintuc);
        }

        // GET: Tintucs/Delete/5
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
            GetInfo();
            return View(tintuc);
        }

        // POST: Tintucs/Delete/5
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
        }

        public string Upload(IFormFile file)
        {
            string uploadFileName = null;
            if (file != null)
            {
                uploadFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var path = $"wwwroot\\img\\{uploadFileName}";
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            return uploadFileName;
        }

        public async Task<IActionResult> SearchTT(string searchTinTuc)
        {
            var lstTinTuc = await _context.Tintuc.Where(k => k.TieuDe.Contains(searchTinTuc)).ToListAsync();
            GetInfo();
            return View(lstTinTuc);
        }

        // tin hot
        public async Task<IActionResult> HOT(int? id)
        {
            Tintuc tintuc = await _context.Tintuc.FirstOrDefaultAsync(d => d.MaTin == id);
            tintuc.Hot = 1;
            _context.Update(tintuc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // không hot
        public async Task<IActionResult> UnHOT(int? id)
        {
            Tintuc tintuc = await _context.Tintuc.FirstOrDefaultAsync(d => d.MaTin == id);
            tintuc.Hot = 0;
            _context.Update(tintuc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
