using FahasaStore.Models.Interfaces;
using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.DTOs.Entities;

namespace FahasaStoreAPI.Models.ViewModels.Entities
{
    public class WebsiteVM : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string LogoUrl { get; set; } = null!;
        public string IconUrl { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }
    public class VoucherVM : IEntity
    {
        public VoucherVM()
        {
            Orders = new HashSet<OrderDto>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        public int DiscountPercent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MinOrderAmount { get; set; }
        public int MaxDiscountAmount { get; set; }
        public int UsageLimit { get; set; }
        public DateTime? CreatedAt { get; set; }

        public int CountOrders { get; set; } = 0;

        public virtual ICollection<OrderDto> Orders { get; set; }
    }
    public class TopicContentVM : IEntity
    {
        public int Id { get; set; }
        public int? TopicId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public virtual TopicDto? Topic { get; set; }
    }
    public class TopicVM : IEntity
    {
        public TopicVM()
        {
            TopicContents = new HashSet<TopicContentDto>();
        }

        public int Id { get; set; }
        public string TopicName { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public int CountTopicContents { get; set; } = 0;

        public virtual ICollection<TopicContentDto> TopicContents { get; set; }
    }
    public class SubcategoryVM : IEntity
    {
        public SubcategoryVM()
        {
            Books = new HashSet<BookDto>();
        }

        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }

        public int CountBooks { get; set; } = 0;

        public virtual CategoryDto? Category { get; set; }
        public virtual ICollection<BookDto> Books { get; set; }
    }
    public class StatusVM : IEntity
    {
        public StatusVM()
        {
            OrderStatuses = new HashSet<OrderStatusDto>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public int CountOrderStatuses { get; set; } = 0;

        public virtual ICollection<OrderStatusDto> OrderStatuses { get; set; }
    }
    public class ReviewVM : IEntity
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public int? OrderId { get; set; }
        public int? UserId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public bool Active { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual BookDto? Book { get; set; }
        public virtual OrderDto? Order { get; set; }
        public virtual AspNetUserDto? User { get; set; }
    }
    public class PosterImageVM : IEntity
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public bool ImageDefault { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual BookDto? Book { get; set; }
    }
    public class PlatformVM : IEntity
    {
        public int Id { get; set; }
        public string PlatformName { get; set; } = null!;
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public string Link { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }
    public class PaymentMethodVM : IEntity
    {
        public PaymentMethodVM()
        {
            Orders = new HashSet<OrderDto>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public bool Active { get; set; }
        public DateTime? CreatedAt { get; set; }

        public int CountOrders { get; set; } = 0;

        public virtual ICollection<OrderDto> Orders { get; set; }
    }
    public class PaymentVM : IEntity
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual OrderDto? Order { get; set; }
    }
    public class PartnerTypeVM : IEntity
    {
        public PartnerTypeVM()
        {
            Partners = new HashSet<PartnerDto>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public int CountPartners { get; set; } = 0;

        public virtual ICollection<PartnerDto> Partners { get; set; }
    }
    public class PartnerVM : IEntity
    {
        public PartnerVM()
        {
            BookPartners = new HashSet<BookPartnerDto>();
        }

        public int Id { get; set; }
        public int? PartnerTypeId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }

        public int CountBookPartners { get; set; } = 0;

        public virtual PartnerTypeDto? PartnerType { get; set; }
        public virtual ICollection<BookPartnerDto> BookPartners { get; set; }
    }
    public class OrderStatusVM : IEntity
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual OrderDto? Order { get; set; }
        public virtual StatusDto? Status { get; set; }
    }
    public class OrderItemVM : IEntity
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? BookId { get; set; }
        public int Quantity { get; set; }
        public int? Price { get; set; }
        public int? DiscountPercentage { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual BookDto? Book { get; set; }
        public virtual OrderDto? Order { get; set; }
    }
    public class OrderVM : IEntity
    {
        public OrderVM()
        {
            OrderItems = new HashSet<OrderItemDto>();
            OrderStatuses = new HashSet<OrderStatusDto>();
            Reviews = new HashSet<ReviewDto>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? VoucherId { get; set; }
        public int? AddressId { get; set; }
        public int? PaymentMethodId { get; set; }
        public string? Note { get; set; }
        public DateTime? CreatedAt { get; set; }

        public int IntoMoney { get; set; } = 0;
        public int CountOrderItems { get; set; } = 0;
        public int CountOrderStatuses { get; set; } = 0;
        public int CountReviews { get; set; } = 0;

        public virtual AddressDto? Address { get; set; }
        public virtual PaymentMethodDto? PaymentMethod { get; set; }
        public virtual AspNetUserDto? User { get; set; }
        public virtual VoucherDto? Voucher { get; set; }
        public virtual PaymentDto? Payment { get; set; }
        public virtual ICollection<OrderItemDto> OrderItems { get; set; }
        public virtual ICollection<OrderStatusDto> OrderStatuses { get; set; }
        public virtual ICollection<ReviewDto> Reviews { get; set; }
    }
    public class NotificationTypeVM : IEntity
    {
        public NotificationTypeVM()
        {
            Notifications = new HashSet<NotificationDto>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public int CountNotifications { get; set; } = 0;

        public virtual ICollection<NotificationDto> Notifications { get; set; }
    }
    public class NotificationVM : IEntity
    {
        public int Id { get; set; }
        public int? NotificationTypeId { get; set; }
        public int? UserId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public bool IsRead { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual NotificationTypeDto? NotificationType { get; set; }
        public virtual AspNetUserDto? User { get; set; }
    }
    public class MenuVM : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Link { get; set; } = null!;
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public class FlashSaleBookVM : IEntity
    {
        public int Id { get; set; }
        public int? FlashSaleId { get; set; }
        public int? BookId { get; set; }
        public int DiscountPercentage { get; set; }
        public int Quantity { get; set; }
        public DateTime? CreatedAt { get; set; }

        public int Solded { get; set; } = 0;
        public int PriceFS { get; set; } = 0;

        public virtual BookDto? Book { get; set; }
        public virtual FlashSaleDto? FlashSale { get; set; }
    }
    public class FlashSaleVM : IEntity
    {
        public FlashSaleVM()
        {
            FlashSaleBooks = new HashSet<FlashSaleBookDto>();
        }

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? CreatedAt { get; set; }

        public int CountFlashSaleBooks { get; set; } = 0;

        public virtual ICollection<FlashSaleBookDto> FlashSaleBooks { get; set; }
    }
    public class FavouriteVM : IEntity
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? BookId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual BookDto? Book { get; set; }
        public virtual AspNetUserDto? User { get; set; }
    }
    public class DimensionVM : IEntity
    {
        public DimensionVM()
        {
            Books = new HashSet<BookDto>();
        }

        public int Id { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Unit { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public int CountBooks { get; set; } = 0;

        public virtual ICollection<BookDto> Books { get; set; }
    }
    public class CoverTypeVM : IEntity
    {
        public CoverTypeVM()
        {
            Books = new HashSet<BookDto>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public int CountBooks { get; set; } = 0;

        public virtual ICollection<BookDto> Books { get; set; }
    }
    public class CategoryVM : IEntity
    {
        public CategoryVM()
        {
            Subcategories = new HashSet<SubcategoryDto>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }

        public int CountSubcategories { get; set; } = 0;

        public virtual ICollection<SubcategoryDto> Subcategories { get; set; }
    }
    public class CartItemVM : IEntity
    {
        public int Id { get; set; }
        public int? CartId { get; set; }
        public int? BookId { get; set; }
        public int Quantity { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual BookDto? Book { get; set; }
        public virtual CartDto? Cart { get; set; }
    }
    public class CartVM : IEntity
    {
        public CartVM()
        {
            CartItems = new HashSet<CartItemDto>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public int CountCartItems { get; set; } = 0;

        public virtual AspNetUserDto? User { get; set; }
        public virtual ICollection<CartItemDto> CartItems { get; set; }
    }
    public class BookPartnerVM : IEntity
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public string? Note { get; set; }
        public DateTime? CreatedAt { get; set; }

        public int? PartnerId { get; set; }
        public string? PartnerName { get; set; }
        public int? PartnerTypeId { get; set; } = 0;
        public string? PartnerType { get; set; }

        public virtual BookDto? Book { get; set; }
        public virtual PartnerDto? Partner { get; set; }
    }
    public class BookVM : IEntity
    {
        public BookVM()
        {
            BookPartners = new HashSet<BookPartnerDto>();
            PosterImages = new HashSet<PosterImageDto>();
        }

        public int Id { get; set; }
        public int? SubcategoryId { get; set; }
        public int? AuthorId { get; set; }
        public int? CoverTypeId { get; set; }
        public int? DimensionId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Price { get; set; }
        public int DiscountPercentage { get; set; }
        public int Quantity { get; set; }
        public double? Weight { get; set; }
        public int? PageCount { get; set; }
        public DateTime? CreatedAt { get; set; }

        public int Solded { get; set; } = 0;
        public int CurrentPrice { get; set; } = 0;
        public int FavouritesCount { get; set; } = 0;

        public string? SubcategoryName { get; set; }
        public string? AuthorName { get; set; }
        public string? CoverTypeName { get; set; }
        public string? DimensionName { get; set; }

        public double RateAverage { get; set; } = 0;
        public int RateCount { get; set; } = 0;
        public int Rate1Percentage { get; set; } = 0;
        public int Rate2Percentage { get; set; } = 0;
        public int Rate3Percentage { get; set; } = 0;
        public int Rate4Percentage { get; set; } = 0;
        public int Rate5Percentage { get; set; } = 0;

        public virtual ICollection<BookPartnerDto> BookPartners { get; set; }
        public virtual ICollection<PosterImageDto> PosterImages { get; set; }
    }
    public class BannerVM : IEntity
    {
        public int Id { get; set; }
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }
    public class AuthorVM : IEntity
    {
        public AuthorVM()
        {
            Books = new HashSet<BookDto>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public int CountBooks { get; set; } = 0;

        public virtual ICollection<BookDto> Books { get; set; }
    }
    public class AspNetUserVM : IEntity
    {
        public AspNetUserVM()
        {
            Addresses = new HashSet<AddressDto>();
            Favourites = new HashSet<FavouriteDto>();
            Notifications = new HashSet<NotificationDto>();
            Orders = new HashSet<OrderDto>();
            Reviews = new HashSet<ReviewDto>();
        }

        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public int CountAddresses { get; set; } = 0;
        public int CountFavourites { get; set; } = 0;
        public int CountNotifications { get; set; } = 0;
        public int CountOrders { get; set; } = 0;
        public int CountReviews { get; set; } = 0;
        public int CountRoles { get; set; } = 0;

        public virtual CartDto? Cart { get; set; }
        public virtual ICollection<AddressDto> Addresses { get; set; }
        public virtual ICollection<FavouriteDto> Favourites { get; set; }
        public virtual ICollection<NotificationDto> Notifications { get; set; }
        public virtual ICollection<OrderDto> Orders { get; set; }
        public virtual ICollection<ReviewDto> Reviews { get; set; }

        public virtual IList<string>? Role { get; set; }
    }
    public class AspNetRoleVM : IEntity
    {
        public AspNetRoleVM()
        {
            Users = new HashSet<AspNetUserDto>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public int CountUsers { get; set; } = 0;

        public virtual ICollection<AspNetUserDto> Users { get; set; }
    }
    public class AddressVM : IEntity
    {
        public AddressVM()
        {
            Orders = new HashSet<OrderDto>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public string ReceiverName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Province { get; set; } = null!;
        public string District { get; set; } = null!;
        public string Ward { get; set; } = null!;
        public string Detail { get; set; } = null!;
        public bool DefaultAddress { get; set; }
        public DateTime? CreatedAt { get; set; }

        public int CountOrders { get; set; } = 0;

        public virtual AspNetUserDto? User { get; set; }
        public virtual ICollection<OrderDto> Orders { get; set; }
    }
}

