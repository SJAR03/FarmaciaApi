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
using Humanizer;
using FarmaciaApi.DTOs.Update;
using FarmaciaApi.DTOs.Create;

namespace FarmaciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedidasController : ControllerBase
    {
        private readonly IMedidasService _service;

        public MedidasController(IMedidasService service)
        {
            _service = service;
        }

        // GET: api/Medidas
        /// <summary>
        /// Return the info of all measures
        /// </summary>
        /// <remarks>Remeber authorize</remarks>
        /// <response code="200">Measures info retrieved</response>
        /// <response code="401">Not authorized</response>
        /// <response code="500">Upsi, internal error</response>
        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medidas>>> GetMedidas()
        {
            var medidas = await _service.GetMedidas();

            if (medidas == null || !medidas.Any())
            {
                return NotFound("No existen medidas.");
            }

            return Ok(medidas);
        }

        // GET: api/Medidas/5
        /// <summary>
        /// Return the info of specific measure by id
        /// </summary>
        /// <remarks>Remeber authorize</remarks>
        /// <response code="200">Measure info retrieved</response>
        /// <response code="401">Not authorized</response>
        /// <response code="500">Upsi, internal error</response>
        //[Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Medidas>> GetMedida(int id)
        {
            var medidas = await _service.GetByIdAsync(id);

            if (medidas == null)
            {
                return NotFound("No existe la medida con ese id");
            }

            return Ok(medidas);
        }

        // PUT: api/Medidas/5
        /// <summary>
        /// Update the info of specific measure by id
        /// </summary>
        /// <remarks>Remeber authorize</remarks>
        /// <response code="200">Measure info updated</response>
        /// <response code="401">Not authorized</response>
        /// <response code="500">Upsi, internal error</response>
        //[Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedidas(int id, MedidasUpdateDTO dto)
        {
            if (id <= 0)
            {
                return BadRequest("No fue posible actualizar la medida");
            }

            await _service.UpdateMedidas(id, dto);
            return Ok("Dosificacion actualizada correctamente");
        }

        // POST: api/Medidas
        /// <summary>
        /// Create new measure object
        /// </summary>
        /// <remarks>Remeber authorize</remarks>
        /// <response code="200">Measure created successfully</response>
        /// <response code="401">Not authorized</response>
        /// <response code="500">Upsi, internal error</response>
        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<Medidas>> PostMedidas(MedidasCreateDTO dto)
        {
            var createdMedidas = await _service.CreateMedida(dto);
            return CreatedAtAction(nameof(GetMedida), new { id = createdMedidas.IdMedidas }, createdMedidas);
        }

        // DELETE: api/Medidas/5
        /// <summary>
        /// Delete dosage object by id
        /// </summary>
        /// <remarks>Remeber authorize</remarks>
        /// <response code="200">Dosage deleted successfully</response>
        /// <response code="401">Not authorized</response>
        /// <response code="500">Upsi, internal error</response>
        //[Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedidas(int id)
        {
            await _service.DeleteMedidas(id);
            return Ok("Medida eliminada correctamente");
        }
    }
}
