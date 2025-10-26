using System.ComponentModel.DataAnnotations;

namespace SumitPortfolio.Models
{
    public class Project
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
    public class ConnectForm
    {
        [Required(ErrorMessage = "First Name is required.")]
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Message is required.")]
        [MinLength(5, ErrorMessage = "Message must be at least 5 characters long.")]
        public string? Message { get; set; }

        [Required(ErrorMessage = "Mobile number is required.")]
        [RegularExpression("^[6-9][0-9]{9}$", ErrorMessage = "Mobile number must be 10 digits and start with 6, 7, 8, or 9.")]
        public string? Mobile { get; set; }

    }
}