using System.Collections.Generic;
using DogAPI.Models;

namespace DogAPI.DTO.ClienteDTOs
{
    public class ReadClienteDTO
    {
        public Cliente Cliente { get; set; }
        public List<Cachorro> Pets { get; set; }
    }
}