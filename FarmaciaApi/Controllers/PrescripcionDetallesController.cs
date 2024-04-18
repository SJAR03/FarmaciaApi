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
    public class PrescripcionDetallesController : ControllerBase
    {
        private readonly FarmaciaDbContext _context;

        public PrescripcionDetallesController(FarmaciaDbContext context)
        {
            _context = context;
        }

        // GET: api/PrescripcionDetalles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrescripcionDetalle>>> GetPrescripcionDetalles()
        {
            return await _context.PrescripcionDetalles.ToListAsync();
        }

        // GET: api/PrescripcionDetalles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrescripcionDetalle>> GetPrescripcionDetalle(int id)
        {
            var prescripcionDetalle = await _context.PrescripcionDetalles.FindAsync(id);

            if (prescripcionDetalle == null)
            {
                return NotFound();
            }

            return prescripcionDetalle;
        }

        // PUT: api/PrescripcionDetalles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrescripcionDetalle(int id, PrescripcionDetalle prescripcionDetalle)
        {
            if (id != prescripcionDetalle.IdPrescripcionDetalle)
            {
                return BadRequest();
            }

            _context.Entry(prescripcionDetalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrescripcionDetalleExists(id))
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

        // POST: api/PrescripcionDetalles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PrescripcionDetalle>> PostPrescripcionDetalle(PrescripcionDetalle prescripcionDetalle)
        {
            _context.PrescripcionDetalles.Add(prescripcionDetalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrescripcionDetalle", new { id = prescripcionDetalle.IdPrescripcionDetalle }, prescripcionDetalle);
        }

        // DELETE: api/PrescripcionDetalles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescripcionDetalle(int id)
        {
            var prescripcionDetalle = await _context.PrescripcionDetalles.FindAsync(id);
            if (prescripcionDetalle == null)
            {
                return NotFound();
            }

            _context.PrescripcionDetalles.Remove(prescripcionDetalle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrescripcionDetalleExists(int id)
        {
            return _context.PrescripcionDetalles.Any(e => e.IdPrescripcionDetalle == id);
        }
    }
}
