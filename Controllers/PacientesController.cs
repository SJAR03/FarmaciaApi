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
using FarmaciaApi.DTOs.Create;
using FarmaciaApi.DTOs.Update;

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

            if (pacientes == null || !pacientes.Any())
            {
                return NotFound("No existen pacientes");
            }

            return Ok(pacientes);
        }

        //[Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> GetPaciente(int id)
        {
            var paciente = await _pacienteService.GetPacienteByIdAsync(id);

            if (paciente == null)
            {
                return NotFound("No existe paciente con ese id");
            }

            return Ok(paciente);
        }

        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<Paciente>> PostPaciente(PacienteCreateDTO dto)
        {
            var createdPaciente = await _pacienteService.AddPacienteAsync(dto);
            return CreatedAtAction(nameof(GetPaciente), new { id = createdPaciente.IdPaciente }, createdPaciente);
        }

        //[Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaciente(int id, PacienteUpdateDTO dto)
        {
            if (id <= 0)
            {
                return BadRequest("No fue posible actualizar el paciente");
            }

            await _pacienteService.UpdatePacienteAsync(id, dto);
            return Ok("Paciente actualizado correctamente");
        }

        //[Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaciente(int id)
        {
            await _pacienteService.DeletePacienteAsync(id);
            return Ok("Paciente eliminado correctamente");
        }
    }
}
