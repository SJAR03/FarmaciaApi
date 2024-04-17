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
    public class DosificacionsController : ControllerBase
    {
        private readonly FarmaciaDbContext _context;

        public DosificacionsController(FarmaciaDbContext context)
        {
            _context = context;
        }

        // GET: api/Dosificacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dosificacion>>> GetDosificaciones()
        {
            return await _context.Dosificaciones.ToListAsync();
        }

        // GET: api/Dosificacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dosificacion>> GetDosificacion(int id)
        {
            var dosificacion = await _context.Dosificaciones.FindAsync(id);

            if (dosificacion == null)
            {
                return NotFound();
            }

            return dosificacion;
        }

        // PUT: api/Dosificacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDosificacion(int id, Dosificacion dosificacion)
        {
            if (id != dosificacion.IdDosificacion)
            {
                return BadRequest();
            }

            _context.Entry(dosificacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DosificacionExists(id))
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

        // POST: api/Dosificacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dosificacion>> PostDosificacion(Dosificacion dosificacion)
        {
            _context.Dosificaciones.Add(dosificacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDosificacion", new { id = dosificacion.IdDosificacion }, dosificacion);
        }

        // DELETE: api/Dosificacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDosificacion(int id)
        {
            var dosificacion = await _context.Dosificaciones.FindAsync(id);
            if (dosificacion == null)
            {
                return NotFound();
            }

            _context.Dosificaciones.Remove(dosificacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DosificacionExists(int id)
        {
            return _context.Dosificaciones.Any(e => e.IdDosificacion == id);
        }
    }
}
