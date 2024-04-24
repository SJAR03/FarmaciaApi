using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarmaciaApi.Models;
using FarmaciaApi.ViewModel;

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

        // GET: api/PrescripcionDetalleView
        [HttpGet("PrescripcionDetalleView")]
        public async Task<ActionResult<IEnumerable<PrescripcionDetalleView>>> GetPrescripcionDetalleView()
        {
            return await _context.PrescripcionDetalleView.ToListAsync();
        }

        // GET: api/PrescripcionDetalleView/5
        [HttpGet("PrescripcionDetalleView/{id}")]
        public async Task<ActionResult<PrescripcionDetalleView>> GetPrescripcionDetalleView(int id)
        {
            var PrescripcionDetalle = await _context.PrescripcionDetalleView.Where(p => p.IdPrescripcionDetalle == id).FirstOrDefaultAsync();

            if (PrescripcionDetalle == null)
            {
                return NotFound();
            }

            return PrescripcionDetalle;
        }

        // PUT: api/PrescripcionDetalles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrescripcionDetalle(int id, PrescripcionDetalle prescripcionDetalle)
        {
            if (id != prescripcionDetalle.IdPrescripcionDetalle)
            {
                return BadRequest("Invalid request. The provided id does not match the id in the object.");
            }

            PrescripcionDetalle existingPrescripcionDetalle = await _context.PrescripcionDetalles.FindAsync(id);

            if (existingPrescripcionDetalle == null)
            {
                return NotFound("The specified prescription detail was not found.");
            }

            LoteFarmaco loteFarmaco = await _context.LoteFarmacos.FindAsync(existingPrescripcionDetalle.IdLoteFarmaco);

            if (loteFarmaco == null)
            {
                return NotFound("The specified lot was not found.");
            }

            // Calcular la diferencia entre la nueva cantidad y la cantidad original de la prescripción
            int cantidadDiferencia = prescripcionDetalle.Cantidad - existingPrescripcionDetalle.Cantidad;

            // Verificar si la cantidad solicitada es mayor que la cantidad original de la prescripción
            if (cantidadDiferencia > 0)
            {
                // Verificar si hay suficiente cantidad disponible en el lote de fármacos
                if (cantidadDiferencia > loteFarmaco.Cantidad)
                {
                    return BadRequest("Insufficient quantity in the specified lot.");
                }

                // Actualizar la cantidad disponible en el lote de fármacos
                loteFarmaco.Cantidad -= cantidadDiferencia;
            }
            else // Si la cantidad solicitada es menor o igual que la cantidad original de la prescripción
            {
                // Actualizar la cantidad disponible en el lote de fármacos
                loteFarmaco.Cantidad += Math.Abs(cantidadDiferencia); // Añadir la diferencia absoluta
            }

            // Actualizar la cantidad en el detalle de prescripción
            existingPrescripcionDetalle.Cantidad = prescripcionDetalle.Cantidad;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
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
        }

        // POST: api/PrescripcionDetalles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PrescripcionDetalle>> PostPrescripcionDetalle(PrescripcionDetalle prescripcionDetalle)
        {
            LoteFarmaco loteFarmaco = await _context.LoteFarmacos.FindAsync(prescripcionDetalle.IdLoteFarmaco);

            if (loteFarmaco == null || loteFarmaco.Cantidad < prescripcionDetalle.Cantidad)
            {
                return BadRequest("Cantidad insufiente en el lote de farmacos");
            }

            loteFarmaco.Cantidad -= prescripcionDetalle.Cantidad;

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
