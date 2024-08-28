using FahasaStoreAPI.Models.DTOs.Entities;
using FahasaStoreAPI.Models.ViewModels;
using FahasaStoreAPI.Models.ViewModels.Entities;
using X.PagedList;

namespace FahasaStoreAPI.Repositories.Interfaces
{
    public interface IBookRecommendationSystem
    {
        Task<PagedVM<BookDto>> FindSimilarBooks(int bookId, int pageNumber, int pageSize);
        Task<PagedVM<BookDto>> FindSimilarBooksBasedOnCart(List<int> bookIdInCart, int pageNumber, int pageSize, string aggregationMethod = "average");
    }
}
