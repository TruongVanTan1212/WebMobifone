using System;
using System.Collections.Generic;
using System.IO;
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
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<Khachhang> _passwordHasher;
        //private readonly IPasswordHasher<Nhanvien> _nvpasswordHasher;
        public AdminController(ApplicationDbContext context, IPasswordHasher<Khachhang> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            //_nvpasswordHasher = nvpasswordHasher;
        }
        void GetInfo()
        {
            
            //  ViewBag.tintuc = _context.Danhmuc.ToList();
            if (HttpContext.Session.GetString("Nhanvien") != "")
            {
                ViewBag.Nhanvien = _context.Nhanvien.FirstOrDefault(k => k.Email == HttpContext.Session.GetString("Nhanvien"));
            }
            if (HttpContext.Session.GetString("khachhang") != "")
            {
                ViewBag.khachhang = _context.Khachhang.FirstOrDefault(k => k.MaKh.ToString() == HttpContext.Session.GetString("khachhang"));

            }
        }
        // GET: Admin
        public async Task<IActionResult> Index()
        {
            GetInfo();
            var applicationDbContext = _context.Hoadon.Include(h => h.MaKhNavigation).Include(h => h.MaTbNavigation).Include(h => h.MaDcNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoadon = await _context.Hoadon
                .Include(h => h.MaKhNavigation)
                .Include(h => h.MaTbNavigation)
                .Include(h => h.MaDcNavigation)
                .FirstOrDefaultAsync(m => m.MaHd == id);
            if (hoadon == null)
            {
                return NotFound();
            }
            GetInfo();
            return View(hoadon);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoadon = await _context.Hoadon.FindAsync(id);
            if (hoadon == null)
            {
                return NotFound();
            }
            ViewData["MaKh"] = new SelectList(_context.Khachhang, "MaKh", "Ten", hoadon.MaKh);
            ViewData["MaTb"] = new SelectList(_context.Thuebao, "MaTb", "SoThueBao", hoadon.MaTb);
            ViewData["MaDc"] = new SelectList(_context.Diachi, "MaDc", "DiaChi", hoadon.MaDc);
            GetInfo();
            return View(hoadon);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaHd,MaTb,Ngay,TongTien,MaKh,MaDc,TrangThai")] Hoadon hoadon)
        {
            if (id != hoadon.MaHd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoadon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoadonExists(hoadon.MaHd))
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
            ViewData["MaKh"] = new SelectList(_context.Khachhang, "MaKh", "Ten", hoadon.MaKh);
            ViewData["MaTb"] = new SelectList(_context.Thuebao, "MaTb", "SoThueBao", hoadon.MaTb);
            ViewData["MaDc"] = new SelectList(_context.Diachi, "MaDc", "DiaChi", hoadon.MaDc);
            GetInfo();
            return View(hoadon);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoadon = await _context.Hoadon
                .Include(h => h.MaKhNavigation)
                .Include(h => h.MaTbNavigation)
                .Include(h => h.MaDcNavigation)
                .FirstOrDefaultAsync(m => m.MaHd == id);
            if (hoadon == null)
            {
                return NotFound();
            }
            GetInfo();
            return View(hoadon);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hoadon = await _context.Hoadon.FindAsync(id);
            _context.Hoadon.Remove(hoadon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoadonExists(int id)
        {
            return _context.Hoadon.Any(e => e.MaHd == id);
        }

        //------------------------------------------------------
        // tra cứu hoá đơn
        public async Task<IActionResult> SearchHD(string searchHoaDon)
        {
            var lstHoaDon = await _context.Hoadon.Include(h => h.MaKhNavigation).Include(h => h.MaTbNavigation).Include(h => h.MaDcNavigation)
                            .Where(k => k.MaKhNavigation.Ten.Contains(searchHoaDon)).ToListAsync();
            GetInfo();
            return View(lstHoaDon);
        }

        // Xuất thông tin khách hàng
        public IActionResult Customer()
        {
            int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            var lstDiaChi = _context.Diachi.Where(d => d.MaKh == makh);
            GetInfo();
            return View(lstDiaChi);
        }

        // sửa thông tin khách hàng
        public IActionResult EditAccount()
        {
            GetInfo();
            return View();
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> EditAccount(int id,string email, string matkhau, string ten, string dienthoai,string cccd,string hinht, string hinhs , IFormFile file)
        {
            // kiểm tra email đã đk tài khoản chưa && không phải khách hàng hiện tại && mật khẩu không bỏ trống
            int makh = int.Parse(HttpContext.Session.GetString("khachhang"));

            Khachhang khCheck = _context.Khachhang.FirstOrDefault(k => k.Email == email && k.MatKhau != matkhau && k.MatKhau != null);
           
            if (khCheck != null)
            {
                GetInfo();
                return RedirectToAction(nameof(EditAccount));

            }

            Khachhang kh = _context.Khachhang.FirstOrDefault(k => k.MaKh == makh);
            kh.Email = email;
            //kh.Ten = ten;
            kh.DienThoai = dienthoai;
            kh.Cccd = cccd;
            hinhs = Upload(file);
            kh.HinhT = hinhs;
            hinht = Upload(file);
            kh.HinhS = hinht;
            if (kh.MatKhau != matkhau )
            {
                kh.MatKhau = _passwordHasher.HashPassword(kh, matkhau);
            }
            _context.Update(kh);
            await _context.SaveChangesAsync();

            GetInfo();
            return RedirectToAction(nameof(Customer));
        }

        // upload file
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
    }
}
