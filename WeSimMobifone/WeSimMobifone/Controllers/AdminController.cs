using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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

        //------------------------------------- tra cứu hóa đơn -------------------------------------------------------
        // tra cứu hoá đơn
        public async Task<IActionResult> SearchHD(string searchHoaDon)
        {
            var lstHoaDon = await _context.Hoadon.Include(h => h.MaKhNavigation).Include(h => h.MaTbNavigation).Include(h => h.MaDcNavigation)
                            .Where(k => k.MaKhNavigation.Ten.Contains(searchHoaDon) && k.Daxoa == 0 && k.TrangThai == 0).ToListAsync();
            GetInfo();
            return View(lstHoaDon);
        }
        public async Task<IActionResult> SearchD(string searchHoaDonD)
        {
            var lstHoaDon = await _context.Hoadon.Include(h => h.MaKhNavigation).Include(h => h.MaTbNavigation).Include(h => h.MaDcNavigation)
                            .Where(k => k.MaKhNavigation.Ten.Contains(searchHoaDonD) && k.Daxoa == 0 && k.TrangThai == 1).ToListAsync();
            GetInfo();
            return View(lstHoaDon);
        }
        public async Task<IActionResult> SearchVC(string searchHoaDonVC)
        {
            var lstHoaDon = await _context.Hoadon.Include(h => h.MaKhNavigation).Include(h => h.MaTbNavigation).Include(h => h.MaDcNavigation)
                            .Where(k => k.MaKhNavigation.Ten.Contains(searchHoaDonVC) && k.Daxoa == 0 && k.TrangThai == 2).ToListAsync();
            GetInfo();
            return View(lstHoaDon);
        }
        public async Task<IActionResult> SearchN(string searchHoaDonN)
        {
            var lstHoaDon = await _context.Hoadon.Include(h => h.MaKhNavigation).Include(h => h.MaTbNavigation).Include(h => h.MaDcNavigation)
                            .Where(k => k.MaKhNavigation.Ten.Contains(searchHoaDonN) && k.Daxoa == 0 && k.TrangThai == 3).ToListAsync();
            GetInfo();
            return View(lstHoaDon);
        }
        public async Task<IActionResult> SearchH(string searchHoaDonH)
        {
            var lstHoaDon = await _context.Hoadon.Include(h => h.MaKhNavigation).Include(h => h.MaTbNavigation).Include(h => h.MaDcNavigation)
                            .Where(k => k.MaKhNavigation.Ten.Contains(searchHoaDonH) && k.Daxoa == 0 && k.TrangThai == 4).ToListAsync();
            GetInfo();
            return View(lstHoaDon);
        }

        //----------------------------- Hóa đơn ----------------------------------------------
        // lấy thông tin hoá đơn
        void GetInfo()
        {
            

            ViewBag.cuahang = _context.Cuahang.FirstOrDefault();
            ViewData["SLChuaDuyet"] = _context.Hoadon.Where(k => k.TrangThai == 0 && k.Daxoa == 0).Count(); // 0 chưa duyệt
            ViewData["SLDaDuyet"] = _context.Hoadon.Where(k => k.TrangThai == 1 && k.Daxoa == 0).Count(); // 1 đã duyệt
            ViewData["SLDaVanChuyen"] = _context.Hoadon.Where(k => k.TrangThai == 2 && k.Daxoa == 0).Count(); // 2 đã vận chuyển
            ViewData["SLDaNhan"] = _context.Hoadon.Where(k => k.TrangThai == 3 && k.Daxoa == 0).Count();  // 3 đã nhận
            ViewData["SLDaHuy"] = _context.Hoadon.Where(k => k.TrangThai == 4 && k.Daxoa == 0).Count();
            ViewData["SLDanhMuc"] = _context.Danhmuc.Count();
            //  ViewBag.tintuc = _context.Danhmuc.ToList();
            if (HttpContext.Session.GetString("Nhanvien") != "")
            {
                ViewBag.Nhanvien = _context.Nhanvien.FirstOrDefault(k => k.Email == HttpContext.Session.GetString("Nhanvien"));
            }
            if (HttpContext.Session.GetString("khachhang") != "")
            {
                ViewBag.khachhang = _context.Khachhang.FirstOrDefault(k => k.MaKh.ToString() == HttpContext.Session.GetString("khachhang"));
            }
            var lstHD = _context.Hoadon.Where(d => d.TrangThai == 3 && d.Daxoa == 0);
            int tongtien = 0;
            foreach (Hoadon hd in lstHD)
            {
                tongtien += hd.TongTien;
            }
            ViewData["tongtien"] = tongtien.ToString("n0");
        }
        // show hoá đơn
        public async Task<IActionResult> Index() // chưa duyệt 0
        {
            GetInfo();
            var applicationDbContext = _context.Hoadon
                .Include(h => h.MaKhNavigation)
                .Include(h => h.MaTbNavigation)
                .Include(h => h.MaDcNavigation)
                .Where(k => k.TrangThai == 0 && k.Daxoa == 0);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> DaDuyetDon()  // đã duyệt 1
        {
            GetInfo();
            var applicationDbContext = _context.Hoadon
                .Include(h => h.MaKhNavigation)
                .Include(h => h.MaTbNavigation)
                .Include(h => h.MaDcNavigation)
                .Where(k => k.TrangThai == 1 && k.Daxoa == 0);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> DaVanChuyen() // đã vận chuyển 2
        {
            GetInfo();
            var applicationDbContext = _context.Hoadon
                .Include(h => h.MaKhNavigation)
                .Include(h => h.MaTbNavigation)
                .Include(h => h.MaDcNavigation)
                .Where(k => k.TrangThai == 2 && k.Daxoa == 0);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> DaNhanDon() //đã nhận đơn 3
        {
            GetInfo();
            var applicationDbContext = _context.Hoadon
                .Include(h => h.MaKhNavigation)
                .Include(h => h.MaTbNavigation)
                .Include(h => h.MaDcNavigation)
                .OrderByDescending(k => k.MaHd)
                .Where(k => k.TrangThai == 3 && k.Daxoa == 0);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> DaHuy() //đã huỷ 4
        {
            GetInfo();
            var applicationDbContext = _context.Hoadon
                .Include(h => h.MaKhNavigation)
                .Include(h => h.MaTbNavigation)
                .Include(h => h.MaDcNavigation)
                .OrderByDescending(t => t.MaHd)
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
        // cập nhật trạng thái đơn hàng
        public async Task<IActionResult> DuyetHoaDon(int? id, int matb, int makh) // duyệt đơn hàng 1
        {
            Khachhang kh = _context.Khachhang.FirstOrDefault(d => d.MaKh == makh);
            if (kh.SlthueB == 3)
            {
                return RedirectToAction(nameof(ThongBaoLoi));
            }
            else
            {
                kh.SlthueB = kh.SlthueB + 1; // đã nhận
                _context.Update(kh);
                await _context.SaveChangesAsync();
            }
           
            //int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            Hoadon hd = _context.Hoadon.FirstOrDefault(d => d.MaHd == id);
            hd.TrangThai = 1; // đã nhận
            _context.Update(hd);
            await _context.SaveChangesAsync();

            Qlthuebao tb = new Qlthuebao();
            tb.MaKh = makh;
            tb.MaTb = matb; // mã thuê bao
            tb.TrangThai = 0;
            tb.Daxoa = 0;
            _context.Add(tb);
            await _context.SaveChangesAsync();
            GetInfo();
            return RedirectToAction(nameof(DaDuyetDon));


        }
        public async Task<IActionResult> HuyHoaDon(int? id) // huỷ đơn hàng 4 
        {
            //int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            Hoadon hd = _context.Hoadon.FirstOrDefault(d => d.MaHd == id && d.Daxoa == 0);
            hd.TrangThai = 4; // đã nhận
            _context.Update(hd);
            await _context.SaveChangesAsync();

            Thuebao tb = await _context.Thuebao.FirstOrDefaultAsync(d => d.MaTb == hd.MaTb);
            tb.TrangThai = 0;
            _context.Update(tb);
            await _context.SaveChangesAsync();

            GetInfo();
            return RedirectToAction(nameof(DaHuy));
        }
        public async Task<IActionResult> DaVanChuyenHang(int? id) // đang vận chuyển 2
        {
            //int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            Hoadon hd = _context.Hoadon.FirstOrDefault(d => d.MaHd == id && d.Daxoa == 0);
            hd.TrangThai = 2; // đã nhận
            _context.Update(hd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(DaVanChuyen));
        }
        // in hoá đơn
        public async Task<IActionResult> InHoaDon(int? id)
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
        public async Task<IActionResult> InHoaDon1(int? id)
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
        // thông báo lỗi
        public IActionResult ThongBaoLoi(){
            GetInfo();
            return View();
        }
        // GET: show thôn tin hóa đơn xóa
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hd = await _context.Hoadon
                .FirstOrDefaultAsync(m => m.MaHd == id);
            if (hd == null)
            {
                return NotFound();
            }
            GetInfo();
            return View(hd);
        }
        // POST: xóa hóa đơn
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hd = await _context.Hoadon.FindAsync(id);
            hd.Daxoa = 1;
            _context.Hoadon.Update(hd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        //------------------------------------------Khách hàng--------------------------------------------------
        // Xuất thông tin khách hàng
        public IActionResult Customer()
        {
            GetInfo();
            return View();
        }

        // sửa thông tin khách hàng
        public async Task<IActionResult> EditAccount(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kh = await _context.Khachhang.FindAsync(id);
            if (kh == null)
            {
                return NotFound();
            }
            GetInfo();
            return View(kh);
        }

        // sửa thông tin khách hàng
        [HttpPost]
        public async Task<IActionResult> EditAccount(int id, [Bind("MaKh,Ten,DienThoai,Email,MatKhau,HinhT,HinhS")] Khachhang kh, string mk, IFormFile hinht, IFormFile hinhs, string cccd)
        {
            if (id != kh.MaKh)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(cccd))
                {
                    ModelState.AddModelError("IDCardNumber", "Căn cước không được để trống");
                    GetInfo();
                    return View(kh);
                }
                else if (!cccd.StartsWith("0") || cccd.Length != 12)
                {
                    ModelState.AddModelError("IDCardNumber", "Căn cước phải có đủ 12 số và số đầu tiên phải là số 0");
                    GetInfo();
                    return View(kh);
                }
                try
                {
                    if (mk != null)
                    {
                        kh.MatKhau = _passwordHasher.HashPassword(kh, mk);
                    }
                    if (hinht != null)
                    {
                        kh.HinhT = Upload(hinht);
                    }
                    if (hinhs != null)
                    {
                        kh.HinhS = Upload1(hinhs);
                    }
                    kh.Cccd = cccd;
                    _context.Update(kh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhachHangExists(kh.MaKh))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Customer));
            }
            GetInfo();
            return View(kh);
        }
        private bool KhachHangExists(int id)
        {
            return _context.Nhanvien.Any(e => e.MaNv == id);
        }
        // hiển thị thêu bao đã đăng ký 
        public IActionResult ShowThueBaoKhach()
        {
            int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            var listThueBao = _context.Qlthuebao
                .Include(h => h.MaTbNavigation)
                .Include(h => h.MaKhNavigation)
                .OrderByDescending(t => t.MaQl)
                .Where(d => d.MaKh == makh && d.Daxoa == 0).ToList();
            GetInfo();
            return View(listThueBao);
        }
        // hiển thị thuê bao đã hủy
        public IActionResult ShowThueBaoKhachHuy()
        {
            int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            var listThueBao = _context.Qlthuebao
                .Include(h => h.MaTbNavigation)
                .Include(h => h.MaKhNavigation)
                .OrderByDescending(t => t.MaQl)
                .Where(d => d.MaKh == makh && d.Daxoa == 1).ToList();
            GetInfo();
            return View(listThueBao);
        }
        // xuất địa chỉ khách hàng
        public IActionResult Address()
        {
            int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            var lstDiaChi = _context.Diachi.Where(d => d.MaKh == makh && d.Daxoa == 0).ToList();
            GetInfo();
            return View(lstDiaChi);
        }

        // thêm địa chỉ khách hàng
        public IActionResult AddAddress()
        {
            GetInfo();
            return View();
        }
        
        // thêm địa chỉ khách hàng
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
            GetInfo();
            return RedirectToAction(nameof(Address));
        }
       
        // xoá địa chỉ
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
       
        // show đơn hàng
        public IActionResult DonHang() // đơn hàng chưa duyệt 0
        {
            int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            var lstdonhang = _context.Hoadon
                .Include(h => h.MaKhNavigation)
                .Include(h => h.MaTbNavigation)
                .Include(h => h.MaDcNavigation)
                .OrderByDescending(t => t.MaHd)
                .Where(d => d.MaKh == makh && (d.TrangThai == 0 || d.TrangThai == 1 || d.TrangThai == 2) && d.Daxoa == 0);
            GetInfo();
            return View(lstdonhang);
        }
        public IActionResult DonDaHuy()// đơn hàng đã huỷ 4
        {
            int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            var lstdonhang = _context.Hoadon
                .Include(h => h.MaKhNavigation)
                .Include(h => h.MaTbNavigation)
                .Include(h => h.MaDcNavigation)
                .OrderByDescending(t => t.MaHd)
                .Where(d => d.MaKh == makh && d.TrangThai == 4 && d.Daxoa == 0);
            GetInfo();
            return View(lstdonhang);
        }
        public IActionResult DonDaNhan()// đơn hàng đã nhận 3
        {
            int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            var lstdonhang = _context.Hoadon
                .Include(h => h.MaKhNavigation)
                .Include(h => h.MaTbNavigation)
                .Include(h => h.MaDcNavigation)
                .OrderByDescending(t => t.MaHd)
                .Where(d => d.MaKh == makh && d.TrangThai == 3 && d.Daxoa == 0);

            GetInfo();
            return View(lstdonhang);
        }
       
        // cập nhật trạng thái đơn hàng
        public async Task<IActionResult> KhachDaNhanDon(int? id) // đang vận chuyển 3
        {
            //int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            Hoadon hd = _context.Hoadon.FirstOrDefault(d => d.MaHd == id && d.Daxoa == 0);
            hd.TrangThai = 3; // đã nhận
            _context.Update(hd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(DonDaNhan));
        }
       
        // cập nhật kích hoạt SIM
        public async Task<IActionResult> KichHoat(int id, int idTB)  // mã khách hàng
        {

            int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            Qlthuebao tb = _context.Qlthuebao.FirstOrDefault(d => d.MaKh == id && d.Daxoa == 0 && d.MaTb == idTB);
            tb.NgayKichHoat = DateTime.Now;
            tb.TrangThai = 1; // đã nhận
            _context.Update(tb);
            await _context.SaveChangesAsync();

            Thuebao lsttb = await _context.Thuebao.FirstOrDefaultAsync(d => d.MaTb ==  idTB);
            lsttb.TrangThai = 2;
            _context.Update(lsttb);
            await _context.SaveChangesAsync();
            GetInfo();
            return RedirectToAction(nameof(DonDaNhan));
        }
       
        // chi tiết đơn khách hàng
        public async Task<IActionResult> ChiTietDonHangKhach(int? id)
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

            int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            var tb = _context.Qlthuebao.FirstOrDefault(d => d.MaKh == makh && d.Daxoa == 0 && d.MaTb == hoadon.MaTb);// điều kiện sai
            ViewBag.qlthuebao = tb;
            GetInfo();
            return View(hoadon);
        }



        // -------------------------báo cáo thống kê -----------------------
        [HttpPost]
        public IActionResult BaoCao(DateTime ngaybatdau ,DateTime ngayketthuc)
        {
            var lstHD = _context.Hoadon.Include(d => d.MaKhNavigation).Include(d => d.MaDcNavigation).Include(d => d.MaTbNavigation)
                .Where(d => d.Ngay >= ngaybatdau && d.Ngay <= ngayketthuc && d.TrangThai == 3);
            int tongtien = 0;
            foreach (Hoadon hd in lstHD)
            {
                tongtien += hd.TongTien;
            }
            ViewData["ngaybatdau"] = ngaybatdau.Month.ToString() + "/" + ngaybatdau.Day.ToString() + "/" + ngaybatdau.Year.ToString();
            ViewData["ngayketthuc"] = ngayketthuc.Month.ToString() + "/" + ngayketthuc.Day.ToString() + "/" + ngayketthuc.Year.ToString();
            ViewData["tongtienDH"] = tongtien.ToString("n0");
            GetInfo();
            return View(lstHD);
        }
        public IActionResult BaoCaothuebao(DateTime ngaybatdau1 ,DateTime ngayketthuc1)
        {
            var lstHD = _context.Qlthuebao
                .Include(d => d.MaTbNavigation)
                .Include(h => h.MaTbNavigation.MaLtbNavigation)
                .Include(h => h.MaTbNavigation.MaDmNavigation)
                .OrderByDescending(t => t.MaQl)
                .Where(d => d.NgayKichHoat >= ngaybatdau1 && d.NgayKichHoat <= ngayketthuc1 && d.TrangThai == 1);
           
            ViewData["ngaybatdau1"] = ngaybatdau1.Month.ToString() + "/" + ngaybatdau1.Day.ToString() + "/" + ngaybatdau1.Year.ToString();
            ViewData["ngayketthuc1"] = ngayketthuc1.Month.ToString() + "/" + ngayketthuc1.Day.ToString() + "/" + ngayketthuc1.Year.ToString();
            GetInfo();
            return View(lstHD);
        }
        public IActionResult BaoCaoTong()
        {
            GetInfo();
            return View();
        }
        public async Task<IActionResult> BaoCaoNgay()
        {
            var hd = _context.Hoadon
                .Include(h => h.MaDcNavigation)
                .Include(h => h.MaKhNavigation)
                .Include(h => h.MaTbNavigation)
                .OrderByDescending(t => t.MaHd)
                .Where(h => h.TrangThai == 3);
            GetInfo();
            return View(await hd.ToListAsync());
        }
        public IActionResult ThongKeThueBao()
        {
            var tb = _context.Qlthuebao
                .Include(h => h.MaTbNavigation.MaLtbNavigation)
                .Include(h => h.MaTbNavigation.MaDmNavigation)
                .Include(h => h.MaTbNavigation)
                .OrderByDescending(t => t.MaQl)
                .Where(h => h.TrangThai == 1);
            GetInfo();
            return View(tb.ToList());
        }



        //-----------------------EXCEL------------------------------
        [HttpGet]
        // xuất ex tất cả hóa đơn
        public async Task<FileResult> DowloadEx()
        {
            var hoadon = await _context.Hoadon
                .Include(h => h.MaDcNavigation)
                .Include(h => h.MaKhNavigation)
                .Include(h => h.MaTbNavigation)
                .Where(h => h.TrangThai == 3).ToListAsync();
            var fil = "Hoa_Don.xlsx";
            return Excel(fil, hoadon);
        }
        // xuất ex tất cả thuê bao 
        public async Task<FileResult> DowloadEx3()
        {
            var tb = await _context.Qlthuebao
                .Include(h => h.MaTbNavigation)
                .Where(h => h.TrangThai == 1).ToListAsync();
            var fil = "ThueBao.xlsx";
            return Excel1(fil, tb);
        }
        // xuất ex hóa đơn theo ngày
        public async Task<FileResult> DowloadEx1(DateTime  BD, DateTime KT)
        {
            var hoadon = await _context.Hoadon
                .Include(h => h.MaDcNavigation)
                .Include(h => h.MaKhNavigation)
                .Include(h => h.MaTbNavigation)
                .Where(d => d.Ngay >= BD && d.Ngay <= KT && d.TrangThai == 3).ToListAsync();
            var fil = "Hoa_Don.xlsx";
            return Excel(fil, hoadon);
        } 
        // xuất ex thuê bao theo ngày
        public async Task<FileResult> DowloadEx2(DateTime  BD, DateTime KT)
        {
            var tb = await _context.Qlthuebao
                .Include(h => h.MaTbNavigation)
                .Where(d => d.NgayKichHoat >= BD && d.NgayKichHoat <= KT && d.TrangThai == 1).ToListAsync();
            var fil1 = "Thue_Bao.xlsx";
            return Excel1(fil1, tb);
        }
        // xuất ra ex hóa đơn
        private FileResult Excel(string fil, IEnumerable<Hoadon> hoadon)
        {
            DataTable data = new DataTable("hoadon");
            data.Columns.AddRange(new DataColumn[]
            {
              new DataColumn("Mã hóa đơn"),
              new DataColumn("Số thuê bao"),
              new DataColumn("Ngày đặt"),
              new DataColumn("Tên khách hàng"),
              new DataColumn("Địa chỉ"),
              new DataColumn("Tổng tiền"),
            });

            foreach (var p in hoadon)
            {
                data.Rows.Add(p.MaHd, p.MaTbNavigation.SoThueBao, p.Ngay, p.MaKhNavigation.Ten, p.MaDcNavigation.DiaChi1, p.TongTien);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(data);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fil);
                }
            }
        }
        // xuất ra ex thuê bao
        private FileResult Excel1(string fil1, IEnumerable<Qlthuebao> qltb)
            {
                DataTable data = new DataTable("thuebao");
                data.Columns.AddRange(new DataColumn[]
                {
              new DataColumn("số thuê bao"),
              new DataColumn("Phí Hòa mạng"),
              new DataColumn("Loại số"),
              new DataColumn("Điểm hòa mạng"),
              new DataColumn("Ngày kích hoạt"),
                });

                foreach (var p in  qltb)
                {
                    data.Rows.Add(p.MaTbNavigation.SoThueBao, p.MaTbNavigation.PhiHoaMang,p.MaTbNavigation.LoaiSo, p.MaTbNavigation.DiaDiemHm,p.NgayKichHoat);
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(data);
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fil1);
                    }
                }
            }
    }
}
