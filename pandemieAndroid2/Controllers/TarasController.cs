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
    public class TarasController : ControllerBase
    {
        private readonly pandemieAndroid2Context _context;

        public TarasController(pandemieAndroid2Context context)
        {
            _context = context;
        }

        // GET: api/Taras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tara>>> GetTara()
        {
          if (_context.Tara == null)
          {
              return NotFound();
          }
            return await _context.Tara.ToListAsync();
        }

        // GET: api/Taras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tara>> GetTara(int id)
        {
          if (_context.Tara == null)
          {
              return NotFound();
          }
            var tara = await _context.Tara.FindAsync(id);

            if (tara == null)
            {
                return NotFound();
            }

            return tara;
        }

        // PUT: api/Taras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTara(int id, Tara tara)
        {
            if (id != tara.ID)
            {
                return BadRequest();
            }

            _context.Entry(tara).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaraExists(id))
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

        // POST: api/Taras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tara>> PostTara(Tara tara)
        {
          if (_context.Tara == null)
          {
              return Problem("Entity set 'pandemieAndroid2Context.Tara'  is null.");
          }
            _context.Tara.Add(tara);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTara", new { id = tara.ID }, tara);
        }

        // DELETE: api/Taras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTara(int id)
        {
            if (_context.Tara == null)
            {
                return NotFound();
            }
            var tara = await _context.Tara.FindAsync(id);
            if (tara == null)
            {
                return NotFound();
            }

            _context.Tara.Remove(tara);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaraExists(int id)
        {
            return (_context.Tara?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
