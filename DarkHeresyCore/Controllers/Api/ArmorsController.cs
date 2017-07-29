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
    [Route("api/Armors")]
    public class ArmorsController : Controller
    {
        private readonly DarkHeresyContext context;
        private readonly IMapper mapper;

        public ArmorsController(DarkHeresyContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET: api/Armors
        [HttpGet("/api/Armors")]
        public async Task<IEnumerable<ArmorDto>> GetArmor()
        {
            var armors = await context.Armor.Include(a => a.Availability).Include(a => a.Category).ToListAsync();
            return mapper.Map<List<Armor>, List<ArmorDto>>(armors);
        }

        // GET: api/Armors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArmor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var armor = await context.Armor.SingleOrDefaultAsync(m => m.Id == id);

            if (armor == null)
            {
                return NotFound();
            }

            return Ok(armor);
        }

        // PUT: api/Armors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArmor([FromRoute] int id, [FromBody] Armor armor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != armor.Id)
            {
                return BadRequest();
            }

            context.Entry(armor).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArmorExists(id))
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

        // POST: api/Armors
        [HttpPost]
        public async Task<IActionResult> PostArmor([FromBody] Armor armor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Armor.Add(armor);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetArmor", new { id = armor.Id }, armor);
        }

        // DELETE: api/Armors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArmor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var armor = await context.Armor.SingleOrDefaultAsync(m => m.Id == id);
            if (armor == null)
            {
                return NotFound();
            }

            context.Armor.Remove(armor);
            await context.SaveChangesAsync();

            return Ok(armor);
        }

        private bool ArmorExists(int id)
        {
            return context.Armor.Any(e => e.Id == id);
        }
    }
}