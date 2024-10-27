using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarmaciaApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace FarmaciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescripcionesController : ControllerBase
    {
        private readonly FarmaciaDbContext _context;

        public PrescripcionesController(FarmaciaDbContext context)
        {
            _context = context;
        }

        // GET: api/Prescripciones
        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prescripcion>>> GetPrescripciones()
        {
            return await _context.Prescripciones.ToListAsync();
        }

        // GET: api/Prescripciones/5
        //[Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Prescripcion>> GetPrescripcion(int id)
        {
            var prescripcion = await _context.Prescripciones.FindAsync(id);

            if (prescripcion == null)
            {
                return NotFound();
            }

            return prescripcion;
        }

        // PUT: api/Prescripciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrescripcion(int id, Prescripcion prescripcion)
        {
            if (id != prescripcion.IdPrescripcion)
            {
                return BadRequest();
            }

            _context.Entry(prescripcion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrescripcionExists(id))
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

        // POST: api/Prescripciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<Prescripcion>> PostPrescripcion(Prescripcion prescripcion)
        {
            _context.Prescripciones.Add(prescripcion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrescripcion", new { id = prescripcion.IdPrescripcion }, prescripcion);
        }

        // DELETE: api/Prescripciones/5
        //[Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescripcion(int id)
        {
            var prescripcion = await _context.Prescripciones.FindAsync(id);
            if (prescripcion == null)
            {
                return NotFound();
            }

            _context.Prescripciones.Remove(prescripcion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrescripcionExists(int id)
        {
            return _context.Prescripciones.Any(e => e.IdPrescripcion == id);
        }
    }
}
