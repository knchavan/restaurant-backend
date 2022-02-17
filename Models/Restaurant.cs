using System.ComponentModel.DataAnnotations;

namespace restaurant_backend.Models
{
    public class Restaurant 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Timings { get; set; }
        [Required]
        public float Rating { get; set; }
    }
}