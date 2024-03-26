using System;
using System.Collections.Generic;
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
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<Khachhang> _pwHear;

        public HomeController(ApplicationDbContext context,IPasswordHasher<Khachhang> passwordHasher)
        {
            _context = context;
            _pwHear = passwordHasher;
        }

        void GetInfo()
        {
            ViewBag.tintuc = _context.Tintuc.ToList();
            //  ViewBag.tintuc = _context.Danhmuc.ToList();
            if (HttpContext.Session.GetString("khachhang") != "")
            {
                ViewBag.khachhang = _context.Khachhang.FirstOrDefault(k => k.Email == HttpContext.Session.GetString("khachhang"));
            }
            if (HttpContext.Session.GetString("Nhanvien") != "")
            {
                ViewBag.Nhanvien = _context.Nhanvien.FirstOrDefault(k => k.Email == HttpContext.Session.GetString("Nhanvien"));
            }
        }
        // GET: Home
        public async Task<IActionResult> Index()
        {
            GetInfo();
            var applicationDbContext = _context.Thuebao.Include(t => t.MaDmNavigation).Include(t => t.MaLtbNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Home/Details/5
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
        public IActionResult Login()
        {
            GetInfo();
            return View();
        }
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
                return RedirectToAction(nameof(Customer));
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
        public IActionResult Customer()
        {
            GetInfo();
            return View();
        }
        public IActionResult Register()
        {

            GetInfo();
            return View();

        }


        [HttpPost]
        public IActionResult Register(string email, string matkhau, string hoten, string dienthoai)
        {
            // kiểm tra email đã tồn tại 


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

        public IActionResult Signout()
        {
            HttpContext.Session.SetString("khachhang", "");
            HttpContext.Session.SetString("Nhanvien", "");
            GetInfo();
            return RedirectToAction(nameof(Index));
        }

    }
}
