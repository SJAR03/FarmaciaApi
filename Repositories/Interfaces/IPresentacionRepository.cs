using FarmaciaApi.Models;

namespace FarmaciaApi.Repositories.Interfaces
{
    public interface IPresentacionRepository
    {
        Task<IEnumerable<Presentacion>> GetPresentaciones();
        Task<Presentacion?> GetByIdAsync(int id);
        Task<Presentacion> CreatePresentacion(Presentacion presentacion);
        Task UpdatePresentacion(Presentacion presentacion);
        Task DeletePresentacion(Presentacion presentacion);
    }
}
