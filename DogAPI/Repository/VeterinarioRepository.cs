using System.Linq;
using System.Threading.Tasks;
using DogAPI.Context;
using DogAPI.Models;
using DogAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DogAPI.Repository
{
    public class VeterinarioRepository : Repository<Veterinario>, IVeterinarioRepository
    {
        public VeterinarioRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task BoleanDelete(int id)
        {
            var veterinario = await GetById(veterinario => veterinario.VeterinarioId == id);

            veterinario.Status = false;
        }
        public IQueryable<Veterinario> GetAll(int skip = 0, int take = 10)
        {
            skip = skip * take;
            return _context.Set<Veterinario>()
                     .Where(p => p.Status == true)
                     .Skip(skip)
                     .Take(take)
                     .OrderBy(c => c.VeterinarioId)
                     .AsNoTracking();
                     
        }
        public async Task<Veterinario> GetByCRMV(string crmv)
        {
            return await _context.Veterinarios.FirstAsync(vet => vet.CRMV.Contains(crmv) && vet.Status == true);
        }
    }
}