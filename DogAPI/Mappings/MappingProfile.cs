using AutoMapper;
using DogAPI.DTO.AtendimentoDTOs;
using DogAPI.DTO.CachorroDTOs;
using DogAPI.DTO.ClienteDTOs;
using DogAPI.DTO.VeterinarioDTOs;
using DogAPI.Models;

namespace DogAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Atendimento, UpdateAtendimentoDTO>().ReverseMap()
                        .ForMember(status => status.Status, map => map
                        .MapFrom(src => true));
            CreateMap<Atendimento, CreateAtendimentoDTO>().ReverseMap()
                        .ForMember(status => status.Status, map => map
                        .MapFrom(src => true));

            CreateMap<Veterinario, CreateVeterinarioDTO>().ReverseMap()
                        .ForMember(status => status.Status, map => map
                        .MapFrom(src => true));
            CreateMap<Veterinario, UpdateVeterinarioDTO>().ReverseMap()
                        .ForMember(status => status.Status, map => map
                        .MapFrom(src => true));

            CreateMap<Cliente, CreateClienteDTO>().ReverseMap()
                        .ForMember(status => status.Status, map => map
                        .MapFrom(src => true));
            CreateMap<Cliente, UpdateClienteDTO>().ReverseMap()
                        .ForMember(status => status.Status, map => map
                        .MapFrom(src => true));

            CreateMap<Cachorro, UpdateCachorroDTO>().ReverseMap()
                        .ForMember(tutor => tutor.Tutor, map => map.Ignore())
                        .ForMember(raca => raca.Raca, map => map.Ignore())
                        .ForMember(status => status.Status, map => map
                        .MapFrom(src => true));

            CreateMap<Cachorro, CreateCachorroDTO>().ReverseMap()
                        .ForMember(tutor => tutor.Tutor, map => map.Ignore())
                        .ForMember(raca => raca.Raca, map => map.Ignore())
                        .ForMember(status => status.Status, map => map
                        .MapFrom(src => true));

        }
    }
}