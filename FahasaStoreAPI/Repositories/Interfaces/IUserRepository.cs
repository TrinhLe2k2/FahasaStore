using FahasaStoreAPI.Identity;
using FahasaStoreAPI.Models.DTOs.Entities;
using Microsoft.AspNetCore.Identity;

namespace FahasaStoreAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<ApplicationUser> FindByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        Task<IList<string>> GetRolesAsync(ApplicationUser user);
        Task<ApplicationUser> FindByIdAsync(string userId);
        Task<bool> CreateAsync(ApplicationUser user, string password);
        Task<bool> UpdateAsync(ApplicationUser user);
        Task<bool> DeleteAsync(ApplicationUser user);
        Task LogOutAsync();
        Task<bool> AddToRoleAsync(ApplicationUser user, string role);
        Task<bool> RemoveFromRoleAsync(ApplicationUser user, string role);
    }
}
