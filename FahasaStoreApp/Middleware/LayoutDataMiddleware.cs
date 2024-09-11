using FahasaStore.Models;
using FahasaStoreApp.Models.ViewModels;
using FahasaStoreApp.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using NuGet.Common;

namespace FahasaStoreApp.Middleware
{
    public class LayoutDataMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache _cache;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LayoutDataMiddleware(RequestDelegate next, IMemoryCache cache, IServiceScopeFactory serviceScopeFactory, IHttpContextAccessor httpContextAccessor)
        {
            _next = next;
            _cache = cache;
            _serviceScopeFactory = serviceScopeFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var cacheKey = "DataForHomeLayout";
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dataService = scope.ServiceProvider.GetRequiredService<IFahasaStoreService>();
                if (!_cache.TryGetValue(cacheKey, out HomeLayoutVM? data) || data == null)
                {
                    var dataForHomeLayout = await dataService.DataForHomeLayout(10, 5, 4);
                    data = dataForHomeLayout;
                    _cache.Set(cacheKey, data, TimeSpan.FromHours(1));
                }
                context.Items["HomeLayout"] = data;
            }

            var userLoginer = _httpContextAccessor.HttpContext?.Request.Cookies["UserLoginer"];
            if (!string.IsNullOrEmpty(userLoginer))
            {
                var user = JsonConvert.DeserializeObject<AspNetUserDetail>(userLoginer);
                context.Items["UserLoginer"] = user;
            }

            await _next(context);
        }
    }
}
