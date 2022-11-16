using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DogAPI.Models
{
    public class Raca
    {
        public int id { get; set; }
        public string name { get; set; }
        public string temperament { get; set; }
        public string life_span { get; set; }
        public Dados weight { get; set; }
        public string country_code { get; set; }
        public Dados height { get; set; }
    }
}