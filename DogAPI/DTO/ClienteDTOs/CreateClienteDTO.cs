using System.ComponentModel.DataAnnotations;

namespace DogAPI.DTO.ClienteDTOs
{
    public class CreateClienteDTO
    {
        [Required(ErrorMessage = "Este atributo é Obrigatório!")]
        [StringLength(14, ErrorMessage = "Máximo de 14 characters")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "Este atributo é Obrigatório!")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 characters")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Este atributo é Obrigatório!")]
        [MaxLength(150, ErrorMessage = "Máximo de 150 characters")]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "Este atributo é Obrigatório!")]
        public int Telefone { get; set; }
        [Required(ErrorMessage = "Informe o seu email")]
        [MaxLength(80, ErrorMessage = "Máximo de 80 characters")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Este atributo é Obrigatório!")]
        public int Cep { get; set; }
        [Required(ErrorMessage = "Este atributo é Obrigatório!")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 characters")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Este atributo é Obrigatório!")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 characters")]
        public string Cidade { get; set; }
    }
}