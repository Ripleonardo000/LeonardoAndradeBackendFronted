using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeonardoAndradeBackendMVC.Data;
using LeonardoAndradeBackendMVC.Models;

namespace LeonardoAndradeBackendMVC.Controllers
{
    public class LA_BurgerController : Controller
    {
        private readonly LA_MVCContext _context;

        public LA_BurgerController(LA_MVCContext context)
        {
            _context = context;
        }

        // GET: LA_Burger
        public async Task<IActionResult> Index()
        {
            return View(await _context.LA_Burger.ToListAsync());
        }

        // GET: LA_Burger/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lA_Burger = await _context.LA_Burger
                .FirstOrDefaultAsync(m => m.BurgerID == id);
            if (lA_Burger == null)
            {
                return NotFound();
            }

            return View(lA_Burger);
        }

        // GET: LA_Burger/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LA_Burger/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BurgerID,Name,WithCheese,Costo")] LA_Burger lA_Burger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lA_Burger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lA_Burger);
        }

        // GET: LA_Burger/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lA_Burger = await _context.LA_Burger.FindAsync(id);
            if (lA_Burger == null)
            {
                return NotFound();
            }
            return View(lA_Burger);
        }

        // POST: LA_Burger/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BurgerID,Name,WithCheese,Costo")] LA_Burger lA_Burger)
        {
            if (id != lA_Burger.BurgerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lA_Burger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LA_BurgerExists(lA_Burger.BurgerID))
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
            return View(lA_Burger);
        }

        // GET: LA_Burger/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lA_Burger = await _context.LA_Burger
                .FirstOrDefaultAsync(m => m.BurgerID == id);
            if (lA_Burger == null)
            {
                return NotFound();
            }

            return View(lA_Burger);
        }

        // POST: LA_Burger/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lA_Burger = await _context.LA_Burger.FindAsync(id);
            if (lA_Burger != null)
            {
                _context.LA_Burger.Remove(lA_Burger);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LA_BurgerExists(int id)
        {
            return _context.LA_Burger.Any(e => e.BurgerID == id);
        }
    }
}
