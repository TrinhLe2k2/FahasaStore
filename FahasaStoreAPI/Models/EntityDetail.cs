namespace FahasaStore.Models
{
    public class AddressDetail : AddressExtend
    {
        //public AddressDetail()
        //{
        //    Orders = new HashSet<OrderExtend>();
        //}

        public AspNetUserExtend? User { get; set; }
        //public ICollection<OrderExtend> Orders { get; set; }
    }

    public class AspNetUserDetail : AspNetUserExtend
    {
        public AspNetUserDetail()
        {
            Favourites = new HashSet<FavouriteExtend>();
            Notifications = new HashSet<NotificationExtend>();
            Orders = new HashSet<OrderExtend>();
            Reviews = new HashSet<ReviewExtend>();
        }

        public CartExtend? Cart { get; set; }
        public AddressExtend? DefaultAddress { get; set; }
        public ICollection<FavouriteExtend> Favourites { get; set; }
        public ICollection<NotificationExtend> Notifications { get; set; }
        public ICollection<OrderExtend> Orders { get; set; }
        public ICollection<ReviewExtend> Reviews { get; set; }

        public IList<string> Role { get; set; } = new List<string>();
    }

    public class AuthorDetail : AuthorExtend
    {
        public AuthorDetail()
        {
            Books = new HashSet<BookExtend>();
        }

        public ICollection<BookExtend> Books { get; set; }
    }

    public class BannerDetail : BannerExtend
    {
    }

    public class BookDetail : BookExtend
    {
        public BookDetail()
        {
            BookPartners = new HashSet<BookPartnerExtend>();
            PosterImages = new HashSet<PosterImageExtend>();
        }

        public AuthorExtend? Author { get; set; }
        public CoverTypeExtend? CoverType { get; set; }
        public DimensionExtend? Dimension { get; set; }
        public SubcategoryExtend? Subcategory { get; set; }
        public ICollection<BookPartnerExtend> BookPartners { get; set; }
        public ICollection<PosterImageExtend> PosterImages { get; set; }
    }

    public class BookPartnerDetail : BookPartnerExtend
    {
        public BookExtend? Book { get; set; }
        public PartnerExtend? Partner { get; set; }
    }

    public class CartDetail : CartExtend
    {
        public CartDetail()
        {
            CartItems = new HashSet<CartItemExtend>();
        }

        public AspNetUserExtend? User { get; set; }
        public ICollection<CartItemExtend> CartItems { get; set; }
    }

    public class CartItemDetail : CartItemExtend
    {

        public BookExtend? Book { get; set; }
        public CartExtend? Cart { get; set; }
    }

    public class CategoryDetail : CategoryExtend
    {
        public CategoryDetail()
        {
            Subcategories = new HashSet<SubcategoryExtend>();
        }

        public ICollection<SubcategoryExtend> Subcategories { get; set; }
    }

    public class CoverTypeDetail : CoverTypeExtend
    {
        public CoverTypeDetail()
        {
            Books = new HashSet<BookExtend>();
        }

        public ICollection<BookExtend> Books { get; set; }
    }

    public class DimensionDetail : DimensionExtend
    {
        public DimensionDetail()
        {
            Books = new HashSet<BookExtend>();
        }

        public ICollection<BookExtend> Books { get; set; }
    }

    public class FavouriteDetail : FavouriteExtend
    {
        public BookExtend? Book { get; set; }
        public AspNetUserExtend? User { get; set; }
    }

    public class FlashSaleDetail : FlashSaleExtend
    {
        public FlashSaleDetail()
        {
            FlashSaleBooks = new HashSet<FlashSaleBookDetail>();
        }

        public ICollection<FlashSaleBookDetail> FlashSaleBooks { get; set; }
    }

    public class FlashSaleBookDetail : FlashSaleBookExtend
    {
        public BookExtend? Book { get; set; }
        public FlashSaleExtend? FlashSale { get; set; }
    }

    public class MenuDetail : MenuExtend
    {
    }

    public class NotificationDetail : NotificationExtend
    {
        public NotificationTypeExtend? NotificationType { get; set; }
        public AspNetUserExtend? User { get; set; }
    }

    public class NotificationTypeDetail : NotificationTypeExtend
    {
        public NotificationTypeDetail()
        {
            Notifications = new HashSet<NotificationExtend>();
        }

        public ICollection<NotificationExtend> Notifications { get; set; }
    }

    public class OrderDetail : OrderExtend
    {
        public OrderDetail()
        {
            OrderItems = new HashSet<OrderItemDetail>();
            OrderStatuses = new HashSet<OrderStatusExtend>();
        }

        public int Reduce
        {
            get {
                if (Voucher != null)
                {
                    var reduceOrder = IntoMoney * Voucher.DiscountPercent / 100;
                    return reduceOrder > Voucher.MaxDiscountAmount ? Voucher.MaxDiscountAmount : reduceOrder;
                }
                return 0;
            }
        }
        public int TotalToPay => IntoMoney - Reduce;
        public AddressExtend? Address { get; set; }
        public PaymentMethodExtend? PaymentMethod { get; set; }
        public AspNetUserExtend? User { get; set; }
        public VoucherExtend? Voucher { get; set; }
        public ICollection<OrderItemDetail> OrderItems { get; set; }
        public ICollection<OrderStatusExtend> OrderStatuses { get; set; }
    }

    public class OrderItemDetail : OrderItemExtend
    {
        public BookExtend? Book { get; set; }
        public OrderExtend? Order { get; set; }
        public ReviewExtend? Review { get; set; }
    }

    public class OrderStatusDetail : OrderStatusExtend
    {
        public OrderExtend? Order { get; set; }
        public StatusExtend? Status { get; set; }
    }

    public class PartnerDetail : PartnerExtend
    {
        public PartnerDetail()
        {
            BookPartners = new HashSet<BookPartnerExtend>();
        }

        public PartnerTypeExtend? PartnerType { get; set; }
        public ICollection<BookPartnerExtend> BookPartners { get; set; }
    }

    public class PartnerTypeDetail : PartnerTypeExtend
    {
        public PartnerTypeDetail()
        {
            Partners = new HashSet<PartnerExtend>();
        }

        public ICollection<PartnerExtend> Partners { get; set; }
    }

    public class PaymentMethodDetail : PaymentMethodExtend
    {
        public PaymentMethodDetail()
        {
            Orders = new HashSet<OrderExtend>();
        }

        public ICollection<OrderExtend> Orders { get; set; }
    }

    public class PlatformDetail : PlatformExtend
    {
    }

    public class PosterImageDetail : PosterImageExtend
    {
        public BookExtend? Book { get; set; }
    }

    public class ReviewDetail : ReviewExtend
    {
        public BookExtend? Book { get; set; }
        public OrderItemExtend? OrderItem { get; set; }
        public AspNetUserExtend? User { get; set; }
    }

    public class StatusDetail : StatusExtend
    {
        public StatusDetail()
        {
            OrderStatuses = new HashSet<OrderStatusExtend>();
        }

        public ICollection<OrderStatusExtend> OrderStatuses { get; set; }
    }

    public class SubcategoryDetail : SubcategoryExtend
    {
        public SubcategoryDetail()
        {
            Books = new HashSet<BookExtend>();
        }

        public CategoryExtend? Category { get; set; }
        public ICollection<BookExtend> Books { get; set; }
    }

    public class TopicDetail : TopicExtend
    {
        public TopicDetail()
        {
            TopicContents = new HashSet<TopicContentExtend>();
        }

        public ICollection<TopicContentExtend> TopicContents { get; set; }
    }

    public class TopicContentDetail : TopicContentExtend
    {
        public TopicExtend? Topic { get; set; }
    }

    public class VoucherDetail : VoucherExtend
    {
        public VoucherDetail()
        {
            Orders = new HashSet<OrderExtend>();
        }

        public ICollection<OrderExtend> Orders { get; set; }
    }

    public class WebsiteDetail : WebsiteExtend
    {
    }
}
