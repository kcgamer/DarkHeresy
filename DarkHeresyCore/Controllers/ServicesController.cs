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
    public class ServicesController : Controller
    {
        private readonly DarkHeresyContext _context;

        public ServicesController(DarkHeresyContext context)
        {
            _context = context;    
        }

        // GET: Service
        public async Task<IActionResult> Index()
        {
            var darkHeresyContext = _context.Services.Include(s => s.Availability).Include(s => s.Category);
            return View(await darkHeresyContext.ToListAsync());
        }

        // GET: Service/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var services = await _context.Services
                .Include(s => s.Availability)
                .Include(s => s.Category)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (services == null)
            {
                return NotFound();
            }
            var serviceViewModel = new ServiceViewModel(services);
            return View(serviceViewModel);
        }

        // GET: Service/Create
        public IActionResult Create()
        {
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
            return View();
        }

        // POST: Service/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryId,Name,Cost,MaterialCost,Effect,AvailabilityId,Difficulty,Source,Notes")] Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Add(service);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name", service.AvailabilityId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", service.CategoryId);
            var serviceViewModel = new ServiceViewModel(service);
            return View(serviceViewModel);
        }

        // GET: Service/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var services = await _context.Services.SingleOrDefaultAsync(m => m.Id == id);
            if (services == null)
            {
                return NotFound();
            }
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name", services.AvailabilityId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", services.CategoryId);
            var serviceViewModel = new ServiceViewModel(services);
            return View(serviceViewModel);
        }

        // POST: Service/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryId,Name,Cost,MaterialCost,Effect,AvailabilityId,Difficulty,Source,Notes")] Service service)
        {
            if (id != service.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(service);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicesExists(service.Id))
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
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Name", service.AvailabilityId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", service.CategoryId);
            var serviceViewModel = new ServiceViewModel(service);
            return View(serviceViewModel);
        }

        // GET: Service/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var services = await _context.Services
                .Include(s => s.Availability)
                .Include(s => s.Category)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (services == null)
            {
                return NotFound();
            }
            var serviceViewModel = new ServiceViewModel(services);
            return View(serviceViewModel);
        }

        // POST: Service/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var services = await _context.Services.SingleOrDefaultAsync(m => m.Id == id);
            _context.Services.Remove(services);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ServicesExists(int id)
        {
            return _context.Services.Any(e => e.Id == id);
        }
    }
}
