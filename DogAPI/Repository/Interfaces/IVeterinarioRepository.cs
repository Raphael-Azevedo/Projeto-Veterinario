using System.Linq;
using System.Threading.Tasks;
using DogAPI.Models;

namespace DogAPI.Repository.Interfaces
{
    public interface IVeterinarioRepository : IRepository<Veterinario>
    {
        Task BoleanDelete(int id);
        IQueryable<Veterinario> GetAll(int skip = 0, int take = 10);
        Task<Veterinario> GetByCRMV(string crmv);

    }
}