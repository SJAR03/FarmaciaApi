using FarmaciaApi.DTOs.Create;
using FarmaciaApi.DTOs.Update;
using FarmaciaApi.Models;

namespace FarmaciaApi.Services.Interfaces
{
    public interface IMedidasService
    {
        Task<IEnumerable<Medidas>> GetMedidas();
        Task<Medidas?> GetByIdAsync(int id);
        Task<Medidas> CreateMedida(MedidasCreateDTO dto);
        Task UpdateMedidas(int id, MedidasUpdateDTO dto);
        Task DeleteMedidas(int id);
    }
}
