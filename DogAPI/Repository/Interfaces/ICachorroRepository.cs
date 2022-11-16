using System.Collections.Generic;
using System.Threading.Tasks;
using DogAPI.Models;

namespace DogAPI.Repository.Interfaces
{
    public interface ICachorroRepository : IRepository<Cachorro>
    {
        Task BoleanDelete(int id);
        Task<IEnumerable<Cachorro>> GetAll(int skip = 0, int take = 10);
        Task<IEnumerable<Cachorro>> GetByCPF(string cpf, int skip = 0, int take = 10);
        Task<Cachorro> GetByIdDog(int id);
        Task<Raca> GetByIdRaca(int id);
    }
}