using FahasaStore.Models;
using FahasaStoreAPI.Models.ViewModels;
using FahasaStoreAPI.Repositories.Interfaces;
using FahasaStoreAPI.Services.Interfaces;

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

        public async Task<FlashSaleDetail?> FlashSaleTodayAsync(int pageNumber, int pageSize)
        {
            return await _fahasaStoreRepository.FlashSaleTodayAsync(pageNumber, pageSize);
        }
        public async Task<PagedVM<BookExtend>> TrendingBooks(string trendingBy, int pageNumber, int pageSize)
        {
            var result = await _fahasaStoreRepository.TrendingBooks(trendingBy, pageNumber, pageSize);
            return result;
        }
        public async Task<PagedVM<BookExtend>> TopSellingBooksByCategory(int categoryId, int pageNumber, int pageSize)
        {
            var result = await _fahasaStoreRepository.TopSellingBooksByCategory(categoryId, pageNumber, pageSize);
            return result;
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
        public async Task<HomeIndexVM> DataForHomeIndex(int numBanner, int numMenu, int numFS, int numTrend, int numCategory, int numTopSelling, int numPartner)
        {
            var result = await _fahasaStoreRepository.DataForHomeIndex(numBanner, numMenu, numFS, numTrend, numCategory, numTopSelling, numPartner);
            return result;
        }
        public async Task<VoucherExtend?> GetVoucherDetailsByIdAsync(int voucherId)
        {
            var result = await _fahasaStoreRepository.GetVoucherDetailsByIdAsync(voucherId);
            return result;
        }
        public async Task<VoucherExtend?> ApplyVoucherAsync(string code, int intoMoney)
        {
            var result = await _fahasaStoreRepository.ApplyVoucherAsync(code, intoMoney);
            return result;
        }
        public async Task<PagedVM<VoucherExtend>> GetVouchersAsync(int pageNumber, int pageSize, int intoMoney = 0)
        {
            return await _fahasaStoreRepository.GetVouchersAsync(pageNumber, pageSize, intoMoney);
        }

        public async Task<HomeProductVM> DataForHomeProduct(int bookId)
        {
            return await _fahasaStoreRepository.DataForHomeProduct(bookId);
        }

        public async Task<PagedVM<ReviewExtend>> ProductReviews(int bookId, int pageNumber, int pageSize)
        {
            return await _fahasaStoreRepository.ProductReviews(bookId, pageNumber, pageSize);
        }

        public async Task<HomeLayoutVM> DataForHomeLayout(int numCategory, int numPlatform, int numTopic)
        {
            return await _fahasaStoreRepository.DataForHomeLayout(numCategory, numPlatform, numTopic);
        }

        public async Task<PagedVM<PaymentMethodExtend>> GetPaymentMethodsAsync(int pageNumber, int pageSize)
        {
            return await _fahasaStoreRepository.GetPaymentMethodsAsync(pageNumber, pageSize);
        }

        public async Task<PagedVM<BookExtend>> FindSimilarBooks(int bookId, int pageNumber, int pageSize)
        {
            return await _bookRecommendationSystem.FindSimilarBooks(bookId, pageNumber, pageSize);
        }
        public async Task<PagedVM<BookExtend>> FindSimilarBooksBasedOnCart(List<int> bookIdInCart, int pageNumber, int pageSize, string aggregationMethod = "average")
        {
            return await _bookRecommendationSystem.FindSimilarBooksBasedOnCart(bookIdInCart, pageNumber, pageSize, aggregationMethod);
        }
    }
}
