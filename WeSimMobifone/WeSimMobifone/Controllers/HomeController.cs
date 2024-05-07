using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WeSimMobifone.Data;
using WeSimMobifone.Models;

namespace WeSimMobifone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<Khachhang> _pwHear;
        private readonly IPasswordHasher<Nhanvien> _nvpasswordHasher;
        public HomeController(ApplicationDbContext context,IPasswordHasher<Khachhang> passwordHasher, IPasswordHasher<Nhanvien> nvpasswordHasher)
        {
            _context = context;
            _pwHear = passwordHasher;
            _nvpasswordHasher = nvpasswordHasher;
        }
        // lấy dữ liệu bảng
        void GetInfo()
        {
            // lấy dữ liệu bảng danh mục
            ViewBag.danhmuc = _context.Danhmuc.ToList();
            // lấy dữ liệu của hàng
            ViewBag.cuahang = _context.Cuahang.FirstOrDefault();
            // lấy dữ liệu bảng tin tức
            ViewBag.tintuc = _context.Tintuc.Where(d => d.Hot == 1).ToList();
            // số lượng mặt hàng có trong giỏ   
           
            // ViewBag.thuebao = _context.Thuebao.FirstOrDefault(k => k.TrangThai == int.Parse(HttpContext.Session.GetString("Thuebao")));

            if (HttpContext.Session.GetString("khachhang") != "")
            {
                ViewBag.khachhang = _context.Khachhang.FirstOrDefault(k => k.MaKh.ToString() == HttpContext.Session.GetString("khachhang"));

            }
            if (HttpContext.Session.GetString("Nhanvien") != "")
            {
                ViewBag.Nhanvien = _context.Nhanvien.FirstOrDefault(k => k.Email == HttpContext.Session.GetString("Nhanvien"));
            }
        }

        // GET: Home // hiển thị danh sách sp
        public async Task<IActionResult> Index()
        {
            GetInfo();
            var applicationDbContext = _context.Thuebao
                .Include(t => t.MaDmNavigation)
                .Include(t => t.MaLtbNavigation)
                .OrderByDescending(t => t.MaTb)
                .Where(h => h.TrangThai == 0 && h.Daxoa == 0);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> SearchTB(string timkiemTB, int id)
        {
            GetInfo();  
            if(id == 1)
            {
                string timkiem = "093";
                var applicationDbContext = _context.Thuebao.Include(t => t.MaDmNavigation).Include(t => t.MaLtbNavigation).Where(k => k.SoThueBao.Contains(timkiem) && k.TrangThai == 0 && k.Daxoa == 0).ToListAsync();
                ViewBag.timkiem = timkiem;
                return View(await applicationDbContext);
            }
            else
            {
                if (id == 2)
                {
                    string timkiem = "090";
                    var applicationDbContext = _context.Thuebao.Include(t => t.MaDmNavigation).Include(t => t.MaLtbNavigation).Where(k => k.SoThueBao.Contains(timkiem) && k.TrangThai == 0 && k.Daxoa == 0).ToListAsync();
                    ViewBag.timkiem = timkiem;
                    return View(await applicationDbContext);
                }
                else
                {
                    if (id ==3)
                    {
                        string timkiem = "089";
                        var applicationDbContext = _context.Thuebao.Include(t => t.MaDmNavigation).Include(t => t.MaLtbNavigation).Where(k => k.SoThueBao.Contains(timkiem) && k.TrangThai == 0 && k.Daxoa == 0).ToListAsync();
                        ViewBag.timkiem = timkiem;
                        return View(await applicationDbContext);
                    }
                    else
                    {
                        if (id == 4)
                        {
                            string timkiem = "070";
                            var applicationDbContext = _context.Thuebao.Include(t => t.MaDmNavigation).Include(t => t.MaLtbNavigation).Where(k => k.SoThueBao.Contains(timkiem) && k.TrangThai == 0 && k.Daxoa == 0).ToListAsync();
                            ViewBag.timkiem = timkiem;
                            return View(await applicationDbContext);
                        }
                        else
                        {
                            if (id == 5)
                            {
                                string timkiem = "076";
                                var applicationDbContext = _context.Thuebao.Include(t => t.MaDmNavigation).Include(t => t.MaLtbNavigation).Where(k => k.SoThueBao.Contains(timkiem) && k.TrangThai == 0 && k.Daxoa == 0).ToListAsync();
                                ViewBag.timkiem = timkiem;
                                return View(await applicationDbContext);
                            }
                            else
                            {
                                if (id == 6)
                                {
                                    string timkiem = "077";
                                    var applicationDbContext = _context.Thuebao.Include(t => t.MaDmNavigation).Include(t => t.MaLtbNavigation).Where(k => k.SoThueBao.Contains(timkiem) && k.TrangThai == 0 && k.Daxoa == 0).ToListAsync();
                                    ViewBag.timkiem = timkiem;
                                    return View(await applicationDbContext);
                                }
                                else
                                {
                                    if (id == 7)
                                    {
                                        string timkiem = "078";
                                        var applicationDbContext = _context.Thuebao.Include(t => t.MaDmNavigation).Include(t => t.MaLtbNavigation).Where(k => k.SoThueBao.Contains(timkiem) && k.TrangThai == 0 && k.Daxoa == 0).ToListAsync();
                                        ViewBag.timkiem = timkiem;
                                        return View(await applicationDbContext);
                                    }
                                    else
                                    {
                                        if (id == 8)
                                        {
                                            string timkiem = "079";
                                            var applicationDbContext = _context.Thuebao.Include(t => t.MaDmNavigation).Include(t => t.MaLtbNavigation).Where(k => k.SoThueBao.Contains(timkiem) && k.TrangThai == 0 && k.Daxoa == 0).ToListAsync();
                                            ViewBag.timkiem = timkiem;
                                            return View(await applicationDbContext);
                                        }
                                        else
                                        {
                                            ViewBag.timkiem = timkiemTB;
                                            var applicationDbContext = _context.Thuebao.Include(t => t.MaDmNavigation).Include(t => t.MaLtbNavigation).Where(k => k.SoThueBao.Contains(timkiemTB) && k.TrangThai == 0 && k.Daxoa == 0).ToListAsync();
                                            return View(await applicationDbContext);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        // danh mục thuê bao
        public async Task<IActionResult> DanhMucSP(int id)
        {
            GetInfo();
            var applicationDbContext = _context.Thuebao.Include(t => t.MaDmNavigation).Include(t => t.MaLtbNavigation).Where(h => h.TrangThai == 0 && h.MaDm == id && h.Daxoa == 0);
            var tb  =  _context.Danhmuc.FirstOrDefault(h => h.MaDm == id);
            ViewBag.DM = tb;
                
            return View(await applicationDbContext.ToListAsync());
        }

        //------------------------ đăng nhập --- đăng ký --------------------
        // đăng nhập
        public IActionResult Login()
        {
            GetInfo();
            return View();
        }
        // khách mua hàng ch đăng nhập
        public async Task<IActionResult> LoginKH(int? id)
        {
            Thuebao sp = _context.Thuebao.FirstOrDefault(d => d.MaTb == id);
            sp.TrangThai = 0;
            _context.Update(sp);
           await _context.SaveChangesAsync();
            GetInfo();
            return View();
        }
        // đăng nhập thất bại
        public IActionResult LoginInAgain()
        {
            GetInfo();
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string matkhau)
        {
            var nv = _context.Nhanvien.FirstOrDefault(k => k.Email == email && k.Daxoa == 0);

            Khachhang kh = _context.Khachhang.FirstOrDefault(k => k.Email == email && k.MatKhau != null && k.Daxoa == 0);

            if (kh != null && matkhau!= null && _pwHear.VerifyHashedPassword(kh, kh.MatKhau, matkhau) == PasswordVerificationResult.Success)
            {
                HttpContext.Session.SetString("khachhang", kh.MaKh.ToString());
                return RedirectToAction(nameof(Index));
            }
            else
            {
                if (nv != null && _nvpasswordHasher.VerifyHashedPassword(nv,nv.MatKhau, matkhau) == PasswordVerificationResult.Success)
                {
                    HttpContext.Session.SetString("Nhanvien", email);
                    return RedirectToAction("Index", "Admin");
                }
            }
            return RedirectToAction(nameof(LoginInAgain));

        }
        // đăng ký
        public IActionResult Register()
        {
            GetInfo();
            return View();
        }
        // đăng ký
        [HttpPost]
        public async Task<IActionResult> Register([Bind("MaNv,Ten,MaCv,DienThoai,Email")] Khachhang kh, string MatKhau)
        {
            if (ModelState.IsValid)
            {
                if (_context.Khachhang.Any(h => (h.Email == kh.Email || h.DienThoai == kh.DienThoai) && h.Daxoa == 0))
                {
                    ModelState.AddModelError(string.Empty, "Email hoặc số điện thoại đã tồn tại");
                    GetInfo();
                    return View(kh);
                }
                kh.MatKhau = _pwHear.HashPassword(kh, MatKhau);
                _context.Add(kh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }
            GetInfo();
            return View(kh);
        }
        // đăng xuất
        public IActionResult Signout()
        {
            HttpContext.Session.SetString("khachhang", "");
            HttpContext.Session.SetString("Nhanvien", "");
            GetInfo();
            return RedirectToAction(nameof(Index));
        }
        // đăng xuất nhân viên
        public async Task<IActionResult> SignoutNV(int? id)
        {
            Thuebao sp = _context.Thuebao.FirstOrDefault(d => d.MaTb == id);
            sp.TrangThai = 0;
            _context.Update(sp);
            await _context.SaveChangesAsync();

            HttpContext.Session.SetString("Nhanvien", "");
            GetInfo();
            return RedirectToAction(nameof(Login));
        }

        //---------------------- khách hàng đăng ký thuê bao -----------------------
        // Giữ số khi khách hàng chọn thuê bao
        public async Task<IActionResult> Update(int? id)
        {
            //int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            Thuebao sp = _context.Thuebao.FirstOrDefault(d => d.MaTb == id && d.Daxoa == 0);
            sp.TrangThai = 0;
            _context.Update(sp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // GET: đưa ra thông tin bill
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
            if(HttpContext.Session.GetString("khachhang") != null)
            {
                int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
                Khachhang kh = _context.Khachhang.FirstOrDefault(k => k.MaKh == makh);
                if (kh.SlthueB == 3)
                {
                    return RedirectToAction(nameof(KiemTraSL));
                }

                List<Diachi> lstDiaChi = _context.Diachi.Where(d => d.MaKh == makh && d.Daxoa == 0).ToList();
                ViewBag.diachi = lstDiaChi;

            }
            Thuebao sp = _context.Thuebao.FirstOrDefault(d => d.MaTb == id);
            sp.TrangThai = 1;
            _context.Update(sp);
            await _context.SaveChangesAsync();
            GetInfo();
            return View(thuebao);
        }
        // thông báo lỗi khi thuê bao đã đủ
        public IActionResult KiemTraSL()
        {
            GetInfo();
            return View();
        }
        // đăng ký thuê bao
        public async Task<IActionResult> CreateBill(int id, int madiachi, int phihoamang,string cccd, IFormFile hinht, IFormFile hinhs)
        {
            Khachhang kh;
            Diachi dc;
            int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            kh = _context.Khachhang.FirstOrDefault(k => k.MaKh == makh);
            if(kh.Cccd == null)
            {
                kh.Cccd = cccd;
                _context.Update(kh);
                await _context.SaveChangesAsync();
            }
            if(kh.HinhT == null && kh.HinhS == null)
            {
                kh.HinhS = Upload1(hinhs);
                kh.HinhT = Upload(hinht);
                _context.Update(kh);
                await _context.SaveChangesAsync();
            }

            dc = _context.Diachi.FirstOrDefault(d => d.MaDc == madiachi);
             
            // Mua trong giỏ hàng
               Hoadon hd = new Hoadon();
                hd.MaTb = id;
                hd.MaKh = kh.MaKh;
                hd.Ngay = DateTime.Now;
                hd.MaDc = dc.MaDc;
                hd.TongTien = phihoamang;
                hd.TrangThai = 0; //0: chưa duyệt, 1: đã duyệt, 2: hủy
                _context.Add(hd);
                await _context.SaveChangesAsync();

            List<Diachi> lstDiaChi = _context.Diachi.Where(d => d.MaKh == makh && d.Daxoa == 0).ToList();
            ViewBag.diachi = lstDiaChi;

            GetInfo();
            return View(hd);
        }
        // tải ảnh lên
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
        // tải ảnh lên
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
        // thêm địa chỉ
        [HttpPost]
        public async Task<IActionResult> ThemDiaChi(int? id,string diachicuthe, string phuongxa, string quanhuyen, string tinhthanh)
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

            int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            Khachhang kh = _context.Khachhang.FirstOrDefault(k => k.MaKh == makh);
            if (kh.SlthueB == 3)
            {
                return RedirectToAction(nameof(KiemTraSL));
            }

            Diachi dc = new Diachi();
            dc.MaKh = makh;
            dc.DiaChi1 = diachicuthe;
            dc.PhuongXa = phuongxa;
            dc.QuanHuyen = quanhuyen;
            dc.TinhThanh = tinhthanh;
            var kt = _context.Diachi.FirstOrDefault(d => d.MaKh == makh);
            if (kt != null)
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

            List<Diachi> lstDiaChi = _context.Diachi.Where(d => d.MaKh == makh && d.Daxoa == 0).ToList();
            ViewBag.diachi = lstDiaChi;
            GetInfo();
            return View(thuebao);
        }
        // Giới Thiệu công ty
        public IActionResult GioiThieu()
        {
            GetInfo();
            return View();
        }

        public async Task<IActionResult> XoaTaiKhoan(int? id)
        {
            Khachhang kh = await _context.Khachhang.FirstOrDefaultAsync(d => d.MaKh == id);
            kh.Daxoa = 2;
            _context.Update(kh);
            await _context.SaveChangesAsync();

            HttpContext.Session.SetString("khachhang", "");
            GetInfo();
            return RedirectToAction(nameof(Login));
        }


    }
}
