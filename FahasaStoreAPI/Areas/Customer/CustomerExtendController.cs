using FahasaStore.Models;
using FahasaStoreAPI.Constants;
using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace FahasaStoreAPI.Areas.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ICustomerExtendService _userService;

        public UsersController(ICustomerExtendService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LogIn(Login model)
        {
            var userLoginer = await _userService.LoginAsync(model);
            if (userLoginer == null)
            {
                return BadRequest(new { Message = "LogIn failed." });
            }
            return Ok(userLoginer);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(Register model)
        {
            var result = await _userService.RegisterAsync(model);
            return Ok(result);
        }

        [HttpPost("BulkRegister")]
        public async Task<IActionResult> BulkRegister(IFormFile filel)
        {
            var result = await _userService.BulkRegisterAsync(filel);
            return Ok(result);
        }

        [HttpGet("Logout")]
        public async Task<IActionResult> LogOut()
        {
            var result = await _userService.LogOutAsync();
            return Ok(result);
        }

        [HttpPut("Update")]
        [Authorize(AppRole.Customer)]
        public async Task<IActionResult> Update(AspNetUserBase model)
        {
            var userId = User.FindFirst(c => c.Type == "UserId")?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var result = await _userService.UpdateAsync(model, int.Parse(userId));
            return Ok(result);
        }

        [HttpPost("AddUserRole")]
        [Authorize(AppRole.Admin)]
        public async Task<IActionResult> AddUserRole(int userId, string role)
        {
            var result = await _userService.AddUserRoleAsync(userId, role);
            return Ok(result);
        }

        [HttpPost("RemoveRoleUser")]
        [Authorize(AppRole.Admin)]
        public async Task<IActionResult> RemoveRoleUser(int userId, string role)
        {
            var result = await _userService.RemoveUserRoleAsync(userId, role);
            return Ok(result);
        }

        [Authorize(AppRole.Customer)]
        [HttpGet("GetNotifications")]
        public async Task<IActionResult> GetNotifications(int pageNumber, int pageSize)
        {
            var userId = User.FindFirst(c => c.Type == "UserId")?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var result = await _userService.GetNotificationsAsync(int.Parse(userId), pageNumber, pageSize);
            return Ok(result);
        }

        [Authorize(AppRole.Customer)]
        [HttpGet("GetNotificationDetailsById")]
        public async Task<IActionResult> GetNotificationDetailsById(int notificationId)
        {
            var userId = User.FindFirst(c => c.Type == "UserId")?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var result = await _userService.GetNotificationDetailsByIdAsync(int.Parse(userId), notificationId);
            return Ok(result);
        }

        [Authorize(AppRole.Customer)]
        [HttpGet("GetProfileUser")]
        public async Task<IActionResult> GetProfileUser()
        {
            var userId = User.FindFirst(c => c.Type == "UserId")?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var result = await _userService.GetProfileUserAsync(int.Parse(userId));
            return Ok(result);
        }

        [HttpPost("CheckRoleAccount")]
        [Authorize(AppRole.Customer)]
        public IActionResult CheckRoleAccount(string role)
        {
            var roles = User.FindAll("http://schemas.microsoft.com/ws/2008/06/identity/claims/role")
                .Select(c => c.Value)
                .ToList();

            if (roles.Contains(role))
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpGet("GetUserLoginer")]
        [Authorize(AppRole.Customer)]
        public async Task<IActionResult> GetUserLoginer()
        {
            var userId = User.FindFirst(c => c.Type == "UserId")?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var result = await _userService.GetUserLoginerAsync(int.Parse(userId));
            return Ok(result);
        }
    }
}
