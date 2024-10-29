using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarmaciaApi.Models;
using FarmaciaApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace FarmaciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacientesController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetPacientes()
        {
            var pacientes = await _pacienteService.GetAllPacientesAsync();
            return Ok(pacientes);
        }

        //[Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> GetPaciente(int id)
        {
            var paciente = await _pacienteService.GetPacienteByIdAsync(id);

            if (paciente == null)
            {
                return NotFound();
            }

            return Ok(paciente);
        }

        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<Paciente>> PostPaciente(Paciente paciente)
        {
            await _pacienteService.AddPacienteAsync(paciente);
            return CreatedAtAction(nameof(GetPaciente), new { id = paciente.IdPaciente }, paciente);
        }

        //[Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaciente(int id, Paciente paciente)
        {
            if (id != paciente.IdPaciente)
            {
                return BadRequest();
            }

            await _pacienteService.UpdatePacienteAsync(id, paciente);
            return NoContent();
        }

        //[Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaciente(int id)
        {
            var pacienteExists = await _pacienteService.PacienteExistsAsync(id);
            if (!pacienteExists)
            {
                return NotFound();
            }

            await _pacienteService.DeletePacienteAsync(id);
            return NoContent();
        }
    }
}
