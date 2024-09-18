using FahasaStore.Models;

namespace FahasaStoreApp.Models.ViewModels
{
    public class HomeIndexVM
    {
        public PagedVM<BannerExtend> BannerPaged { get; set; } = new PagedVM<BannerExtend>();
        public PagedVM<MenuExtend> MenuPaged { get; set; } = new PagedVM<MenuExtend>();
        public FlashSaleDetail? FlashSaleToday { get; set; } = new FlashSaleDetail();
        public PagedVM<BookExtend> TrendOfMonthPaged { get; set; } = new PagedVM<BookExtend>();
        public PagedVM<BookExtend> TrendOfYearPaged { get; set; } = new PagedVM<BookExtend>();
        public PagedVM<CategoryExtend> CategoryPaged { get; set; } = new PagedVM<CategoryExtend>();
        public PagedVM<BookExtend> TopSellingBooksByCategoryPaged { get; set; } = new PagedVM<BookExtend>();
        public PagedVM<PartnerExtend> PartnerPaged { get; set; } = new PagedVM<PartnerExtend>();
        public PagedVM<BookExtend> BooksRecommendationSystem { get; set; } = new PagedVM<BookExtend>();
    }
}
