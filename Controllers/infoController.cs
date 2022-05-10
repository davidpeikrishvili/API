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

        // GET: api/info
        [HttpGet]
        public async Task<ActionResult<IEnumerable<info>>> Getinfo()
        {
            return await _context.info.ToListAsync();
        }

        // GET: api/info/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> Getinfo(int id)
        {
            var response = new Response();
            var info = await _context.info.FindAsync(id);
            var theme = await _context.theme.FindAsync(id);

            response.StatusCode = 200;
            response.StatusDesc = "Success! Here is the anime you were looking for!";
            response.info = info;
            response.theme = theme;

            if (info == null)
            {
                response.StatusCode = 400;
                response.StatusDesc = "Invalid anime or does not exist!";
                
                return response;
            }

            return response;
        }

        // PUT: api/info/5
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

        // POST: api/info
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Response>> Postinfo(info info)
        {
            // Adds an additional anime to the info list
            var response = new Response();
            _context.info.Add(info);
            await _context.SaveChangesAsync();
            response.StatusCode = 201;
            response.StatusDesc = "Successfully Added to the List!";
            CreatedAtAction("Getinfo", new { id = info.animeId }, info);
           
            return response;
        }



        // DELETE: api/info/5
        [HttpDelete("{id}")]
        public async Task<Response> Deleteinfo(int id)
        {

            var info = await _context.info.FindAsync(id);
            var response = new Response();
            //If Successful
            response.StatusCode = 200;
            response.StatusDesc = "Successfully Removed!";
            response.info = info;

            //If cannot remove
            if (info == null)
            {
                response.StatusCode = 400;
                response.StatusDesc = "You cannot remove something that doesn't exist!";
                return response;
            }

            _context.info.Remove(info);
            await _context.SaveChangesAsync();
            return response;
        }

        private bool infoExists(int id)
        {
            return _context.info.Any(e => e.animeId == id);
        }
    }
}
