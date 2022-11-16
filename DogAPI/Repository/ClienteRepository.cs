using System.Linq;
using System.Threading.Tasks;
using DogAPI.Context;
using DogAPI.Models;
using DogAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DogAPI.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task BoleanDelete(int id)
        {
            var cliente = await GetById(cliente => cliente.ClienteId == id);

            cliente.Status = false;
        }
        public IQueryable<Cliente> GetAll(int skip = 0, int take = 10)
        {
            skip = skip * take;
            return _context.Set<Cliente>()
                     .Where(p => p.Status == true)
                     .Skip(skip)
                     .Take(take)
                     .OrderBy(c => c.ClienteId)
                     .AsNoTracking();
        }
        public async Task<Cliente> GetByCPF(string cpf)
        {
            return await _context.Clientes.FirstAsync(cliente => cliente.CPF == cpf && cliente.Status == true);
        }
    }
}