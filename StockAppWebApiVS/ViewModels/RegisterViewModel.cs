using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockAppWebApiVS.ViewModels
{
    public class RegisterViewModel
    {
        public string? Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = "";

        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; } = "";

        public string? FullName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Country { get; set; }
    }
}
