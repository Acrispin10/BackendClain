using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendClain.Data;
using BackendClain.Models;

namespace BackendClain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClainsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClainsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Clains
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clain>>> GetClain()
        {
            return await _context.Clain.ToListAsync();
        }

        // GET: api/Clains/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clain>> GetClain(string id)
        {
            var clain = await _context.Clain.FindAsync(id);

            if (clain == null)
            {
                return NotFound();
            }

            return clain;
        }

        // PUT: api/Clains/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClain(string id, Clain clain)
        {
            if (id != clain.Dieta)
            {
                return BadRequest();
            }

            _context.Entry(clain).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClainExists(id))
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

        // POST: api/Clains
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Clain>> PostClain(Clain clain)
        {
            _context.Clain.Add(clain);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClainExists(clain.Dieta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClain", new { id = clain.Dieta }, clain);
        }

        // DELETE: api/Clains/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClain(string id)
        {
            var clain = await _context.Clain.FindAsync(id);
            if (clain == null)
            {
                return NotFound();
            }

            _context.Clain.Remove(clain);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClainExists(string id)
        {
            return _context.Clain.Any(e => e.Dieta == id);
        }
    }
}
