namespace DogAPI.Models
{
    public class Veterinario : Pessoa
    {
        public int VeterinarioId { get; set; }
        public string CRMV { get; set; }
        public string Consultorio { get; set; }
        public bool Status { get; set; }
    }
}