using System.ComponentModel.DataAnnotations;

namespace MyJwtAuthApp.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } // Updated from Username to Name

        [Required]
        [EmailAddress]
        public string Email { get; set; } // Added Email field

        [Required]
        public string PasswordHash { get; set; }
    }
}
