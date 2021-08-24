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
        public class LaptopsController : Controller
        {
            private readonly ITNextContext _context;

            public LaptopsController(ITNextContext context)
            {
                _context = context;
            }

            // GET: Laptops
            public async Task<IActionResult> Index()
            {
            if (HttpContext.Session.GetString("Id") != null || HttpContext.Session.GetString("LoginUser") != null)
            {
                var value = HttpContext.Session.GetString("Id");
                var name = HttpContext.Session.GetString("LoginUser");
                var Authenticate = _context.Authenticate.Where(x => x.Id == Convert.ToInt32(value)).FirstOrDefault();

                if (name == "ITNext@next.com")
                {
                    return View(await _context.Laptops.ToListAsync());
                    }
                    else
                    {
                    if (_context.Laptops.ToList().Count == 0)
                    {
                        return RedirectToAction(nameof(NoLaptop));
                    }
                    else
                    return RedirectToAction("Index", "Laptop");
                    }
            }
            else
                return RedirectToAction("UserAuthenticate", "Authenticate");
            }

            // GET: Laptops/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Laptops = await _context.Laptops
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Laptops == null)
                {
                    return NotFound();
                }

                return View(Laptops);
            }
        public IActionResult NoLaptop()
        {
            return View();
        }
        
        // GET: Laptops/Create
        public IActionResult Create()
            {
            return View();
            }

            // POST: Laptops/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,LaptopModel,Brand,Size,Price")] Laptops Laptops)
            {
                if (ModelState.IsValid)
                {
                    //Laptops.UserId = Convert.ToInt32(HttpContext.Session.GetString("Id"));
                    _context.Add(Laptops);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(Laptops);
            }

            // GET: Laptops/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Laptops = await _context.Laptops.FindAsync(id);
                if (Laptops == null)
                {
                    return NotFound();
                }
                return View(Laptops);
            }

            // POST: Laptops/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,LaptopModel,Brand,Size,Price")] Laptops Laptops)
            {
                if (id != Laptops.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(Laptops);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!LaptopsExists(Laptops.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(Laptops);
            }

            // GET: Laptops/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Laptops = await _context.Laptops
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Laptops == null)
                {
                    return NotFound();
                }

                return View(Laptops);
            }

            // POST: Laptops/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var Laptops = await _context.Laptops.FindAsync(id);
                _context.Laptops.Remove(Laptops);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool LaptopsExists(int id)
            {
                return _context.Laptops.Any(e => e.Id == id);
            }
        }
    }
