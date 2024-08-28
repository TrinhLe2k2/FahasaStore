using FahasaStoreAPI.Base.Implementations;
using FahasaStoreAPI.Models.DTOs.Entities;
using FahasaStoreAPI.Models.ViewModels;
using FahasaStoreAPI.Models.ViewModels.Entities;
using FahasaStoreAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<FlashSaleVM?>> FlashSaleToday(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _fahasaStoreService.FlashSaleTodayAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpGet("TrendingBooks")]
        public async Task<ActionResult<PagedVM<BookVM>>> TrendingBooks(string trendingBy = "Daily", int pageNumber = 1, int pageSize = 10)
        {
            var result = await _fahasaStoreService.TrendingBooks(trendingBy, pageNumber, pageSize);
            return Ok(result);
        }

        [HttpGet("TopSellingBooksByCategory")]
        public async Task<ActionResult<PagedVM<BookVM>>> TopSellingBooksByCategory(int categoryId = 0, int pageNumber = 1, int pageSize = 10)
        {
            var result = await _fahasaStoreService.TopSellingBooksByCategory(categoryId, pageNumber, pageSize);
            return Ok(result);
        }

        [HttpGet("FindSimilarBooks")]
        public async Task<ActionResult<PagedVM<BookDto>>> FindSimilarBooks(int bookId, int pageNumber = 1, int pageSize = 10)
        {
            var result = await _fahasaStoreService.FindSimilarBooks(bookId, pageNumber, pageSize);
            return Ok(result);
        }

        [HttpPost("FindSimilarBooksBasedOnCart")]
        public async Task<ActionResult<PagedVM<BookDto>>> FindSimilarBooksBasedOnCart(List<int> bookIdInCart, int pageNumber = 1, int pageSize = 10, string aggregationMethod = "average")
        {
            var result = await _fahasaStoreService.FindSimilarBooksBasedOnCart(bookIdInCart, pageNumber, pageSize, aggregationMethod);
            return Ok(result);
        }

        [HttpGet("DataOptionsFilterBook")]
        public async Task<DataOptionsFilterBook> DataOptionsFilterBook()
        {
            var result = await _fahasaStoreService.DataOptionsFilterBook();
            return result;
        }

        [HttpPost("FilterBook")]
        public async Task<ResultFilterBook> FilterBook(OptionsFilterBook optionsFilterBook)
        {
            var result = await _fahasaStoreService.FilterBook(optionsFilterBook);
            return result;
        }
    }
}
