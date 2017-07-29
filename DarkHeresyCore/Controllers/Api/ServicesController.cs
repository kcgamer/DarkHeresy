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
    [Route("api/Service")]
    public class ServicesController : Controller
    {
        private readonly DarkHeresyContext _context;
        private readonly IMapper _mapper;

        public ServicesController(DarkHeresyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Service
        [HttpGet("/api/Service")]
        public async Task<IEnumerable<ServiceDto>> GetServices()
        {
            var services = await _context.Services.Include(s => s.Category).Include(s => s.Availability).ToListAsync();
            return _mapper.Map<List<Service>, List<ServiceDto>>(services);
        }

        // GET: api/Service/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServices([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var services = await _context.Services.SingleOrDefaultAsync(m => m.Id == id);

            if (services == null)
            {
                return NotFound();
            }

            return Ok(services);
        }

        // PUT: api/Service/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServices([FromRoute] int id, [FromBody] Service service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != service.Id)
            {
                return BadRequest();
            }

            _context.Entry(service).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicesExists(id))
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

        // POST: api/Service
        [HttpPost]
        public async Task<IActionResult> PostServices([FromBody] Service service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Services.Add(service);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServices", new { id = service.Id }, service);
        }

        // DELETE: api/Service/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServices([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var services = await _context.Services.SingleOrDefaultAsync(m => m.Id == id);
            if (services == null)
            {
                return NotFound();
            }

            _context.Services.Remove(services);
            await _context.SaveChangesAsync();

            return Ok(services);
        }

        private bool ServicesExists(int id)
        {
            return _context.Services.Any(e => e.Id == id);
        }
    }
}