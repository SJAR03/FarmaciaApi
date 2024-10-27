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
        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dosificacion>>> GetDosificaciones()
        {
            var dosificaciones = await _service.GetDosificaciones();
            return Ok(dosificaciones);
        }

        // GET: api/Dosificaciones/5
        //[Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Dosificacion>> GetDosificacion(int id)
        {
            var dosificacion = await _service.GetByIdAsync(id);

            if (dosificacion == null)
            {
                return NotFound();
            }

            return Ok(dosificacion);
        }

        // PUT: api/Dosificaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDosificacion(int id, DosificacionUpdateDTO dto)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            await _service.UpdateDosificacion(id, dto);
            return Ok("Dosificacion actualizada correctamente");
        }

        // POST: api/Dosificaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<Dosificacion>> PostDosificacion(DosificacionCreateDTO dto)
        {
            var createdDosificacion = await _service.CreateDosificacion(dto);
            return CreatedAtAction(nameof(GetDosificacion), new { id = createdDosificacion.IdDosificacion }, createdDosificacion);
        }

        // DELETE: api/Dosificaciones/5
        //[Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDosificacion(int id)
        {
            await _service.DeleteDosificacion(id);
            return Ok("Dosificacion eliminada correctamente");
        }
    }
}
