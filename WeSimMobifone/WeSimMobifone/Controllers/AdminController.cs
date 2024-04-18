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
        
        public AdminController(ApplicationDbContext context, IPasswordHasher<Khachhang> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }
       
      

        //-------------------------------------Hoá đơn-------------------------------------------------------
        // tra cứu hoá đơn
        public async Task<IActionResult> SearchHD(string searchHoaDon)
        {
            var lstHoaDon = await _context.Hoadon.Include(h => h.MaKhNavigation).Include(h => h.MaTbNavigation).Include(h => h.MaDcNavigation)
                            .Where(k => k.MaKhNavigation.Ten.Contains(searchHoaDon) && k.Daxoa == 0).ToListAsync();
            GetInfo();
            return View(lstHoaDon);
        }
        // lấy thông tin hoá đơn
        void GetInfo()
        {

            ViewData["SLChuaDuyet"] = _context.Hoadon.Where(k => k.TrangThai == 0 && k.Daxoa == 0).Count(); // 0 chưa duyệt
            ViewData["SLDaDuyet"] = _context.Hoadon.Where(k => k.TrangThai == 1 && k.Daxoa == 0).Count(); // 1 đã duyệt
            ViewData["SLDaVanChuyen"] = _context.Hoadon.Where(k => k.TrangThai == 2 && k.Daxoa == 0).Count(); // 2 đã vận chuyển
            ViewData["SLDaNhan"] = _context.Hoadon.Where(k => k.TrangThai == 3 && k.Daxoa == 0).Count();  // 3 đã nhận
            ViewData["SLDaHuy"] = _context.Hoadon.Where(k => k.TrangThai == 3 && k.Daxoa == 0).Count();
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
        public async Task<IActionResult> Index() // chưa duyệt
        {
            GetInfo();
            var applicationDbContext = _context.Hoadon.Include(h => h.MaKhNavigation).Include(h => h.MaTbNavigation).Include(h => h.MaDcNavigation)
                .Where(k => k.TrangThai == 0 && k.Daxoa == 0);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> DaDuyetDon()  // đã duyệt
        {
            GetInfo();
            var applicationDbContext = _context.Hoadon.Include(h => h.MaKhNavigation).Include(h => h.MaTbNavigation).Include(h => h.MaDcNavigation)
                .Where(k => k.TrangThai == 1 && k.Daxoa == 0);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> DaVanChuyen() // đã vận chuyển
        {
            GetInfo();
            var applicationDbContext = _context.Hoadon.Include(h => h.MaKhNavigation).Include(h => h.MaTbNavigation).Include(h => h.MaDcNavigation)
                .Where(k => k.TrangThai == 2 && k.Daxoa == 0);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> DaNhanDon() //đã nhận đơn
        {
            GetInfo();
            var applicationDbContext = _context.Hoadon.Include(h => h.MaKhNavigation).Include(h => h.MaTbNavigation).Include(h => h.MaDcNavigation)
                .Where(k => k.TrangThai == 3 && k.Daxoa == 0);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> DaHuy() //đã huỷ
        {
            GetInfo();
            var applicationDbContext = _context.Hoadon.Include(h => h.MaKhNavigation).Include(h => h.MaTbNavigation).Include(h => h.MaDcNavigation)
                .Where(k => k.TrangThai == 4 && k.Daxoa == 0);
            return View(await applicationDbContext.ToListAsync());
        }

        // chi tiết hoá đơn
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
        public async Task<IActionResult> DuyetHoaDon(int? id)
        {
            //int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            Hoadon hd = _context.Hoadon.FirstOrDefault(d => d.MaHd == id && d.Daxoa == 0);
            hd.TrangThai = 1; // đã nhận
            _context.Update(hd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(DaDuyetDon));
        }

        //------------------------------------------Khách hàng--------------------------------------------------
        // Xuất thông tin khách hàng
        public IActionResult Customer()
        {
            GetInfo();
            return View();
        }

        // sửa thông tin khách hàng
        public IActionResult EditAccount()
        {
            GetInfo();
            return View();
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> EditAccount(string email, string matkhau, string ten, string dienthoai,string cccd,IFormFile hinht, IFormFile hinhs)
        {
            // kiểm tra email đã đk tài khoản chưa && không phải khách hàng hiện tại && mật khẩu không bỏ trống
            int makh = int.Parse(HttpContext.Session.GetString("khachhang"));

            Khachhang khCheck = _context.Khachhang.FirstOrDefault(k => k.Email == email && k.MatKhau != matkhau && k.MatKhau != null);
           
            if (khCheck == null)
            {
                GetInfo();
                return RedirectToAction(nameof(EditAccount));
            }

            Khachhang kh = _context.Khachhang.FirstOrDefault(k => k.MaKh == makh);
            kh.Email = email;
            kh.Ten = ten;
            kh.DienThoai = dienthoai;
            kh.Cccd = cccd;
            if(hinht != null)
            {
                kh.HinhT = Upload(hinht);
            }
            if(hinhs != null)
            {
                kh.HinhS = Upload1(hinhs);
            }
            if (kh.MatKhau != matkhau )
            {
                kh.MatKhau = _passwordHasher.HashPassword(kh, matkhau);
            }
            _context.Update(kh);
            await _context.SaveChangesAsync();

            GetInfo();
            return RedirectToAction(nameof(Customer));
        }
        // xuất địa chỉ
        public IActionResult Address()
        {
            int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            var lstDiaChi = _context.Diachi.Where(d => d.MaKh == makh && d.Daxoa == 0).ToList();
            GetInfo();
            return View(lstDiaChi);
        }

        // thêm địa chỉ
        public IActionResult AddAddress()
        {
            GetInfo();
            return View();
        }
        // thêm địa chỉ
        [HttpPost]
        public async Task<IActionResult> AddAddress(string diachicuthe, string phuongxa, string quanhuyen, string tinhthanh)
        {
            int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            Diachi dc = new Diachi();
            dc.MaKh = makh;
            dc.DiaChi1 = diachicuthe;
            dc.PhuongXa = phuongxa;
            dc.QuanHuyen = quanhuyen;
            dc.TinhThanh = tinhthanh;
            var kt = _context.Diachi.FirstOrDefault(d => d.MaKh == makh);
            if(kt != null)
            {
                dc.MacDinh = 2;
            }
            else
            {
                dc.MacDinh = 1;
            }
            dc.Daxoa = 0;
            _context.Add(dc);
            await _context.SaveChangesAsync();
            GetInfo();
            return RedirectToAction(nameof(Address));
        }

        // đặt địa chỉ làm mặc định
        public async Task<IActionResult> SetDefaultAddress(int id)
        {
            int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            Diachi dc1 = _context.Diachi.FirstOrDefault(d => d.MaKh == makh && d.MacDinh == 1);
            dc1.MacDinh = 2;
            _context.Update(dc1);

            Diachi dc2 = _context.Diachi.FirstOrDefault(d => d.MaDc == id);
            dc2.MacDinh = 1;
            _context.Update(dc2);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Address));
        }

        public async Task<IActionResult> DeleteAddress(int id)
        {
            Diachi dc = _context.Diachi.FirstOrDefault(d => d.MaDc == id);
            dc.Daxoa = 1;
            _context.Diachi.Update(dc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Address));
        }
        // upload file
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

        public IActionResult DonHang()
        {
            int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            var lstdonhang = _context.Hoadon.Include(h => h.MaKhNavigation).Include(h => h.MaTbNavigation).Include(h => h.MaDcNavigation).Where(d => d.MaKh == makh && d.TrangThai == 0);
            GetInfo();
            return View(lstdonhang);
        }
        public IActionResult DonDaHuy()
        {
            int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            var lstdonhang = _context.Hoadon.Include(h => h.MaKhNavigation).Include(h => h.MaTbNavigation).Include(h => h.MaDcNavigation).Where(d => d.MaKh == makh && d.TrangThai == 3);
            GetInfo();
            return View(lstdonhang);
        }
        public IActionResult DonDaDuyet()
        {
            int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            var lstdonhang = _context.Hoadon.Include(h => h.MaKhNavigation).Include(h => h.MaTbNavigation).Include(h => h.MaDcNavigation).Where(d => d.MaKh == makh && d.TrangThai == 1);
            GetInfo();
            return View(lstdonhang);
        }
        public IActionResult DonDaNhan()
        {
            int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            var lstdonhang = _context.Hoadon.Include(h => h.MaKhNavigation).Include(h => h.MaTbNavigation).Include(h => h.MaDcNavigation).Where(d => d.MaKh == makh && d.TrangThai == 2);
            GetInfo();
            return View(lstdonhang);
        }

        public async Task<IActionResult> HuyDon(int? id)
        {
            //int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            Hoadon hd = _context.Hoadon.FirstOrDefault(d => d.MaHd == id && d.Daxoa == 0);
            hd.TrangThai = 3; // đã xoá
            _context.Update(hd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(DonDaHuy));
        }
        public async Task<IActionResult> DaNhan(int? id)
        {
            //int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            Hoadon hd = _context.Hoadon.FirstOrDefault(d => d.MaHd == id && d.Daxoa == 0);
            hd.TrangThai = 2; // đã nhận
            _context.Update(hd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(DonDaNhan));
        }
        public async Task<IActionResult> DaDuyet(int? id)
        {
            //int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            Hoadon hd = _context.Hoadon.FirstOrDefault(d => d.MaHd == id && d.Daxoa == 0);
            hd.TrangThai = 1; // đã duyệt
            _context.Update(hd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(DonDaNhan));
        }

        public async Task<IActionResult> KichHoat(int id)
        {
            Khachhang kh;
            int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            kh = _context.Khachhang.FirstOrDefault(k => k.MaKh == makh);

            Qlthuebao tb = new Qlthuebao();
            tb.MaKh = makh;
            tb.MaTb = id; // mã thuê bao
            tb.NgayKichHoat = DateTime.Now;
            tb.TrangThai = 0;
            tb.Daxoa = 0;
            _context.Add(tb);
            await _context.SaveChangesAsync();
            GetInfo();
            return RedirectToAction(nameof(DonHang));
        }

    }
}
