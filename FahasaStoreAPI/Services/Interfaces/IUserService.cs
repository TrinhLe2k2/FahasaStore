using FahasaStoreAPI.Base.Interfaces;
using FahasaStoreAPI.Identity;
using FahasaStoreAPI.Models.DTOs.Entities;
using FahasaStoreAPI.Models.Entities;

namespace FahasaStoreAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> FindByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        Task<IList<string>> GetRolesAsync(ApplicationUser user);
        Task<ApplicationUser> FindByIdAsync(string userId);
        Task<bool> CreateAsync(ApplicationUser user, string password);
        Task<bool> UpdateAsync(ApplicationUser user);
        Task<bool> DeleteAsync(ApplicationUser user);
        Task<string> LoginAsync(Login model);
        Task<bool> RegisterAsync(Register model);
        Task LogOutAsync();
        Task<bool> AddUserRoleAsync(string userId, string role);
        Task<bool> RemoveUserRoleAsync(string userId, string role);
    }
}
