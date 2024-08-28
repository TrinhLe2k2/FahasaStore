using AutoMapper;
using CloudinaryDotNet.Actions;
using FahasaStoreAPI.Base.Implementations;
using FahasaStoreAPI.Base.Interfaces;
using FahasaStoreAPI.Constants;
using FahasaStoreAPI.Identity;
using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.DTOs.Entities;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Repositories.Interfaces;
using FahasaStoreAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FahasaStoreAPI.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _configuration = configuration;
        }

        public async Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return await _userRepository.FindByEmailAsync(email);
        }

        public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            return await _userRepository.CheckPasswordAsync(user, password);
        }

        public async Task<IList<string>> GetRolesAsync(ApplicationUser user)
        {
            return await _userRepository.GetRolesAsync(user);
        }

        public async Task<ApplicationUser> FindByIdAsync(string userId)
        {
            return await _userRepository.FindByIdAsync(userId);
        }

        public async Task<bool> CreateAsync(ApplicationUser user, string password)
        {
            return await _userRepository.CreateAsync(user, password);
        }

        public async Task<bool> UpdateAsync(ApplicationUser user)
        {
            return await _userRepository.UpdateAsync(user);
        }

        public async Task<bool> DeleteAsync(ApplicationUser user)
        {
            return await _userRepository.DeleteAsync(user);
        }

        public async Task<string> LoginAsync(Login model)
        {
            var user = await _userRepository.FindByEmailAsync(model.Email);
            var passwordValid = await _userRepository.CheckPasswordAsync(user, model.Password);

            if (user == null || !passwordValid)
            {
                throw new Exception("User not found or Invalid password.");
            }

            var authClaims = new List<Claim>
            {
                new Claim("UserId", user.Id.ToString()),
                new Claim("FullName", user.FullName),
                new Claim(ClaimTypes.Email, model.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var userRoles = await _userRepository.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }

            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(2),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
            );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

            return accessToken;
        }

        public async Task<bool> RegisterAsync(Register model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email.Split('@')[0],
                Email = model.Email,
                FullName = model.FullName,
                CreatedAt = DateTime.UtcNow
            };

            var userResult = await _userRepository.CreateAsync(user, model.Password);
            if (userResult)
            {
                var userCurrent = await _userRepository.FindByEmailAsync(user.Email);
                if (userCurrent == null)
                {
                    throw new Exception("User current not found.");
                }

                var roleExists = await _roleRepository.ExistsAsync(AppRole.Customer);
                if (!roleExists)
                {
                    var roleNew = await _roleRepository.CreateAsync(new IdentityRole<int> { Name = AppRole.Customer });
                    if (!roleNew)
                    {
                        throw new Exception("Failed to create the role.");
                    }
                    
                }

                var roleResult = await _userRepository.AddToRoleAsync(userCurrent, AppRole.Customer);
                if (!roleResult)
                {
                    throw new Exception("Failed to add role to the user.");
                }
            }
            return userResult;
        }

        public async Task<bool> AddUserRoleAsync(string userId, string role)
        {
            var roleExists = await _roleRepository.ExistsAsync(userId);
            if (!roleExists)
            {
                throw new Exception("Role not found.");
            }
            var user = await _userRepository.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            return await _userRepository.AddToRoleAsync(user, role);
        }

        public async Task<bool> RemoveUserRoleAsync(string userId, string role)
        {
            var user = await _userRepository.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            return await _userRepository.RemoveFromRoleAsync(user, role);
        }

        public async Task LogOutAsync()
        {
            await _userRepository.LogOutAsync();
        }
    }
}
