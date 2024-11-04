using FarmaciaApi.Models;
using FarmaciaApi.Repositories.Interfaces;
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

        public async Task<IEnumerable<Presentacion>> GetPresentaciones()
        {
            return await _context.Presentaciones.ToListAsync();
        }

        public Task UpdatePresentacion(Presentacion presentacion)
        {
            _context.Entry(presentacion).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
    }
}
