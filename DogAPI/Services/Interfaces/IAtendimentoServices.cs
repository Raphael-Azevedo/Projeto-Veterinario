using System.Collections.Generic;
using System.Threading.Tasks;
using DogAPI.DTO.AtendimentoDTOs;
using DogAPI.Models;

namespace DogAPI.Services.Interfaces
{
    public interface IAtendimentoServices
    {
        Task<IEnumerable<Atendimento>> Get(int skip, int take);
        Task<IEnumerable<Atendimento>> GetByCpf(string cpf, int skip, int take);
        Task<IEnumerable<Atendimento>> GetByPetName(string petName, int skip, int take);
        Task<IEnumerable<Atendimento>> GetByUser(string user, int skip, int take);
        Task<Atendimento> GetById(int id);
        Task Create(CreateAtendimentoDTO veterinarioDTO);
        Task Update(int id, UpdateAtendimentoDTO veterinarioDTO);
        Task Delete(int id);
    }
}