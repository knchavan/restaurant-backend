using System.ComponentModel.DataAnnotations;

namespace restaurant_backend.Models
{
    public class User 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, DataType("Password")]
        public string Password { get; set; }
    }
}