using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DarkHeresy.Models;
using DarkHeresy.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DarkHeresy.Controllers
{
    public class ArmorsController : Controller
    {
        private readonly DarkHeresyContext _context;

        public ArmorsController(DarkHeresyContext context)
        {
            _context = context;    
        }

        // GET: Armors
        public async Task<IActionResult> Index()
        {
            var darkHeresyContext = _context.Armor
                .Include(a => a.Availability)
                .Include(a => a.Category)
                .ToListAsync();
            return View(await darkHeresyContext);
        }

        // GET: Armors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armor = await _context.Armor
                .Include(a => a.Availability)
                .Include(a => a.Category)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (armor == null)
            {
                return NotFound();
            }
            var armorViewModel = new ArmorViewModel(armor);
            return View(armorViewModel);
        }

        // GET: Armors/Create
        public IActionResult Create()
        {
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");

            return View();
        }

        // POST: Armors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryId,Name,LocCovered,Ap,Weight,Cost,AvailabilityId,Source,Notes")] Armor armor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(armor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name", armor.AvailabilityId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", armor.CategoryId);
            var armorViewModel = new ArmorViewModel(armor);
            return View(armorViewModel);
        }

        // GET: Armors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armor = await _context.Armor.SingleOrDefaultAsync(m => m.Id == id);
            if (armor == null)
            {
                return NotFound();
            }
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name", armor.AvailabilityId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", armor.CategoryId);
            var armorViewModel = new ArmorViewModel(armor);
            return View(armorViewModel);
        }

        // POST: Armors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryId,Name,LocCovered,Ap,Weight,Cost,AvailabilityId,Source,Notes")] Armor armor)
        {
            if (id != armor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(armor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArmorExists(armor.Id))
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
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name", armor.AvailabilityId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", armor.CategoryId);
            var armorViewModel = new ArmorViewModel(armor);
            return View(armorViewModel);
        }

        // GET: Armors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armor = await _context.Armor
                .Include(a => a.Availability)
                .Include(a => a.Category)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (armor == null)
            {
                return NotFound();
            }
            var armorViewModel = new ArmorViewModel(armor);
            return View(armorViewModel);
        }

        // POST: Armors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var armor = await _context.Armor.SingleOrDefaultAsync(m => m.Id == id);
            _context.Armor.Remove(armor);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ArmorExists(int id)
        {
            return _context.Armor.Any(e => e.Id == id);
        }
    }
}
