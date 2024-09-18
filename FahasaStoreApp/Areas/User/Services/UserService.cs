using CloudinaryDotNet.Actions;
using FahasaStore.Models;
using FahasaStoreApp.Helpers;
using FahasaStoreApp.Models;
using FahasaStoreApp.Models.DTOs;
using FahasaStoreApp.Models.ViewModels;
using FahasaStoreApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreApp.Areas.User.Services
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(Register model);
        Task<UserLoginer?> LoginAsync(Login model);
        Task<bool> UpdateAsync(AspNetUserBase model);
        Task<bool> LogOutAsync();
        Task<PagedVM<NotificationExtend>> GetNotificationsAsync(int pageNumber, int pageSize);
        Task<NotificationExtend?> GetNotificationDetailsByIdAsync(int notificationId);
        Task<AspNetUserDetail> GetProfileUserAsync();
        Task<bool> CheckRoleAccount(string role);
        Task<UserLoginer> GetUserLoginerAsync();
    }

    public class UserService : IUserService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMethodsHelper _methodsHelper;
        private readonly ICloudinaryService _cloudinaryService;

        public UserService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService)
        {
            _httpClientFactory = httpClientFactory;
            _methodsHelper = methodsHelper;
            _cloudinaryService = cloudinaryService;
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

        public async Task<bool> UpdateAsync(AspNetUserBase model)
        {
            model = await _cloudinaryService.UploadImageHandlerAsync(model);
            var endpoint = "/Users/Update";
            var result = await _methodsHelper.RequestHttpPut<bool, AspNetUserBase>(_httpClientFactory, endpoint, model);
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

        public async Task<bool> CheckRoleAccount(string role)
        {
            var endpoint = "/Users/CheckRoleAccount?role=" + role;
            var result = await _methodsHelper.RequestHttpPost<bool, string>(_httpClientFactory, endpoint, role);
            return result;
        }

        public async Task<UserLoginer> GetUserLoginerAsync()
        {
            var endpoint = $"/Users/GetUserLoginer";
            var result = await _methodsHelper.RequestHttpGet<UserLoginer>(_httpClientFactory, endpoint);
            return result;
        }
    }
}
