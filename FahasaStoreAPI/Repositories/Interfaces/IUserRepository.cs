using FahasaStore.Models;
using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.ViewModels;

namespace FahasaStoreAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> RegisterAsync(Register model);
        Task<UserLoginer?> LoginAsync(Login model);
        Task<bool> UpdateAsync(AspNetUserExtend model);
        Task<bool> DeleteAsync(int userId);
        Task<bool> LogOutAsync();
        Task<bool> AddUserRoleAsync(int userId, string role);
        Task<bool> RemoveUserRoleAsync(int userId, string role);
        Task<PagedVM<NotificationExtend>> GetNotificationsAsync(int userId, int pageNumber, int pageSize);
        Task<NotificationExtend?> GetNotificationDetailsByIdAsync(int userId, int notificationId);
        Task<AspNetUserDetail> GetProfileUserAsync(int userId);
    }
}
