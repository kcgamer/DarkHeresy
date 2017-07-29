using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DarkHeresyCore.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DarkHeresyCore.Models;

namespace DarkHeresyCore.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/MeleeWeapon")]
    public class MeleeWeaponsController : Controller
    {
        private readonly DarkHeresyContext _context;
        private readonly IMapper _mapper;

        public MeleeWeaponsController(DarkHeresyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/MeleeWeapon
        [HttpGet("/api/MeleeWeapon")]
        public async Task<IEnumerable<MeleeWeaponDto>> GetMeleeWeapons()
        {
            var melee = await _context.MeleeWeapons
                .Include(m => m.Category)
                .Include(m => m.Class)
                .Include(m => m.Availability)
                .ToListAsync();
            return _mapper.Map<List<MeleeWeapon>, List<MeleeWeaponDto>>(melee);
        }

        // GET: api/MeleeWeapon/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMeleeWeapons([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var meleeWeapons = await _context.MeleeWeapons.SingleOrDefaultAsync(m => m.Id == id);

            if (meleeWeapons == null)
            {
                return NotFound();
            }

            return Ok(meleeWeapons);
        }

        // PUT: api/MeleeWeapon/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeleeWeapons([FromRoute] int id, [FromBody] MeleeWeapon meleeWeapon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != meleeWeapon.Id)
            {
                return BadRequest();
            }

            _context.Entry(meleeWeapon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeleeWeaponsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MeleeWeapon
        [HttpPost]
        public async Task<IActionResult> PostMeleeWeapons([FromBody] MeleeWeapon meleeWeapon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MeleeWeapons.Add(meleeWeapon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMeleeWeapons", new { id = meleeWeapon.Id }, meleeWeapon);
        }

        // DELETE: api/MeleeWeapon/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeleeWeapons([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var meleeWeapons = await _context.MeleeWeapons.SingleOrDefaultAsync(m => m.Id == id);
            if (meleeWeapons == null)
            {
                return NotFound();
            }

            _context.MeleeWeapons.Remove(meleeWeapons);
            await _context.SaveChangesAsync();

            return Ok(meleeWeapons);
        }

        private bool MeleeWeaponsExists(int id)
        {
            return _context.MeleeWeapons.Any(e => e.Id == id);
        }
    }
}