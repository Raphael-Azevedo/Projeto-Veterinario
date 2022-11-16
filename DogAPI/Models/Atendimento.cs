using System;

namespace DogAPI.Models
{
    public class Atendimento
    {
        public int AtendimentoId { get; set; }
        public DateTime DataDeAtendimento { get; set; }
        public Cachorro Pet { get; set; }
        public Veterinario veterinario { get; set; }
        public string Diagnostico { get; set; }
        public string Comentario { get; set; }
        public bool Status { get; set; }
    }
}