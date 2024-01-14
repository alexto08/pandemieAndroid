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
    public class VaccinsController : ControllerBase
    {
        private readonly pandemieAndroid2Context _context;

        public VaccinsController(pandemieAndroid2Context context)
        {
            _context = context;
        }

        // GET: api/Vaccins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vaccin>>> GetVaccin()
        {
          if (_context.Vaccin == null)
          {
              return NotFound();
          }
            return await _context.Vaccin.ToListAsync();
        }

        // GET: api/Vaccins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vaccin>> GetVaccin(int id)
        {
          if (_context.Vaccin == null)
          {
              return NotFound();
          }
            var vaccin = await _context.Vaccin.FindAsync(id);

            if (vaccin == null)
            {
                return NotFound();
            }

            return vaccin;
        }

        // PUT: api/Vaccins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVaccin(int id, Vaccin vaccin)
        {
            if (id != vaccin.ID)
            {
                return BadRequest();
            }

            _context.Entry(vaccin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VaccinExists(id))
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

        // POST: api/Vaccins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vaccin>> PostVaccin(Vaccin vaccin)
        {
          if (_context.Vaccin == null)
          {
              return Problem("Entity set 'pandemieAndroid2Context.Vaccin'  is null.");
          }
            _context.Vaccin.Add(vaccin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVaccin", new { id = vaccin.ID }, vaccin);
        }

        // DELETE: api/Vaccins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaccin(int id)
        {
            if (_context.Vaccin == null)
            {
                return NotFound();
            }
            var vaccin = await _context.Vaccin.FindAsync(id);
            if (vaccin == null)
            {
                return NotFound();
            }

            _context.Vaccin.Remove(vaccin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VaccinExists(int id)
        {
            return (_context.Vaccin?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
