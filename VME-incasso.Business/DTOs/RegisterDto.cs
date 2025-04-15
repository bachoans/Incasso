using System.ComponentModel.DataAnnotations;

namespace VME.incasso.Business.DTOs
{
    public class RegisterDto
    {
        // Company Information
        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string CompanyEmail { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        // User Information
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
