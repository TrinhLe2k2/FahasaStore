using FahasaStore.Models;
using System.ComponentModel.DataAnnotations;

namespace FahasaStoreAPI.Models.DTOs
{
    public class UserLoginer
    {
        public string? AccessToken { get; set; }
        public int UserId { get; set; } = 0;
        public int CartId { get; set; } = 0;
        public string FullName { get; set; } = null!;
        public string? ImageUrl { get; set; }
    }

    public class Login
    {
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        public bool RememberMe { get; set; }
    }
    public class Register
    {
        [Required]
        public string FullName { get; set; } = null!;
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required, Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; } = null!;
    }
    public class AccountRole
    {
        public string UserId { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
