using System;
using System.ComponentModel.DataAnnotations;

namespace DogAPI.DTO.AtendimentoDTOs
{
    public class UpdateAtendimentoDTO
    {
        public int AtendimentoId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataDeAtendimento { get; set; }
        public int CachorroId { get; set; }
        public int veterinarioId { get; set; }
        [Required(ErrorMessage = "Este atributo é Obrigatório!")]
        [StringLength(300, ErrorMessage = "Máximo de 300 characters")]
        public string Diagnostico { get; set; }
        [Required(ErrorMessage = "Este atributo é Obrigatório!")]
        [StringLength(300, ErrorMessage = "Máximo de 300 characters")]
        public string Comentario { get; set; }
    }
}