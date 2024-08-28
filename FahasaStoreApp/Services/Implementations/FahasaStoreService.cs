using FahasaStoreApp.Helpers;
using FahasaStoreApp.Models.ViewModels.Entities;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using FahasaStoreApp.Services.Interfaces;
using static System.Net.WebRequestMethods;
using FahasaStoreApp.Models.ViewModels;
using System.Drawing.Printing;
using Microsoft.AspNetCore.Mvc;
using FahasaStoreApp.Models.DTOs.Entities;

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

        public async Task<PagedVM<BookDto>> TrendingBooks(string trendingBy, int pageNumber, int pageSize)
        {
            var endpoint = $"https://localhost:7094/api/FahasaStore/TrendingBooks?trendingBy={trendingBy}&pageNumber={pageNumber}&pageSize={pageSize}";
            var result = await MethodsHelper.RequestHttpGet<PagedVM<BookDto>>(_httpClientFactory, _userLogined, endpoint);
            return result;
        }

        public async Task<PagedVM<BookVM>> TopSellingBooksByCategory(int categoryId, int pageNumber, int pageSize)
        {
            var endpoint = $"https://localhost:7094/api/FahasaStore/TopSellingBooksByCategory?categoryId={categoryId}&pageNumber={pageNumber}&pageSize={pageSize}";
            var result = await MethodsHelper.RequestHttpGet<PagedVM<BookVM>>(_httpClientFactory, _userLogined, endpoint);
            return result;
        }

        public async Task<PagedVM<BookDto>> FindSimilarBooks(int bookId, int pageNumber = 1, int pageSize = 10)
        {
            var endpoint = $"https://localhost:7094/api/FahasaStore/FindSimilarBooks?bookId={bookId}&pageNumber={pageNumber}&pageSize={pageSize}";
            var result = await MethodsHelper.RequestHttpGet<PagedVM<BookDto>>(_httpClientFactory, _userLogined, endpoint);
            return result;
        }

        public async Task<PagedVM<BookDto>> FindSimilarBooksBasedOnCart(List<int> bookIdInCart, int pageNumber = 1, int pageSize = 10, string aggregationMethod = "average")
        {
            var requestData = new
            {
                BookIdInCart = bookIdInCart,
                PageNumber = pageNumber,
                PageSize = pageSize,
                AggregationMethod = aggregationMethod
            };

            var endpoint = $"https://localhost:7094/api/FahasaStore/FindSimilarBooksBasedOnCart";
            var result = await MethodsHelper.RequestHttpPost<PagedVM<BookDto>, Object>(_httpClientFactory, _userLogined, endpoint, requestData);
            return result;
        }

        public async Task<DataOptionsFilterBook> DataOptionsFilterBook()
        {
            var endpoint = $"https://localhost:7094/api/FahasaStore/DataOptionsFilterBook";
            var result = await MethodsHelper.RequestHttpGet<DataOptionsFilterBook>(_httpClientFactory, _userLogined, endpoint);
            return result;
        }

        public async Task<ResultFilterBook> FilterBook(OptionsFilterBook optionsFilterBook)
        {
            var endpoint = $"https://localhost:7094/api/FahasaStore/FilterBook";
            var result = await MethodsHelper.RequestHttpPost<ResultFilterBook, OptionsFilterBook>(_httpClientFactory, _userLogined, endpoint, optionsFilterBook);
            return result;
        }
    }
}