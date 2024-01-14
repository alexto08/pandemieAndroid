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
    public class ProducatorsController : ControllerBase
    {
        private readonly pandemieAndroid2Context _context;

        public ProducatorsController(pandemieAndroid2Context context)
        {
            _context = context;
        }

        // GET: api/Producators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producator>>> GetProducator()
        {
          if (_context.Producator == null)
          {
              return NotFound();
          }
            return await _context.Producator.ToListAsync();
        }

        // GET: api/Producators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producator>> GetProducator(int id)
        {
          if (_context.Producator == null)
          {
              return NotFound();
          }
            var producator = await _context.Producator.FindAsync(id);

            if (producator == null)
            {
                return NotFound();
            }

            return producator;
        }

        // PUT: api/Producators/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducator(int id, Producator producator)
        {
            if (id != producator.ID)
            {
                return BadRequest();
            }

            _context.Entry(producator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProducatorExists(id))
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

        // POST: api/Producators
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Producator>> PostProducator(Producator producator)
        {
          if (_context.Producator == null)
          {
              return Problem("Entity set 'pandemieAndroid2Context.Producator'  is null.");
          }
            _context.Producator.Add(producator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducator", new { id = producator.ID }, producator);
        }

        // DELETE: api/Producators/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducator(int id)
        {
            if (_context.Producator == null)
            {
                return NotFound();
            }
            var producator = await _context.Producator.FindAsync(id);
            if (producator == null)
            {
                return NotFound();
            }

            _context.Producator.Remove(producator);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProducatorExists(int id)
        {
            return (_context.Producator?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
