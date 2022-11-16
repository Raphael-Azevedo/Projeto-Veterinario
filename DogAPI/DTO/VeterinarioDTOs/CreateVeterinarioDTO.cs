using System.ComponentModel.DataAnnotations;

namespace DogAPI.DTO.VeterinarioDTOs
{
    public class CreateVeterinarioDTO
    {
        [Required(ErrorMessage = "Este atributo é Obrigatório!")]
        [MaxLength(300, ErrorMessage = "Máximo de 300 characters")]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "Este atributo é Obrigatório!")]
        [MaxLength(50, ErrorMessage = "Máximo de 50 characters")]
        public string CRMV { get; set; }
        [Required(ErrorMessage = "Este atributo é Obrigatório!")]
        public int Telefone { get; set; }
        [Required(ErrorMessage = "Este atributo é Obrigatório!")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 characters")]
        public string Consultorio { get; set; }

        [Required(ErrorMessage = "Informe o seu email")]
        [MaxLength(150, ErrorMessage = "Máximo de 150 characters")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Este atributo é Obrigatório!")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 characters")]
        public string Nome { get; set; }
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

