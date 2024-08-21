using FahasaStoreAPI.Models.Entities;
using FahasaStoreApp.Base.Interfaces;
using FahasaStoreApp.Models.DTOs;
using FahasaStoreApp.Models.DTOs.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace FahasaStoreApp.Components
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly IMemoryCache _cache;
        private readonly IBaseService<Category, CategoryCreateDto, CategoryEditDto, int> _categoryService;
        private readonly IBaseService<Subcategory, SubcategoryCreateDto, SubcategoryEditDto, int> _subcategoryService;

        public HeaderViewComponent(
            IMemoryCache cache,
            IBaseService<Category, CategoryCreateDto, CategoryEditDto, int> categoryService,
            IBaseService<Subcategory, SubcategoryCreateDto, SubcategoryEditDto, int> subcategoryService
        )
        {
            _cache = cache;
            _categoryService = categoryService;
            _subcategoryService = subcategoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            const string cacheKey = "CategoriesWithSubcategories";
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<Category>? data) || data == null)
            {
                // Fetch data from API
                data = await RenderCategories();
                // Set cache options
                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromMinutes(60),
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1)
                };
                _cache.Set(cacheKey, data, cacheEntryOptions);
            }
            ViewData["categories"] = data;
            return View("Header");
        }

        private async Task<IEnumerable<Category>> RenderCategories()
        {
            var categoryFilter = await _categoryService.Filter(new FilterOptions
            {
                AttributeCollectionInclude = new List<AttributeCollection>
                {
                    new AttributeCollection {AttributeCollectionName = "Subcategories", take = 50}
                }
            });
            var categories = categoryFilter.Paged.Items;
            return categories;
        }
    }
}
