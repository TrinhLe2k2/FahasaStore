using FahasaStore.Models;
using FahasaStoreAPI.Models.ViewModels;

namespace FahasaStoreAPI.Repositories.Interfaces
{
    public interface IBookRecommendationSystem
    {
        Task<PagedVM<BookExtend>> FindSimilarBooks(int bookId, int pageNumber, int pageSize);
        Task<PagedVM<BookExtend>> FindSimilarBooksBasedOnCart(List<int> bookIdInCart, int pageNumber, int pageSize, string aggregationMethod = "average");
    }
}
