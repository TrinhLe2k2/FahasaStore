using FahasaStore.Models;
using FahasaStoreAPI.Constants;
using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FahasaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
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

        [HttpGet("Logout")]
        public async Task<IActionResult> LogOut()
        {
            var result = await _userService.LogOutAsync();
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(AspNetUserExtend model)
        {
            var result = await _userService.UpdateAsync(model);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int userId)
        {
            var result = await _userService.DeleteAsync(userId);
            return Ok(result);
        }

        [HttpPost("AddUserRole")]
        public async Task<IActionResult> AddUserRole(int userId, string role)
        {
            var result = await _userService.AddUserRoleAsync(userId, role);
            return Ok(result);
        }

        [HttpPost("RemoveRoleUser")]
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
    }
}
