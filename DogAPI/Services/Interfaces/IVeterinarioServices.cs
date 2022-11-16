using System.Collections.Generic;
using System.Threading.Tasks;
using DogAPI.DTO.VeterinarioDTOs;
using DogAPI.Models;

namespace DogAPI.Services.Interfaces
{
    public interface IVeterinarioServices
    {
        Task<IEnumerable<Veterinario>> Get(int skip, int take);
        Task<Veterinario> GetById(int id);
        Task<Veterinario> GetByCRMV(string crmv);
        Task Create(CreateVeterinarioDTO veterinarioDTO);
        Task Update(int id, UpdateVeterinarioDTO veterinarioDTO);
        Task Delete(int id);
    }
}