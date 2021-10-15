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
    public class TripPricesController : Controller
    {
        private readonly NetRomTestDbContext _context;

        public TripPricesController(NetRomTestDbContext context)
        {
            _context = context;
        }

        // GET: TripPrices
        public async Task<IActionResult> Index()
        {
            var netRomTestDbContext = _context.TripPrices.Include(t => t.EndCity).Include(t => t.StartCity);
            return View(await netRomTestDbContext.ToListAsync());
        }

        // GET: TripPrices/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripPrice = await _context.TripPrices
                .Include(t => t.EndCity)
                .Include(t => t.StartCity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tripPrice == null)
            {
                return NotFound();
            }

            return View(tripPrice);
        }

        // GET: TripPrices/Create
        public IActionResult Create()
        {
            ViewData["EndCityId"] = new SelectList(_context.TollLocations, "Id", "City");
            ViewData["StartCityId"] = new SelectList(_context.TollLocations, "Id", "City");
            return View();
        }

        // POST: TripPrices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartCityId,EndCityId,Price,Vehicle")] TripPrice tripPrice)
        {
            if (ModelState.IsValid)
            {
                tripPrice.Id = Guid.NewGuid();
                _context.Add(tripPrice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EndCityId"] = new SelectList(_context.TollLocations, "Id", "City", tripPrice.EndCityId);
            ViewData["StartCityId"] = new SelectList(_context.TollLocations, "Id", "City", tripPrice.StartCityId);
            return View(tripPrice);
        }

        // GET: TripPrices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripPrice = await _context.TripPrices.FindAsync(id);
            if (tripPrice == null)
            {
                return NotFound();
            }
            ViewData["EndCityId"] = new SelectList(_context.TollLocations, "Id", "City", tripPrice.EndCityId);
            ViewData["StartCityId"] = new SelectList(_context.TollLocations, "Id", "City", tripPrice.StartCityId);
            return View(tripPrice);
        }

        // POST: TripPrices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,StartCityId,EndCityId,Price,Vehicle")] TripPrice tripPrice)
        {
            if (id != tripPrice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tripPrice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripPriceExists(tripPrice.Id))
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
            ViewData["EndCityId"] = new SelectList(_context.TollLocations, "Id", "City", tripPrice.EndCityId);
            ViewData["StartCityId"] = new SelectList(_context.TollLocations, "Id", "City", tripPrice.StartCityId);
            return View(tripPrice);
        }

        // GET: TripPrices/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripPrice = await _context.TripPrices
                .Include(t => t.EndCity)
                .Include(t => t.StartCity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tripPrice == null)
            {
                return NotFound();
            }

            return View(tripPrice);
        }

        // POST: TripPrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tripPrice = await _context.TripPrices.FindAsync(id);
            _context.TripPrices.Remove(tripPrice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripPriceExists(Guid id)
        {
            return _context.TripPrices.Any(e => e.Id == id);
        }
    }
}
