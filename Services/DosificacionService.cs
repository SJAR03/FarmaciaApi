using FarmaciaApi.DTOs.Create;
using FarmaciaApi.DTOs.Update;
using FarmaciaApi.Models;
using FarmaciaApi.Repositories.Interfaces;
using FarmaciaApi.Services.Interfaces;

namespace FarmaciaApi.Services
{
    public class DosificacionService : IDosificacionService
    {

        private readonly IDosificacionRepository _repository;

        public DosificacionService(IDosificacionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Dosificacion> CreateDosificacion(DosificacionCreateDTO dto)
        {
            var newDosificacion = new Dosificacion
            {
                Nombre = dto.Nombre,
                Estado = dto.Estado,
                IdUsuarioCreacion = dto.IdUsuarioCreacion,
                FechaCreacion = dto.FechaCreacion,
                IdUsuarioModificacion = dto.IdUsuarioModificacion,
                FechaModificacion = dto.FechaModificacion
            };

            return await _repository.CreateDosificacion(newDosificacion);
        }

        public async Task DeleteDosificacion(int id)
        {
            var dosificacion = await _repository.GetByIdAsync(id);
            if (dosificacion != null)
            {
                await _repository.DeleteDosificacion(dosificacion);
            }
        }

        public async Task<Dosificacion?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Dosificacion>> GetDosificaciones()
        {
            return await _repository.GetDosificaciones();
        }

        public async Task UpdateDosificacion(int id, DosificacionUpdateDTO dto)
        {
            var existingDosificacion = await _repository.GetByIdAsync(id);
            if (existingDosificacion != null)
            {
                existingDosificacion.Nombre = dto.Nombre;
                existingDosificacion.Estado = dto.Estado;
                existingDosificacion.IdUsuarioModificacion = dto.IdUsuarioModificacion;
                existingDosificacion.FechaModificacion = dto.FechaModificacion;

                await _repository.UpdateDosificacion(existingDosificacion);
            }
        }
    }
}
