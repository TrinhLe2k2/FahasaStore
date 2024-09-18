using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.ViewModels;
using FahasaStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FahasaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FahasaStoreController : ControllerBase
    {
        private readonly IFahasaStoreService _fahasaStoreService;

        public FahasaStoreController(IFahasaStoreService fahasaStoreService)
        {
            _fahasaStoreService = fahasaStoreService;
        }

        [HttpGet("FlashSaleToday")]
        public async Task<ActionResult> FlashSaleToday(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _fahasaStoreService.FlashSaleTodayAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpGet("TrendingBooks")]
        public async Task<ActionResult> TrendingBooks(string trendingBy = "Daily", int pageNumber = 1, int pageSize = 10)
        {
            var result = await _fahasaStoreService.TrendingBooks(trendingBy, pageNumber, pageSize);
            return Ok(result);
        }

        [HttpGet("TopSellingBooksByCategory")]
        public async Task<ActionResult> TopSellingBooksByCategory(int categoryId = 0, int pageNumber = 1, int pageSize = 10)
        {
            var result = await _fahasaStoreService.TopSellingBooksByCategory(categoryId, pageNumber, pageSize);
            return Ok(result);
        }

        [HttpGet("FindSimilarBooks")]
        public async Task<ActionResult> FindSimilarBooks(int bookId, int pageNumber = 1, int pageSize = 10)
        {
            var result = await _fahasaStoreService.FindSimilarBooks(bookId, pageNumber, pageSize);
            return Ok(result);
        }

        [HttpPost("FindSimilarBooksBasedOnCart")]
        public async Task<ActionResult> FindSimilarBooksBasedOnCart(List<int> bookIdInCart, int pageNumber = 1, int pageSize = 10, string aggregationMethod = "average")
        {
            var result = await _fahasaStoreService.FindSimilarBooksBasedOnCart(bookIdInCart, pageNumber, pageSize, aggregationMethod);
            return Ok(result);
        }

        [HttpGet("DataOptionsFilterBook")]
        public async Task<ActionResult> DataOptionsFilterBook()
        {
            var result = await _fahasaStoreService.DataOptionsFilterBook();
            return Ok(result);
        }

        [HttpPost("FilterBook")]
        public async Task<ActionResult> FilterBook(OptionsFilterBook optionsFilterBook)
        {
            var result = await _fahasaStoreService.FilterBook(optionsFilterBook);
            return Ok(result);
        }

        [HttpGet("DataForHomeIndex")]
        public async Task<ActionResult> DataForHomeIndex(int numBanner = 10, int numMenu = 10, int numFS = 10, int numTrend = 10, int numCategory = 10, int numTopSelling = 10, int numPartner = 10)
        {
            var userId = User.FindFirst(c => c.Type == "UserId")?.Value;
            var result = new HomeIndexVM();
            if (string.IsNullOrEmpty(userId))
            {
                result = await _fahasaStoreService.DataForHomeIndex(numBanner, numMenu, numFS, numTrend, numCategory, numTopSelling, numPartner, null);
            }
            else
            {
                result = await _fahasaStoreService.DataForHomeIndex(numBanner, numMenu, numFS, numTrend, numCategory, numTopSelling, numPartner, int.Parse(userId));
            }

            return Ok(result);
        }

        [HttpGet("DataForHomeProduct")]
        public async Task<ActionResult> DataForHomeProduct(int bookId)
        {
            var result = await _fahasaStoreService.DataForHomeProduct(bookId);
            return Ok(result);
        }

        [HttpGet("VoucherDetailsById")]
        public async Task<ActionResult> VoucherDetails(int voucherId)
        {
            var result = await _fahasaStoreService.GetVoucherDetailsByIdAsync(voucherId);
            return Ok(result);
        }

        [HttpGet("ApplyVoucher")]
        public async Task<ActionResult> ApplyVoucher(string code, int intoMoney)
        {
            var result = await _fahasaStoreService.ApplyVoucherAsync(code, intoMoney);
            return Ok(result);
        }

        [HttpGet("GetVouchers")]
        public async Task<IActionResult> GetVouchers(int pageNumber = 1, int pageSize = 10, int intoMoney = 0)
        {
            var result = await _fahasaStoreService.GetVouchersAsync(pageNumber, pageSize, intoMoney);
            return Ok(result);
        }

        [HttpGet("ProductReviews")]
        public async Task<IActionResult> ProductReviews(int bookId, int pageNumber = 1, int pageSize = 10)
        {
            var result = await _fahasaStoreService.ProductReviews(bookId, pageNumber, pageSize);
            return Ok(result);
        }

        [HttpGet("DataForHomeLayout")]
        public async Task<IActionResult> DataForHomeLayout(int numCategory = 10, int numPlatform = 10, int numTopic = 10)
        {
            var result = await _fahasaStoreService.DataForHomeLayout(numCategory, numPlatform, numTopic);
            return Ok(result);
        }

        [HttpGet("GetPaymentMethods")]
        public async Task<IActionResult> GetPaymentMethods(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _fahasaStoreService.GetPaymentMethodsAsync(pageNumber, pageSize);
            return Ok(result);
        }

        
    }
}
