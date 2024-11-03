using FarmaciaApi.Models;
using FarmaciaApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaApi.Repositories
{
    public class MedidasRepository : IMedidasRepository
    {

        private readonly FarmaciaDbContext _context;

        public MedidasRepository(FarmaciaDbContext context)
        {
            _context = context;
        }

        public async Task<Medidas> CreateMedida(Medidas medidas)
        {
            _context.Medidas.Add(medidas);
            await _context.SaveChangesAsync();
            return medidas;
        }

        public async Task DeleteMedidas(Medidas medidas)
        {
            _context.Medidas.Remove(medidas);
            await _context.SaveChangesAsync();
        }

        public async Task<Medidas?> GetByIdAsync(int id)
        {
            return await _context.Medidas.FindAsync(id);
        }

        public async Task<IEnumerable<Medidas>> GetMedidas()
        {
            return await _context.Medidas.ToListAsync();
        }

        public async Task UpdateMedidas(Medidas medidas)
        {
            _context.Entry(medidas).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
