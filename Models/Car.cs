using System;

namespace ratingcore.Models
{
    public class Car
    {
        public long Id { get; set; }   
        
        public string Description { get; set; }
        
        public string Make { get; set; }
        
        public string Model { get; set; }
        
        public string Image { get; set; }
        public DateTime? Estimatedate { get; set; }
        
        public int Km { get; set; }
    }
}