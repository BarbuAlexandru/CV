using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HighwayTolls.Models;
using Microsoft.AspNetCore.Authorization;

namespace HighwayTolls.Controllers
{
    [Authorize]
    public class TollPricesController : Controller
    {
        private readonly NetRomTestDbContext _context;

        public TollPricesController(NetRomTestDbContext context)
        {
            _context = context;
        }

        // GET: TollPrices
        public async Task<IActionResult> Index()
        {
            var netRomTestDbContext = _context.TollPrices.Include(t => t.TollLocation);
            return View(await netRomTestDbContext.ToListAsync());
        }

        // GET: TollPrices/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tollPrice = await _context.TollPrices
                .Include(t => t.TollLocation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tollPrice == null)
            {
                return NotFound();
            }

            return View(tollPrice);
        }

        // GET: TollPrices/Create
        public IActionResult Create()
        {
            ViewData["TollLocationId"] = new SelectList(_context.TollLocations, "Id", "City");
            return View();
        }

        // POST: TollPrices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Vehicle,Price,TollLocationId")] TollPrice tollPrice)
        {
            if (ModelState.IsValid)
            {
                tollPrice.Id = Guid.NewGuid();
                _context.Add(tollPrice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TollLocationId"] = new SelectList(_context.TollLocations, "Id", "City", tollPrice.TollLocationId);
            return View(tollPrice);
        }

        // GET: TollPrices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tollPrice = await _context.TollPrices.FindAsync(id);
            if (tollPrice == null)
            {
                return NotFound();
            }
            ViewData["TollLocationId"] = new SelectList(_context.TollLocations, "Id", "City", tollPrice.TollLocationId);
            return View(tollPrice);
        }

        // POST: TollPrices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Vehicle,Price,TollLocationId")] TollPrice tollPrice)
        {
            if (id != tollPrice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tollPrice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TollPriceExists(tollPrice.Id))
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
            ViewData["TollLocationId"] = new SelectList(_context.TollLocations, "Id", "City", tollPrice.TollLocationId);
            return View(tollPrice);
        }

        // GET: TollPrices/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tollPrice = await _context.TollPrices
                .Include(t => t.TollLocation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tollPrice == null)
            {
                return NotFound();
            }

            return View(tollPrice);
        }

        // POST: TollPrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tollPrice = await _context.TollPrices.FindAsync(id);
            _context.TollPrices.Remove(tollPrice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TollPriceExists(Guid id)
        {
            return _context.TollPrices.Any(e => e.Id == id);
        }
    }
}
