using FarmaciaApi.Models;

namespace FarmaciaApi.Services.Interfaces
{
    public interface IPacienteService
    {
        Task<IEnumerable<Paciente>> GetAllPacientesAsync();
        Task<Paciente> GetPacienteByIdAsync(int id);
        Task AddPacienteAsync(Paciente paciente);
        Task UpdatePacienteAsync(int id, Paciente paciente);
        Task DeletePacienteAsync(int id);
        Task<bool> PacienteExistsAsync(int id);
    }
}
