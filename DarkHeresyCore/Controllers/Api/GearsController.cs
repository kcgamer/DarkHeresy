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
    [Route("api/Gears")]
    public class GearsController : Controller
    {
        private readonly DarkHeresyContext context;
        private readonly IMapper mapper;

        public GearsController(DarkHeresyContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET: api/Gears
        [HttpGet("/api/Gears")]
        public async Task<IEnumerable<GearDto>> GetGear()
        {
            var gears = await context.Gear.Include(g => g.Availability).Include(g => g.Category).ToListAsync();
            return mapper.Map<List<Gear>, List<GearDto>>(gears);
        }

        // GET: api/Gears/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGear([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gear = await context.Gear.SingleOrDefaultAsync(m => m.Id == id);

            if (gear == null)
            {
                return NotFound();
            }

            return Ok(gear);
        }

        // PUT: api/Gears/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGear([FromRoute] int id, [FromBody] Gear gear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gear.Id)
            {
                return BadRequest();
            }

            context.Entry(gear).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GearExists(id))
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

        // POST: api/Gears
        [HttpPost]
        public async Task<IActionResult> PostGear([FromBody] Gear gear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Gear.Add(gear);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetGear", new { id = gear.Id }, gear);
        }

        // DELETE: api/Gears/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGear([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gear = await context.Gear.SingleOrDefaultAsync(m => m.Id == id);
            if (gear == null)
            {
                return NotFound();
            }

            context.Gear.Remove(gear);
            await context.SaveChangesAsync();

            return Ok(gear);
        }

        private bool GearExists(int id)
        {
            return context.Gear.Any(e => e.Id == id);
        }
    }
}