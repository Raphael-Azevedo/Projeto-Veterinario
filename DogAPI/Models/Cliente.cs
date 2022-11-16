using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DogAPI.Models
{
    public class Cliente : Pessoa
    {
        public int ClienteId { get; set; }
        public string CPF { get; set; }
        [JsonIgnore]
        public List<Cachorro> Pets { get; set; }
        public bool Status { get; set; }
    }
}