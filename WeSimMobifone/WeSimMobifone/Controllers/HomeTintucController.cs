using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeSimMobifone.Data;
using WeSimMobifone.Models;

namespace WeSimMobifone.Controllers
{
    public class HomeTintucController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeTintucController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HomeTintuc
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tintuc.ToListAsync());
        }

        // GET: HomeTintuc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tintuc = await _context.Tintuc
                .FirstOrDefaultAsync(m => m.MaTin == id);
            if (tintuc == null)
            {
                return NotFound();
            }

            return View(tintuc);
        }

        
    }
}
