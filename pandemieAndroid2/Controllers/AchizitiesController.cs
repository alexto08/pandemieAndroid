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
    public class AchizitiesController : ControllerBase
    {
        private readonly pandemieAndroid2Context _context;

        public AchizitiesController(pandemieAndroid2Context context)
        {
            _context = context;
        }

        // GET: api/Achizities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Achizitie>>> GetAchizitie()
        {
          if (_context.Achizitie == null)
          {
              return NotFound();
          }
            return await _context.Achizitie.ToListAsync();
        }

        // GET: api/Achizities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Achizitie>> GetAchizitie(int id)
        {
          if (_context.Achizitie == null)
          {
              return NotFound();
          }
            var achizitie = await _context.Achizitie.FindAsync(id);

            if (achizitie == null)
            {
                return NotFound();
            }

            return achizitie;
        }

        // PUT: api/Achizities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAchizitie(int id, Achizitie achizitie)
        {
            if (id != achizitie.ID)
            {
                return BadRequest();
            }

            _context.Entry(achizitie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AchizitieExists(id))
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

        // POST: api/Achizities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Achizitie>> PostAchizitie(Achizitie achizitie)
        {
          if (_context.Achizitie == null)
          {
              return Problem("Entity set 'pandemieAndroid2Context.Achizitie'  is null.");
          }
            _context.Achizitie.Add(achizitie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAchizitie", new { id = achizitie.ID }, achizitie);
        }

        // DELETE: api/Achizities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAchizitie(int id)
        {
            if (_context.Achizitie == null)
            {
                return NotFound();
            }
            var achizitie = await _context.Achizitie.FindAsync(id);
            if (achizitie == null)
            {
                return NotFound();
            }

            _context.Achizitie.Remove(achizitie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AchizitieExists(int id)
        {
            return (_context.Achizitie?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
