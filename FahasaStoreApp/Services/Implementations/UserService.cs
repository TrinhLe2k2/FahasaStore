using FahasaStore.Models;
using FahasaStoreApp.Helpers;
using FahasaStoreApp.Models;
using FahasaStoreApp.Models.DTOs;
using FahasaStoreApp.Models.ViewModels;
using FahasaStoreApp.Services.Interfaces;

namespace FahasaStoreApp.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMethodsHelper _methodsHelper;

        public UserService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper)
        {
            _httpClientFactory = httpClientFactory;
            _methodsHelper = methodsHelper;
        }

        public async Task<bool> RegisterAsync(Register model)
        {
            var endpoint = "/Users/Register";
            var result = await _methodsHelper.RequestHttpPost<bool, Register>(_httpClientFactory, endpoint, model);
            return result;
        }

        public async Task<UserLoginer?> LoginAsync(Login model)
        {
            var endpoint = "/Users/Login";
            var result = await _methodsHelper.RequestHttpPost<UserLoginer?, Login>(_httpClientFactory, endpoint, model);
            return result;
        }

        public async Task<AspNetUserExtend> UpdateAsync(AspNetUserExtend model)
        {
            var endpoint = "/Users/Update";
            var result = await _methodsHelper.RequestHttpPut<AspNetUserExtend, AspNetUserExtend>(_httpClientFactory, endpoint, model);
            return result;
        }

        public async Task<bool> LogOutAsync()
        {
            var endpoint = "/Users/Logout";
            var result = await _methodsHelper.RequestHttpGet<bool>(_httpClientFactory, endpoint);
            return result;
        }

        public async Task<PagedVM<NotificationExtend>> GetNotificationsAsync(int pageNumber, int pageSize)
        {
            var endpoint = $"/Users/GetNotifications?pageNumber={pageNumber}&pageSize={pageSize}";
            var result = await _methodsHelper.RequestHttpGet<PagedVM<NotificationExtend>>(_httpClientFactory, endpoint);
            return result;
        }

        public async Task<NotificationExtend?> GetNotificationDetailsByIdAsync(int notificationId)
        {
            var endpoint = $"/Users/GetNotificationDetailsById?notificationId={notificationId}";
            var result = await _methodsHelper.RequestHttpGet<NotificationExtend>(_httpClientFactory, endpoint);
            return result;
        }

        public async Task<AspNetUserDetail> GetProfileUserAsync()
        {
            var endpoint = $"/Users/GetProfileUser";
            var result = await _methodsHelper.RequestHttpGet<AspNetUserDetail>(_httpClientFactory, endpoint);
            return result;
        }

        
    }
}
