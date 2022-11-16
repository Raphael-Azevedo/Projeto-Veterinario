using System.Collections.Generic;
using System.Threading.Tasks;
using DogAPI.DTO.CachorroDTOs;
using DogAPI.Models;

namespace DogAPI.Services.Interfaces
{
    public interface ICachorroServices
    {
        Task<IEnumerable<Cachorro>> Get(int skip, int take);
        Task<IEnumerable<Cachorro>> GetByCpf(string cpf, int skip, int take);
        Task<Cachorro> GetById(int id);
        Task Create(CreateCachorroDTO veterinarioDTO);
        Task Update(int id, UpdateCachorroDTO veterinarioDTO);
        Task Delete(int id);
    }
}