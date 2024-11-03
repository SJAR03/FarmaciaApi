using FarmaciaApi.DTOs.Create;
using FarmaciaApi.DTOs.Update;
using FarmaciaApi.Models;
using FarmaciaApi.Repositories.Interfaces;
using FarmaciaApi.Services.Interfaces;

namespace FarmaciaApi.Services
{
    public class MedidasService : IMedidasService
    {
        private readonly IMedidasRepository _repository;

        public MedidasService(IMedidasRepository repository)
        {
            _repository = repository;
        }

        public async Task<Medidas> CreateMedida(MedidasCreateDTO medidas)
        {
            var newMedida = new Medidas
            {
                Nombre = medidas.Nombre,
                Estado = medidas.Estado,
                IdUsuarioCreacion = medidas.IdUsuarioCreacion,
                FechaCreacion = medidas.FechaCreacion,
                IdUsuarioModificacion = medidas.IdUsuarioModificacion,
                FechaModificacion = medidas.FechaModificacion
            };

            return await _repository.CreateMedida(newMedida);
        }

        public async Task DeleteMedidas(int id)
        {
            var medida = await _repository.GetByIdAsync(id);
            if (medida != null)
            {
                await _repository.DeleteMedidas(medida);
            }
        }

        public async Task<Medidas?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Medidas>> GetMedidas()
        {
            return await _repository.GetMedidas();
        }

        public async Task UpdateMedidas(int id, MedidasUpdateDTO medidas)
        {
            var existingMedida = await _repository.GetByIdAsync(id);
            if (existingMedida != null)
            {
                existingMedida.Nombre = medidas.Nombre;
                existingMedida.Estado = medidas.Estado;
                existingMedida.IdUsuarioModificacion = medidas.IdUsuarioModificacion;
                existingMedida.FechaModificacion = medidas.FechaModificacion;

                await _repository.UpdateMedidas(existingMedida);
            }
        }
    }
}
