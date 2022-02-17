using System.ComponentModel.DataAnnotations;

namespace restaurant_backend.Models.ViewModels
{
    public class LoginUserVM
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, DataType("Password")]
        public string Password { get; set; }
    }
}