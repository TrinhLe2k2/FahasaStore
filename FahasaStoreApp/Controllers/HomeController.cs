using FahasaStoreAPI.Models.Entities;
using FahasaStoreApp.Base.Interfaces;
using FahasaStoreApp.Constants;
using FahasaStoreApp.Models.DTOs;
using FahasaStoreApp.Models.ViewModels;
using FahasaStoreApp.Models.ViewModels.Entities;
using FahasaStoreApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFahasaStoreService _fahasaStoreService;
        private readonly IBaseService<Banner, BannerVM> _bannerService;
        private readonly IBaseService<Menu, MenuVM> _menuService;
        private readonly IBaseService<Category, CategoryVM> _categoryService;
        private readonly IBaseService<Partner, PartnerVM> _partnerService;
        private readonly IBaseService<Book, BookVM> _bookService;
        private readonly IBaseService<Voucher, VoucherVM> _voucherService;
        private readonly IBaseService<Review, ReviewVM> _reviewService;

        public HomeController(
            IBaseService<Banner, BannerVM> bannerService, 
            IBaseService<Menu, MenuVM> menuService, 
            IBaseService<Category, CategoryVM> categoryService, 
            IBaseService<Partner, PartnerVM> partnerService, 
            IBaseService<Book, BookVM> bookService, 
            IBaseService<Voucher, VoucherVM> voucherService,
            IBaseService<Review, ReviewVM> reviewService,
            IFahasaStoreService fahasaStoreService)
        {
            _fahasaStoreService = fahasaStoreService;
            _bannerService = bannerService;
            _menuService = menuService;
            _categoryService = categoryService;
            _partnerService = partnerService;
            _bookService = bookService;
            _voucherService = voucherService;
            _reviewService = reviewService;
        }

        public async Task<IActionResult> Index()
        {
            var bannersFilter = await _bannerService.FilterAsync(new FilterOptions { PageSize = 15 });
            ViewData["banners"] = bannersFilter.Paged.Items;

            var menuFilter = await _menuService.FilterAsync(new FilterOptions { PageSize = 20 });
            ViewData["menu"] = menuFilter.Paged.Items;

            var flashSaleToday = await _fahasaStoreService.FlashSaleTodayAsync(1, 50);
            ViewData["flashSaleToday"] = flashSaleToday;

            var trendOfMonth = await _fahasaStoreService.TrendingBooks(TrendingBy.Monthly, 1, 10);
            var trendOfYear = await _fahasaStoreService.TrendingBooks(TrendingBy.Yearly, 1, 10);

            ViewData["trendOfMonth"] = trendOfMonth.Items;
            ViewData["trendOfYear"] = trendOfYear.Items;

            var categories = await _categoryService.FilterAsync(new FilterOptions { });
            ViewData["categories"] = categories.Paged.Items;

            var topSellingBooksByCategory = await _fahasaStoreService.TopSellingBooksByCategory(categories.Paged.Items.First().Id, 1, 5);
            ViewData["topSellingBooksByCategory"] = topSellingBooksByCategory.Items;

            var partners = await _partnerService.FilterAsync(new FilterOptions { PageSize = 30 });
            ViewData["partners"] = partners.Paged.Items;
            return View();
        }

        public async Task<IActionResult> Product(int id)
        {
            var product = await _bookService.GetByIdAsync(id);
            ViewData["Product"] = product;
            var vouchers = await _voucherService.FilterAsync(new FilterOptions { 
                Filters = new List<FilterItem>
                {
                    new FilterItem {TypeOfKey = "DateTime", Key = "StartDate", Value = DateTime.Now.ToString(), ComparisonOperator = ">="},
                    new FilterItem {TypeOfKey = "DateTime", Key = "EndDate", Value = DateTime.Now.ToString(), ComparisonOperator = "<="}
                },
                PageSize = 50
            });
            ViewData["Vouchers"] = vouchers.Paged.Items;

            var reviews = await _reviewService.FilterAsync(new FilterOptions
            {
                Filters = new List<FilterItem>
                {
                    new FilterItem {TypeOfKey = "int", Key = "BookId", Value = id.ToString(), ComparisonOperator = "="}
                },
                PageSize = 10,
               SortField = "CreatedAt"
            });
            ViewData["Reviews"] = reviews.Paged.Items;

            var similarBooks = await _fahasaStoreService.FindSimilarBooks(id, 1, 50);
            ViewData["SimilarBooks"] = similarBooks.Items;
            return View();
        }

        public async Task<IActionResult> Filter(OptionsFilterBook optionsFilterBook)
        {
            var dataOptionsFilterBook = await _fahasaStoreService.DataOptionsFilterBook();
            ViewData["DataOptionsFilterBook"] = dataOptionsFilterBook;
            var resultFilter = await _fahasaStoreService.FilterBook(optionsFilterBook);
            ViewData["ResultFilter"] = resultFilter;
            return View();
        }
    }
}
