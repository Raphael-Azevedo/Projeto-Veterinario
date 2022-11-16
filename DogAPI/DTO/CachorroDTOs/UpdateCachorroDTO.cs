using System;
using System.ComponentModel.DataAnnotations;

namespace DogAPI.DTO.CachorroDTOs
{
    public class UpdateCachorroDTO
    {
        [Required(ErrorMessage = "Este atributo é Obrigatório!")]
        public int CachorroId { get; set; }
        [Required(ErrorMessage = "Este atributo é Obrigatório!")]
        public string TutorCpf { get; set; }
        [Required(ErrorMessage = "Este atributo é Obrigatório!")]
        [StringLength(80, ErrorMessage = "Máximo de 80 characters")]
        public string NomeRaca { get; set; }
        [Required(ErrorMessage = "Este atributo é Obrigatório!")]
        public float Tamanho { get; set; }
        [Required(ErrorMessage = "Este atributo é Obrigatório!")]
        public float Peso { get; set; }
        [Required(ErrorMessage = "Este atributo é Obrigatório!")]
        [StringLength(200, ErrorMessage = "Máximo de 200 characters")]
        public string Vacinas { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataDeNascimento { get; set; }
        [Required(ErrorMessage = "Este atributo é Obrigatório!")]
        [StringLength(80, ErrorMessage = "Máximo de 80 characters")]
        public string Pedigree { get; set; }
        [Required(ErrorMessage = "Este atributo é Obrigatório!")]
        [StringLength(80, ErrorMessage = "Máximo de 80 characters")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Este atributo é Obrigatório!")]
        [StringLength(80, ErrorMessage = "Máximo de 80 characters")]
        public string Porte { get; set; }
    }
}