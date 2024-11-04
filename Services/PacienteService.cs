using FarmaciaApi.DTOs.Create;
using FarmaciaApi.DTOs.Update;
using FarmaciaApi.Models;
using FarmaciaApi.Repositories.Interfaces;
using FarmaciaApi.Services.Interfaces;

namespace FarmaciaApi.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task<IEnumerable<Paciente>> GetAllPacientesAsync()
        {
            return await _pacienteRepository.GetAllAsync();
        }

        public async Task<Paciente?> GetPacienteByIdAsync(int id)
        {
            return await _pacienteRepository.GetByIdAsync(id);
        }

        public async Task<Paciente> AddPacienteAsync(PacienteCreateDTO paciente)
        {
            var newPaciente = new Paciente
            {
                Nombres = paciente.Nombres,
                Apellidos = paciente.Apellidos,
                FechaNacimiento = paciente.FechaNacimiento,
                Sexo = paciente.Sexo,
                Direccion = paciente.Direccion,
                Telefono = paciente.Telefono,
                Correo = paciente.Correo,
                Estado = paciente.Estado,
                IdUsuarioCreacion = paciente.IdUsuarioCreacion,
                FechaCreacion = paciente.FechaCreacion,
                IdUsuarioModificacion = paciente.IdUsuarioModificacion,
                FechaModificacion = paciente.FechaModificacion
            };

            return await _pacienteRepository.AddAsync(newPaciente);
        }

        public async Task UpdatePacienteAsync(int id, PacienteUpdateDTO paciente)
        {
            var existingPaciente = await _pacienteRepository.GetByIdAsync(id);
            if (existingPaciente != null)
            {
                existingPaciente.Nombres = paciente.Nombres;
                existingPaciente.Apellidos = paciente.Apellidos;
                existingPaciente.FechaNacimiento = paciente.FechaNacimiento;
                existingPaciente.Sexo = paciente.Sexo;
                existingPaciente.Direccion = paciente.Direccion;
                existingPaciente.Telefono = paciente.Telefono;
                existingPaciente.Correo = paciente.Correo;
                existingPaciente.Estado = paciente.Estado;
                existingPaciente.IdUsuarioModificacion = paciente.IdUsuarioModificacion;
                existingPaciente.FechaModificacion = paciente.FechaModificacion;

                await _pacienteRepository.UpdateAsync(existingPaciente);
            }
        }

        public async Task DeletePacienteAsync(int id)
        {
            var paciente = await _pacienteRepository.GetByIdAsync(id);
            if (paciente != null)
            {
                await _pacienteRepository.DeleteAsync(paciente);
            }
        }
    }
}
