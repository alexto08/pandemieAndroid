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
    public class FondsController : ControllerBase
    {
        private readonly pandemieAndroid2Context _context;

        public FondsController(pandemieAndroid2Context context)
        {
            _context = context;
        }

        // GET: api/Fonds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fond>>> GetFond()
        {
          if (_context.Fond == null)
          {
              return NotFound();
          }
            return await _context.Fond.ToListAsync();
        }

        // GET: api/Fonds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fond>> GetFond(int id)
        {
          if (_context.Fond == null)
          {
              return NotFound();
          }
            var fond = await _context.Fond.FindAsync(id);

            if (fond == null)
            {
                return NotFound();
            }

            return fond;
        }

        // PUT: api/Fonds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFond(int id, Fond fond)
        {
            if (id != fond.ID)
            {
                return BadRequest();
            }

            _context.Entry(fond).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FondExists(id))
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

        // POST: api/Fonds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fond>> PostFond(Fond fond)
        {
          if (_context.Fond == null)
          {
              return Problem("Entity set 'pandemieAndroid2Context.Fond'  is null.");
          }
            _context.Fond.Add(fond);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFond", new { id = fond.ID }, fond);
        }

        // DELETE: api/Fonds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFond(int id)
        {
            if (_context.Fond == null)
            {
                return NotFound();
            }
            var fond = await _context.Fond.FindAsync(id);
            if (fond == null)
            {
                return NotFound();
            }

            _context.Fond.Remove(fond);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FondExists(int id)
        {
            return (_context.Fond?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
