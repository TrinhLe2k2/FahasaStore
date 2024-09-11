using FahasaStore.Models.Interfaces;
using System.Collections.ObjectModel;

namespace FahasaStore.Models
{
    public class AddressBase : IEntity, IUserModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string ReceiverName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Province { get; set; } = null!;
        public string District { get; set; } = null!;
        public string Ward { get; set; } = null!;
        public string Detail { get; set; } = null!;
        public bool Default { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class AspNetUserBase : IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }

    public class AuthorBase : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }

    public class BannerBase : IEntity
    {
        public int Id { get; set; }
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }

    public class BookBase : IEntity
    {
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
    }

    public class BookPartnerBase : IEntity
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public int? PartnerId { get; set; }
        public string? Note { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class CartBase : IEntity
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class CartItemBase : IEntity, IUserModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? CartId { get; set; }
        public int? BookId { get; set; }
        public int Quantity { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class CategoryBase : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class CoverTypeBase : IEntity
    {
        public int Id { get; set; }
        public string TypeName { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }

    public class DimensionBase : IEntity
    {
        public int Id { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Unit { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }

    public class FavouriteBase : IEntity, IUserModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? BookId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class FlashSaleBase : IEntity
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class FlashSaleBookBase : IEntity
    {
        public int Id { get; set; }
        public int? FlashSaleId { get; set; }
        public int? BookId { get; set; }
        public int DiscountPercentage { get; set; }
        public int Quantity { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class MenuBase : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Link { get; set; } = null!;
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class NotificationBase : IEntity
    {
        public int Id { get; set; }
        public int? NotificationTypeId { get; set; }
        public int? UserId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public bool IsRead { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class NotificationTypeBase : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }

    public class OrderBase : IEntity, IUserModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? VoucherId { get; set; }
        public int? AddressId { get; set; }
        public int? PaymentMethodId { get; set; }
        public bool IsComplete { get; set; }
        public string? Note { get; set; }
        public DateTime? CreatedAt { get; set; }

        public List<int> CartItemIds { get; set; } = new List<int>();
    }

    public class OrderItemBase : IEntity, IUserModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? OrderId { get; set; }
        public int? BookId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int DiscountPercentage { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class OrderStatusBase : IEntity
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class PartnerBase : IEntity
    {
        public int Id { get; set; }
        public int? PartnerTypeId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class PartnerTypeBase : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }

    public class PaymentMethodBase : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public bool Active { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class PlatformBase : IEntity
    {
        public int Id { get; set; }
        public string PlatformName { get; set; } = null!;
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public string Link { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }

    public class PosterImageBase : IEntity
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public bool Default { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class ReviewBase : IEntity, IUserModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? BookId { get; set; }
        public int? OrderItemId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public bool Active { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class StatusBase : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }

    public class SubcategoryBase : IEntity
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class TopicBase : IEntity
    {
        public int Id { get; set; }
        public string TopicName { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }

    public class TopicContentBase : IEntity
    {
        public int Id { get; set; }
        public int? TopicId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }

    public class VoucherBase : IEntity
    {
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
    }

    public class WebsiteBase : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string LogoUrl { get; set; } = null!;
        public string IconUrl { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool Default { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
