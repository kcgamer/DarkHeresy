using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DarkHeresy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DarkHeresy;
using DarkHeresy.ViewModels;

namespace DarkHeresy.Controllers
{
    public class CharactersController : Controller
    {
        private readonly DarkHeresyContext _context;
        private readonly IMapper _mapper;

        public CharactersController(DarkHeresyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Characters
        public async Task<IActionResult> Index()
        {
            var characters = await _context.Characters
                .Include(c => c.CharacterSkills)
                .Include(c => c.CharacterMelees)
                .Include(c => c.CharacterRangeds)
                .ToListAsync();
            return View(characters as IEnumerable<CharacterViewModel>);
        }

        // GET: Characters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters
                .SingleOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }
            var characterViewModel = new CharacterViewModel(character);
            return View(characterViewModel);
        }

        // GET: Characters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CharacterName,PlayerName,WeaponSkill,BallisticSkill,Strength,Toughness,Agility,Intelligence,Perception,Willpower,Fellowship,CareerId,Career,Rank,HomeWorld,Quirk,Divination,OrdoFaction,Description,Wounds,FatePoints,TotalXp,SpentXp")] Character character)
        {
            if (ModelState.IsValid)
            {
                _context.Add(character);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(character);
        }

        // GET: Characters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters.SingleOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }

            var characterViewModel = new CharacterViewModel(character);
            return View(characterViewModel);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CharacterName,PlayerName,WeaponSkill,BallisticSkill,Strength,Toughness,Agility,Intelligence,Perception,Willpower,Fellowship,Career,Rank,HomeWorld,Quirk,Divination,OrdoFaction,Description,Wounds,FatePoints,TotalXp,SpentXp")] Character character)
        {
            if (id != character.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(character);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterExists(character.Id))
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
            var characterViewModel = new CharacterViewModel(character);
            return View(characterViewModel);
        }

        // GET: Characters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters
                .SingleOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var character = await _context.Characters.SingleOrDefaultAsync(m => m.Id == id);
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CharacterExists(int id)
        {
            return _context.Characters.Any(e => e.Id == id);
        }
    }
}
