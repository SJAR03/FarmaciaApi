using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarmaciaApi.Models;
using Microsoft.AspNetCore.Authorization;
using FarmaciaApi.Services.Interfaces;
using FarmaciaApi.Services;
using FarmaciaApi.DTOs.Create;
using FarmaciaApi.DTOs.Update;

namespace FarmaciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DosificacionesController : ControllerBase
    {
        private readonly IDosificacionService _service;

        public DosificacionesController(IDosificacionService service)
        {
            _service = service;
        }

        // GET: api/Dosificaciones
        /// <summary>
        /// Return the info of all dosages
        /// </summary>
        /// <remarks>Remeber authorize</remarks>
        /// <response code="200">Dosages info retrieved</response>
        /// <response code="401">Not authorized</response>
        /// <response code="500">Upsi, internal error</response>
        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dosificacion>>> GetDosificaciones()
        {
            var dosificaciones = await _service.GetDosificaciones();

            if (dosificaciones == null || dosificaciones.Any())
            {
                return NotFound("No existen dosificaciones");
            }

            return Ok(dosificaciones);
        }

        // GET: api/Dosificaciones/5
        /// <summary>
        /// Return the info of specific dosage by id
        /// </summary>
        /// <remarks>Remeber authorize</remarks>
        /// <response code="200">Dosages info retrieved</response>
        /// <response code="401">Not authorized</response>
        /// <response code="500">Upsi, internal error</response>
        //[Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Dosificacion>> GetDosificacion(int id)
        {
            var dosificacion = await _service.GetByIdAsync(id);

            if (dosificacion == null)
            {
                return NotFound("No existe la dosificación con ese id");
            }

            return Ok(dosificacion);
        }

        // PUT: api/Dosificaciones/5
        /// <summary>
        /// Update the info of specific dosage by id
        /// </summary>
        /// <remarks>Remeber authorize</remarks>
        /// <response code="200">Dosage info updated</response>
        /// <response code="401">Not authorized</response>
        /// <response code="500">Upsi, internal error</response>
        //[Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDosificacion(int id, DosificacionUpdateDTO dto)
        {
            if (id <= 0)
            {
                return BadRequest("No fue posible actualizar la dosificación");
            }

            await _service.UpdateDosificacion(id, dto);
            return Ok("Dosificacion actualizada correctamente");
        }

        // POST: api/Dosificaciones
        /// <summary>
        /// Create new dosage object
        /// </summary>
        /// <remarks>Remeber authorize</remarks>
        /// <response code="200">Dosage created successfully</response>
        /// <response code="401">Not authorized</response>
        /// <response code="500">Upsi, internal error</response>
        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<Dosificacion>> PostDosificacion(DosificacionCreateDTO dto)
        {
            var createdDosificacion = await _service.CreateDosificacion(dto);
            return CreatedAtAction(nameof(GetDosificacion), new { id = createdDosificacion.IdDosificacion }, createdDosificacion);
        }

        // DELETE: api/Dosificaciones/5
        /// <summary>
        /// Delete dosage object by id
        /// </summary>
        /// <remarks>Remeber authorize</remarks>
        /// <response code="200">Dosage deleted successfully</response>
        /// <response code="401">Not authorized</response>
        /// <response code="500">Upsi, internal error</response>
        //[Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDosificacion(int id)
        {
            await _service.DeleteDosificacion(id);
            return Ok("Dosificacion eliminada correctamente");
        }
    }
}
