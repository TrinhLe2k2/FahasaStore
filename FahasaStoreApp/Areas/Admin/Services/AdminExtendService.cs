using FahasaStoreApp.Helpers;
using FahasaStoreApp.Models;
using FahasaStoreApp.Models.DTOs;

namespace FahasaStoreApp.Areas.Admin.Services
{
    public interface IAdminExtendService
    {
        Task<ApiResponse<IEnumerable<MonthlyStatisticsDTO>>> GetYearlyStatisticsAsync(int? year = null);
    }
    public class AdminExtendService : IAdminExtendService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMethodsHelper _methodsHelper;

        public AdminExtendService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper)
        {
            _httpClientFactory = httpClientFactory;
            _methodsHelper = methodsHelper;
        }
        public async Task<ApiResponse<IEnumerable<MonthlyStatisticsDTO>>> GetYearlyStatisticsAsync(int? year = null)
        {
            string endpoint = "";
            if (year == null)
            {
                endpoint = "/AdminExtend/GetYearlyStatistics";
            }
            else
            {
                endpoint = "/AdminExtend/GetYearlyStatistics?year=" + year;
            }
            
            return await _methodsHelper.RequestHttpGet<ApiResponse<IEnumerable<MonthlyStatisticsDTO>>>(_httpClientFactory, endpoint);
        }
    }
}
