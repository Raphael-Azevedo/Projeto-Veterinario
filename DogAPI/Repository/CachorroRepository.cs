using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogAPI.Context;
using DogAPI.Models;
using DogAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DogAPI.Repository
{
    public class CachorroRepository : Repository<Cachorro>, ICachorroRepository
    {
        public CachorroRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task BoleanDelete(int id)
        {
            var cachorro = await GetById(cachorro => cachorro.CachorroId == id);

            cachorro.Status = false;
        }
        public async Task<IEnumerable<Cachorro>> GetAll(int skip = 0, int take = 10)
        {
            skip = skip * take;
            return await _context.Set<Cachorro>()
                     .Where(p => p.Status == true)
                     .Include(c => c.Tutor)
                     .Include(r => r.Raca)
                     .Include(d => d.Raca.height)
                     .Include(d => d.Raca.weight)
                     .Skip(skip)
                     .Take(take)
                     .OrderBy(c => c.CachorroId)
                     .AsNoTracking()
                     .ToListAsync();
        }
        public async Task<IEnumerable<Cachorro>> GetByCPF(string cpf, int skip = 0, int take = 10)
        {
            skip = skip * take;
            return await _context.Set<Cachorro>()
                     .Where(cliente => cliente.Tutor.CPF == cpf && cliente.Status == true)
                     .Include(c => c.Tutor)
                     .Include(d => d.Raca.height)
                     .Include(d => d.Raca.weight)
                     .Include(r => r.Raca)
                     .Skip(skip)
                     .Take(take)
                     .OrderBy(c => c.CachorroId)
                     .AsNoTracking()
                     .ToListAsync();
        }
        public async Task<Cachorro> GetByIdDog(int id)
        {
            return await _context.Set<Cachorro>().Include(c => c.Tutor)
                                    .Include(r => r.Raca)
                                    .Include(d => d.Raca.height)
                                    .Include(d => d.Raca.weight)
                                    .FirstOrDefaultAsync(cachorro => cachorro.CachorroId == id);
        }
        public async Task<Raca> GetByIdRaca(int id)
        {
            return await _context.Set<Raca>().FirstOrDefaultAsync(raca => raca.id == id);
        }
    }
}
