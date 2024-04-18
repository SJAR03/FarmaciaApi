using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarmaciaApi.Models;

namespace FarmaciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedidasController : ControllerBase
    {
        private readonly FarmaciaDbContext _context;

        public MedidasController(FarmaciaDbContext context)
        {
            _context = context;
        }

        // GET: api/Medidas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medidas>>> GetMedidas()
        {
            return await _context.Medidas.ToListAsync();
        }

        // GET: api/Medidas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medidas>> GetMedidas(int id)
        {
            var medidas = await _context.Medidas.FindAsync(id);

            if (medidas == null)
            {
                return NotFound();
            }

            return medidas;
        }

        // PUT: api/Medidas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedidas(int id, Medidas medidas)
        {
            if (id != medidas.IdMedidas)
            {
                return BadRequest();
            }

            _context.Entry(medidas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedidasExists(id))
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

        // POST: api/Medidas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Medidas>> PostMedidas(Medidas medidas)
        {
            _context.Medidas.Add(medidas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedidas", new { id = medidas.IdMedidas }, medidas);
        }

        // DELETE: api/Medidas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedidas(int id)
        {
            var medidas = await _context.Medidas.FindAsync(id);
            if (medidas == null)
            {
                return NotFound();
            }

            _context.Medidas.Remove(medidas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedidasExists(int id)
        {
            return _context.Medidas.Any(e => e.IdMedidas == id);
        }
    }
}
