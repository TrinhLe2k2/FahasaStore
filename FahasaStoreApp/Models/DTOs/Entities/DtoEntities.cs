namespace FahasaStoreApp.Models.DTOs.Entities
{
    public class WebsiteDto
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
    public class VoucherDto
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

        public int CountOrders { get; set; } = 0;
    }
    public class TopicContentDto
    {
        public int Id { get; set; }
        public int? TopicId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }
    public class TopicDto
    {
        public int Id { get; set; }
        public string TopicName { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public int CountTopicContents { get; set; } = 0;
    }
    public class SubcategoryDto
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }

        public string? CategoryName { get; set; }
        public int CountBooks { get; set; } = 0;
    }
    public class StatusDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public int CountOrderStatuses { get; set; } = 0;
    }
    public class ReviewDto
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public int? OrderId { get; set; }
        public int? UserId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public bool Active { get; set; }
        public DateTime? CreatedAt { get; set; }

        public string? UserAvatar { get; set; }
        public string? UserFullName { get; set; }
    }
    public class PosterImageDto
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public bool ImageDefault { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public class PlatformDto
    {
        public int Id { get; set; }
        public string PlatformName { get; set; } = null!;
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public string Link { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }
    public class PaymentMethodDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public bool Active { get; set; }
        public DateTime? CreatedAt { get; set; }

        public int CountOrders { get; set; } = 0;
    }
    public class PaymentDto
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public class PartnerTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public int CountPartners { get; set; } = 0;
    }
    public class PartnerDto
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

        public string? PartnerTypeName { get; set; }

        public int CountBookPartners { get; set; } = 0;
    }
    public class OrderStatusDto
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public string? StatusName { get; set; }
    }
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? BookId { get; set; }
        public int Quantity { get; set; }
        public int? Price { get; set; }
        public int? DiscountPercentage { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public class OrderDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? VoucherId { get; set; }
        public int? AddressId { get; set; }
        public int? PaymentMethodId { get; set; }
        public string? Note { get; set; }
        public DateTime? CreatedAt { get; set; }

        public int CountOrderItems { get; set; } = 0;
        public int CountOrderStatuses { get; set; } = 0;
        public int CountReviews { get; set; } = 0;
    }
    public class NotificationTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public int CountNotifications { get; set; } = 0;
    }
    public class NotificationDto
    {
        public int Id { get; set; }
        public int? NotificationTypeId { get; set; }
        public int? UserId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public bool IsRead { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public class MenuDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Link { get; set; } = null!;
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public class FlashSaleBookDto
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
    }
    public class FlashSaleDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? CreatedAt { get; set; }

        public int CountFlashSaleBooks { get; set; } = 0;
    }
    public class FavouriteDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? BookId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public class DimensionDto
    {
        public int Id { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Unit { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public int CountBooks { get; set; } = 0;
    }
    public class CoverTypeDto
    {
        public int Id { get; set; }
        public string TypeName { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public int CountBooks { get; set; } = 0;
    }
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }

        public int CountSubcategories { get; set; } = 0;
    }
    public class CartItemDto
    {
        public int Id { get; set; }
        public int? CartId { get; set; }
        public int? BookId { get; set; }
        public int Quantity { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public class CartDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public int CountCartItems { get; set; } = 0;
    }
    public class BookPartnerDto
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public int? PartnerId { get; set; }
        public string? Note { get; set; }
        public DateTime? CreatedAt { get; set; }

        public string? PartnerName { get; set; }
        public int? PartnerTypeId { get; set; } = 0;
        public string? PartnerTypeName { get; set; }
    }
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Price { get; set; }
        public int DiscountPercentage { get; set; }
        public int Quantity { get; set; }
        public DateTime? CreatedAt { get; set; }

        public double RateAverage { get; set; } = 0;
        public int RateCount { get; set; } = 0;
        public int Solded { get; set; } = 0;
        public int CurrentPrice { get; set; } = 0;
        public int FavouritesCount { get; set; } = 0;

        public string? poster { get; set; }
    }
    public class BannerDto
    {
        public int Id { get; set; }
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public int CountBooks { get; set; } = 0;
    }
    public class AspNetUserDto
    {
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
        public int Count { get; set; } = 0;
        public int CountOrders { get; set; } = 0;
        public int CountReviews { get; set; } = 0;
        public int CountRoles { get; set; } = 0;
    }
    public class AspNetRoleDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int CountUsers { get; set; } = 0;
    }
    public class AddressDto
    {
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
    }
}