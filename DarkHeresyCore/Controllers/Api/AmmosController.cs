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
    [Route("api/Ammos")]
    public class AmmosController : Controller
    {
        private readonly DarkHeresyContext context;
        private readonly IMapper mapper;

        public AmmosController(DarkHeresyContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET: api/Ammos
        [HttpGet("/api/Ammos")]
        public async Task<IEnumerable<AmmoDto>> GetAmmo()
        {
            var ammos = await context.Ammo.Include(a => a.Availability).ToListAsync();
            return mapper.Map<List<Ammo>, List<AmmoDto>>(ammos);
        }

        // GET: api/Ammos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAmmo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ammo = await context.Ammo.SingleOrDefaultAsync(m => m.Id == id);

            if (ammo == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Ammo, AmmoDto>(ammo));
        }

        // PUT: api/Ammos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmmo([FromRoute] int id, [FromBody] AmmoDto ammoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ammoDto.Id)
            {
                return BadRequest();
            }

            var ammoInDb = await context.Ammo.SingleOrDefaultAsync(a => a.Id == id);
            if (ammoInDb == null)
                return NotFound();

            Mapper.Map(ammoDto, ammoInDb);

            await context.SaveChangesAsync();
            return Ok();
        }

        // POST: api/Ammos
        [HttpPost]
        public async Task<IActionResult> CreateAmmo([FromBody] AmmoDto ammoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var ammo = Mapper.Map<AmmoDto, Ammo>(ammoDto);
            context.Ammo.Add(ammo);
            await context.SaveChangesAsync();

            ammoDto.Id = ammo.Id;
            return CreatedAtAction("GetAmmo", new { id = ammo.Id }, ammo);
        }

        // DELETE: api/Ammos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmmo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ammo = await context.Ammo.SingleOrDefaultAsync(m => m.Id == id);
            if (ammo == null)
            {
                return NotFound();
            }

            context.Ammo.Remove(ammo);
            await context.SaveChangesAsync();

            return Ok(ammo);
        }

        private bool AmmoExists(int id)
        {
            return context.Ammo.Any(e => e.Id == id);
        }
    }
}