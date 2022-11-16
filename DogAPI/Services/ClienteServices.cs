using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DogAPI.DTO.ClienteDTOs;
using DogAPI.Models;
using DogAPI.Repository.Interfaces;
using DogAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DogAPI.Services
{
    public class ClienteServices : IClienteServices
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public ClienteServices(IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Cliente>> Get(int skip, int take)
        {
            var clientes = await _uof.ClienteRepository
                                    .GetAll(skip: skip, take: take)
                                    .ToListAsync();
            return clientes;
        }
        public async Task<Cliente> GetById(int id)
        {
            var cliente = await _uof.ClienteRepository.GetById(cliente => cliente.ClienteId == id && cliente.Status == true);
            return cliente;
        }
        public async Task<Cliente> GetByCPF(string cpf)
        {
            var cliente = await _uof.ClienteRepository.GetByCPF(cpf);
            return cliente;
        }

        public async Task Create(CreateClienteDTO clienteDTO)
        {
            var cliente = _mapper.Map<Cliente>(clienteDTO);
            await _uof.ClienteRepository.Add(cliente);
            await _uof.Commit();
        }
        public async Task Update(int id, UpdateClienteDTO clienteDTO)
        {
            var cliente = _mapper.Map<Cliente>(clienteDTO);
            _uof.ClienteRepository.Update(cliente);
            await _uof.Commit();
        }
        public async Task Delete(int id)
        {
            await _uof.ClienteRepository.BoleanDelete(id);
            await _uof.Commit();
        }
    }
}