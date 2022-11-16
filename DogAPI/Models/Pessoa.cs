namespace DogAPI.Models
{
    public abstract class Pessoa
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int Telefone { get; set; }
        public string Email { get; set; }
        public int Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
    }
}