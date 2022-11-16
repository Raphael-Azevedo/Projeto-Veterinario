using System.Collections.Generic;
using System.Threading.Tasks;
using DogAPI.DTO.ClienteDTOs;
using DogAPI.Models;

namespace DogAPI.Services.Interfaces
{
    public interface IClienteServices
    {
        Task<IEnumerable<Cliente>> Get(int skip, int take);
        Task<Cliente> GetById(int id);
        Task<Cliente> GetByCPF(string crmv);
        Task Create(CreateClienteDTO veterinarioDTO);
        Task Update(int id, UpdateClienteDTO veterinarioDTO);
        Task Delete(int id);
    }
}