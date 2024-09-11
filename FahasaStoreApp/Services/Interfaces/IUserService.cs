
using FahasaStore.Models;
using FahasaStoreApp.Models.DTOs;
using FahasaStoreApp.Models.ViewModels;

namespace FahasaStoreApp.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(Register model);
        Task<UserLoginer?> LoginAsync(Login model);
        Task<AspNetUserExtend> UpdateAsync(AspNetUserExtend model);
        Task<bool> LogOutAsync();
        Task<PagedVM<NotificationExtend>> GetNotificationsAsync(int pageNumber, int pageSize);
        Task<NotificationExtend?> GetNotificationDetailsByIdAsync(int notificationId);
        Task<AspNetUserDetail> GetProfileUserAsync();
    }
}
