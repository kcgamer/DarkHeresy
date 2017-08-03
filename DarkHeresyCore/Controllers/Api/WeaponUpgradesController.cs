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
    [Route("api/WeaponUpgrade")]
    public class WeaponUpgradesController : Controller
    {
        private readonly DarkHeresyContext _context;
        private readonly IMapper _mapper;

        public WeaponUpgradesController(DarkHeresyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/WeaponUpgrade
        [HttpGet("/api/WeaponUpgrade")]
        public async Task<IEnumerable<WeaponUpgradeDto>> GetWeaponUpgrades()
        {
            var upgrades = await _context.WeaponUpgrades.Include(u => u.Category).Include(u => u.Availability)
                .ToListAsync();
            return _mapper.Map<List<WeaponUpgrade>, List<WeaponUpgradeDto>>(upgrades);
        }

        // GET: api/WeaponUpgrade/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWeaponUpgrades([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var weaponUpgrades = await _context.WeaponUpgrades.SingleOrDefaultAsync(m => m.Id == id);

            if (weaponUpgrades == null)
            {
                return NotFound();
            }

            return Ok(weaponUpgrades);
        }

        // PUT: api/WeaponUpgrade/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeaponUpgrades([FromRoute] int id, [FromBody] WeaponUpgrade weaponUpgrade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != weaponUpgrade.Id)
            {
                return BadRequest();
            }

            _context.Entry(weaponUpgrade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeaponUpgradesExists(id))
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

        // POST: api/WeaponUpgrade
        [HttpPost]
        public async Task<IActionResult> PostWeaponUpgrades([FromBody] WeaponUpgrade weaponUpgrade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.WeaponUpgrades.Add(weaponUpgrade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeaponUpgrades", new { id = weaponUpgrade.Id }, weaponUpgrade);
        }

        // DELETE: api/WeaponUpgrade/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeaponUpgrades([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var weaponUpgrades = await _context.WeaponUpgrades.SingleOrDefaultAsync(m => m.Id == id);
            if (weaponUpgrades == null)
            {
                return NotFound();
            }

            _context.WeaponUpgrades.Remove(weaponUpgrades);
            await _context.SaveChangesAsync();

            return Ok(weaponUpgrades);
        }

        private bool WeaponUpgradesExists(int id)
        {
            return _context.WeaponUpgrades.Any(e => e.Id == id);
        }
    }
}