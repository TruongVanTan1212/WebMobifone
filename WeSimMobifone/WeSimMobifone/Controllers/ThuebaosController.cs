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
    public class ThuebaosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<Khachhang> _passwordHasher;

        public ThuebaosController(ApplicationDbContext context, IPasswordHasher<Khachhang> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }
        void GetInfo()
        {
            ViewBag.cuahang = _context.Cuahang.FirstOrDefault();
            //  ViewBag.tintuc = _context.Danhmuc.ToList();
            if (HttpContext.Session.GetString("Nhanvien") != "")
            {
                ViewBag.Nhanvien = _context.Nhanvien.FirstOrDefault(k => k.Email == HttpContext.Session.GetString("Nhanvien"));
            }

        }
        // tìm kiếm thuê bao
        public async Task<IActionResult> SearchThueBao(string searchThueBao)
        {
            var lstThueBao = await _context.Thuebao
                .Include(t => t.MaDmNavigation)
                .Include(t => t.MaLtbNavigation)
                .Where(k => k.SoThueBao.Contains(searchThueBao)).ToListAsync();
            GetInfo();
            return View(lstThueBao);
        }
        // GET: Thuebaos
        public async Task<IActionResult> Index()
        {
            GetInfo();
            var applicationDbContext = _context.Thuebao
                .Include(t => t.MaDmNavigation)
                .Include(t => t.MaLtbNavigation)
                .OrderByDescending(t => t.MaTb)
                .Where(h => h.Daxoa == 0);
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
        public async Task<IActionResult> Create([Bind("MaTb,SoThueBao,PhiHoaMang,MaDm,MaLtb,LoaiSo,DiaDiemHm")] Thuebao thuebao)
        {
            if (ModelState.IsValid)
            {
                thuebao.TrangThai = 0;
                thuebao.Daxoa = 0;
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
        public async Task<IActionResult> Edit(int id, [Bind("MaTb,SoThueBao,PhiHoaMang,MaDm,MaLtb,LoaiSo,DiaDiemHm")] Thuebao thuebao)
        {
            if (id != thuebao.MaTb)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    thuebao.TrangThai = 0;
                    thuebao.Daxoa = 0;
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

        private bool ThuebaoExists(int id)
        {
            return _context.Thuebao.Any(e => e.MaTb == id);
        }
        // xóa thuê bao
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuebao = await _context.Thuebao
                .Include(n => n.MaDmNavigation)
                .Include(n => n.MaLtbNavigation)
                .FirstOrDefaultAsync(m => m.MaTb == id);
            if (thuebao == null)
            {
                return NotFound();
            }
            GetInfo();
            return View(thuebao);
        }
        // POST: Huongdans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thuebao = await _context.Thuebao.FindAsync(id);
            thuebao.Daxoa = 1;
            _context.Thuebao.Update(thuebao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /*-----------------------đăng ký thuê bao tại quầy--------------------*/
        public IActionResult ThongBaoLoi404()
        {
            GetInfo();
            return View();
        }
        public async Task<IActionResult> DanhSachTB()
        {
            GetInfo();
            var applicationDbContext = _context.Thuebao.Include(t => t.MaDmNavigation).Include(t => t.MaLtbNavigation).Where(k => k.TrangThai == 0 && k.Daxoa == 0);
            return View(await applicationDbContext.ToListAsync());
        }
        
        public async Task<IActionResult> DKThueBao(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var thuebao = await _context.Thuebao
                .Include(t => t.MaDmNavigation)
                .Include(t => t.MaLtbNavigation)
                .FirstOrDefaultAsync(m => m.MaTb == id);
            thuebao.TrangThai = 1;
            _context.Update(thuebao);
            await _context.SaveChangesAsync();

            if (thuebao == null)
            {
                return NotFound();
            }
            GetInfo();
            return View(thuebao);
        }
        [HttpPost, ActionName("LuuDangKy")]
        public async Task<IActionResult> HuyThueBao(int? id)
        {
            Thuebao thuebao = await _context.Thuebao.FirstOrDefaultAsync( d => d.MaTb == id);
            thuebao.TrangThai = 0;
            _context.Update(thuebao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(DanhSachTB));
        }
        public async Task<IActionResult> LuuDangKy(int id/*matb*/, string ten, string email, string dienthoai, string cccd, string matkhau, string diachi, string xa, string huyen, string tinh, int phihoamang, IFormFile hinht, IFormFile hinhs)
        {

            Khachhang kh;
            Diachi dc;

             var  khachH = await _context.Khachhang.FirstOrDefaultAsync(d => d.Email == email && d.Cccd == cccd);
            if(khachH == null)
            {
                // đăng ký tài khoản mới
                kh = new Khachhang();
                kh.Ten = ten;
                kh.Email = email;
                kh.DienThoai = dienthoai;
                kh.Cccd = cccd;
                kh.HinhT = Upload(hinht);
                kh.HinhS = Upload1(hinhs);
                kh.MatKhau = _passwordHasher.HashPassword(kh, matkhau);
                kh.SlthueB = 1;
                kh.Daxoa = 0;
                _context.Add(kh);
                _context.SaveChanges();

                // đăng ký địa chỉ mới
                dc = new Diachi();
                dc.MaKh = kh.MaKh;
                dc.DiaChi1 = diachi;
                dc.PhuongXa = xa;
                dc.QuanHuyen = huyen;
                dc.TinhThanh = tinh;
                dc.MacDinh = 1; // mặc định 
                dc.Daxoa = 0;
                _context.Add(dc);
                await _context.SaveChangesAsync();
            }
            else
            {
                kh = await _context.Khachhang.FirstOrDefaultAsync(d => d.Email == email && d.Cccd == cccd);
                if(kh.SlthueB == 3)
                {
                    return RedirectToAction(nameof(ThongBaoLoi404));
                }
                kh.SlthueB = kh.SlthueB + 1;
                _context.Update(kh);
                await _context.SaveChangesAsync();
                dc = await _context.Diachi.FirstOrDefaultAsync(d => d.MaKh == kh.MaKh && d.Daxoa == 0 && d.MacDinh == 1);
            }
            // tạo hoá đơn
            Hoadon hd = new Hoadon();
            hd.MaTb = id;
            hd.MaKh = kh.MaKh;
            hd.Ngay = DateTime.Now;
            hd.MaDc = dc.MaDc;
            hd.TongTien = phihoamang;
            hd.TrangThai = 3; // cập nhật trạng thái đã nhận
            _context.Add(hd);
            await _context.SaveChangesAsync();

            // lưu thông tin khách hàng vào thuê bao
            Qlthuebao tb = new Qlthuebao();
            tb.MaKh = kh.MaKh;
            tb.MaTb = id; // mã thuê bao
            tb.NgayKichHoat = DateTime.Now;
            tb.TrangThai = 1;
            tb.Daxoa = 0;
            _context.Add(tb);
            await _context.SaveChangesAsync();

            Thuebao thuebao = await _context.Thuebao.FirstOrDefaultAsync(d => d.MaTb == id);
            thuebao.TrangThai = 2;
            _context.Update(thuebao);
            await _context.SaveChangesAsync();

            List<Hoadon> lstHoaDon = _context.Hoadon
                .Include(h => h.MaKhNavigation)
                .Include(h => h.MaTbNavigation)
                .Include(h => h.MaDcNavigation)
                .Where(d => d.MaHd == hd.MaHd && d.Daxoa == 0 && d.TrangThai == 3).ToList();
            ViewBag.Hoadon = lstHoaDon;

            GetInfo();
            return View(hd);
        }
        // upload file
        public IActionResult InHoaDonKH(int? id)
        {
            List<Hoadon> lstHoaDon = _context.Hoadon
                .Include(h => h.MaKhNavigation)
                .Include(h => h.MaTbNavigation)
                .Include(h => h.MaDcNavigation)
                .Where(d => d.MaHd == id && d.Daxoa == 0 && d.TrangThai == 3).ToList();
            ViewBag.Hoadon = lstHoaDon;
            GetInfo();
            return View();
        }
        public string Upload(IFormFile hinht)
        {
            string uploadFileName = null;
            if (hinht != null)
            {
                uploadFileName = Guid.NewGuid().ToString() + "_" + hinht.FileName;
                var path = $"wwwroot\\img\\{uploadFileName}";
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    hinht.CopyTo(stream);
                }
            }
            return uploadFileName;
        }
        public string Upload1(IFormFile hinhs)
        {
            string uploadFileName = null;
            if (hinhs != null)
            {
                uploadFileName = Guid.NewGuid().ToString() + "_" + hinhs.FileName;
                var path = $"wwwroot\\img\\{uploadFileName}";
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    hinhs.CopyTo(stream);
                }
            }
            return uploadFileName;
        }
    }
}
