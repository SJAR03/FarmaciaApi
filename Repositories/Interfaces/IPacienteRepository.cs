using FarmaciaApi.Models;
namespace FarmaciaApi.Repositories.Interfaces
{
    public interface IPacienteRepository
    {
        Task<IEnumerable<Paciente>> GetAllAsync();
        Task<Paciente> GetByIdAsync(int id);
        Task AddAsync(Paciente entity);
        Task UpdateAsync(Paciente entity);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
