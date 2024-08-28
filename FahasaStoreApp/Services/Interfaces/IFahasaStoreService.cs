using FahasaStoreApp.Models.DTOs.Entities;
using FahasaStoreApp.Models.ViewModels;
using FahasaStoreApp.Models.ViewModels.Entities;

namespace FahasaStoreApp.Services.Interfaces
{
    public interface IFahasaStoreService
    {
        Task<FlashSaleVM?> FlashSaleTodayAsync(int pageNumber, int pageSize);
        Task<PagedVM<BookDto>> TrendingBooks(string trendingBy, int pageNumber, int pageSize);
        Task<PagedVM<BookVM>> TopSellingBooksByCategory(int categoryId, int pageNumber, int pageSize);
        Task<PagedVM<BookDto>> FindSimilarBooks(int bookId, int pageNumber, int pageSize);
        Task<PagedVM<BookDto>> FindSimilarBooksBasedOnCart(List<int> bookIdInCart, int pageNumber, int pageSize, string aggregationMethod);
        Task<DataOptionsFilterBook> DataOptionsFilterBook();
        Task<ResultFilterBook> FilterBook(OptionsFilterBook optionsFilterBook);
    }
}
