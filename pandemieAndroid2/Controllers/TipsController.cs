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
    public class TipsController : ControllerBase
    {
        private readonly pandemieAndroid2Context _context;

        public TipsController(pandemieAndroid2Context context)
        {
            _context = context;
        }

        // GET: api/Tips
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tip>>> GetTip()
        {
          if (_context.Tip == null)
          {
              return NotFound();
          }
            return await _context.Tip.ToListAsync();
        }

        // GET: api/Tips/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tip>> GetTip(int id)
        {
          if (_context.Tip == null)
          {
              return NotFound();
          }
            var tip = await _context.Tip.FindAsync(id);

            if (tip == null)
            {
                return NotFound();
            }

            return tip;
        }

        // PUT: api/Tips/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTip(int id, Tip tip)
        {
            if (id != tip.ID)
            {
                return BadRequest();
            }

            _context.Entry(tip).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipExists(id))
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

        // POST: api/Tips
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tip>> PostTip(Tip tip)
        {
          if (_context.Tip == null)
          {
              return Problem("Entity set 'pandemieAndroid2Context.Tip'  is null.");
          }
            _context.Tip.Add(tip);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTip", new { id = tip.ID }, tip);
        }

        // DELETE: api/Tips/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTip(int id)
        {
            if (_context.Tip == null)
            {
                return NotFound();
            }
            var tip = await _context.Tip.FindAsync(id);
            if (tip == null)
            {
                return NotFound();
            }

            _context.Tip.Remove(tip);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipExists(int id)
        {
            return (_context.Tip?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
