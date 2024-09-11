using FahasaStore.Models;
using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.ViewModels;
using FahasaStoreAPI.Repositories.Interfaces;
using FahasaStoreAPI.Services.Interfaces;

namespace FahasaStoreAPI.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<UserLoginer?> LoginAsync(Login model)
        {
            var loginer = await _userRepository.LoginAsync(model);
            return loginer;
        }
        public async Task<bool> AddUserRoleAsync(int userId, string role)
        {
            return await _userRepository.AddUserRoleAsync(userId, role);
        }
        public async Task<bool> DeleteAsync(int userId)
        {
            return await _userRepository.DeleteAsync(userId);
        }
        public async Task<bool> LogOutAsync()
        {
            return await _userRepository.LogOutAsync();
        }
        public async Task<bool> RegisterAsync(Register model)
        {
            return await _userRepository.RegisterAsync(model);
        }
        public async Task<bool> RemoveUserRoleAsync(int userId, string role)
        {
            return await _userRepository.RemoveUserRoleAsync(userId, role);
        }
        public async Task<bool> UpdateAsync(AspNetUserExtend model)
        {
            return await _userRepository.UpdateAsync(model);
        }
        public async Task<PagedVM<NotificationExtend>> GetNotificationsAsync(int userId, int pageNumber, int pageSize)
        {
            return await _userRepository.GetNotificationsAsync(userId, pageNumber, pageSize);
        }
        public async Task<NotificationExtend?> GetNotificationDetailsByIdAsync(int userId, int notificationId)
        {
            return await _userRepository.GetNotificationDetailsByIdAsync(userId, notificationId);
        }
        public async Task<AspNetUserDetail> GetProfileUserAsync(int userId)
        {
            return await _userRepository.GetProfileUserAsync(userId);
        }
    }
}
