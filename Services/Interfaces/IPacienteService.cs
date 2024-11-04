using FarmaciaApi.DTOs.Create;
using FarmaciaApi.DTOs.Update;
using FarmaciaApi.Models;

namespace FarmaciaApi.Services.Interfaces
{
    public interface IPacienteService
    {
        Task<IEnumerable<Paciente>> GetAllPacientesAsync();
        Task<Paciente?> GetPacienteByIdAsync(int id);
        Task<Paciente>AddPacienteAsync(PacienteCreateDTO dto);
        Task UpdatePacienteAsync(int id, PacienteUpdateDTO dto);
        Task DeletePacienteAsync(int id);
    }
}
