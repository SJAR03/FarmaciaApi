using FarmaciaApi.Models;
using FarmaciaApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaApi.Repositories
{
    public class DosificacionRepository : IDosificacionRepository
    {

        private readonly FarmaciaDbContext _context;

        public DosificacionRepository(FarmaciaDbContext context)
        {
            _context = context;
        }

        public async Task<Dosificacion> CreateDosificacion(Dosificacion dosificacion)
        {
            _context.Dosificaciones.Add(dosificacion);
            await _context.SaveChangesAsync();
            return dosificacion;
        }

        public async Task DeleteDosificacion(Dosificacion dosificacion)
        {
            _context.Dosificaciones.Remove(dosificacion);
            await _context.SaveChangesAsync();
        }

        public async Task<Dosificacion?> GetByIdAsync(int id)
        {
            return await _context.Dosificaciones.FindAsync(id);
        }

        public async Task<IEnumerable<Dosificacion>> GetDosificaciones()
        {
            return await _context.Dosificaciones.ToListAsync();
        }

        public async Task UpdateDosificacion(Dosificacion dosificacion)
        {
            _context.Entry(dosificacion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
