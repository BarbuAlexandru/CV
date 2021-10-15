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
    public class TollLocationsController : Controller
    {
        private readonly NetRomTestDbContext _context;

        public TollLocationsController(NetRomTestDbContext context)
        {
            _context = context;
        }

        // GET: TollLocations
        public async Task<IActionResult> Index()
        {
            return View(await _context.TollLocations.ToListAsync());
        }

        // GET: TollLocations/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tollLocation = await _context.TollLocations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tollLocation == null)
            {
                return NotFound();
            }

            return View(tollLocation);
        }

        // GET: TollLocations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TollLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,City")] TollLocation tollLocation)
        {
            if (ModelState.IsValid)
            {
                tollLocation.Id = Guid.NewGuid();
                _context.Add(tollLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tollLocation);
        }

        // GET: TollLocations/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tollLocation = await _context.TollLocations.FindAsync(id);
            if (tollLocation == null)
            {
                return NotFound();
            }
            return View(tollLocation);
        }

        // POST: TollLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,City")] TollLocation tollLocation)
        {
            if (id != tollLocation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tollLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TollLocationExists(tollLocation.Id))
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
            return View(tollLocation);
        }

        // GET: TollLocations/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tollLocation = await _context.TollLocations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tollLocation == null)
            {
                return NotFound();
            }

            return View(tollLocation);
        }

        // POST: TollLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tollLocation = await _context.TollLocations.FindAsync(id);
            _context.TollLocations.Remove(tollLocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TollLocationExists(Guid id)
        {
            return _context.TollLocations.Any(e => e.Id == id);
        }
    }
}
