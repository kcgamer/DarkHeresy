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
    [Route("api/Cybernetic")]
    public class CyberneticsController : Controller
    {
        private readonly DarkHeresyContext context;
        private readonly IMapper mapper;

        public CyberneticsController(DarkHeresyContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET: api/Cybernetic
        [HttpGet("/api/Cybernetic")]
        public async Task<IEnumerable<CyberneticDto>> GetCybernetics()
        {
            var cybernetics = await context.Cybernetics
                .Include(c => c.Category)
                .Include(c => c.Availability)
                .ToListAsync();
            return mapper.Map<List<Cybernetic>, List<CyberneticDto>>(cybernetics);
        }

        // GET: api/Cybernetic/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCybernetics([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cybernetics = await context.Cybernetics.SingleOrDefaultAsync(m => m.Id == id);

            if (cybernetics == null)
            {
                return NotFound();
            }

            return Ok(cybernetics);
        }

        // PUT: api/Cybernetic/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCybernetics([FromRoute] int id, [FromBody] Cybernetic cybernetic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cybernetic.Id)
            {
                return BadRequest();
            }

            context.Entry(cybernetic).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CyberneticsExists(id))
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

        // POST: api/Cybernetic
        [HttpPost]
        public async Task<IActionResult> PostCybernetics([FromBody] Cybernetic cybernetic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Cybernetics.Add(cybernetic);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetCybernetics", new { id = cybernetic.Id }, cybernetic);
        }

        // DELETE: api/Cybernetic/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCybernetics([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cybernetics = await context.Cybernetics.SingleOrDefaultAsync(m => m.Id == id);
            if (cybernetics == null)
            {
                return NotFound();
            }

            context.Cybernetics.Remove(cybernetics);
            await context.SaveChangesAsync();

            return Ok(cybernetics);
        }

        private bool CyberneticsExists(int id)
        {
            return context.Cybernetics.Any(e => e.Id == id);
        }
    }
}