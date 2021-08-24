using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITNext.Data;
using ITNext.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ITNext.Controllers
{
    public class LaptopController : Controller
    {
        private readonly ITNextContext _context;

        public LaptopController(ITNextContext context)
        {
            _context = context;
        }

        // GET: Laptops
        public async Task<IActionResult> Index()
        {
          return View(await _context.Laptops.ToListAsync());
        }
        public async Task<IActionResult> AddItem(int? id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var value = HttpContext.Session.GetString("Id");

                YourLaptops buyBook = new YourLaptops();
                var book = _context.Laptops.Where(x => x.Id == id).FirstOrDefault();
                buyBook.LaptopModel = book.LaptopModel;
                buyBook.Brand = book.Brand;
                buyBook.Size = book.Size;
                buyBook.Price = book.Price;
                buyBook.UserId = Convert.ToInt32(value);
                _context.Add(buyBook);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "YourLaptops");
            }
            else
                return RedirectToAction("UserAuthenticate", "Authenticate");
        }

    }
}
