using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using DogAPI.DTO.CachorroDTOs;
using DogAPI.Models;
using DogAPI.Repository.Interfaces;
using DogAPI.Services.Interfaces;

namespace DogAPI.Services
{
    public class CachorroServices : ICachorroServices
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public CachorroServices(IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Cachorro>> Get(int skip, int take)
        {
            var cachorros = await _uof.CachorroRepository
                                    .GetAll(skip: skip, take: take);
            return cachorros;
        }
        public async Task<Cachorro> GetById(int id)
        {
            var cachorro = await _uof.CachorroRepository.GetByIdDog(id);
            return cachorro;
        }
        public async Task<IEnumerable<Cachorro>> GetByCpf(string cpf, int skip, int take)
        {
            var cachorros = await _uof.CachorroRepository.GetByCPF(cpf, skip: skip, take: take);
            return cachorros;
        }
        public async Task Create(CreateCachorroDTO cachorroDTO)
        {
            var raca = await GetCachorro(cachorroDTO);
            var tutor = await _uof.ClienteRepository.GetByCPF(cachorroDTO.TutorCpf);
            var cachorro = _mapper.Map<Cachorro>(cachorroDTO);
            cachorro.Raca = raca;
            cachorro.Tutor = tutor;
            await _uof.CachorroRepository.Add(cachorro);
            await _uof.Commit();
        }
        public async Task Update(int id, UpdateCachorroDTO cachorroDTO)
        {
            var cachorro = _mapper.Map<Cachorro>(cachorroDTO);
            _uof.CachorroRepository.Update(cachorro);
            await _uof.Commit();
        }
        public async Task Delete(int id)
        {
            await _uof.CachorroRepository.BoleanDelete(id);
            await _uof.Commit();
        }
        public async Task<Raca> GetCachorro(CreateCachorroDTO cachorroDTO)
        {
            string apiUrl = "https://api.thedogapi.com/v1/breeds/search?q=" + cachorroDTO.NomeRaca;

            using (var cliente = new HttpClient())
            {
                var breed = await cliente.GetStringAsync(apiUrl);

                var result = JsonSerializer.Deserialize<Raca[]>(breed);
                if (result != null)
                {
                    var raca = await _uof.CachorroRepository.GetByIdRaca(result[0].id);
                    if (raca == null)
                        return result[0];
                        
                    return raca;
                } 
                return result[0];
            }
        }
    }
}