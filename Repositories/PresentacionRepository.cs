using FarmaciaApi.DTOs.Views;
using FarmaciaApi.Models;
using FarmaciaApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaApi.Repositories
{
    public class PresentacionRepository : IPresentacionRepository
    {

        private readonly FarmaciaDbContext _context;

        public PresentacionRepository(FarmaciaDbContext context)
        {
            _context = context;
        }

        public async Task<Presentacion> CreatePresentacion(Presentacion presentacion)
        {
            _context.Presentaciones.Add(presentacion);
            await _context.SaveChangesAsync();
            return presentacion;
        }

        public async Task DeletePresentacion(Presentacion presentacion)
        {
            _context.Presentaciones.Remove(presentacion);
            await _context.SaveChangesAsync();
        }

        public async Task<Presentacion?> GetByIdAsync(int id)
        {
            return await _context.Presentaciones.FindAsync(id);
        }

        public async Task<PresentacionViewDTO?> GetByIdViewAsync(int id)
        {
            var presentaciones = await _context.Presentaciones
                .Include(e => e.Medidas)
                .Include(e => e.Dosificacion)
                .Where(e => e.IdPresentacion == id)
                .Select(e => new PresentacionViewDTO
                {
                    IdPresentacion = e.IdPresentacion,
                    Nombre = e.Nombre,
                    Descripcion = e.Descripcion,
                    Estado = e.Estado,
                    Medidas = new MedidasViewDTO
                    {
                        IdMedidas = e.Medidas.IdMedidas,
                        Nombre = e.Medidas.Nombre,
                        Estado = e.Medidas.Estado
                    },
                    Dosificacion = new DosificacionViewDTO
                    {
                        IdDosificacion = e.Dosificacion.IdDosificacion,
                        Nombre = e.Dosificacion.Nombre,
                        Estado = e.Dosificacion.Estado
                    }
                })
                .FirstOrDefaultAsync();

            return presentaciones;
        }

        public async Task<IEnumerable<Presentacion>> GetPresentaciones()
        {
            return await _context.Presentaciones.ToListAsync();
        }

        public async Task<IEnumerable<PresentacionViewDTO>> GetPresentacionesView()
        {
            var presentaciones = await _context.Presentaciones
                .Include(e => e.Medidas)
                .Include(e => e.Dosificacion)
                .Select(e => new PresentacionViewDTO
                {
                    IdPresentacion = e.IdPresentacion,
                    Nombre = e.Nombre,
                    Descripcion = e.Descripcion,
                    Estado = e.Estado,
                    Medidas = new MedidasViewDTO
                    {
                        IdMedidas = e.Medidas.IdMedidas,
                        Nombre = e.Medidas.Nombre,
                        Estado = e.Medidas.Estado
                    },
                    Dosificacion = new DosificacionViewDTO
                    {
                        IdDosificacion = e.Dosificacion.IdDosificacion,
                        Nombre = e.Dosificacion.Nombre,
                        Estado = e.Dosificacion.Estado
                    }
                })
                .ToListAsync();

            return presentaciones;

        }

        public Task UpdatePresentacion(Presentacion presentacion)
        {
            _context.Entry(presentacion).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
    }
}
