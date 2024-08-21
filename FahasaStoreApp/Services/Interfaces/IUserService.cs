
using FahasaStoreApp.Models.DTOs.Entities;

namespace FahasaStoreApp.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> LoginAsync(Login model);
        Task<bool> RegisterAsync(Register model);
        Task LogOutAsync();
    }
}
