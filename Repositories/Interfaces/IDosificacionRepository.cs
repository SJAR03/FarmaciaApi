using FarmaciaApi.Models;

namespace FarmaciaApi.Repositories.Interfaces
{
    public interface IDosificacionRepository
    {
        Task<IEnumerable<Dosificacion>> GetDosificaciones();
        Task<Dosificacion?> GetByIdAsync(int id);
        Task<Dosificacion> CreateDosificacion(Dosificacion dosificacion);
        Task UpdateDosificacion(Dosificacion dosificacion);
        Task DeleteDosificacion(Dosificacion dosificacion);
    }
}
