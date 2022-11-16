using System.Collections.Generic;
using System.Threading.Tasks;
using DogAPI.Models;

namespace DogAPI.Repository.Interfaces
{
    public interface IAtendimentoRepository : IRepository<Atendimento>
    {
        Task BoleanDelete(int id);
        Task<IEnumerable<Atendimento>> GetAll(int skip = 0, int take = 10);
        Task<IEnumerable<Atendimento>> GetByCPF(string cpf, int skip = 0, int take = 10);
        Task<IEnumerable<Atendimento>> GetByUser(string user, int skip = 0, int take = 10);
        Task<IEnumerable<Atendimento>> GetByPetName(string petName, int skip, int take);
        Task<Atendimento> GetByIdAtendimento(int id);
    }
}