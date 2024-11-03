using FarmaciaApi.Models;

namespace FarmaciaApi.Repositories.Interfaces
{
    public interface IMedidasRepository
    {
        Task<IEnumerable<Medidas>> GetMedidas();
        Task<Medidas?> GetByIdAsync(int id);
        Task<Medidas> CreateMedida(Medidas medidas);
        Task UpdateMedidas(Medidas medidas);
        Task DeleteMedidas(Medidas medidas);
    }
}
