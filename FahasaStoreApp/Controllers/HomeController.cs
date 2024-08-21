using FahasaStoreAPI.Models.Entities;
using FahasaStoreApp.Base.Interfaces;
using FahasaStoreApp.Constants;
using FahasaStoreApp.Models.DTOs;
using FahasaStoreApp.Models.DTOs.Entities;
using FahasaStoreApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBaseService<Banner, CategoryCreateDto, CategoryEditDto, int> _bannerService;
        private readonly IBaseService<Menu, CategoryCreateDto, CategoryEditDto, int> _menuService;
        private readonly IBaseService<Category, SubcategoryCreateDto, SubcategoryEditDto, int> _categoryService;
        private readonly IBaseService<Partner, SubcategoryCreateDto, SubcategoryEditDto, int> _partnerService;
        private readonly IBookService _bookService;
        private readonly IFahasaStoreService _fahasaStoreService;

        public HomeController(
            IBaseService<Banner, CategoryCreateDto, CategoryEditDto, int> bannerService,
            IBaseService<Menu, CategoryCreateDto, CategoryEditDto, int> menuService,
            IBaseService<Category, SubcategoryCreateDto, SubcategoryEditDto, int> categoryService,
            IBaseService<Partner, SubcategoryCreateDto, SubcategoryEditDto, int> partnerService,
            IBookService bookService,
            IFahasaStoreService fahasaStoreService
            )
        {
            _bannerService = bannerService;
            _menuService = menuService;
            _categoryService = categoryService;
            _partnerService = partnerService;
            _bookService = bookService;
            _fahasaStoreService = fahasaStoreService;
        }

        public async Task<IActionResult> Index()
        {
            var bannersFilter = await _bannerService.Filter(new FilterOptions { PageSize = 15});
            ViewData["banners"] = bannersFilter.Paged.Items;

            var menuFilter = await _menuService.Filter(new FilterOptions { PageSize = 20 });
            ViewData["menu"] = menuFilter.Paged.Items;

            var flashSaleToday = await _fahasaStoreService.FlashSaleTodayAsync(1, 50);
            ViewData["flashSaleToday"] = flashSaleToday;

            var trendOfMonth = await _fahasaStoreService.TrendingBooks(TrendingBy.Monthly, 1, 10);
            var trendOfYear = await _fahasaStoreService.TrendingBooks(TrendingBy.Yearly, 1, 10);

            ViewData["trendOfMonth"] = trendOfMonth.Items;
            ViewData["trendOfYear"] = trendOfYear.Items;

            var categories = await _categoryService.Filter(new FilterOptions { });
            ViewData["categories"] = categories.Paged.Items;

            var topSellingBooksByCategory = await _fahasaStoreService.TopSellingBooksByCategory(categories.Paged.Items.First().Id, 1, 5);
            ViewData["topSellingBooksByCategory"] = topSellingBooksByCategory.Items;

            var partners = await _partnerService.Filter(new FilterOptions { PageSize = 30 });
            ViewData["partners"] = partners.Paged.Items;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> TopSellingBooksByCategory(int id)
        {
            var topSellingBooksByCategory = await _fahasaStoreService.TopSellingBooksByCategory(id, 1, 5);
            ViewData["TopSellingBooksByCategory"] = topSellingBooksByCategory.Items;
            return PartialView();
        }
    }
}
