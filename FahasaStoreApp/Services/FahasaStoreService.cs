using FahasaStoreApp.Helpers;
using FahasaStoreApp.Models.ViewModels;
using FahasaStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreApp.Services
{
    public interface IFahasaStoreService
    {
        Task<FlashSaleDetail?> FlashSaleTodayAsync(int pageNumber, int pageSize);
        Task<PagedVM<BookExtend>> TrendingBooks(string trendingBy, int pageNumber, int pageSize);
        Task<PagedVM<BookExtend>> TopSellingBooksByCategory(int categoryId, int pageNumber, int pageSize);
        Task<DataOptionsFilterBook> DataOptionsFilterBook();
        Task<ResultFilterBook> FilterBook(OptionsFilterBook optionsFilterBook);
        Task<HomeIndexVM> DataForHomeIndex(int numBanner, int numMenu, int numFS, int numTrend, int numCategory, int numTopSelling, int numPartner);
        Task<VoucherExtend?> GetVoucherDetailsByIdAsync(int voucherId);
        Task<VoucherExtend?> ApplyVoucherAsync(string code, int intoMoney);
        Task<PagedVM<VoucherExtend>> GetVouchersAsync(int pageNumber, int pageSize, int intoMoney = 0);
        Task<HomeProductVM> DataForHomeProduct(int bookId);
        Task<PagedVM<ReviewExtend>> ProductReviews(int bookId, int pageNumber, int pageSize);
        Task<HomeLayoutVM> DataForHomeLayout(int numCategory, int numPlatform, int numTopic);
        Task<PagedVM<PaymentMethodExtend>> GetPaymentMethods(int pageNumber, int pageSize);

        Task<PagedVM<BookExtend>> FindSimilarBooks(int bookId, int pageNumber, int pageSize);
        Task<PagedVM<BookExtend>> FindSimilarBooksBasedOnCart(List<int> bookIdInCart, int pageNumber, int pageSize, string aggregationMethod);
    }

    public class FahasaStoreService : IFahasaStoreService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        protected readonly IMethodsHelper _methodsHelper;

        public FahasaStoreService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper)
        {
            _httpClientFactory = httpClientFactory;
            _methodsHelper = methodsHelper;
        }

        public async Task<HomeIndexVM> DataForHomeIndex(int numBanner, int numMenu, int numFS, int numTrend, int numCategory, int numTopSelling, int numPartner)
        {
            var endpoint = $"/FahasaStore/DataForHomeIndex?numBanner={numBanner}&numMenu={numMenu}&numFS={numFS}&numTrend={numTrend}&numCategory={numCategory}&numTopSelling={numTopSelling}&numPartner={numPartner}";
            var result = await _methodsHelper.RequestHttpGet<HomeIndexVM>(_httpClientFactory, endpoint);
            return result;
        }

        public async Task<HomeProductVM> DataForHomeProduct(int bookId)
        {
            var endpoint = $"/FahasaStore/DataForHomeProduct?bookId={bookId}";
            var result = await _methodsHelper.RequestHttpGet<HomeProductVM>(_httpClientFactory, endpoint);
            return result;
        }

        public async Task<HomeLayoutVM> DataForHomeLayout(int numCategory, int numPlatform, int numTopic)
        {
            var endpoint = $"/FahasaStore/DataForHomeLayout?numCategory={numCategory}&numPlatform={numPlatform}&numTopic={numTopic}";
            var result = await _methodsHelper.RequestHttpGet<HomeLayoutVM>(_httpClientFactory, endpoint);
            return result;
        }

        public async Task<FlashSaleDetail?> FlashSaleTodayAsync(int pageNumber, int pageSize)
        {
            var endpoint = $"/FahasaStore/FlashSaleToday?pageNumber={pageNumber}&pageSize={pageSize}";
            var result = await _methodsHelper.RequestHttpGet<FlashSaleDetail>(_httpClientFactory, endpoint);
            return result;
        }

        public async Task<PagedVM<BookExtend>> TrendingBooks(string trendingBy, int pageNumber, int pageSize)
        {
            var endpoint = $"/FahasaStore/TrendingBooks?trendingBy={trendingBy}&pageNumber={pageNumber}&pageSize={pageSize}";
            var result = await _methodsHelper.RequestHttpGet<PagedVM<BookExtend>>(_httpClientFactory, endpoint);
            return result;
        }

        public async Task<PagedVM<BookExtend>> TopSellingBooksByCategory(int categoryId, int pageNumber, int pageSize)
        {
            var endpoint = $"/FahasaStore/TopSellingBooksByCategory?categoryId={categoryId}&pageNumber={pageNumber}&pageSize={pageSize}";
            var result = await _methodsHelper.RequestHttpGet<PagedVM<BookExtend>>(_httpClientFactory, endpoint);
            return result;
        }

        public async Task<PagedVM<BookExtend>> FindSimilarBooks(int bookId, int pageNumber = 1, int pageSize = 10)
        {
            var endpoint = $"/FahasaStore/FindSimilarBooks?bookId={bookId}&pageNumber={pageNumber}&pageSize={pageSize}";
            var result = await _methodsHelper.RequestHttpGet<PagedVM<BookExtend>>(_httpClientFactory, endpoint);
            return result;
        }

        public async Task<PagedVM<BookExtend>> FindSimilarBooksBasedOnCart(List<int> bookIdInCart, int pageNumber = 1, int pageSize = 10, string aggregationMethod = "average")
        {
            var requestData = new
            {
                BookIdInCart = bookIdInCart,
                PageNumber = pageNumber,
                PageSize = pageSize,
                AggregationMethod = aggregationMethod
            };

            var endpoint = $"/FahasaStore/FindSimilarBooksBasedOnCart";
            var result = await _methodsHelper.RequestHttpPost<PagedVM<BookExtend>, Object>(_httpClientFactory, endpoint, requestData);
            return result;
        }

        public async Task<DataOptionsFilterBook> DataOptionsFilterBook()
        {
            var endpoint = $"/FahasaStore/DataOptionsFilterBook";
            var result = await _methodsHelper.RequestHttpGet<DataOptionsFilterBook>(_httpClientFactory, endpoint);
            return result;
        }

        public async Task<ResultFilterBook> FilterBook(OptionsFilterBook optionsFilterBook)
        {
            var endpoint = $"/FahasaStore/FilterBook";
            var result = await _methodsHelper.RequestHttpPost<ResultFilterBook, OptionsFilterBook>(_httpClientFactory, endpoint, optionsFilterBook);
            return result;
        }

        public async Task<VoucherExtend?> GetVoucherDetailsByIdAsync(int voucherId)
        {
            var endpoint = $"/FahasaStore/VoucherDetailsById?voucherId={voucherId}";
            var result = await _methodsHelper.RequestHttpGet<VoucherExtend?>(_httpClientFactory, endpoint);
            return result;
        }

        public async Task<VoucherExtend?> ApplyVoucherAsync(string code, int intoMoney)
        {
            var endpoint = $"/FahasaStore/ApplyVoucher?code={code}&intoMoney={intoMoney}";
            var result = await _methodsHelper.RequestHttpGet<VoucherExtend?>(_httpClientFactory, endpoint);
            return result;
        }

        public async Task<PagedVM<VoucherExtend>> GetVouchersAsync(int pageNumber, int pageSize, int intoMoney = 0)
        {
            var endpoint = $"/FahasaStore/GetVouchers?pageNumber={pageNumber}&pageSize={pageSize}&intoMoney={intoMoney}";
            var result = await _methodsHelper.RequestHttpGet<PagedVM<VoucherExtend>>(_httpClientFactory, endpoint);
            return result;
        }

        public async Task<PagedVM<ReviewExtend>> ProductReviews(int bookId, int pageNumber, int pageSize)
        {
            var endpoint = $"/FahasaStore/ProductReviews?bookId={bookId}&pageNumber={pageNumber}&pageSize={pageSize}";
            var result = await _methodsHelper.RequestHttpGet<PagedVM<ReviewExtend>>(_httpClientFactory, endpoint);
            return result;
        }

        public async Task<PagedVM<PaymentMethodExtend>> GetPaymentMethods(int pageNumber, int pageSize)
        {
            var endpoint = $"/FahasaStore/GetPaymentMethods?pageNumber={pageNumber}&pageSize={pageSize}";
            var result = await _methodsHelper.RequestHttpGet<PagedVM<PaymentMethodExtend>>(_httpClientFactory, endpoint);
            return result;
        }
    }
}