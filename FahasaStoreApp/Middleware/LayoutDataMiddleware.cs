using FahasaStoreAPI.Models.Entities;
using FahasaStoreApp.Base.Interfaces;
using FahasaStoreApp.Models.DTOs;
using FahasaStoreApp.Models.Interfaces;
using FahasaStoreApp.Models.ViewModels.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace FahasaStoreApp.Middleware
{
    public class LayoutDataMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache _cache;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public LayoutDataMiddleware(RequestDelegate next, IMemoryCache cache, IServiceScopeFactory serviceScopeFactory)
        {
            _next = next;
            _cache = cache;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Items["Categories"] = await GetData<Category, CategoryVM>("Categories", new FilterOptions());

            var web = await GetData<Website, WebsiteVM>("Website", new FilterOptions { PageSize = 1 });

            context.Items["Website"] = web.LastOrDefault();

            context.Items["Platforms"] = await GetData<FahasaStoreAPI.Models.Entities.Platform, PlatformVM>(
                    "Platforms", new FilterOptions { PageSize = 5 });

            context.Items["Topics"] = await GetData<Topic, TopicVM>(
                    "Topics", new FilterOptions { PageSize = 4 } );

            await _next(context);
        }

        public async Task<IEnumerable<TViewModel>> GetData<T, TViewModel>(string cacheKey, FilterOptions filterOptions) 
            where T : class
            where TViewModel : class, IEntity<int>
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dataService = scope.ServiceProvider.GetRequiredService<IBaseService<T, TViewModel>>();
                if (!_cache.TryGetValue(cacheKey, out IEnumerable<TViewModel>? data) || data == null)
                {
                    var dataFilter = await dataService.FilterAsync(filterOptions);
                    data = dataFilter.Paged.Items;
                    _cache.Set(cacheKey, data, TimeSpan.FromHours(1));
                }
                return data;
            }
        }
    }
}
