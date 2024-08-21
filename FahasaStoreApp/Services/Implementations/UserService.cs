using FahasaStoreApp.Helpers;
using FahasaStoreApp.Models.DTOs.Entities;
using FahasaStoreApp.Services.Interfaces;
using System.Drawing.Printing;
using System.Reflection;

namespace FahasaStoreApp.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserLogined _userLogined;

        public UserService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
        {
            _httpClientFactory = httpClientFactory;
            _userLogined = userLogined;
        }

        public async Task<string> LoginAsync(Login model)
        {
            var result = await MethodsHelper.RequestHttpPost<string, Login>(_httpClientFactory, _userLogined, "https://localhost:7094/api/Users/login", model);
            return result;
        }

        public async Task LogOutAsync()
        {
            var endpoint = $"https://localhost:7094/api/Users/logout";
            var result = await MethodsHelper.RequestHttpGet<bool>(_httpClientFactory, _userLogined, endpoint);
        }

        public async Task<bool> RegisterAsync(Register model)
        {
            var result = await MethodsHelper.RequestHttpPost<bool, Register>(_httpClientFactory, _userLogined, "https://localhost:7094/api/Users/login", model);
            return result;
        }
    }
}
