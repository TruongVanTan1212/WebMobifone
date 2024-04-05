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
            ViewData["solg"] = GetCartItems().Count();
           
            // ViewBag.thuebao = _context.Thuebao.FirstOrDefault(k => k.TrangThai == int.Parse(HttpContext.Session.GetString("Thuebao")));

            if (HttpContext.Session.GetString("khachhang") != "")
            {
                ViewBag.khachhang = _context.Khachhang.FirstOrDefault(k => k.Email == HttpContext.Session.GetString("khachhang"));
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
            var nv1 = _context.Nhanvien.FirstOrDefault(k => k.Email == email);
            var nv2 = _context.Nhanvien.FirstOrDefault(k => k.MatKhau == matkhau);
            var kh = _context.Khachhang.FirstOrDefault(k => k.Email == email);
            if (kh != null && _pwHear.VerifyHashedPassword(kh, kh.MatKhau, matkhau) == PasswordVerificationResult.Success)
            {
                HttpContext.Session.SetString("khachhang", kh.Email);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                if (nv1 != null && nv2 != null)
                {
                    HttpContext.Session.SetString("Nhanvien", nv1.Email);
                    return RedirectToAction(nameof(Index));
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
            // kiểm tra email đã tồn tại 
            var taikhoan = _context.Khachhang.FirstOrDefault(k => k.Email == email && k.MatKhau != null);
            if(taikhoan != null)
            {
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
        public IActionResult Customer()
        {
            GetInfo();
            return View();
        }

       // gửi số khi khách hàng chọn thuê bao
        public async Task<IActionResult> Update(int id)
        {
            //int makh = int.Parse(HttpContext.Session.GetString("khachhang"));
            Thuebao sp = _context.Thuebao.FirstOrDefault(d => d.MaTb == id);
            sp.TrangThai = 1;
            _context.Update(sp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        //------------giỏ hàng--------------------------------
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
            var item = cart.Find(p => p.Thuebao.MaTb == id);
            if (item != null)
            {
                item.SoLuong++;
            }
            else
            {
                cart.Add(new CartItem() { Thuebao = thuebao, SoLuong = 1 });
            }
            SaveCartSession(cart);
            return RedirectToAction(nameof(ViewCart));
        }
        // chuyển đến view giỏ hàng
        public IActionResult ViewCart()
        {
            GetInfo();
            return View(GetCartItems());
        }
        // lấy t
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
        }

        // Chuyển đến view thanh toán
        public IActionResult CheckOut()
        {
            GetInfo();
            return View(GetCartItems());
        }

    }
}
