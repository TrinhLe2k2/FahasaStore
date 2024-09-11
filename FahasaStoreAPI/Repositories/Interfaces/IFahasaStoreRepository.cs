using FahasaStore.Models;
using FahasaStoreAPI.Models.ViewModels;

namespace FahasaStoreAPI.Repositories.Interfaces
{
    public interface IFahasaStoreRepository
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
        Task<PagedVM<PaymentMethodExtend>> GetPaymentMethodsAsync(int pageNumber, int pageSize);
    }
}
