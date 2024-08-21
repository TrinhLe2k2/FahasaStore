using FahasaStoreAPI.Models.Entities;
using FahasaStoreApp.Base.Implementations;
using FahasaStoreApp.Helpers;
using FahasaStoreApp.Models.DTOs;
using FahasaStoreApp.Models.ViewModels;
using FahasaStoreApp.Models.ViewModels.Entities;
using FahasaStoreApp.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace FahasaStoreApp.Services.Implementations
{
    public class BookService : BaseService<Book, Book, Book, int>, IBookService
    {
        public BookService(IHttpClientFactory httpClientFactory, UserLogined userLogined) : base(httpClientFactory, userLogined)
        {
        }

        async Task<BookVM?> IBookService.Details(int id)
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _userLogined.JWToken);
                var response = await httpClient.GetAsync($"{_api}/{id}");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<BookVM>(content);
                return data ?? throw new Exception("Received null data from API.");
            }
        }

        async Task<FilterVM<BookVM>> IBookService.Filter(FilterOptions filterOptions)
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _userLogined.JWToken);
                var content = new StringContent(JsonConvert.SerializeObject(filterOptions), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync($"{_api}/filter", content);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<FilterVM<BookVM>>(responseContent);
                return data ?? throw new Exception("Received null data from API.");
            }
        }
    }
}
