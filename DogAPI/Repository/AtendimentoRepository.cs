using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogAPI.Context;
using DogAPI.Models;
using DogAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DogAPI.Repository
{
    public class AtendimentoRepository : Repository<Atendimento>, IAtendimentoRepository
    {
        public AtendimentoRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task BoleanDelete(int id)
        {
            var atendimento = await GetById(atendimento => atendimento.AtendimentoId == id);

            atendimento.Status = false;
        }
        public async Task<IEnumerable<Atendimento>> GetAll(int skip = 0, int take = 10)
        {
            skip = skip * take;
            return await _context.Set<Atendimento>()
                     .Where(p => p.Status == true)
                     .Include(c => c.Pet)
                     .Include(c => c.veterinario)
                     .Include(c => c.Pet.Tutor)
                     .Skip(skip)
                     .Take(take)
                     .OrderByDescending(c => c.DataDeAtendimento)
                     .AsNoTracking()
                     .ToListAsync();
        }
        public async Task<IEnumerable<Atendimento>> GetByCPF(string cpf, int skip = 0, int take = 10)
        {
            skip = skip * take;
            return await _context.Set<Atendimento>()
                     .Where(cliente => cliente.Pet.Tutor.CPF == cpf && cliente.Status == true)
                     .Include(c => c.Pet)
                     .Include(c => c.veterinario)
                     .Include(c => c.Pet.Tutor)
                     .Skip(skip)
                     .Take(take)
                     .OrderBy(c => c.DataDeAtendimento)
                     .AsNoTracking()
                     .ToListAsync();
        }
        public async Task<IEnumerable<Atendimento>> GetByUser(string user, int skip = 0, int take = 10)
        {
            skip = skip * take;
            return await _context.Set<Atendimento>()
                     .Where(cliente => cliente.Pet.Tutor.Email == user && cliente.Status == true)
                     .Include(c => c.Pet)
                     .Include(c => c.veterinario)
                     .Include(c => c.Pet.Tutor)
                     .Skip(skip)
                     .Take(take)
                     .OrderBy(c => c.DataDeAtendimento)
                     .AsNoTracking()
                     .ToListAsync();
        }
        public async Task<IEnumerable<Atendimento>> GetByPetName(string petName, int skip, int take)
        {
            skip = skip * take;
            return await _context.Set<Atendimento>()
                     .Where(cliente => cliente.Pet.Nome == petName && cliente.Status == true)
                     .Include(c => c.Pet)
                     .Include(c => c.veterinario)
                     .Include(c => c.Pet.Tutor)
                     .Skip(skip)
                     .Take(take)
                     .OrderBy(c => c.DataDeAtendimento)
                     .AsNoTracking()
                     .ToListAsync();
        }
        public async Task<Atendimento> GetByIdAtendimento(int id)
        {
            return await _context.Set<Atendimento>()
                     .Where(cliente => cliente.Status == true)
                     .Include(c => c.Pet)
                     .Include(c => c.veterinario)
                     .Include(c => c.Pet.Tutor)
                     .FirstOrDefaultAsync(Atendimento => Atendimento.AtendimentoId == id);
        }
        public async Task<Raca> GetByIdRaca(int id)
        {
            return await _context.Set<Raca>().FirstOrDefaultAsync(raca => raca.id == id);
        }
    }
}