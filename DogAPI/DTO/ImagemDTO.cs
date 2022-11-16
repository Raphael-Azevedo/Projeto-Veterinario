using System;

namespace DogAPI.DTO
{
    public class ImagemDTO
    {
        public string id { get; set; }
        public string url { get; set; }
        public Object[] categories { get; set; }
        public Object[] breeds { get; set; }
    }
}