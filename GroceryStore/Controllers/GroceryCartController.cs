using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroceryStore.Data;
using GroceryStore.Models;

namespace GroceryStore.Controllers
{
    public class GroceryCartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroceryCartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GroceryCart
        public async Task<IActionResult> Index()
        {
            return View(await _context.GroceryProductCart.ToListAsync());
        }

        // GET: GroceryCart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groceryProductCart = await _context.GroceryProductCart
                .SingleOrDefaultAsync(m => m.ID == id);
            if (groceryProductCart == null)
            {
                return NotFound();
            }

            return View(groceryProductCart);
        }

        // GET: GroceryCart/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GroceryCart/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID")] GroceryProductCart groceryProductCart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groceryProductCart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(groceryProductCart);
        }

        // GET: GroceryCart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groceryProductCart = await _context.GroceryProductCart.SingleOrDefaultAsync(m => m.ID == id);
            if (groceryProductCart == null)
            {
                return NotFound();
            }
            return View(groceryProductCart);
        }

        // POST: GroceryCart/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID")] GroceryProductCart groceryProductCart)
        {
            if (id != groceryProductCart.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groceryProductCart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroceryProductCartExists(groceryProductCart.ID))
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
            return View(groceryProductCart);
        }

        // GET: GroceryCart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groceryProductCart = await _context.GroceryProductCart
                .SingleOrDefaultAsync(m => m.ID == id);
            if (groceryProductCart == null)
            {
                return NotFound();
            }

            return View(groceryProductCart);
        }

        // POST: GroceryCart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groceryProductCart = await _context.GroceryProductCart.SingleOrDefaultAsync(m => m.ID == id);
            _context.GroceryProductCart.Remove(groceryProductCart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroceryProductCartExists(int id)
        {
            return _context.GroceryProductCart.Any(e => e.ID == id);
        }
    }
}
