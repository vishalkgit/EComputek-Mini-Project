using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EComputek.Models
{

    [Table("Registeration")]
    public class Registeration
    {
        [Key]
        public int Userid { get; set; }


        public string? Firstname { get; set; }


        public string? Lastname { get; set; }


        public string? Address { get; set; }


        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        public int roleid { get; set; }

        [Display(Name = "Confirm Password")]
        [NotMapped]
        [Compare("Password", ErrorMessage = "Password can't be match !")]
        public string? ConfirmPassword { get; set; }

        [NotMapped]
        [Display(Name = "Role")]
        public string? Rolename { get; set; }

    }
}
