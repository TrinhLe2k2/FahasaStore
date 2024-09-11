using FahasaStoreAPI.Models.Entities;
using FahasaStoreApp.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace FahasaStoreApp.Components
{
    //public class HeaderViewComponent : ViewComponent
    //{
    //    private readonly IMemoryCache _cache;
    //    private readonly IBaseService<Category, CategoryVM> _categoryService;
    //    private readonly IBaseService<Subcategory, SubcategoryVM> _subcategoryService;

    //    public HeaderViewComponent(
    //        IMemoryCache cache,
    //        IBaseService<Category, CategoryVM> categoryService,
    //        IBaseService<Subcategory, SubcategoryVM> subcategoryService
    //    )
    //    {
    //        _cache = cache;
    //        _categoryService = categoryService;
    //        _subcategoryService = subcategoryService;
    //    }

    //    public async Task<IViewComponentResult> InvokeAsync()
    //    {
    //        const string cacheKey = "CategoriesWithSubcategories";
    //        if (!_cache.TryGetValue(cacheKey, out IEnumerable<CategoryVM>? data) || data == null)
    //        {
    //            // Fetch data from API
    //            data = await RenderCategories();
    //            // Set cache options
    //            var cacheEntryOptions = new MemoryCacheEntryOptions
    //            {
    //                SlidingExpiration = TimeSpan.FromMinutes(60),
    //                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1)
    //            };
    //            _cache.Set(cacheKey, data, cacheEntryOptions);
    //        }
    //        ViewData["categories"] = data;
    //        return View("Header");
    //    }

    //    private async Task<IEnumerable<CategoryVM>> RenderCategories()
    //    {
    //        var categoryFilter = await _categoryService.FilterAsync(new FilterOptions());
    //        var categories = categoryFilter.Paged.Items;
    //        return categories;
    //    }
    //}
}
