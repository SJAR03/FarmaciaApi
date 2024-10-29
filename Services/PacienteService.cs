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

        public async Task<Paciente> GetPacienteByIdAsync(int id)
        {
            return await _pacienteRepository.GetByIdAsync(id);
        }

        public async Task AddPacienteAsync(Paciente paciente)
        {
            await _pacienteRepository.AddAsync(paciente);
        }

        public async Task UpdatePacienteAsync(int id, Paciente paciente)
        {
            if (id == paciente.IdPaciente)
            {
                await _pacienteRepository.UpdateAsync(paciente);
            }
        }

        public async Task DeletePacienteAsync(int id)
        {
            await _pacienteRepository.DeleteAsync(id);
        }

        public async Task<bool> PacienteExistsAsync(int id)
        {
            return await _pacienteRepository.ExistsAsync(id);
        }
    }
}
