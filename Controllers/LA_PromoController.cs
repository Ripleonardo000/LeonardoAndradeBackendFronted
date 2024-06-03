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
    public class LA_PromoController : Controller
    {
        private readonly LA_MVCContext _context;

        public LA_PromoController(LA_MVCContext context)
        {
            _context = context;
        }

        // GET: LA_Promo
        public async Task<IActionResult> Index()
        {
            var leonardoAndradeBackendMVCContext = _context.LA_Promo.Include(l => l.burger);
            return View(await leonardoAndradeBackendMVCContext.ToListAsync());
        }

        // GET: LA_Promo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lA_Promo = await _context.LA_Promo
                .Include(l => l.burger)
                .FirstOrDefaultAsync(m => m.PromoID == id);
            if (lA_Promo == null)
            {
                return NotFound();
            }

            return View(lA_Promo);
        }

        // GET: LA_Promo/Create
        public IActionResult Create()
        {
            ViewData["BurgerID"] = new SelectList(_context.LA_Burger, "BurgerID", "Name");
            return View();
        }

        // POST: LA_Promo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PromoID,Descripcion,FechaPromo,BurgerID")] LA_Promo lA_Promo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lA_Promo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BurgerID"] = new SelectList(_context.LA_Burger, "BurgerID", "Name", lA_Promo.BurgerID);
            return View(lA_Promo);
        }

        // GET: LA_Promo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lA_Promo = await _context.LA_Promo.FindAsync(id);
            if (lA_Promo == null)
            {
                return NotFound();
            }
            ViewData["BurgerID"] = new SelectList(_context.LA_Burger, "BurgerID", "Name", lA_Promo.BurgerID);
            return View(lA_Promo);
        }

        // POST: LA_Promo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PromoID,Descripcion,FechaPromo,BurgerID")] LA_Promo lA_Promo)
        {
            if (id != lA_Promo.PromoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lA_Promo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LA_PromoExists(lA_Promo.PromoID))
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
            ViewData["BurgerID"] = new SelectList(_context.LA_Burger, "BurgerID", "Name", lA_Promo.BurgerID);
            return View(lA_Promo);
        }

        // GET: LA_Promo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lA_Promo = await _context.LA_Promo
                .Include(l => l.burger)
                .FirstOrDefaultAsync(m => m.PromoID == id);
            if (lA_Promo == null)
            {
                return NotFound();
            }

            return View(lA_Promo);
        }

        // POST: LA_Promo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lA_Promo = await _context.LA_Promo.FindAsync(id);
            if (lA_Promo != null)
            {
                _context.LA_Promo.Remove(lA_Promo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LA_PromoExists(int id)
        {
            return _context.LA_Promo.Any(e => e.PromoID == id);
        }
    }
}
