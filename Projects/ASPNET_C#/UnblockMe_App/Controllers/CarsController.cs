using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UnblockMe_App.Models;

namespace UnblockMe_App.Controllers
{
    [Authorize]
    public class CarsController : Controller
    {
        private readonly UnblockMeContext _context;

        public CarsController(UnblockMeContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var unblockMeContext = _context.Car.Include(c => c.Owner);
            return View(await unblockMeContext.ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .Include(c => c.Owner)
                .FirstOrDefaultAsync(m => m.LicencePlate == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            ViewData["OwnerId"] = new SelectList(_context.User, "Id", "Id");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LicencePlate,OwnerId,Maker,Model,Color,AdditionalInfo,BlockedLicencePlate,BlockedByLicencePlate")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OwnerId"] = new SelectList(_context.User, "Id", "Id", car.OwnerId);
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["OwnerId"] = new SelectList(_context.User, "Id", "Id", car.OwnerId);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("LicencePlate,OwnerId,Maker,Model,Color,AdditionalInfo,BlockedLicencePlate,BlockedByLicencePlate")] Car car)
        {
            if (id != car.LicencePlate)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.LicencePlate))
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
            ViewData["OwnerId"] = new SelectList(_context.User, "Id", "Id", car.OwnerId);
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .Include(c => c.Owner)
                .FirstOrDefaultAsync(m => m.LicencePlate == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var car = await _context.Car.FindAsync(id);
            _context.Car.Remove(car);
            _context.Car.Where(carBlockedBy => carBlockedBy.BlockedByLicencePlate == car.LicencePlate).ToList().ForEach(c => c.BlockedByLicencePlate = null);
            _context.Car.Where(carBlocking => carBlocking.BlockedLicencePlate == car.LicencePlate).ToList().ForEach(c => c.BlockedLicencePlate = null);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(string id)
        {
            return _context.Car.Any(e => e.LicencePlate == id);
        }
    }
}
