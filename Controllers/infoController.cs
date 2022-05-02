#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimeAPI.Models;

namespace AnimeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class infoController : ControllerBase
    {
        private readonly AnimeAPIDBContext _context;

        public infoController(AnimeAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/infoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<info>>> Getinfo()
        {
            return await _context.info.ToListAsync();
        }

        // GET: api/infoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<info>> Getinfo(int id)
        {
            var info = await _context.info.FindAsync(id);

            if (info == null)
            {
                return NotFound();
            }

            return info;
        }

        // PUT: api/infoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putinfo(int id, info info)
        {
            if (id != info.animeId)
            {
                return BadRequest();
            }

            _context.Entry(info).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!infoExists(id))
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

        // POST: api/infoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<info>> Postinfo(info info)
        {
            _context.info.Add(info);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getinfo", new { id = info.animeId }, info);
        }

        // DELETE: api/infoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteinfo(int id)
        {
            var info = await _context.info.FindAsync(id);
            if (info == null)
            {
                return NotFound();
            }

            _context.info.Remove(info);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool infoExists(int id)
        {
            return _context.info.Any(e => e.animeId == id);
        }
    }
}
