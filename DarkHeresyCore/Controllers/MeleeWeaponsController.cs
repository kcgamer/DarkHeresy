using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DarkHeresyCore.Models;
using DarkHeresyCore.ViewModels;

namespace DarkHeresyCore.Controllers
{
    public class MeleeWeaponsController : Controller
    {
        private readonly DarkHeresyContext _context;

        public MeleeWeaponsController(DarkHeresyContext context)
        {
            _context = context;    
        }

        // GET: MeleeWeapon
        public async Task<IActionResult> Index()
        {
            var darkHeresyContext = _context.MeleeWeapons.Include(m => m.Availability).Include(m => m.Category).Include(m => m.Class);
            return View(await darkHeresyContext.ToListAsync() as IEnumerable<MeleeWeaponViewModel>);
        }

        // GET: MeleeWeapon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meleeWeapons = await _context.MeleeWeapons
                .Include(m => m.Availability)
                .Include(m => m.Category)
                .Include(m => m.Class)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (meleeWeapons == null)
            {
                return NotFound();
            }

            return View(meleeWeapons);
        }

        // GET: MeleeWeapon/Create
        public IActionResult Create()
        {
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
            ViewData["ClassId"] = new SelectList(_context.Class, "Id", "Name");
            return View();
        }

        // POST: MeleeWeapon/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CategoryId,ClassId,Range,Damage,Pen,Special,Weight,Cost,AvailabilityId,Source,TwoHanded,Notes")] MeleeWeapon meleeWeapon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meleeWeapon);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name", meleeWeapon.AvailabilityId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", meleeWeapon.CategoryId);
            ViewData["ClassId"] = new SelectList(_context.Class, "Id", "Name", meleeWeapon.ClassId);
            return View(meleeWeapon);
        }

        // GET: MeleeWeapon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meleeWeapons = await _context.MeleeWeapons.SingleOrDefaultAsync(m => m.Id == id);
            if (meleeWeapons == null)
            {
                return NotFound();
            }
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name", meleeWeapons.AvailabilityId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", meleeWeapons.CategoryId);
            ViewData["ClassId"] = new SelectList(_context.Class, "Id", "Name", meleeWeapons.ClassId);
            var viewModel = new MeleeWeaponViewModel(meleeWeapons);
            return View("Edit", viewModel);
        }

        // POST: MeleeWeapon/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CategoryId,ClassId,Range,Damage,Pen,Special,Weight,Cost,AvailabilityId,Source,TwoHanded,Notes")] MeleeWeapon meleeWeapon)
        {
            if (id != meleeWeapon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meleeWeapon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeleeWeaponsExists(meleeWeapon.Id))
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
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name", meleeWeapon.AvailabilityId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", meleeWeapon.CategoryId);
            ViewData["ClassId"] = new SelectList(_context.Class, "Id", "Name", meleeWeapon.ClassId);
            return View(meleeWeapon);
        }

        // GET: MeleeWeapon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meleeWeapons = await _context.MeleeWeapons
                .Include(m => m.Availability)
                .Include(m => m.Category)
                .Include(m => m.Class)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (meleeWeapons == null)
            {
                return NotFound();
            }

            return View(meleeWeapons);
        }

        // POST: MeleeWeapon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meleeWeapons = await _context.MeleeWeapons.SingleOrDefaultAsync(m => m.Id == id);
            _context.MeleeWeapons.Remove(meleeWeapons);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MeleeWeaponsExists(int id)
        {
            return _context.MeleeWeapons.Any(e => e.Id == id);
        }
    }
}
