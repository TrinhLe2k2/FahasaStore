namespace FahasaStore.Models
{
    public class AddressExtend : AddressBase
    {
        public bool IsChanger { get; set; } = false;
        public int OrdersCount { get; set; } = 0;
    }

    public class AspNetUserExtend : AspNetUserBase
    {
        public int CartId { get; set; } = 0;
        public int AddressesCount { get; set; } = 0;
        public int FavouritesCount { get; set; } = 0;
        public int NotificationsCount { get; set; } = 0;
        public int OrdersCount { get; set; } = 0;
        public int ReviewsCount { get; set; } = 0;
        public int RolesCount { get; set; } = 0;
    }

    public class AuthorExtend : AuthorBase
    {
        public int BooksCount { get; set; } = 0;
    }

    public class BannerExtend : BannerBase
    {

    }

    public class BookExtend : BookBase
    {
        public int Solded { get; set; } = 0;
        public int CurrentPrice { get; set; } = 0;
        public int FavouritesCount { get; set; } = 0;
        public string? SubcategoryName { get; set; }
        public string? AuthorName { get; set; }
        public string? CoverTypeName { get; set; }
        public string? DimensionName { get; set; }
        public string? BookPoster { get; set; }
        public double RateAverage { get; set; } = 0;
        public int RateCount { get; set; } = 0;
        public int Rate1Percentage { get; set; } = 0;
        public int Rate2Percentage { get; set; } = 0;
        public int Rate3Percentage { get; set; } = 0;
        public int Rate4Percentage { get; set; } = 0;
        public int Rate5Percentage { get; set; } = 0;
    }

    public class BookPartnerExtend : BookPartnerBase
    {
        public string? PartnerName { get; set; }
        public int? PartnerTypeId { get; set; } = 0;
        public string? PartnerTypeName { get; set; }
    }

    public class CartExtend : CartBase
    {
        public int CartItemsCount { get; set; } = 0;
        public List<int> BookIds { get; set; } = new List<int>();
    }

    public class CartItemExtend : CartItemBase
    {
        public int IntoMoney { get; set; } = 0;
    }

    public class CategoryExtend : CategoryBase
    {
        public int SubcategoriesCount { get; set; } = 0;
    }

    public class CoverTypeExtend : CoverTypeBase
    {
        public int BooksCount { get; set; } = 0;
    }

    public class DimensionExtend : DimensionBase
    {
        public int BooksCount { get; set; } = 0;
    }

    public class FavouriteExtend : FavouriteBase
    {

    }

    public class FlashSaleExtend : FlashSaleBase
    {
        public int FlashSaleBooksCount { get; set; } = 0;
    }

    public class FlashSaleBookExtend : FlashSaleBookBase
    {
        public int Solded { get; set; } = 0;
        public int PriceFS { get; set; } = 0;
        public DateTime FlashSaleStartDate { get; set; }
        public DateTime FlashSaleEndDate { get; set;}
        public string BookName { get; set; } = null!;
    }

    public class MenuExtend : MenuBase
    {

    }

    public class NotificationExtend : NotificationBase
    {
        public string? NotificationTypeName { get; set; }
        public string? UserFullName { get; set; }
    }

    public class NotificationTypeExtend : NotificationTypeBase
    {
        public int NotificationsCount { get; set; } = 0;
    }

    public class OrderExtend : OrderBase
    {
        public int IntoMoney { get; set; } = 0;
        public string? ReceiverName { get; set; }
        public string? OrderLastStatus { get; set; }
        public bool isCancelable { get; set; } = false;
        public bool isReturnable { get; set; } = false;
        public bool isCompletable { get; set; } = false;
        public int OrderItemsCount { get; set; } = 0;
        public int OrderStatusesCount { get; set; } = 0;
    }

    public class OrderItemExtend : OrderItemBase
    {
        public int? ReviewId { get; set; }
        public bool HasReview { get; set; } = false;
        public int PriceBook { get; set; } = 0;
        public int IntoMoney { get; set; } = 0;
    }

    public class OrderStatusExtend : OrderStatusBase
    {
        public string? StatusName { get; set; }
    }

    public class PartnerExtend : PartnerBase
    {
        public string? PartnerTypeName { get; set; }
        public int BookPartnersCount { get; set; } = 0;
    }

    public class PartnerTypeExtend : PartnerTypeBase
    {
        public int PartnersCount { get; set; } = 0;
    }

    public class PaymentMethodExtend : PaymentMethodBase
    {
        public int OrdersCount { get; set; } = 0;
    }

    public class PlatformExtend : PlatformBase
    {

    }

    public class PosterImageExtend : PosterImageBase
    {

    }

    public class ReviewExtend : ReviewBase
    {
        public string? UserImageUrl { get; set; }
        public string? UserFullName { get; set; }
        public string? BookName { get; set; }
        public string? BookPoster { get; set; }
    }

    public class StatusExtend : StatusBase
    {
        public int OrderStatusesCount { get; set; } = 0;
    }

    public class SubcategoryExtend : SubcategoryBase
    {
        public string? CategoryName { get; set; }
        public int BooksCount { get; set; } = 0;
    }

    public class TopicExtend : TopicBase
    {
        public int TopicContentsCount { get; set; } = 0;
    }

    public class TopicContentExtend : TopicContentBase
    {

    }

    public class VoucherExtend : VoucherBase
    {
        public int OrdersCount { get; set; } = 0;
    }

    public class WebsiteExtend : WebsiteBase
    {

    }
}