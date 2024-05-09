using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WeSimMobifone.Data;
using WeSimMobifone.Models;

namespace WeSimMobifone.Controllers
{
    public class HomeHDController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeHDController(ApplicationDbContext context)
        {
            _context = context;
        }
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
        // GET: HomeHD
        public async Task<IActionResult> Index()
        {
            GetInfo();
            return View(await _context.Huongdan.ToListAsync());
        }
        public IActionResult KichHoat()
        {
            GetInfo();
            return View();
        }
    }
}
