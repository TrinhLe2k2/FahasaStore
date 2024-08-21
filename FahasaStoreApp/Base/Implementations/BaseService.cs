using FahasaStoreApp.Base.Interfaces;
using FahasaStoreApp.Models.DTOs;
using FahasaStoreApp.Models.ViewModels;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using FahasaStoreApp.Helpers;
using AutoMapper;
using System.Net.Http;
using System.Reflection;
using Humanizer;
using FahasaStoreAPI.Models.Interfaces;

namespace FahasaStoreApp.Base.Implementations
{
    public class BaseService<TEntity, TCreateDto, TEditDto, TKey> : IBaseService<TEntity, TCreateDto, TEditDto, TKey>
        where TEntity : class, IEntity<TKey>
        where TCreateDto : class
        where TEditDto : class
        where TKey : IEquatable<TKey>
    {
        protected readonly IHttpClientFactory _httpClientFactory;
        protected readonly UserLogined _userLogined;
        protected readonly string _api;

        public BaseService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
        {
            _httpClientFactory = httpClientFactory;
            _userLogined = userLogined;
            _api = $"https://localhost:7094/api/{GetEntityPluralName()}";
        }

        public virtual async Task<TEntity> CreateAsync(TCreateDto model)
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _userLogined.JWToken);
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync($"{_api}", content);
                response.EnsureSuccessStatusCode();
                var createdContent = await response.Content.ReadAsStringAsync();

                var created = JsonConvert.DeserializeObject<TEntity>(createdContent);

                if (created == null)
                {
                    throw new Exception("Error: Failed to create entity.");
                }

                return created;
            }
        }

        public virtual async Task<bool> Delete(TKey id)
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _userLogined.JWToken);
                var response = await httpClient.DeleteAsync($"{_api}/{id}");
                response.EnsureSuccessStatusCode();
                return response.IsSuccessStatusCode;
            }
        }

        public virtual async Task<TEntity> Details(TKey id)
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _userLogined.JWToken);
                var response = await httpClient.GetAsync($"{_api}/{id}");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<TEntity>(content);
                return data ?? throw new Exception("Received null data from API.");
            }
        }

        public virtual async Task<FilterVM<TEntity>> Filter(FilterOptions filterOptions)
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _userLogined.JWToken);
                var content = new StringContent(JsonConvert.SerializeObject(filterOptions), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync($"{_api}/filter", content);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<FilterVM<TEntity>>(responseContent);
                return data ?? throw new Exception("Received null data from API.");
            }
        }

        //public virtual async Task<FilterVM<TEntity>> Filter(FilterOptions filterOptions)
        //{
        //    using (var httpClient = _httpClientFactory.CreateClient())
        //    {
        //        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _userLogined.JWToken);

        //        // Xây dựng query string từ FilterOptions
        //        var query = new List<string>();
        //        for (int i = 0; i < filterOptions.Filters.Count; i++)
        //        {
        //            query.Add($"filters[{i}].key={filterOptions.Filters[i].Key}");
        //            query.Add($"filters[{i}].value={filterOptions.Filters[i].Value}");
        //        }
        //        query.Add($"sortField={filterOptions.SortField}");
        //        query.Add($"orderByDescending={filterOptions.OrderByDescending}");
        //        query.Add($"pageNumber={filterOptions.PageNumber}");
        //        query.Add($"pageSize={filterOptions.PageSize}");

        //        var queryString = string.Join("&", query);
        //        var requestUri = $"https://localhost:7094/api/Categories/filter?{queryString}";

        //        var response = await httpClient.GetAsync(requestUri);
        //        response.EnsureSuccessStatusCode();

        //        var responseContent = await response.Content.ReadAsStringAsync();
        //        var data = JsonConvert.DeserializeObject<FilterVM<TEntity>>(responseContent);
        //        return data ?? throw new Exception("Received null data from API.");
        //    }
        //}

        public virtual async Task<TEntity> Update(TKey id, TEditDto dto)
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _userLogined.JWToken);
                var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync($"{_api}/{id}", content);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                var updatedEntity = JsonConvert.DeserializeObject<TEntity>(responseContent);
                return updatedEntity ?? throw new Exception("Received null data from API.");
            }
        }

        private string GetEntityPluralName()
        {
            var entityTypeName = typeof(TEntity).Name;
            var pluralName = entityTypeName.Pluralize();
            return pluralName;
        }
    }
}
