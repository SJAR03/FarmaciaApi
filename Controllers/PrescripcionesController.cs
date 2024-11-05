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
        public async Task<ActionResult<IEnumerable<PrescripcionViewDTO>>> GetPrescripciones()
        {
            var prescripcion = await _context.Prescripciones
                .Include(e => e.Expediente)
                .Select(e => new PrescripcionViewDTO
                {
                    IdPrescripcion = e.IdPrescripcion,
                    Fecha = e.Fecha,
                    Dosis = e.Dosis,
                    Duracion = e.Duracion,
                    Instrucciones = e.Instrucciones,
                    Estado = e.Estado,
                    Expediente = new ExpedienteViewDTO
                    {
                        IdExpediente = e.Expediente.IdExpediente,
                        Notas = e.Expediente.Notas,
                        Estado = e.Expediente.Estado,
                        Paciente = new PacienteViewDTO
                        {
                            IdPaciente = e.Expediente.Paciente.IdPaciente,
                            Nombres = e.Expediente.Paciente.Nombres,
                            Apellidos = e.Expediente.Paciente.Apellidos,
                            FechaNacimiento = e.Expediente.Paciente.FechaNacimiento,
                            Sexo = e.Expediente.Paciente.Sexo,
                            Direccion = e.Expediente.Paciente.Direccion,
                            Telefono = e.Expediente.Paciente.Telefono,
                            Correo = e.Expediente.Paciente.Correo,
                            Estado = e.Expediente.Paciente.Estado
                        }
                    }
                })
                .ToListAsync();

            return Ok(prescripcion);
        }

        // GET: api/Prescripciones/5
        //[Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Prescripcion>> GetPrescripcion(int id)
        {
            var prescripcion = await _context.Prescripciones
                .Include(e => e.Expediente)
                .Where(e => e.IdPrescripcion == id)
                .Select(e => new PrescripcionViewDTO
                {
                    IdPrescripcion = e.IdPrescripcion,
                    Fecha = e.Fecha,
                    Dosis = e.Dosis,
                    Duracion = e.Duracion,
                    Instrucciones = e.Instrucciones,
                    Estado = e.Estado,
                    Expediente = new ExpedienteViewDTO
                    {
                        IdExpediente = e.Expediente.IdExpediente,
                        Notas = e.Expediente.Notas,
                        Estado = e.Expediente.Estado,
                        Paciente = new PacienteViewDTO
                        {
                            IdPaciente = e.Expediente.Paciente.IdPaciente,
                            Nombres = e.Expediente.Paciente.Nombres,
                            Apellidos = e.Expediente.Paciente.Apellidos,
                            FechaNacimiento = e.Expediente.Paciente.FechaNacimiento,
                            Sexo = e.Expediente.Paciente.Sexo,
                            Direccion = e.Expediente.Paciente.Direccion,
                            Telefono = e.Expediente.Paciente.Telefono,
                            Correo = e.Expediente.Paciente.Correo,
                            Estado = e.Expediente.Paciente.Estado
                        }
                    }
                })
                .FirstOrDefaultAsync();

            if (prescripcion == null)
            {
                return NotFound();
            }

            return Ok(prescripcion);
        }

        // PUT: api/Prescripciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrescripcion(int id, PrescripcionUpdateDTO prescripcion)
        {
            var existingPrescripcion = await _context.Prescripciones.FindAsync(id);

            if (existingPrescripcion == null)
            {
                return NotFound();
            }

            existingPrescripcion.Fecha = prescripcion.Fecha;
            existingPrescripcion.Dosis = prescripcion.Dosis;
            existingPrescripcion.Duracion = prescripcion.Duracion;
            existingPrescripcion.Instrucciones = prescripcion.Instrucciones;
            existingPrescripcion.Estado = prescripcion.Estado;
            existingPrescripcion.IdExpediente = prescripcion.IdExpediente;
            existingPrescripcion.IdUsuarioModificacion = prescripcion.IdUsuarioModificacion;
            existingPrescripcion.FechaModificacion = prescripcion.FechaModificacion;

            _context.Entry(existingPrescripcion).State = EntityState.Modified;

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

            return Ok(existingPrescripcion);
        }

        // POST: api/Prescripciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<Prescripcion>> PostPrescripcion(PrescripcionCreateDTO prescripcion)
        {
            var prescripcionObj = new Prescripcion
            {
                Fecha = prescripcion.Fecha,
                Dosis = prescripcion.Dosis,
                Duracion = prescripcion.Duracion,
                Instrucciones = prescripcion.Instrucciones,
                Estado = prescripcion.Estado,
                IdExpediente = prescripcion.IdExpediente,
                IdUsuarioCreacion = prescripcion.IdUsuarioCreacion,
                FechaCreacion = prescripcion.FechaCreacion,
                IdUsuarioModificacion = prescripcion.IdUsuarioModificacion,
                FechaModificacion = prescripcion.FechaModificacion
            };

            _context.Prescripciones.Add(prescripcionObj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrescripcion", new { id = prescripcionObj.IdPrescripcion }, prescripcionObj);
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

            return Ok();
        }

        private bool PrescripcionExists(int id)
        {
            return _context.Prescripciones.Any(e => e.IdPrescripcion == id);
        }
    }
}
