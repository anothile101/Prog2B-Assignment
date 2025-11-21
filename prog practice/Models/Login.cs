using System.ComponentModel.DataAnnotations;

namespace prog_practice.Models
{
    public class Login
    {
        [Required]
        [Display(Name = "Email")]
        public string? UserEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
