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
using FarmaciaApi.DTOs.Update;
using FarmaciaApi.DTOs.Create;
using FarmaciaApi.DTOs.Views;

namespace FarmaciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresentacionesController : ControllerBase
    {
        private readonly IPresentacionService _service;

        public PresentacionesController(IPresentacionService service)
        {
            _service = service;
        }

        // GET: api/Presentaciones
        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Presentacion>>> GetPresentaciones()
        {
            var presentacion = await _service.GetPresentaciones();

            if (presentacion == null || !presentacion.Any())
            {
                return NotFound("No existen presentaciones");
            }

            return Ok(presentacion);
        }

        [HttpGet("View")]
        public async Task<ActionResult<IEnumerable<PresentacionViewDTO>>> GetPresentacionesView()
        {
            var presentacion = await _service.GetPresentacionesView();

            if (presentacion == null || !presentacion.Any())
            {
                return NotFound("No existen presentaciones");
            }

            return Ok(presentacion);
        }

        // GET: api/Presentaciones/5
        //[Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Presentacion>> GetPresentacion(int id)
        {
            var presentacion = await _service.GetByIdAsync(id);

            if (presentacion == null)
            {
                return NotFound("No existe la presentación con ese id");
            }

            return Ok(presentacion);
        }

        // GET: api/Presentaciones/5
        //[Authorize]
        [HttpGet("View/{id}")]
        public async Task<ActionResult<PresentacionViewDTO>> GetPresentacionView(int id)
        {
            var presentacion = await _service.GetByIdViewAsync(id);

            if (presentacion == null)
            {
                return NotFound("No existe la presentación con ese id");
            }

            return Ok(presentacion);
        }

        // PUT: api/Presentaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPresentacion(int id, PresentacionUpdateDTO dto)
        {
            if (id <= 0)
            {
                return BadRequest("El id de la presentación debe ser mayor a 0");
            }

            await _service.UpdatePresentacion(id, dto);
            return Ok("Presentación actualizada correctamente");
        }

        // POST: api/Presentaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<Presentacion>> PostPresentacion(PresentacionCreateDTO dto)
        {
            var createdPresentacion = await _service.CreatePresentacion(dto);
            return CreatedAtAction(nameof(GetPresentacion), new { id = createdPresentacion.IdPresentacion }, createdPresentacion);
        }

        // DELETE: api/Presentaciones/5
        //[Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePresentacion(int id)
        {
            await _service.DeletePresentacion(id);
            return Ok("Presentación eliminada correctamente");
        }
    }
}
