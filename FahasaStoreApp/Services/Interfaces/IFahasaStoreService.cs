using FahasaStoreApp.Models.ViewModels;
using FahasaStoreApp.Models.ViewModels.Entities;

namespace FahasaStoreApp.Services.Interfaces
{
    public interface IFahasaStoreService
    {
        Task<FlashSaleVM?> FlashSaleTodayAsync(int pageNumber, int pageSize);
        Task<PagedVM<BookVM>> TrendingBooks(string trendingBy, int pageNumber, int pageSize);
        Task<PagedVM<BookVM>> TopSellingBooksByCategory(int categoryId, int pageNumber, int pageSize);
    }
}
