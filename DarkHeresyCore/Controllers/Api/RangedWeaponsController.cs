using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DarkHeresy.Dtos;
using DarkHeresy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DarkHeresy.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/RangedWeapon")]
    public class RangedWeaponsController : Controller
    {
        private readonly DarkHeresyContext _context;
        private readonly IMapper _mapper;

        public RangedWeaponsController(DarkHeresyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/RangedWeapon
        [HttpGet("/api/RangedWeapon")]
        public async Task<IEnumerable<RangedWeaponDto>> GetRangedWeapons()
        {
            var ranged = await _context.RangedWeapons.Include(r => r.Category).Include(r => r.Availability)
                .Include(r => r.Class).ToListAsync();
            return _mapper.Map<List<RangedWeapon>,List<RangedWeaponDto>>(ranged);
        }

        // GET: api/RangedWeapon/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRangedWeapons([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rangedWeapons = await _context.RangedWeapons.SingleOrDefaultAsync(m => m.Id == id);

            if (rangedWeapons == null)
            {
                return NotFound();
            }

            return Ok(rangedWeapons);
        }

        // PUT: api/RangedWeapon/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRangedWeapons([FromRoute] int id, [FromBody] RangedWeapon rangedWeapon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rangedWeapon.Id)
            {
                return BadRequest();
            }

            _context.Entry(rangedWeapon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RangedWeaponsExists(id))
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

        // POST: api/RangedWeapon
        [HttpPost]
        public async Task<IActionResult> PostRangedWeapons([FromBody] RangedWeapon rangedWeapon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RangedWeapons.Add(rangedWeapon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRangedWeapons", new { id = rangedWeapon.Id }, rangedWeapon);
        }

        // DELETE: api/RangedWeapon/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRangedWeapons([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rangedWeapons = await _context.RangedWeapons.SingleOrDefaultAsync(m => m.Id == id);
            if (rangedWeapons == null)
            {
                return NotFound();
            }

            _context.RangedWeapons.Remove(rangedWeapons);
            await _context.SaveChangesAsync();

            return Ok(rangedWeapons);
        }

        private bool RangedWeaponsExists(int id)
        {
            return _context.RangedWeapons.Any(e => e.Id == id);
        }
    }
}