using FahasaStoreAPI.Models.DTOs.Entities;
using FahasaStoreAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("login")]
        public async Task<IActionResult> LogIn([FromBody] Login model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var token = await _userService.LoginAsync(model);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Register model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _userService.RegisterAsync(model);
                if (result)
                {
                    return Ok(new { Message = "Registration successful." });
                }

                return BadRequest(new { Message = "Registration failed." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("logout")]
        public async Task<IActionResult> LogOut()
        {
            await _userService.LogOutAsync();
            return Ok(new { Message = "Logout successful." });
        }

        [HttpPost("add-role")]
        public async Task<IActionResult> AddUserRole([FromBody] UserRole model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _userService.AddUserRoleAsync(model.UserId, model.Role);
                if (result)
                {
                    return Ok(new { Message = "Role added successfully." });
                }

                return BadRequest(new { Message = "Failed to add role." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("remove-role")]
        public async Task<IActionResult> RemoveUserRole([FromBody] UserRole model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _userService.RemoveUserRoleAsync(model.UserId, model.Role);
                if (result)
                {
                    return Ok(new { Message = "Role removed successfully." });
                }

                return BadRequest(new { Message = "Failed to remove role." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("FindUser")]
        public async Task<IActionResult> FindUser(string id)
        {
            var u = await _userService.FindByIdAsync(id);
            return Ok(u);
        }
    }
}
