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
using FarmaciaApi.DTOs.Views;

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
        public async Task<ActionResult<IEnumerable<ExpedienteViewDTO>>> GetExpedientes()
        {
            var expedientes = await _context.Expedientes
                .Include(e => e.Paciente)
                .Select(e => new ExpedienteViewDTO
                {
                    IdExpediente = e.IdExpediente,
                    Notas = e.Notas,
                    Estado = e.Estado,
                    Paciente = new PacienteViewDTO
                    {
                        IdPaciente = e.Paciente.IdPaciente,
                        Nombres = e.Paciente.Nombres,
                        Apellidos = e.Paciente.Apellidos,
                        FechaNacimiento = e.Paciente.FechaNacimiento,
                        Sexo = e.Paciente.Sexo,
                        Direccion = e.Paciente.Direccion,
                        Telefono = e.Paciente.Telefono,
                        Correo = e.Paciente.Correo,
                        Estado = e.Paciente.Estado
                    }   
                })
                .ToListAsync();

            return Ok(expedientes);
        }

        // GET: api/Expedientes/5
        //[Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpedienteViewDTO>> GetExpediente(int id)
        {
            var expediente = await _context.Expedientes
        .Include(e => e.Paciente)
        .Where(e => e.IdExpediente == id)
        .Select(e => new ExpedienteViewDTO
        {
            IdExpediente = e.IdExpediente,
            Notas = e.Notas,
            Estado = e.Estado,
            Paciente = new PacienteViewDTO
            {
                IdPaciente = e.Paciente.IdPaciente,
                Nombres = e.Paciente.Nombres,
                Apellidos = e.Paciente.Apellidos,
                FechaNacimiento = e.Paciente.FechaNacimiento,
                Sexo = e.Paciente.Sexo,
                Direccion = e.Paciente.Direccion,
                Telefono = e.Paciente.Telefono,
                Correo = e.Paciente.Correo,
                Estado = e.Paciente.Estado
            }
        })
        .FirstOrDefaultAsync();

            if (expediente == null)
            {
                return NotFound();
            }

            return Ok(expediente);
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
