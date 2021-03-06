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
    public class RangedWeaponsController : Controller
    {
        private readonly DarkHeresyContext _context;

        public RangedWeaponsController(DarkHeresyContext context)
        {
            _context = context;    
        }

        // GET: RangedWeapon
        public async Task<IActionResult> Index()
        {
            var darkHeresyContext = _context.RangedWeapons.Include(r => r.Availability).Include(r => r.Category).Include(r => r.Class);
            return View(await darkHeresyContext.ToListAsync());
        }

        // GET: RangedWeapon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rangedWeapons = await _context.RangedWeapons
                .Include(r => r.Availability)
                .Include(r => r.Category)
                .Include(r => r.Class)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (rangedWeapons == null)
            {
                return NotFound();
            }
            var rangedWeaponViewModel = new RangedWeaponViewModel(rangedWeapons);
            return View(rangedWeaponViewModel);
        }

        // GET: RangedWeapon/Create
        public IActionResult Create()
        {
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
            ViewData["ClassId"] = new SelectList(_context.Class, "Id", "Name");
            return View();
        }

        // POST: RangedWeapon/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CategoryId,ClassId,Range,RoF,Damage,Pen,Clip,Reload,Special,Weight,Cost,AvailabilityId,Source,Notes")] RangedWeapon rangedWeapon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rangedWeapon);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name", rangedWeapon.AvailabilityId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", rangedWeapon.CategoryId);
            ViewData["ClassId"] = new SelectList(_context.Class, "Id", "Name", rangedWeapon.ClassId);
            var rangedWeaponViewModel = new RangedWeaponViewModel(rangedWeapon);
            return View(rangedWeaponViewModel);
        }

        // GET: RangedWeapon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rangedWeapons = await _context.RangedWeapons.SingleOrDefaultAsync(m => m.Id == id);
            if (rangedWeapons == null)
            {
                return NotFound();
            }
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name", rangedWeapons.AvailabilityId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", rangedWeapons.CategoryId);
            ViewData["ClassId"] = new SelectList(_context.Class, "Id", "Name", rangedWeapons.ClassId);
            var rangedWeaponViewModel = new RangedWeaponViewModel(rangedWeapons);
            return View(rangedWeaponViewModel);
        }

        // POST: RangedWeapon/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CategoryId,ClassId,Range,RoF,Damage,Pen,Clip,Reload,Special,Weight,Cost,AvailabilityId,Source,Notes")] RangedWeapon rangedWeapon)
        {
            if (id != rangedWeapon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rangedWeapon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RangedWeaponsExists(rangedWeapon.Id))
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
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name", rangedWeapon.AvailabilityId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", rangedWeapon.CategoryId);
            ViewData["ClassId"] = new SelectList(_context.Class, "Id", "Name", rangedWeapon.ClassId);
            var rangedWeaponViewModel = new RangedWeaponViewModel(rangedWeapon);
            return View(rangedWeaponViewModel);
        }

        // GET: RangedWeapon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rangedWeapons = await _context.RangedWeapons
                .Include(r => r.Availability)
                .Include(r => r.Category)
                .Include(r => r.Class)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (rangedWeapons == null)
            {
                return NotFound();
            }
            var rangedWeaponViewModel = new RangedWeaponViewModel(rangedWeapons);
            return View(rangedWeaponViewModel);
        }

        // POST: RangedWeapon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rangedWeapons = await _context.RangedWeapons.SingleOrDefaultAsync(m => m.Id == id);
            _context.RangedWeapons.Remove(rangedWeapons);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RangedWeaponsExists(int id)
        {
            return _context.RangedWeapons.Any(e => e.Id == id);
        }
    }
}
