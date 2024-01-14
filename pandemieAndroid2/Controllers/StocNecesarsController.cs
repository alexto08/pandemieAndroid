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
    public class StocNecesarsController : ControllerBase
    {
        private readonly pandemieAndroid2Context _context;

        public StocNecesarsController(pandemieAndroid2Context context)
        {
            _context = context;
        }

        // GET: api/StocNecesars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StocNecesar>>> GetStocNecesar()
        {
          if (_context.StocNecesar == null)
          {
              return NotFound();
          }
            return await _context.StocNecesar.ToListAsync();
        }

        // GET: api/StocNecesars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StocNecesar>> GetStocNecesar(int id)
        {
          if (_context.StocNecesar == null)
          {
              return NotFound();
          }
            var stocNecesar = await _context.StocNecesar.FindAsync(id);

            if (stocNecesar == null)
            {
                return NotFound();
            }

            return stocNecesar;
        }

        // PUT: api/StocNecesars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStocNecesar(int id, StocNecesar stocNecesar)
        {
            if (id != stocNecesar.ID)
            {
                return BadRequest();
            }

            _context.Entry(stocNecesar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StocNecesarExists(id))
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

        // POST: api/StocNecesars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StocNecesar>> PostStocNecesar(StocNecesar stocNecesar)
        {
          if (_context.StocNecesar == null)
          {
              return Problem("Entity set 'pandemieAndroid2Context.StocNecesar'  is null.");
          }
            _context.StocNecesar.Add(stocNecesar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStocNecesar", new { id = stocNecesar.ID }, stocNecesar);
        }

        // DELETE: api/StocNecesars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStocNecesar(int id)
        {
            if (_context.StocNecesar == null)
            {
                return NotFound();
            }
            var stocNecesar = await _context.StocNecesar.FindAsync(id);
            if (stocNecesar == null)
            {
                return NotFound();
            }

            _context.StocNecesar.Remove(stocNecesar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StocNecesarExists(int id)
        {
            return (_context.StocNecesar?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
