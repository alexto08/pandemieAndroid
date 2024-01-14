using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pandemieAndroid2.Data;
using pandemieAndroid2.Models;

namespace pandemieAndroid2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembrusController : ControllerBase
    {
        private readonly pandemieAndroid2Context _context;

        public MembrusController(pandemieAndroid2Context context)
        {
            _context = context;
        }

        // GET: api/Membrus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Membru>>> GetMembru()
        {
          if (_context.Membru == null)
          {
              return NotFound();
          }
            return await _context.Membru.ToListAsync();
        }

        // GET: api/Membrus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Membru>> GetMembru(int id)
        {
          if (_context.Membru == null)
          {
              return NotFound();
          }
            var membru = await _context.Membru.FindAsync(id);

            if (membru == null)
            {
                return NotFound();
            }

            return membru;
        }

        // PUT: api/Membrus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMembru(int id, Membru membru)
        {
            if (id != membru.ID)
            {
                return BadRequest();
            }

            _context.Entry(membru).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembruExists(id))
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

        // POST: api/Membrus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Membru>> PostMembru(Membru membru)
        {
          if (_context.Membru == null)
          {
              return Problem("Entity set 'pandemieAndroid2Context.Membru'  is null.");
          }
            _context.Membru.Add(membru);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMembru", new { id = membru.ID }, membru);
        }

        // DELETE: api/Membrus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMembru(int id)
        {
            if (_context.Membru == null)
            {
                return NotFound();
            }
            var membru = await _context.Membru.FindAsync(id);
            if (membru == null)
            {
                return NotFound();
            }

            _context.Membru.Remove(membru);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MembruExists(int id)
        {
            return (_context.Membru?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
