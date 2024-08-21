using FahasaStoreApp.Helpers;
using FahasaStoreApp.Models.ViewModels.Entities;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using FahasaStoreApp.Services.Interfaces;
using static System.Net.WebRequestMethods;
using FahasaStoreApp.Models.ViewModels;
using System.Drawing.Printing;

namespace FahasaStoreApp.Services.Implementations
{
    public class FahasaStoreService : IFahasaStoreService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserLogined _userLogined;

        public FahasaStoreService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
        {
            _httpClientFactory = httpClientFactory;
            _userLogined = userLogined;
        }

        public async Task<FlashSaleVM?> FlashSaleTodayAsync(int pageNumber, int pageSize)
        {
            var endpoint = $"https://localhost:7094/api/FahasaStore/FlashSaleToday?pageNumber={pageNumber}&pageSize={pageSize}";
            var result = await MethodsHelper.RequestHttpGet<FlashSaleVM>(_httpClientFactory, _userLogined, endpoint);
            return result;
        }

        public async Task<PagedVM<BookVM>> TrendingBooks(string trendingBy, int pageNumber, int pageSize)
        {
            var endpoint = $"https://localhost:7094/api/FahasaStore/TrendingBooks?trendingBy={trendingBy}&pageNumber={pageNumber}&pageSize={pageSize}";
            var result = await MethodsHelper.RequestHttpGet<PagedVM<BookVM>>(_httpClientFactory, _userLogined, endpoint);
            return result;
        }

        public async Task<PagedVM<BookVM>> TopSellingBooksByCategory(int categoryId, int pageNumber, int pageSize)
        {
            var endpoint = $"https://localhost:7094/api/FahasaStore/TopSellingBooksByCategory?categoryId={categoryId}&pageNumber={pageNumber}&pageSize={pageSize}";
            var result = await MethodsHelper.RequestHttpGet<PagedVM<BookVM>>(_httpClientFactory, _userLogined, endpoint);
            return result;
        }
    }
}