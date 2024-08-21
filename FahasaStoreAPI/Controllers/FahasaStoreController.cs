using FahasaStoreAPI.Base.Implementations;
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
    }
}
