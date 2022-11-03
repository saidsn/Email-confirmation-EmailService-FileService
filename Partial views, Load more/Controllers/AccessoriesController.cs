using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Partial_views__Load_more.Data;
using Partial_views__Load_more.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Partial_views__Load_more.Controllers
{
    public class AccessoriesController : Controller
    {
        private readonly AppDbContext _context;

        public AccessoriesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.count = await _context.Products.Where(m => !m.IsDeleted).CountAsync();
            IEnumerable <Product> products = await _context.Products.Where(m=>!m.IsDeleted).Take(3).OrderBy(m=>m.Id).ToListAsync();
            return View(products);
        }

        public async Task<IActionResult> LoadMore(int skip)
        {
            IEnumerable<Product> products = await _context.Products.Where(m => !m.IsDeleted).Skip(skip).Take(3).ToListAsync();
            return PartialView("_ProductPartial", products);
        }

   
    }
}
