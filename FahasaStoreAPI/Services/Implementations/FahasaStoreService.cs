using FahasaStoreAPI.Constants;
using FahasaStoreAPI.Helpers;
using FahasaStoreAPI.Models.DTOs.Entities;
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
        private readonly IBookRecommendationSystem _bookRecommendationSystem;

        public FahasaStoreService(IFahasaStoreRepository fahasaStoreRepository, IBookRecommendationSystem bookRecommendationSystem)
        {
            _fahasaStoreRepository = fahasaStoreRepository;
            _bookRecommendationSystem = bookRecommendationSystem;
        }

        public async Task<FlashSaleVM?> FlashSaleTodayAsync(int pageNumber, int pageSize)
        {
            return await _fahasaStoreRepository.FlashSaleTodayAsync(pageNumber, pageSize);
        }

        public async Task<PagedVM<BookDto>> TrendingBooks(string trendingBy, int pageNumber, int pageSize)
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

        public async Task<PagedVM<BookDto>> FindSimilarBooks(int bookId, int pageNumber, int pageSize)
        {
            return await _bookRecommendationSystem.FindSimilarBooks(bookId, pageNumber, pageSize);
        }
        public async Task<PagedVM<BookDto>> FindSimilarBooksBasedOnCart(List<int> bookIdInCart, int pageNumber, int pageSize, string aggregationMethod = "average")
        {
            return await _bookRecommendationSystem.FindSimilarBooksBasedOnCart(bookIdInCart, pageNumber, pageSize, aggregationMethod);
        }

        public async Task<DataOptionsFilterBook> DataOptionsFilterBook()
        {
            var result = await _fahasaStoreRepository.DataOptionsFilterBook();
            return result;
        }

        public async Task<ResultFilterBook> FilterBook(OptionsFilterBook optionsFilterBook)
        {
            var result = await _fahasaStoreRepository.FilterBook(optionsFilterBook);
            return result;
        }
    }
}
