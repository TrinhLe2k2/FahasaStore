using FahasaStore.Models;
using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.ViewModels;

namespace FahasaStoreAPI.Areas.Customer
{
    public interface ICustomerExtendService
    {
        Task<bool> RegisterAsync(Register model);
        Task<List<string>> BulkRegisterAsync(IFormFile file);
        Task<UserLoginer?> LoginAsync(Login model);
        Task<bool> UpdateAsync(AspNetUserBase model, int id);
        Task<bool> LogOutAsync();
        Task<bool> AddUserRoleAsync(int userId, string role);
        Task<bool> RemoveUserRoleAsync(int userId, string role);
        Task<PagedVM<NotificationExtend>> GetNotificationsAsync(int userId, int pageNumber, int pageSize);
        Task<NotificationExtend?> GetNotificationDetailsByIdAsync(int userId, int notificationId);
        Task<AspNetUserDetail> GetProfileUserAsync(int userId);
        Task<UserLoginer?> GetUserLoginerAsync(int userId);
    }

    public class CustomerExtendService : ICustomerExtendService
    {
        private readonly ICustomerExtendRepository _userRepository;
        private readonly IConfiguration _configuration;

        public CustomerExtendService(ICustomerExtendRepository userRepository, IConfiguration configuration)
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
        
        public async Task<bool> LogOutAsync()
        {
            return await _userRepository.LogOutAsync();
        }

        public async Task<bool> RegisterAsync(Register model)
        {
            return await _userRepository.RegisterAsync(model);
        }

        public async Task<List<string>> BulkRegisterAsync(IFormFile file)
        {
            return await _userRepository.BulkRegisterAsync(file);
        }

        public async Task<bool> RemoveUserRoleAsync(int userId, string role)
        {
            return await _userRepository.RemoveUserRoleAsync(userId, role);
        }

        public async Task<bool> UpdateAsync(AspNetUserBase model, int id)
        {
            model.Id = id;
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

        public async Task<UserLoginer?> GetUserLoginerAsync(int userId)
        {
            return await _userRepository.GetUserLoginerAsync(userId);
        }
    }
}
