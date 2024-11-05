using FarmaciaApi.DTOs.Create;
using FarmaciaApi.DTOs.Update;
using FarmaciaApi.DTOs.Views;
using FarmaciaApi.Models;
using FarmaciaApi.Repositories.Interfaces;
using FarmaciaApi.Services.Interfaces;

namespace FarmaciaApi.Services
{
    public class PresentacionService : IPresentacionService
    {

        private readonly IPresentacionRepository _repository;

        public PresentacionService(IPresentacionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Presentacion> CreatePresentacion(PresentacionCreateDTO dto)
        {
            var newPresentacion = new Presentacion
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Estado = dto.Estado,
                IdMedidas = dto.IdMedidas,
                IdDosificacion = dto.IdDosificacion,
                IdUsuarioCreacion = dto.IdUsuarioCreacion,
                FechaCreacion = dto.FechaCreacion,
                IdUsuarioModificacion = dto.IdUsuarioModificacion,
                FechaModificacion = dto.FechaModificacion
            };

            return await _repository.CreatePresentacion(newPresentacion);
        }

        public async Task DeletePresentacion(int id)
        {
            var presentacion = await _repository.GetByIdAsync(id);
            if (presentacion != null)
            {
                await _repository.DeletePresentacion(presentacion);
            }
        }

        public async Task<Presentacion?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<PresentacionViewDTO>> GetPresentaciones()
        {
            return await _repository.GetPresentaciones();
        }

        public async Task<PresentacionViewDTO?> GetByIdViewAsync(int id)
        {
            return await _repository.GetByIdViewAsync(id);
        }

        public async Task UpdatePresentacion(int id, PresentacionUpdateDTO dto)
        {
            var existingPresentacion = await _repository.GetByIdAsync(id);
            if (existingPresentacion != null)
            {
                existingPresentacion.Nombre = dto.Nombre;
                existingPresentacion.Descripcion = dto.Descripcion;
                existingPresentacion.Estado = dto.Estado;
                existingPresentacion.IdMedidas = dto.IdMedidas;
                existingPresentacion.IdDosificacion = dto.IdDosificacion;
                existingPresentacion.IdUsuarioModificacion = dto.IdUsuarioModificacion;
                existingPresentacion.FechaModificacion = dto.FechaModificacion;

                await _repository.UpdatePresentacion(existingPresentacion);
            }
        }
    }
}