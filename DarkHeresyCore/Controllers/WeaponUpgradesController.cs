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
    public class WeaponUpgradesController : Controller
    {
        private readonly DarkHeresyContext _context;

        public WeaponUpgradesController(DarkHeresyContext context)
        {
            _context = context;    
        }

        // GET: WeaponUpgrade
        public async Task<IActionResult> Index()
        {
            var darkHeresyContext = _context.WeaponUpgrades.Include(w => w.Availability).Include(w => w.Category);
            return View(await darkHeresyContext.ToListAsync());
        }

        // GET: WeaponUpgrade/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weaponUpgrade = await _context.WeaponUpgrades
                .Include(w => w.Availability)
                .Include(w => w.Category)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (weaponUpgrade == null)
            {
                return NotFound();
            }
            var weaponUpgradeViewModel = new WeaponUpgradeViewModel(weaponUpgrade);
            return View(weaponUpgradeViewModel);
        }

        // GET: WeaponUpgrade/Create
        public IActionResult Create()
        {
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
            return View();
        }

        // POST: WeaponUpgrade/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryId,Name,Weight,Cost,AvailabilityId,Source,Notes")] WeaponUpgrade weaponUpgrade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weaponUpgrade);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name", weaponUpgrade.AvailabilityId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", weaponUpgrade.CategoryId);
            var weaponUpgradeViewModel = new WeaponUpgradeViewModel(weaponUpgrade);
            return View(weaponUpgradeViewModel);
        }

        // GET: WeaponUpgrade/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weaponUpgrades = await _context.WeaponUpgrades.SingleOrDefaultAsync(m => m.Id == id);
            if (weaponUpgrades == null)
            {
                return NotFound();
            }
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name", weaponUpgrades.AvailabilityId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", weaponUpgrades.CategoryId);
            var weaponUpgradeViewModel = new WeaponUpgradeViewModel(weaponUpgrades);
            return View(weaponUpgradeViewModel);
        }

        // POST: WeaponUpgrade/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryId,Name,Weight,Cost,AvailabilityId,Source,Notes")] WeaponUpgrade weaponUpgrade)
        {
            if (id != weaponUpgrade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weaponUpgrade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeaponUpgradesExists(weaponUpgrade.Id))
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
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name", weaponUpgrade.AvailabilityId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", weaponUpgrade.CategoryId);
            var weaponUpgradeViewModel = new WeaponUpgradeViewModel(weaponUpgrade);
            return View(weaponUpgradeViewModel);
        }

        // GET: WeaponUpgrade/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weaponUpgrades = await _context.WeaponUpgrades
                .Include(w => w.Availability)
                .Include(w => w.Category)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (weaponUpgrades == null)
            {
                return NotFound();
            }
            var weaponUpgradeViewModel = new WeaponUpgradeViewModel(weaponUpgrades);
            return View(weaponUpgradeViewModel);
        }

        // POST: WeaponUpgrade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weaponUpgrades = await _context.WeaponUpgrades
                .SingleOrDefaultAsync(m => m.Id == id);
            _context.WeaponUpgrades.Remove(weaponUpgrades);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool WeaponUpgradesExists(int id)
        {
            return _context.WeaponUpgrades.Any(e => e.Id == id);
        }
    }
}
