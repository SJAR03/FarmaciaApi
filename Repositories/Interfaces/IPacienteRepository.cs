using FarmaciaApi.Models;
namespace FarmaciaApi.Repositories.Interfaces
{
    public interface IPacienteRepository
    {
        Task<IEnumerable<Paciente>> GetAllAsync();
        Task<Paciente?> GetByIdAsync(int id);
        Task <Paciente> AddAsync(Paciente entity);
        Task UpdateAsync(Paciente entity);
        Task DeleteAsync(Paciente entity);
    }
}
