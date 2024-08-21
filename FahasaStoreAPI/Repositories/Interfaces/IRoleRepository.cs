using Microsoft.AspNetCore.Identity;

namespace FahasaStoreAPI.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<IdentityRole<int>> FindByNameAsync(string roleName);
        Task<bool> CreateAsync(IdentityRole<int> role);
        Task<bool> UpdateAsync(IdentityRole<int> role);
        Task<bool> DeleteAsync(IdentityRole<int> role);
        Task<IList<IdentityRole<int>>> GetAllRolesAsync();
        Task<bool> ExistsAsync(string role);
    }
}
