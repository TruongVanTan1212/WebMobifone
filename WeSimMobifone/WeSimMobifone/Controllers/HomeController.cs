using System;
using System.Collections.Generic;
using System.Linq;
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

        public HomeController(ApplicationDbContext context,IPasswordHasher<Khachhang> passwordHasher)
        {
            _context = context;
            _pwHear = passwordHasher;
        }
        // lấy dữ liệu bảng
        void GetInfo()
        {
            // lấy dữ liệu bảng danh mục
            ViewBag.danhmuc = _context.Danhmuc.ToList();
            // lấy dữ liệu của hàng
            ViewBag.cuahang = _context.Cuahang.ToList();
            // lấy dữ liệu bảng tin tức
            ViewBag.tintuc = _context.Tintuc.ToList();
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
            var applicationDbContext = _context.Thuebao.Include(t => t.MaDmNavigation).Include(t => t.MaLtbNavigation).Where(h =>h.TrangThai==0);
            return View(await applicationDbContext.ToListAsync());
        }
        // danh mục thuê bao
        public async Task<IActionResult> DanhMucSP(int id)
        {
            GetInfo();
            var applicationDbContext = _context.Thuebao.Include(t => t.MaDmNavigation).Include(t => t.MaLtbNavigation).Where(h => h.TrangThai == 0 && h.MaDm == id);
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

            int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            List<Diachi> lstDiaChi = _context.Diachi.Where(d => d.MaKh == makh).ToList();
            ViewBag.diachi = lstDiaChi;
            GetInfo();
            return View(thuebao);
        }

        // đăng nhập
        public IActionResult Login()
        {
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
            if(String.IsNullOrEmpty(email) || String.IsNullOrEmpty(matkhau))
            {
                // không nhập email hoặc mật khẩu
                return RedirectToAction(nameof(LoginInAgain));
            }

            var nv1 = _context.Nhanvien.FirstOrDefault(k => k.Email == email);
            var nv2 = _context.Nhanvien.FirstOrDefault(k => k.MatKhau == matkhau);
            var kh = _context.Khachhang.FirstOrDefault(k => k.Email == email);
            if (kh != null && _pwHear.VerifyHashedPassword(kh, kh.MatKhau, matkhau) == PasswordVerificationResult.Success)
            {
                HttpContext.Session.SetString("khachhang", kh.MaKh.ToString());
                return RedirectToAction("Customer", "Admin");
            }
            else
            {
                if (nv1 != null && nv2 != null)
                {
                    HttpContext.Session.SetString("Nhanvien", nv1.Email);
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
        // tài khoản đã tồn tại
        public IActionResult AccountAlreadyExists()
        {
            GetInfo();
            return View();
        }

        [HttpPost]
        public IActionResult Register(string email, string matkhau, string hoten, string dienthoai)
        {
            if(String.IsNullOrEmpty(email) || String.IsNullOrEmpty(matkhau)) 
            {
                // email || matkhau null
                return RedirectToAction(nameof(AccountAlreadyExists));
            }
            // kiểm tra email đã tồn tại 
            var taikhoan = _context.Khachhang.FirstOrDefault(k => k.Email == email && k.MatKhau != null);
            if(taikhoan != null)
            {
                // tài khoản đã đăng ký
                return RedirectToAction(nameof(AccountAlreadyExists));
            }

            // thêm khach hàng vào db
            var kh = new Khachhang();
            kh.Email = email;
            kh.MatKhau = _pwHear.HashPassword(kh, matkhau);   // mã hóa mật khẩu
            kh.Ten = hoten;
            kh.DienThoai = dienthoai;
            _context.Add(kh);
            _context.SaveChanges();

            return RedirectToAction(nameof(Login));
        }

        // đăng xuất
        public IActionResult Signout()
        {
            HttpContext.Session.SetString("khachhang", "");
            HttpContext.Session.SetString("Nhanvien", "");
            GetInfo();
            return RedirectToAction(nameof(Index));
        }
        // thông tin khách hàng

       // Giữ số khi khách hàng chọn thuê bao
        public async Task<IActionResult> Update(int id)
        {
            //int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            Thuebao sp = _context.Thuebao.FirstOrDefault(d => d.MaTb == id);
            sp.TrangThai = 1;
            _context.Update(sp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


      /*  //------------giỏ hàng--------------------------------
        // thêm thuê bao vào giỏ hàng
        public async Task<IActionResult> AddToCart(int id)
        {
            Thuebao sp = _context.Thuebao.FirstOrDefault(d => d.MaTb == id);
            sp.TrangThai = 1;
            _context.Update(sp);
            await _context.SaveChangesAsync();

            var thuebao = await _context.Thuebao.FirstOrDefaultAsync(m => m.MaTb == id);

            if (thuebao == null)
            {
                return NotFound("Sản phẩm không tồn tại");
            }

            var cart = GetCartItems();

            cart.Add(new CartItem() { Thuebao = thuebao, SoLuong = 1 });
            
            SaveCartSession(cart);
            return RedirectToAction(nameof(ViewCart));
        }
        // chuyển đến view giỏ hàng
        public IActionResult ViewCart()
        {
            GetInfo();
            return View(GetCartItems());
        }
        
        //đọc danh sách
        List<CartItem> GetCartItems()
        {
            var session = HttpContext.Session;
            string jsoncart = session.GetString("Mobifone");
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem>();
        }

        // Lưu danh sách CartItem trong giỏ hàng vào session
        void SaveCartSession(List<CartItem> list)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(list);
            session.SetString("Mobifone", jsoncart);
        }


        // Xóa session giỏ hàng
        void ClearCart()
        {
            GetInfo();
            var session = HttpContext.Session;
            session.Remove("Mobifone");
        }

        public async Task<IActionResult> RemoveItem(int id)
        {
            Thuebao sp = _context.Thuebao.FirstOrDefault(d => d.MaTb == id);
            sp.TrangThai = 0;
            _context.Update(sp);
            await _context.SaveChangesAsync();

            var cart = GetCartItems();
            var item = cart.Find(p => p.Thuebao.MaTb == id);
            if (item != null)
            {
                cart.Remove(item);
            }
            SaveCartSession(cart);
            return RedirectToAction(nameof(ViewCart));
        }*/

        // Chuyển đến view thanh toán
        public IActionResult CheckOut()
        {
                int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
                List<Diachi> lstDiaChi = _context.Diachi.Where(d => d.MaKh == makh).ToList();
                ViewBag.diachi = lstDiaChi;
                GetInfo();
                return View();
        }
      
        public async Task<IActionResult> CreateBill(int id, int madiachi, int phihoamang)
        {
            Khachhang kh;
            Diachi dc;

            int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            kh = _context.Khachhang.FirstOrDefault(k => k.MaKh == makh);
            dc = _context.Diachi.FirstOrDefault(d => d.MaDc == madiachi);
            // khách hàng mua hàng lần đầu cập nhật số lượng thuê bao 1
            if (kh.SlthueB == 0)
            {
                kh = _context.Khachhang.FirstOrDefault(k => k.MaKh == makh);
                kh.SlthueB = 1;
                _context.Update(kh);
                await _context.SaveChangesAsync();
            }
            else
            {
                // khách hàng đã mua hàng cập nhật số lượng thuê bao tăng thêm 1
                kh = _context.Khachhang.FirstOrDefault(k => k.MaKh == makh);
                kh.SlthueB = kh.SlthueB + 1;
                _context.Update(kh);
                await _context.SaveChangesAsync();
            }
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

            GetInfo();
            return View(hd);
        }
        // Giới Thiệu công ty
        public IActionResult GioiThieu()
        {
            GetInfo();
            return View();
        }

    }
}
