using FahasaStoreAPI.Models.ViewModels.Entities;
using X.PagedList;

namespace FahasaStoreAPI.Repositories.Interfaces
{
    public interface IFahasaStoreRepository
    {
        Task<FlashSaleVM?> FlashSaleTodayAsync(int pageNumber, int pageSize);
        Task<IPagedList<BookVM>> TrendingBooks(string trendingBy, int pageNumber, int pageSize);
        Task<IPagedList<BookVM>> TopSellingBooksByCategory(int categoryId, int pageNumber, int pageSize);
    }
}
