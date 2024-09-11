using FahasaStore.Models;

namespace FahasaStoreApp.Models.ViewModels
{
    public class HomeProductVM
    {
        public BookDetail Book { get; set; } = new BookDetail();
        public PagedVM<BookExtend> SimilarBooks { get; set; } = new PagedVM<BookExtend>();
        public PagedVM<ReviewExtend> Reviews { get; set; } = new PagedVM<ReviewExtend>();
        public PagedVM<VoucherExtend> Vouchers { get; set; } = new PagedVM<VoucherExtend>();
    }
}
