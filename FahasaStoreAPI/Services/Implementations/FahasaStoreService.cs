using FahasaStoreAPI.Constants;
using FahasaStoreAPI.Helpers;
using FahasaStoreAPI.Models.ViewModels;
using FahasaStoreAPI.Models.ViewModels.Entities;
using FahasaStoreAPI.Repositories.Interfaces;
using FahasaStoreAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace FahasaStoreAPI.Services.Implementations
{
    public class FahasaStoreService : IFahasaStoreService
    {
        private readonly IFahasaStoreRepository _fahasaStoreRepository;

        public FahasaStoreService(IFahasaStoreRepository fahasaStoreRepository)
        {
            _fahasaStoreRepository = fahasaStoreRepository;
        }

        public async Task<FlashSaleVM?> FlashSaleTodayAsync(int pageNumber, int pageSize)
        {
            return await _fahasaStoreRepository.FlashSaleTodayAsync(pageNumber, pageSize);
        }

        public async Task<PagedVM<BookVM>> TrendingBooks(string trendingBy, int pageNumber, int pageSize)
        {
            var pageListBooks = await _fahasaStoreRepository.TrendingBooks(trendingBy, pageNumber, pageSize);
            var result = MethodsHelper.GetPagedAsync(pageListBooks);
            return result;
        }

        public async Task<PagedVM<BookVM>> TopSellingBooksByCategory(int categoryId, int pageNumber, int pageSize)
        {
            var pageListBooks = await _fahasaStoreRepository.TopSellingBooksByCategory(categoryId, pageNumber, pageSize);
            var result = MethodsHelper.GetPagedAsync(pageListBooks);
            return result;
        }
    }
}
