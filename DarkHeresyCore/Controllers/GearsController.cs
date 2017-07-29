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
    public class GearsController : Controller
    {
        private readonly DarkHeresyContext _context;

        public GearsController(DarkHeresyContext context)
        {
            _context = context;    
        }

        // GET: Gears
        public async Task<IActionResult> Index()
        {
            var darkHeresyContext = _context.Gear.Include(g => g.Availability).Include(g => g.Category);
            return View(await darkHeresyContext.ToListAsync());
        }

        // GET: Gears/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gear = await _context.Gear
                .Include(g => g.Availability)
                .Include(g => g.Category)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (gear == null)
            {
                return NotFound();
            }

            return View(gear);
        }

        // GET: Gears/Create
        public IActionResult Create()
        {
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
            return View();
        }

        // POST: Gears/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryId,Name,Weight,Cost,AvailabilityId,Source,Notes")] Gear gear)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gear);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name", gear.AvailabilityId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", gear.CategoryId);
            return View(gear);
        }

        // GET: Gears/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gear = await _context.Gear.SingleOrDefaultAsync(m => m.Id == id);
            if (gear == null)
            {
                return NotFound();
            }
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name", gear.AvailabilityId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", gear.CategoryId);
            return View(gear);
        }

        // POST: Gears/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryId,Name,Weight,Cost,AvailabilityId,Source,Notes")] Gear gear)
        {
            if (id != gear.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gear);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GearExists(gear.Id))
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
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name", gear.AvailabilityId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", gear.CategoryId);
            return View(gear);
        }

        // GET: Gears/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gear = await _context.Gear
                .Include(g => g.Availability)
                .Include(g => g.Category)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (gear == null)
            {
                return NotFound();
            }

            return View(gear);
        }

        // POST: Gears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gear = await _context.Gear.SingleOrDefaultAsync(m => m.Id == id);
            _context.Gear.Remove(gear);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool GearExists(int id)
        {
            return _context.Gear.Any(e => e.Id == id);
        }
    }
}
