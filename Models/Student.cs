using System.ComponentModel.DataAnnotations;

namespace MyJwtAuthApp.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Class { get; set; }

        [Required]
        public int RollNo { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
