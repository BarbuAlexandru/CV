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
    public class TollBoothsController : Controller
    {
        private readonly NetRomTestDbContext _context;

        public TollBoothsController(NetRomTestDbContext context)
        {
            _context = context;
        }

        // GET: TollBooths
        public async Task<IActionResult> Index()
        {
            var netRomTestDbContext = _context.TollBooths.Include(t => t.TollLocation);
            return View(await netRomTestDbContext.ToListAsync());
        }

        // GET: TollBooths/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tollBooth = await _context.TollBooths
                .Include(t => t.TollLocation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tollBooth == null)
            {
                return NotFound();
            }

            return View(tollBooth);
        }

        // GET: TollBooths/Create
        public IActionResult Create()
        {
            ViewData["TollLocationId"] = new SelectList(_context.TollLocations, "Id", "City");
            return View();
        }

        // POST: TollBooths/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TollLocationId")] TollBooth tollBooth)
        {
            if (ModelState.IsValid)
            {
                tollBooth.Id = Guid.NewGuid();
                _context.Add(tollBooth);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TollLocationId"] = new SelectList(_context.TollLocations, "Id", "City", tollBooth.TollLocationId);
            return View(tollBooth);
        }

        // GET: TollBooths/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tollBooth = await _context.TollBooths.FindAsync(id);
            if (tollBooth == null)
            {
                return NotFound();
            }
            ViewData["TollLocationId"] = new SelectList(_context.TollLocations, "Id", "City", tollBooth.TollLocationId);
            return View(tollBooth);
        }

        // POST: TollBooths/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,TollLocationId")] TollBooth tollBooth)
        {
            if (id != tollBooth.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tollBooth);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TollBoothExists(tollBooth.Id))
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
            ViewData["TollLocationId"] = new SelectList(_context.TollLocations, "Id", "City", tollBooth.TollLocationId);
            return View(tollBooth);
        }

        // GET: TollBooths/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tollBooth = await _context.TollBooths
                .Include(t => t.TollLocation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tollBooth == null)
            {
                return NotFound();
            }

            return View(tollBooth);
        }

        // POST: TollBooths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tollBooth = await _context.TollBooths.FindAsync(id);
            _context.TollBooths.Remove(tollBooth);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TollBoothExists(Guid id)
        {
            return _context.TollBooths.Any(e => e.Id == id);
        }
    }
}
