using Humanizer;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace FahasaStoreApp.Helpers
{
    public interface IMethodsHelper
    {
        Task<T> RequestHttpGet<T>(IHttpClientFactory httpClientFactory, string endpoint, string endpointAnother = "");
        Task<T> RequestHttpPost<T, TModel>(IHttpClientFactory httpClientFactory, string endpoint, TModel model, string endpointAnother = "");
        Task<T> RequestHttpDelete<T>(IHttpClientFactory httpClientFactory, string endpoint, string endpointAnother = "");
        Task<T> RequestHttpPut<T, TModel>(IHttpClientFactory httpClientFactory, string endpoint, TModel model, string endpointAnother = "");
        string PluralizeWord<T>();
    }
    public class MethodsHelper : IMethodsHelper
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string? token;

        public MethodsHelper(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            token = _httpContextAccessor.HttpContext?.Request.Cookies["AccessToken"];
        }

        public async Task<T> RequestHttpGet<T>(IHttpClientFactory httpClientFactory, string endpoint, string endpointAnother = "")
        {
            using (var httpClient = httpClientFactory.CreateClient())
            {
                if (string.IsNullOrEmpty(endpointAnother))
                {
                    endpoint = _configuration["AppSettings:EndPointApi"] + endpoint;
                }
                else
                {
                    endpoint = endpointAnother;
                }
                
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await httpClient.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<T>(content);
                return data ?? throw new Exception("Received null data from API.");
            }
        }

        public async Task<T> RequestHttpPost<T, TModel>(IHttpClientFactory httpClientFactory, string endpoint, TModel model, string endpointAnother = "")
        {
            using (var httpClient = httpClientFactory.CreateClient())
            {
                if (string.IsNullOrEmpty(endpointAnother))
                {
                    endpoint = _configuration["AppSettings:EndPointApi"] + endpoint;
                }
                else
                {
                    endpoint = endpointAnother;
                }

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(endpoint, content);
                response.EnsureSuccessStatusCode();
                var readResponse = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<T>(readResponse);
                return data ?? throw new Exception("Received null data from API.");
            }
        }

        public async Task<T> RequestHttpDelete<T>(IHttpClientFactory httpClientFactory, string endpoint, string endpointAnother = "")
        {
            using (var httpClient = httpClientFactory.CreateClient())
            {
                if (string.IsNullOrEmpty(endpointAnother))
                {
                    endpoint = _configuration["AppSettings:EndPointApi"] + endpoint;
                }
                else
                {
                    endpoint = endpointAnother;
                }

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await httpClient.DeleteAsync(endpoint);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<T>(responseContent);
                return data ?? throw new Exception("Received null data from API.");
            }
        }

        public async Task<T> RequestHttpPut<T, TModel>(IHttpClientFactory httpClientFactory, string endpoint, TModel model, string endpointAnother = "")
        {
            using (var httpClient = httpClientFactory.CreateClient())
            {
                if (string.IsNullOrEmpty(endpointAnother))
                {
                    endpoint = _configuration["AppSettings:EndPointApi"] + endpoint;
                }
                else
                {
                    endpoint = endpointAnother;
                }

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(endpoint, content);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<T>(responseContent);
                return data ?? throw new Exception("Received null data from API.");
            }
        }

        public string PluralizeWord<T>()
        {
            var entityTypeName = typeof(T).Name;
            var pluralName = entityTypeName.Pluralize();
            return pluralName;
        }
    }
}
