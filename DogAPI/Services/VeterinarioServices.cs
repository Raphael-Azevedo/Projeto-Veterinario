using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DogAPI.DTO.VeterinarioDTOs;
using DogAPI.Models;
using DogAPI.Repository.Interfaces;
using DogAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DogAPI.Services
{
    public class VeterinarioServices : IVeterinarioServices
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public VeterinarioServices(IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Veterinario>> Get(int skip, int take)
        {
            var veterinarios = await _uof.VeterinarioRepository
                                    .GetAll(skip: skip, take: take)
                                    .ToListAsync();
            return veterinarios;
        }
        public async Task<Veterinario> GetById(int id)
        {
            var veterinario = await _uof.VeterinarioRepository.GetById(vet => vet.VeterinarioId == id && vet.Status == true);
            return veterinario;
        }
        public async Task<Veterinario> GetByCRMV(string crmv)
        {
            var veterinario = await _uof.VeterinarioRepository.GetByCRMV(crmv);
            return veterinario;
        }

        public async Task Create(CreateVeterinarioDTO veterinarioDTO)
        {
            var veterinario = _mapper.Map<Veterinario>(veterinarioDTO);
            await _uof.VeterinarioRepository.Add(veterinario);
            await _uof.Commit();
        }
        public async Task Update(int id, UpdateVeterinarioDTO veterinarioDTO)
        {
            var veterinario = _mapper.Map<Veterinario>(veterinarioDTO);
            _uof.VeterinarioRepository.Update(veterinario);
            await _uof.Commit();
        }
        public async Task Delete(int id)
        {
            await _uof.VeterinarioRepository.BoleanDelete(id);
            await _uof.Commit();
        }
    }
}