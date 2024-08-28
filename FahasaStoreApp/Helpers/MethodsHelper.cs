using Humanizer;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace FahasaStoreApp.Helpers
{
    public static class MethodsHelper
    {
        public static async Task<T> RequestHttpGet<T>(IHttpClientFactory httpClientFactory, UserLogined userLogined, string endpoint)
        {
            using (var httpClient = httpClientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userLogined.JWToken);
                var response = await httpClient.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<T>(content);
                return data ?? throw new Exception("Received null data from API.");
            }
        }

        public static async Task<T> RequestHttpPost<T, TModel>(IHttpClientFactory httpClientFactory, UserLogined userLogined, string endpoint, TModel model)
        {
            using (var httpClient = httpClientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userLogined.JWToken);
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(endpoint, content);
                response.EnsureSuccessStatusCode();
                var readResponse = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<T>(readResponse);
                return data ?? throw new Exception("Received null data from API.");
            }
        }

        public static async Task<bool> RequestHttpDelete(IHttpClientFactory httpClientFactory, UserLogined userLogined, string endpoint)
        {
            using (var httpClient = httpClientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userLogined.JWToken);
                var response = await httpClient.DeleteAsync(endpoint);
                response.EnsureSuccessStatusCode();
                return response.IsSuccessStatusCode;
            }
        }

        public static async Task<T> RequestHttpPut<T>(IHttpClientFactory httpClientFactory, UserLogined userLogined, string endpoint, T model)
        {
            using (var httpClient = httpClientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userLogined.JWToken);
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(endpoint, content);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<T>(responseContent);
                return data ?? throw new Exception("Received null data from API.");
            }
        }

        public static string PluralizeWord<T>()
        {
            var entityTypeName = typeof(T).Name;
            var pluralName = entityTypeName.Pluralize();
            return pluralName;
        }
    }
}
