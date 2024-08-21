using FahasaStoreAPI.Repositories.Interfaces;
using FahasaStoreAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace FahasaStoreAPI.Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IdentityRole<int>> FindByNameAsync(string roleName)
        {
            return await _roleRepository.FindByNameAsync(roleName);
        }

        public async Task<bool> CreateAsync(IdentityRole<int> role)
        {
            return await _roleRepository.CreateAsync(role);
        }

        public async Task<bool> UpdateAsync(IdentityRole<int> role)
        {
            return await _roleRepository.UpdateAsync(role);
        }

        public async Task<bool> DeleteAsync(IdentityRole<int> role)
        {
            return await _roleRepository.DeleteAsync(role);
        }

        public async Task<IList<IdentityRole<int>>> GetAllRolesAsync()
        {
            return await _roleRepository.GetAllRolesAsync();
        }
    }
}
