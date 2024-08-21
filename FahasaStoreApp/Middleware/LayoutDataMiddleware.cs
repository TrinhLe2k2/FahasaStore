using FahasaStoreAPI.Models.Entities;
using FahasaStoreApp.Base.Interfaces;
using FahasaStoreApp.Helpers;
using FahasaStoreApp.Models.DTOs;
using FahasaStoreApp.Models.DTOs.Entities;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Caching.Memory;
using System;

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
            context.Items["Categories"] = await GetData<Category>(
                    "Categories",
                    new FilterOptions
                    {
                        AttributeCollectionInclude = new List<AttributeCollection>
                        {
                            new AttributeCollection { AttributeCollectionName = "Subcategories", take = 50 }
                        }
                    }
                );

            var web = await GetData<Website>("Website",
                    new FilterOptions
                    {
                        PageSize = 1
                    }
                );

            context.Items["Website"] = web.LastOrDefault();

            context.Items["Platforms"] = await GetData<FahasaStoreAPI.Models.Entities.Platform>(
                    "Platforms",
                    new FilterOptions
                    {
                        PageSize = 5
                    }
                );

            context.Items["Topics"] = await GetData<Topic>(
                    "Topics",
                    new FilterOptions
                    {
                        AttributeCollectionInclude = new List<AttributeCollection>
                        {
                            new AttributeCollection { AttributeCollectionName = "TopicContents", take = 5 }
                        },
                        PageSize = 4
                    }
                );

            await _next(context);
        }

        public async Task<IEnumerable<T>> GetData<T>(string cacheKey, FilterOptions filterOptions) where T : class
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dataService = scope.ServiceProvider.GetRequiredService<IBaseService<T, T, T, int>>();

                if (!_cache.TryGetValue(cacheKey, out IEnumerable<T>? data) || data == null)
                {
                    var dataFilter = await dataService.Filter(filterOptions);

                    data = dataFilter.Paged.Items;
                    _cache.Set(cacheKey, data, TimeSpan.FromHours(1));
                }
                return data;
            }
        }
    }
}
