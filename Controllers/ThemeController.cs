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
    public class ThemeController : ControllerBase
    {
        private readonly AnimeAPIDBContext _context;

        public ThemeController(AnimeAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Theme
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Theme>>> GetTheme()
        {
            return await _context.theme.ToListAsync();
        }

        // GET: api/Theme/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetTheme(int id)
        {
            var response = new Response();
            
            var theme = await _context.theme.FindAsync(id);

            response.StatusCode = 200;
            response.StatusDesc = "Success! Here is the anime you were looking for!";
            response.theme = theme;

            if (theme == null)
            {
                response.StatusCode = 400;
                response.StatusDesc = "Invalid anime or does not exist!";

                return response;
            }

            return response;
        }

        // PUT: api/Theme/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTheme(int id, Theme theme)
        {
            if (id != theme.anime_info_id)
            {
                return BadRequest();
            }

            _context.Entry(theme).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThemeExists(id))
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

        // POST: api/Theme
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Response>> PostTheme(Theme theme)
        {
            // Adds an additional anime to the theme  list
            var response = new Response();
            _context.theme.Add(theme);
            await _context.SaveChangesAsync();

            response.StatusCode = 201;
            response.StatusDesc = "Successfully Added to the List!";

            CreatedAtAction("GetTheme", new { id = theme.anime_info_id }, theme);
            return response;
        }

        // DELETE: api/Theme/5
        [HttpDelete("{id}")]
        public async Task<Response> DeleteTheme(int id)
        {
            var theme = await _context.theme.FindAsync(id);
            var response = new Response();
            //If Successful
            response.StatusCode = 200;
            response.StatusDesc = "Successfully Removed!";
            response.theme = theme;

            //If cannot remove
            if (theme == null)
            {
                response.StatusCode = 400;
                response.StatusDesc = "You cannot remove something that doesn't exist!";
                return response;
            }

            _context.theme.Remove(theme);
            await _context.SaveChangesAsync();
            return response;
        }

        private bool ThemeExists(int id)
        {
            return _context.theme.Any(e => e.anime_info_id == id);
        }
    }
}
