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
    public class KhachhangsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KhachhangsController(ApplicationDbContext context)
        {
            _context = context;
        }
        void GetInfo()
        {
            ViewBag.cuahang = _context.Cuahang.ToList();
            //  ViewBag.tintuc = _context.Danhmuc.ToList();
            if (HttpContext.Session.GetString("Nhanvien") != "")
            {
                ViewBag.Nhanvien = _context.Nhanvien.FirstOrDefault(k => k.Email == HttpContext.Session.GetString("Nhanvien"));
            }
        }
        // GET: Khachhangs
        public async Task<IActionResult> Index()
        {
            GetInfo();
            return View(await _context.Khachhang.ToListAsync());
        }

        // GET: // số thuê bao đã đăng ký
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhang
                .FirstOrDefaultAsync(m => m.MaKh == id);
            if (khachhang == null)
            {
                return NotFound();
            }
            List<Qlthuebao> listQlTB = _context.Qlthuebao.Include(d => d.MaTbNavigation).Where(d => d.MaKh == id && d.Daxoa == 0).ToList();
            ViewBag.QlTB = listQlTB;
            GetInfo();
            return View(khachhang);
        }
        // tìm kiếm khách hàng
        public async Task<IActionResult> SearchKH(string searchKhachHang)
        {
            var lstKhachHang = await _context.Khachhang.Where(k => k.Ten.Contains(searchKhachHang)).ToListAsync();
            GetInfo();
            return View(lstKhachHang);
        }
        // huỷ thuê bao
        public async Task<IActionResult> HuyThueBao(int id)
        {
            Qlthuebao tb = await _context.Qlthuebao.FirstOrDefaultAsync(k => k.MaQl == id );
            tb.Daxoa = 1;
            _context.Update(tb);
            await _context.SaveChangesAsync();

            Khachhang kh = await _context.Khachhang.FirstOrDefaultAsync(k => k.MaKh == tb.MaKh && k.Daxoa == 0);
            kh.SlthueB = kh.SlthueB - 1;
            _context.Update(kh);
            await _context.SaveChangesAsync();

            Thuebao thuebao = await _context.Thuebao.FirstOrDefaultAsync(k => k.MaTb == tb.MaTb );
            thuebao.TrangThai = 0;
            _context.Update(thuebao);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        // đăng ký thuê bao
        public async Task<IActionResult> DSThueBao(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhang
                .FirstOrDefaultAsync(m => m.MaKh == id);
            if (khachhang == null)
            {
                return NotFound();
            }
            List<Thuebao> listTB = _context.Thuebao.Include(d => d.MaDmNavigation).Include(d => d.MaLtbNavigation).Where(d => d.TrangThai == 0 && d.Daxoa == 0).ToList();
            ViewBag.thuebao = listTB;
            GetInfo();
            return View(khachhang);
        }

        public async Task<IActionResult> DangKyTB(int idTB ,int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhang
                .FirstOrDefaultAsync(m => m.MaKh == id);

            var dc = await _context.Diachi.Include(d => d.MaKhNavigation).FirstOrDefaultAsync(m => m.MaKh == id && m.MacDinh == 1);
            ViewBag.diachi = dc;

            var thuebao = await _context.Thuebao
                .Include(t => t.MaDmNavigation)
                .Include(t => t.MaLtbNavigation)
                .FirstOrDefaultAsync(m => m.MaTb == idTB);
            thuebao.TrangThai = 1;
            _context.Update(thuebao);
            await _context.SaveChangesAsync();
            ViewBag.tb = thuebao;

            if (thuebao == null)
            {
                return NotFound();
            }
            GetInfo();
            return View(khachhang);
        }
        public async Task<IActionResult> LuuDangKyTB(int id/*makh*/,int idTB ,int phihoamang)
        {
            Diachi dc = await _context.Diachi.Include(d => d.MaKhNavigation).FirstOrDefaultAsync( m => m.MaKh == id && m.MacDinh == 1) ;

            // tạo hoá đơn
            Hoadon hd = new Hoadon();
            hd.MaTb = idTB;
            hd.MaKh = id;
            hd.Ngay = DateTime.Now;
            hd.MaDc = dc.MaDc;
            hd.TongTien = phihoamang;
            hd.TrangThai = 3; //0: chưa duyệt, 1: đã duyệt, 2: hủy
            _context.Add(hd);
            await _context.SaveChangesAsync();

            // cập nhật trạng thái đơn hàng
            Khachhang kh = await _context.Khachhang.FirstOrDefaultAsync(d => d.MaKh == id && d.Daxoa == 0);
            kh.SlthueB = kh.SlthueB + 1;
            _context.Update(kh);
            await _context.SaveChangesAsync();

            // lưu thông tin khách hàng vào thuê bao
            Qlthuebao tb = new Qlthuebao();
            tb.MaKh = id;
            tb.MaTb = idTB; // mã thuê bao
            tb.NgayKichHoat = DateTime.Now;
            tb.TrangThai = 1;
            tb.Daxoa = 0;
            _context.Add(tb);
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
        public IActionResult InHoaDonKH1(int? id)
        {
            List<Hoadon> lstHoaDon = _context.Hoadon
                .Include(h => h.MaKhNavigation)
                .Include(h => h.MaTbNavigation)
                .Include(h => h.MaDcNavigation)
                .Where(d => d.MaHd == id && d.Daxoa == 0 && d.TrangThai == 3).ToList();
            ViewBag.Hoadon = lstHoaDon;
            return View();
        }
    }
}
