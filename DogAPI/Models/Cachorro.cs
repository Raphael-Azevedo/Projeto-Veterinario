using System;

namespace DogAPI.Models
{
    public class Cachorro
    {
        public int CachorroId { get; set; }
        public Cliente Tutor { get; set; }
        public Raca Raca { get; set; }
        public float Tamanho { get; set; }
        public float Peso { get; set; }
        public string Vacinas { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Pedigree { get; set; }
        public string Nome { get; set; }
        public string Porte { get; set; }
        public bool Status { get; set; }

    }
}