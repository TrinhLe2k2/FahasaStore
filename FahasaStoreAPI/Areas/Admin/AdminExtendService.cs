using FahasaStore.Models;
using FahasaStoreAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreAPI.Areas.Admin
{
    public interface IAdminExtendService
    {
        Task<ApiResponse<IEnumerable<MonthlyStatisticsDTO>>> GetYearlyStatisticsAsync(int? year);
    }
    public class AdminExtendService : IAdminExtendService
    {
        private readonly IAdminExtendRepository _adminExtendRepository;

        public AdminExtendService(IAdminExtendRepository adminExtendRepository)
        {
            _adminExtendRepository = adminExtendRepository;
        }

        public async Task<ApiResponse<IEnumerable<MonthlyStatisticsDTO>>> GetYearlyStatisticsAsync(int? year)
        {
            try
            {
                var response = await _adminExtendRepository.GetYearlyStatisticsAsync(year);
                return new ApiResponse<IEnumerable<MonthlyStatisticsDTO>>(status: 200, error: false, message: "Success", data: response);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<MonthlyStatisticsDTO>>(status: 500, error: true, message: ex.Message, data: null);
            }
        }
    }
}
