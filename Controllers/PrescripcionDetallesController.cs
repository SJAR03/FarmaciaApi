using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarmaciaApi.Models;
using Microsoft.AspNetCore.Authorization;
using FarmaciaApi.DTOs.Update;
using FarmaciaApi.DTOs.Create;

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
        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrescripcionDetalle>>> GetPrescripcionDetalles()
        {
            return await _context.PrescripcionDetalles.ToListAsync();
        }

        // GET: api/PrescripcionDetalles/5
        //[Authorize]
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
        //[Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrescripcionDetalle(int id, PrescripcionDetalleUpdateDTO prescripcionDetalle)
        {

            PrescripcionDetalle existingPrescripcionDetalle = await _context.PrescripcionDetalles.FindAsync(id);

            if (existingPrescripcionDetalle == null)
            {
                return NotFound("The specified prescription detail was not found.");
            }

            FarmacoPresentacion farmacoPresentacion = await _context.LoteFarmacoDetalles.FindAsync(prescripcionDetalle.IdFarmacoPresentacion);
            var idLoteFarmaco = farmacoPresentacion.IdLoteFarmaco;

            LoteFarmaco loteFarmaco = await _context.LoteFarmacos.FindAsync(idLoteFarmaco);

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
            existingPrescripcionDetalle.Estado = prescripcionDetalle.Estado;
            existingPrescripcionDetalle.IdPrescripcion = prescripcionDetalle.IdPrescripcion;
            existingPrescripcionDetalle.IdFarmacoPresentacion = prescripcionDetalle.IdFarmacoPresentacion;
            existingPrescripcionDetalle.IdUsuarioModificacion = prescripcionDetalle.IdUsuarioModificacion;
            existingPrescripcionDetalle.FechaModificacion = prescripcionDetalle.FechaModificacion;

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
            return Ok(existingPrescripcionDetalle);

        }

        // POST: api/PrescripcionDetalles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<PrescripcionDetalle>> PostPrescripcionDetalle(PrescripcionDetalleCreateDTO prescripcionDetalle)
        {
            FarmacoPresentacion farmacoPresentacion = await _context.LoteFarmacoDetalles.FindAsync(prescripcionDetalle.IdFarmacoPresentacion);
            var idLoteFarmaco = farmacoPresentacion.IdLoteFarmaco;

            LoteFarmaco loteFarmaco = await _context.LoteFarmacos.FindAsync(idLoteFarmaco);

            if (loteFarmaco == null || loteFarmaco.Cantidad < prescripcionDetalle.Cantidad)
            {
                return BadRequest("Cantidad insufiente en el lote de farmacos");
            }

            var prescripcionDetalleObj = new PrescripcionDetalle
            {
                Cantidad = prescripcionDetalle.Cantidad,
                Estado = prescripcionDetalle.Estado,
                IdPrescripcion = prescripcionDetalle.IdPrescripcion,
                IdFarmacoPresentacion = prescripcionDetalle.IdFarmacoPresentacion,
                IdUsuarioCreacion = prescripcionDetalle.IdUsuarioCreacion,
                FechaCreacion = prescripcionDetalle.FechaCreacion,
                IdUsuarioModificacion = prescripcionDetalle.IdUsuarioModificacion,
                FechaModificacion = prescripcionDetalle.FechaModificacion
            };

            loteFarmaco.Cantidad -= prescripcionDetalle.Cantidad;

            _context.PrescripcionDetalles.Add(prescripcionDetalleObj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrescripcionDetalle", new { id = prescripcionDetalleObj.IdPrescripcionDetalle }, prescripcionDetalleObj);
        }


        // DELETE: api/PrescripcionDetalles/5
        //[Authorize]
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

            return Ok();
        }

        private bool PrescripcionDetalleExists(int id)
        {
            return _context.PrescripcionDetalles.Any(e => e.IdPrescripcionDetalle == id);
        }
    }
}
