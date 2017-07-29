using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DarkHeresyCore.Models;

namespace DarkHeresyCore.Controllers
{
    public class AmmosController : Controller
    {
        private readonly DarkHeresyContext _context;

        public AmmosController(DarkHeresyContext context)
        {
            _context = context;    
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Ammos
        public async Task<IActionResult> Index()
        {
            var darkHeresyContext = _context.Ammo.Include(a => a.Availability);
            return View(await darkHeresyContext.ToListAsync());
        }

        // GET: Ammos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ammo = await _context.Ammo
                .Include(a => a.Availability)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (ammo == null)
            {
                return NotFound();
            }

            return View(ammo);
        }

        // GET: Ammos/Create
        public IActionResult Create()
        {
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name");
            return View();
        }

        // POST: Ammos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Cost,Amount,AvailabilityId,Source,Notes")] Ammo ammo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ammo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name", ammo.AvailabilityId);
            return View(ammo);
        }

        // GET: Ammos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ammo = await _context.Ammo.SingleOrDefaultAsync(m => m.Id == id);
            if (ammo == null)
            {
                return NotFound();
            }
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name", ammo.AvailabilityId);
            return View(ammo);
        }

        // POST: Ammos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Cost,Amount,AvailabilityId,Source,Notes")] Ammo ammo)
        {
            if (id != ammo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ammo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmmoExists(ammo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name", ammo.AvailabilityId);
            return View(ammo);
        }

        // GET: Ammos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ammo = await _context.Ammo
                .Include(a => a.Availability)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (ammo == null)
            {
                return NotFound();
            }

            return View(ammo);
        }

        // POST: Ammos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ammo = await _context.Ammo.SingleOrDefaultAsync(m => m.Id == id);
            _context.Ammo.Remove(ammo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AmmoExists(int id)
        {
            return _context.Ammo.Any(e => e.Id == id);
        }
    }
}