using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DogAPI.DTO.AtendimentoDTOs;
using DogAPI.Models;
using DogAPI.Repository.Interfaces;
using DogAPI.Services.Interfaces;

namespace DogAPI.Services
{
    public class AtendimentoServices : IAtendimentoServices
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public AtendimentoServices(IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Atendimento>> Get(int skip, int take)
        {
            var atendimentos = await _uof.AtendimentoRepository
                                    .GetAll(skip: skip, take: take);
            return atendimentos;
        }
        public async Task<Atendimento> GetById(int id)
        {
            var atendimento = await _uof.AtendimentoRepository.GetByIdAtendimento(id);
            return atendimento;
        }
        public async Task<IEnumerable<Atendimento>> GetByPetName(string petName, int skip, int take)
        {
            var atendimentos = await _uof.AtendimentoRepository.GetByPetName(petName, skip: skip, take: take);
            return atendimentos;
        }
        public async Task<IEnumerable<Atendimento>> GetByCpf(string cpf, int skip, int take)
        {
            var atendimentos = await _uof.AtendimentoRepository.GetByCPF(cpf, skip: skip, take: take);
            return atendimentos;
        }
        public async Task<IEnumerable<Atendimento>> GetByUser(string user, int skip, int take)
        {
            var atendimentos = await _uof.AtendimentoRepository.GetByUser(user, skip: skip, take: take);
            return atendimentos;
        }
        public async Task Create(CreateAtendimentoDTO atendimentoDTO)
        {
            var atendimento = _mapper.Map<Atendimento>(atendimentoDTO);
            var veterinario = await _uof.VeterinarioRepository.GetById(x => x.VeterinarioId == atendimentoDTO.veterinarioId);
            var pet = await _uof.CachorroRepository.GetById(x => x.CachorroId == atendimentoDTO.CachorroId);
            atendimento.veterinario = veterinario;
            atendimento.Pet = pet;


            await _uof.AtendimentoRepository.Add(atendimento);
            await _uof.Commit();
        }
        public async Task Update(int id, UpdateAtendimentoDTO atendimentoDTO)
        {
            var atendimento = _mapper.Map<Atendimento>(atendimentoDTO);
            var veterinario = await _uof.VeterinarioRepository.GetById(x => x.VeterinarioId == atendimentoDTO.veterinarioId);
            var pet = await _uof.CachorroRepository.GetById(x => x.CachorroId == atendimentoDTO.CachorroId);
            atendimento.veterinario = veterinario;
            atendimento.Pet = pet;

            _uof.AtendimentoRepository.Update(atendimento);
            await _uof.Commit();
        }
        public async Task Delete(int id)
        {
            await _uof.AtendimentoRepository.BoleanDelete(id);
            await _uof.Commit();
        }
    }
}