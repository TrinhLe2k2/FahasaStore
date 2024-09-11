using FahasaStore.Models;
using System.ComponentModel.DataAnnotations;

namespace FahasaStoreApp.Models.DTOs
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
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ email"), EmailAddress]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; } = null!;
        public bool RememberMe { get; set; }
    }
    public class Register
    {
        [Required(ErrorMessage = "Vui lòng nhập họ và tên")]
        [Display(Name = "Họ và tên")]
        public string FullName { get; set; } = null!;
        [Required(ErrorMessage = "Vui lòng nhập email"), EmailAddress]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = "Vui lòng xác nhận mật khẩu"), Compare("Password", ErrorMessage = "Mật khẩu không trùng khớp")]
        [Display(Name = "Xác nhận mật khẩu")]
        public string ConfirmPassword { get; set; } = null!;
    }
    public class UserRole
    {
        public string UserId { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
