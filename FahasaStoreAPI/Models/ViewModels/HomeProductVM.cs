using FahasaStore.Models;

namespace FahasaStoreAPI.Models.ViewModels
{
    public class HomeProductVM 
    {
        public BookDetail Book { get; set; } = new BookDetail();
        public PagedVM<BookExtend> SimilarBooks { get; set; } = new PagedVM<BookExtend>();
        public PagedVM<ReviewExtend> reviews { get; set; } = new PagedVM<ReviewExtend>();
    }
}
