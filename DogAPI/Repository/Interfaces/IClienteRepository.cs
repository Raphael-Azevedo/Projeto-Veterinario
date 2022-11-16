using System.Linq;
using System.Threading.Tasks;
using DogAPI.Models;

namespace DogAPI.Repository.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task BoleanDelete(int id);
        IQueryable<Cliente> GetAll(int skip = 0, int take = 10);
        Task<Cliente> GetByCPF(string CPF);
    }
}