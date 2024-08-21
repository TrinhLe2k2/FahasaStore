﻿using System.ComponentModel.DataAnnotations;

namespace FahasaStoreApp.Models.DTOs.Entities
{
    public class Login
    {
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
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
    public class UserRole
    {
        public string UserId { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
