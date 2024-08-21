using Newtonsoft.Json;
using System.Drawing.Printing;
using System.Net.Http.Headers;
using System.Net.Http;
using X.PagedList;
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

        public static async Task<T> RequestHttpPost<T, Dto>(IHttpClientFactory httpClientFactory, UserLogined userLogined, string endpoint, Dto model)
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
    }
}
