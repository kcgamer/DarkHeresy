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
    public class CyberneticsController : Controller
    {
        private readonly DarkHeresyContext _context;

        public CyberneticsController(DarkHeresyContext context)
        {
            _context = context;    
        }

        // GET: Cybernetic
        public async Task<IActionResult> Index()
        {
            var darkHeresyContext = _context.Cybernetics.Include(c => c.Availability).Include(c => c.Category);
            return View(await darkHeresyContext.ToListAsync());
        }

        // GET: Cybernetic/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cybernetics = await _context.Cybernetics
                .Include(c => c.Availability)
                .Include(c => c.Category)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (cybernetics == null)
            {
                return NotFound();
            }

            return View(cybernetics);
        }

        // GET: Cybernetic/Create
        public IActionResult Create()
        {
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
            return View();
        }

        // POST: Cybernetic/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryId,Name,Cost,AvailabilityId,Source,Notes")] Cybernetic cybernetic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cybernetic);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name", cybernetic.AvailabilityId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", cybernetic.CategoryId);
            return View(cybernetic);
        }

        // GET: Cybernetic/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cybernetics = await _context.Cybernetics.SingleOrDefaultAsync(m => m.Id == id);
            if (cybernetics == null)
            {
                return NotFound();
            }
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name", cybernetics.AvailabilityId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", cybernetics.CategoryId);
            return View(cybernetics);
        }

        // POST: Cybernetic/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryId,Name,Cost,AvailabilityId,Source,Notes")] Cybernetic cybernetic)
        {
            if (id != cybernetic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cybernetic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CyberneticsExists(cybernetic.Id))
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
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name", cybernetic.AvailabilityId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", cybernetic.CategoryId);
            return View(cybernetic);
        }

        // GET: Cybernetic/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cybernetics = await _context.Cybernetics
                .Include(c => c.Availability)
                .Include(c => c.Category)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (cybernetics == null)
            {
                return NotFound();
            }

            return View(cybernetics);
        }

        // POST: Cybernetic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cybernetics = await _context.Cybernetics.SingleOrDefaultAsync(m => m.Id == id);
            _context.Cybernetics.Remove(cybernetics);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CyberneticsExists(int id)
        {
            return _context.Cybernetics.Any(e => e.Id == id);
        }
    }
}
