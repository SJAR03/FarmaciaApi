using FarmaciaApi.DTOs.Create;
using FarmaciaApi.DTOs.Update;
using FarmaciaApi.Models;

namespace FarmaciaApi.Services.Interfaces
{
    public interface IDosificacionService
    {
        Task<IEnumerable<Dosificacion>> GetDosificaciones();
        Task<Dosificacion?> GetByIdAsync(int id);
        Task<Dosificacion> CreateDosificacion(DosificacionCreateDTO dto);
        Task UpdateDosificacion(int id, DosificacionUpdateDTO dto);
        Task DeleteDosificacion(int id);
    }
}
