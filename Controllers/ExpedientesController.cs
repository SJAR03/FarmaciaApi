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
    public class ExpedientesController : ControllerBase
    {
        private readonly FarmaciaDbContext _context;

        public ExpedientesController(FarmaciaDbContext context)
        {
            _context = context;
        }

        // GET: api/Expedientes
        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Expediente>>> GetExpedientes()
        {
            return await _context.Expedientes.ToListAsync();
        }

        // GET: api/Expedientes/5
        //[Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Expediente>> GetExpediente(int id)
        {
            var expediente = await _context.Expedientes.FindAsync(id);

            if (expediente == null)
            {
                return NotFound();
            }

            return expediente;
        }

        // PUT: api/Expedientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpediente(int id, ExpedienteUpdateDTO expediente)
        {
            var existingExpediente = await _context.Expedientes.FindAsync(id);

            if (existingExpediente == null)
            {
                return NotFound();
            }

            existingExpediente.Notas = expediente.Notas;
            existingExpediente.Estado = expediente.Estado;
            existingExpediente.IdPaciente = expediente.IdPaciente;
            existingExpediente.IdUsuarioModificacion = expediente.IdUsuarioModificacion;
            existingExpediente.FechaModificacion = expediente.FechaModificacion;

            _context.Entry(existingExpediente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpedienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(existingExpediente);
        }

        // POST: api/Expedientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<Expediente>> PostExpediente(ExpedienteCreateDTO expediente)
        {

            var expedienteObj = new Expediente
            {
                Notas = expediente.Notas,
                Estado = expediente.Estado,
                IdPaciente = expediente.IdPaciente,
                IdUsuarioCreacion = expediente.IdUsuarioCreacion,
                FechaCreacion = expediente.FechaCreacion,
                IdUsuarioModificacion = expediente.IdUsuarioModificacion,
                FechaModificacion = expediente.FechaModificacion
            };

            _context.Expedientes.Add(expedienteObj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExpediente", new { id = expedienteObj.IdExpediente }, expedienteObj);
        }

        // DELETE: api/Expedientes/5
        //[Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpediente(int id)
        {
            var expediente = await _context.Expedientes.FindAsync(id);
            if (expediente == null)
            {
                return NotFound();
            }

            _context.Expedientes.Remove(expediente);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ExpedienteExists(int id)
        {
            return _context.Expedientes.Any(e => e.IdExpediente == id);
        }
    }
}
