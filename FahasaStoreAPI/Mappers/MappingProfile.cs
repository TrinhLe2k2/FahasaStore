using AutoMapper;
using FahasaStoreAPI.Controllers;
using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.DTOs.Entities;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.ViewModels.Entities;

namespace FahasaStoreAPI.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, RSProduct>()
                .ForMember(dest => dest.SubcategoryName, opt => opt.MapFrom(src => src.Subcategory != null ? src.Subcategory.Name : null))
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author != null ? src.Author.Name : null))
                .ForMember(dest => dest.CoverTypeName, opt => opt.MapFrom(src => src.CoverType != null ? src.CoverType.TypeName : null))
                .ReverseMap();

            #region Entity to VM

            CreateMap<Website, WebsiteVM>().ReverseMap();
            CreateMap<Voucher, VoucherVM>()
                .ForMember(destination => destination.CountOrders, opt => opt.MapFrom(src => src.Orders.Count))
                .ForMember(destination => destination.Orders, opt => opt.MapFrom(src => src.Orders.OrderByDescending(p => p.CreatedAt).Take(10)))
                .ReverseMap();
            CreateMap<TopicContent, TopicContentVM>().ReverseMap();
            CreateMap<Topic, TopicVM>()
                .ForMember(destination => destination.CountTopicContents, opt => opt.MapFrom(src => src.TopicContents.Count))
                .ForMember(destination => destination.TopicContents, opt => opt.MapFrom(src => src.TopicContents.OrderByDescending(p => p.CreatedAt).Take(5)))
                .ReverseMap();
            CreateMap<Subcategory, SubcategoryVM>()
                .ForMember(destination => destination.CountBooks, opt => opt.MapFrom(src => src.Books.Count))
                .ForMember(destination => destination.Books, opt => opt.MapFrom(src => src.Books.OrderByDescending(p => p.CreatedAt).Take(10)))
                .ReverseMap();
            CreateMap<Status, StatusVM>()
                .ForMember(destination => destination.CountOrderStatuses, opt => opt.MapFrom(src => src.OrderStatuses.Count))
                .ForMember(destination => destination.OrderStatuses, opt => opt.MapFrom(src => src.OrderStatuses.OrderByDescending(p => p.CreatedAt).Take(10)))
                .ReverseMap();
            CreateMap<Review, ReviewVM>().ReverseMap();
            CreateMap<PosterImage, PosterImageVM>().ReverseMap();
            CreateMap<Platform, PlatformVM>().ReverseMap();
            CreateMap<PaymentMethod, PaymentMethodVM>()
                .ForMember(destination => destination.CountOrders, opt => opt.MapFrom(src => src.Orders.Count))
                .ForMember(destination => destination.Orders, opt => opt.MapFrom(src => src.Orders.OrderByDescending(p => p.CreatedAt).Take(10)))
                .ReverseMap();
            CreateMap<Payment, PaymentVM>().ReverseMap();
            CreateMap<PartnerType, PartnerTypeVM>()
                .ForMember(destination => destination.CountPartners, opt => opt.MapFrom(src => src.Partners.Count))
                .ForMember(destination => destination.Partners, opt => opt.MapFrom(src => src.Partners.OrderByDescending(p => p.CreatedAt).Take(10)))
                .ReverseMap();
            CreateMap<Partner, PartnerVM>()
                .ForMember(destination => destination.CountBookPartners, opt => opt.MapFrom(src => src.BookPartners.Count))
                .ForMember(destination => destination.BookPartners, opt => opt.MapFrom(src => src.BookPartners.OrderByDescending(p => p.CreatedAt).Take(10)))
                .ReverseMap();
            CreateMap<OrderStatus, OrderStatusVM>().ReverseMap();
            CreateMap<OrderItem, OrderItemVM>().ReverseMap();
            CreateMap<Order, OrderVM>()
                .ForMember(destination => destination.CountOrderItems, opt => opt.MapFrom(src => src.OrderItems.Count))
                .ForMember(destination => destination.OrderItems, opt => opt.MapFrom(src => src.OrderItems.OrderByDescending(p => p.CreatedAt).Take(10)))
                .ForMember(destination => destination.CountOrderStatuses, opt => opt.MapFrom(src => src.OrderStatuses.Count))
                .ForMember(destination => destination.OrderStatuses, opt => opt.MapFrom(src => src.OrderStatuses.OrderByDescending(p => p.CreatedAt).Take(10)))
                .ForMember(destination => destination.CountReviews, opt => opt.MapFrom(src => src.Reviews.Count))
                .ForMember(destination => destination.Reviews, opt => opt.MapFrom(src => src.Reviews.OrderByDescending(p => p.CreatedAt).Take(10)))
                .ReverseMap();
            CreateMap<NotificationType, NotificationTypeVM>()
                .ForMember(destination => destination.CountNotifications, opt => opt.MapFrom(src => src.Notifications.Count))
                .ForMember(destination => destination.Notifications, opt => opt.MapFrom(src => src.Notifications.OrderByDescending(p => p.CreatedAt).Take(10)))
                .ReverseMap();
            CreateMap<Notification, NotificationVM>().ReverseMap();
            CreateMap<Menu, MenuVM>().ReverseMap();
            CreateMap<FlashSaleBook, FlashSaleBookVM>()
                .ForMember(destination => destination.Solded, opt => opt.MapFrom(src =>
                    src.Book != null
                        ? src.Book.OrderItems
                            .Where(oi => src.FlashSale != null && oi.CreatedAt >= src.FlashSale.StartDate && oi.CreatedAt <= src.FlashSale.EndDate)
                            .Sum(oi => oi.Quantity)
                        : 0))
                .ForMember(destination => destination.PriceFS, opt => opt.MapFrom(src => src.Book != null ? src.Book.Price - (src.Book.Price * src.DiscountPercentage / 100) : default))
                .ReverseMap();
            CreateMap<FlashSale, FlashSaleVM>()
                .ForMember(destination => destination.CountFlashSaleBooks, opt => opt.MapFrom(src => src.FlashSaleBooks.Count))
                .ForMember(destination => destination.FlashSaleBooks, opt => opt.MapFrom(src => src.FlashSaleBooks.OrderByDescending(p => p.CreatedAt).Take(50)))
                .ReverseMap();
            CreateMap<Favourite, FavouriteVM>().ReverseMap();
            CreateMap<Dimension, DimensionVM>()
                .ForMember(destination => destination.CountBooks, opt => opt.MapFrom(src => src.Books.Count))
                .ForMember(destination => destination.Books, opt => opt.MapFrom(src => src.Books.OrderByDescending(p => p.CreatedAt).Take(10)))
                .ReverseMap();
            CreateMap<CoverType, CoverTypeVM>()
                .ForMember(destination => destination.CountBooks, opt => opt.MapFrom(src => src.Books.Count))
                .ForMember(destination => destination.Books, opt => opt.MapFrom(src => src.Books.OrderByDescending(p => p.CreatedAt).Take(10)))
                .ReverseMap();
            CreateMap<Category, CategoryVM>()
                .ForMember(destination => destination.CountSubcategories, opt => opt.MapFrom(src => src.Subcategories.Count))
                .ForMember(destination => destination.Subcategories, opt => opt.MapFrom(src => src.Subcategories.OrderByDescending(p => p.CreatedAt).Take(10)))
                .ReverseMap();
            CreateMap<CartItem, CartItemVM>().ReverseMap();
            CreateMap<Cart, CartVM>()
                .ForMember(destination => destination.CountCartItems, opt => opt.MapFrom(src => src.CartItems.Count))
                .ForMember(destination => destination.CartItems, opt => opt.MapFrom(src => src.CartItems.OrderByDescending(p => p.CreatedAt).Take(10)))
                .ReverseMap();
            CreateMap<BookPartner, BookPartnerVM>().ReverseMap();
            CreateMap<Book, BookVM>()
            .ForMember(dest => dest.RateAverage, opt => opt.MapFrom(src => src.Reviews.Any() ? src.Reviews.Average(r => r.Rating) : 0))
            .ForMember(dest => dest.RateCount, opt => opt.MapFrom(src => src.Reviews.Count))
            .ForMember(dest => dest.Rate1Percentage, opt => opt.MapFrom(src => src.Reviews.Any() ? src.Reviews.Count(r => r.Rating == 1) * 100 / src.Reviews.Count : 0))
            .ForMember(dest => dest.Rate2Percentage, opt => opt.MapFrom(src => src.Reviews.Any() ? src.Reviews.Count(r => r.Rating == 2) * 100 / src.Reviews.Count : 0))
            .ForMember(dest => dest.Rate3Percentage, opt => opt.MapFrom(src => src.Reviews.Any() ? src.Reviews.Count(r => r.Rating == 3) * 100 / src.Reviews.Count : 0))
            .ForMember(dest => dest.Rate4Percentage, opt => opt.MapFrom(src => src.Reviews.Any() ? src.Reviews.Count(r => r.Rating == 4) * 100 / src.Reviews.Count : 0))
            .ForMember(dest => dest.Rate5Percentage, opt => opt.MapFrom(src => src.Reviews.Any() ? src.Reviews.Count(r => r.Rating == 5) * 100 / src.Reviews.Count : 0))

            .ForMember(dest => dest.Solded, opt => opt.MapFrom(src => src.OrderItems.Sum(oi => oi.Quantity)))
            .ForMember(dest => dest.CurrentPrice, opt => opt.MapFrom(src => src.Price - (src.Price * src.DiscountPercentage / 100)))
            .ForMember(dest => dest.FavouritesCount, opt => opt.MapFrom(src => src.Favourites.Count))
            .ForMember(dest => dest.SubcategoryName, opt => opt.MapFrom(src => src.Subcategory != null ? src.Subcategory.Name : null))
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author != null ? src.Author.Name : null))
            .ForMember(dest => dest.CoverTypeName, opt => opt.MapFrom(src => src.CoverType != null ? src.CoverType.TypeName : null))
            .ForMember(dest => dest.DimensionName, opt => opt.MapFrom(src => src.Dimension != null ? $"{src.Dimension.Length} x {src.Dimension.Width} x {src.Dimension.Height} {src.Dimension.Unit}" : null))
            .ForMember(dest => dest.BookPartners, opt => opt.MapFrom(src => src.BookPartners.OrderByDescending(p => p.CreatedAt).Take(10)))
            .ForMember(dest => dest.PosterImages, opt => opt.MapFrom(src => src.PosterImages.OrderByDescending(p => p.ImageDefault).Take(10)))
            .ReverseMap();

            CreateMap<Banner, BannerVM>().ReverseMap();
            CreateMap<Author, AuthorVM>()
                .ForMember(destination => destination.CountBooks, opt => opt.MapFrom(src => src.Books.Count))
                .ForMember(destination => destination.Books, opt => opt.MapFrom(src => src.Books.OrderByDescending(p => p.CreatedAt).Take(10)))
                .ReverseMap();
            CreateMap<AspNetUser, AspNetUserVM>()
                .ForMember(destination => destination.CountAddresses, opt => opt.MapFrom(src => src.Addresses.Count))
                .ForMember(destination => destination.Addresses, opt => opt.MapFrom(src => src.Addresses.OrderByDescending(p => p.CreatedAt).Take(10)))
                .ForMember(destination => destination.CountFavourites, opt => opt.MapFrom(src => src.Favourites.Count))
                .ForMember(destination => destination.Favourites, opt => opt.MapFrom(src => src.Favourites.OrderByDescending(p => p.CreatedAt).Take(10)))
                .ForMember(destination => destination.CountNotifications, opt => opt.MapFrom(src => src.Notifications.Count))
                .ForMember(destination => destination.Notifications, opt => opt.MapFrom(src => src.Notifications.OrderByDescending(p => p.CreatedAt).Take(10)))
                .ForMember(destination => destination.CountOrders, opt => opt.MapFrom(src => src.Orders.Count))
                .ForMember(destination => destination.Orders, opt => opt.MapFrom(src => src.Orders.OrderByDescending(p => p.CreatedAt).Take(10)))
                .ForMember(destination => destination.CountReviews, opt => opt.MapFrom(src => src.Reviews.Count))
                .ForMember(destination => destination.Reviews, opt => opt.MapFrom(src => src.Reviews.OrderByDescending(p => p.CreatedAt).Take(10)))
                .ForMember(destination => destination.CountRoles, opt => opt.MapFrom(src => src.Roles.Count))
                .ForMember(destination => destination.Roles, opt => opt.MapFrom(src => src.Roles.OrderByDescending(p => p.Id).Take(10)))
                .ReverseMap();
            CreateMap<AspNetRole, AspNetRoleVM>()
                .ForMember(destination => destination.CountUsers, opt => opt.MapFrom(src => src.Users.Count))
                .ForMember(destination => destination.Users, opt => opt.MapFrom(src => src.Users.OrderByDescending(p => p.CreatedAt).Take(10)))
                .ReverseMap();
            CreateMap<Address, AddressVM>()
                .ForMember(destination => destination.CountOrders, opt => opt.MapFrom(src => src.Orders.Count))
                .ForMember(destination => destination.Orders, opt => opt.MapFrom(src => src.Orders.OrderByDescending(p => p.CreatedAt).Take(10)))
                .ReverseMap();

            #endregion

            #region Entity to Dto

            CreateMap<Website, WebsiteDto>().ReverseMap();
            CreateMap<Voucher, VoucherDto>()
                .ForMember(destination => destination.CountOrders, opt => opt.MapFrom(src => src.Orders.Count))
                .ReverseMap();
            CreateMap<TopicContent, TopicContentDto>().ReverseMap();
            CreateMap<Topic, TopicDto>()
                .ForMember(destination => destination.CountTopicContents, opt => opt.MapFrom(src => src.TopicContents.Count))
                .ReverseMap();
            CreateMap<Subcategory, SubcategoryDto>()
                .ForMember(destination => destination.CountBooks, opt => opt.MapFrom(src => src.Books.Count))
                .ReverseMap();
            CreateMap<Status, StatusDto>()
                .ForMember(destination => destination.CountOrderStatuses, opt => opt.MapFrom(src => src.OrderStatuses.Count))
                .ReverseMap();
            CreateMap<Review, ReviewDto>()
                .ForMember(destination => destination.UserFullName, opt => opt.MapFrom(src => src.User != null ? src.User.FullName : default))
                .ForMember(destination => destination.UserAvatar, opt => opt.MapFrom(src => src.User != null ? src.User.ImageUrl : default))
                .ReverseMap();
            CreateMap<PosterImage, PosterImageDto>().ReverseMap();
            CreateMap<Platform, PlatformDto>().ReverseMap();
            CreateMap<PaymentMethod, PaymentMethodDto>()
                .ForMember(destination => destination.CountOrders, opt => opt.MapFrom(src => src.Orders.Count))
                .ReverseMap();
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<PartnerType, PartnerTypeDto>()
                .ForMember(destination => destination.CountPartners, opt => opt.MapFrom(src => src.Partners.Count))
                .ReverseMap();
            CreateMap<Partner, PartnerDto>()
                .ForMember(destination => destination.CountBookPartners, opt => opt.MapFrom(src => src.BookPartners.Count))
                .ReverseMap();
            CreateMap<OrderStatus, OrderStatusDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<Order, OrderDto>()
                .ForMember(destination => destination.CountOrderItems, opt => opt.MapFrom(src => src.OrderItems.Count))
                .ForMember(destination => destination.CountOrderStatuses, opt => opt.MapFrom(src => src.OrderStatuses.Count))
                .ForMember(destination => destination.CountReviews, opt => opt.MapFrom(src => src.Reviews.Count))
                .ReverseMap();
            CreateMap<NotificationType, NotificationTypeDto>()
                .ForMember(destination => destination.CountNotifications, opt => opt.MapFrom(src => src.Notifications.Count))
                .ReverseMap();
            CreateMap<Notification, NotificationDto>().ReverseMap();
            CreateMap<Menu, MenuDto>().ReverseMap();
            CreateMap<FlashSaleBook, FlashSaleBookDto>()
                .ForMember(destination => destination.Solded, opt => opt.MapFrom(src =>
                    src.Book != null
                        ? src.Book.OrderItems
                            .Where(oi => src.FlashSale != null && oi.CreatedAt >= src.FlashSale.StartDate && oi.CreatedAt <= src.FlashSale.EndDate)
                            .Sum(oi => oi.Quantity)
                        : 0))
                .ForMember(destination => destination.PriceFS, opt => opt.MapFrom(src => src.Book != null ? src.Book.Price - (src.Book.Price * src.DiscountPercentage / 100) : default))
                .ReverseMap();
            CreateMap<FlashSale, FlashSaleDto>()
                .ForMember(destination => destination.CountFlashSaleBooks, opt => opt.MapFrom(src => src.FlashSaleBooks.Count))
                .ReverseMap();
            CreateMap<Favourite, FavouriteDto>().ReverseMap();
            CreateMap<Dimension, DimensionDto>()
                .ForMember(destination => destination.CountBooks, opt => opt.MapFrom(src => src.Books.Count))
                .ReverseMap();
            CreateMap<CoverType, CoverTypeDto>()
                .ForMember(destination => destination.CountBooks, opt => opt.MapFrom(src => src.Books.Count))
                .ReverseMap();
            CreateMap<Category, CategoryDto>()
                .ForMember(destination => destination.CountSubcategories, opt => opt.MapFrom(src => src.Subcategories.Count))
                .ReverseMap();
            CreateMap<CartItem, CartItemDto>().ReverseMap();
            CreateMap<Cart, CartDto>()
                .ForMember(destination => destination.CountCartItems, opt => opt.MapFrom(src => src.CartItems.Count))
                .ReverseMap();
            CreateMap<BookPartner, BookPartnerDto>()
                .ForMember(destination => destination.PartnerName, opt => opt.MapFrom(src => src.Partner != null ? src.Partner.Name : default))
                .ForMember(destination => destination.PartnerTypeId, opt => opt.MapFrom(src => src.Partner != null ? src.Partner.PartnerTypeId : default ))
                .ForMember(destination => destination.PartnerTypeName, opt => opt.MapFrom(src => src.Partner != null && src.Partner.PartnerType != null ? src.Partner.PartnerType.Name : default))
                .ReverseMap();
            CreateMap<Book, BookDto>()
            .ForMember(dest => dest.RateAverage, opt => opt.MapFrom(src => src.Reviews.Any() ? src.Reviews.Average(r => r.Rating) : 0))
            .ForMember(dest => dest.RateCount, opt => opt.MapFrom(src => src.Reviews.Count))
            .ForMember(dest => dest.Solded, opt => opt.MapFrom(src => src.OrderItems.Sum(oi => oi.Quantity)))
            .ForMember(dest => dest.CurrentPrice, opt => opt.MapFrom(src => src.Price - (src.Price * src.DiscountPercentage / 100)))
            .ForMember(dest => dest.FavouritesCount, opt => opt.MapFrom(src => src.Favourites.Count))
            .ForMember(dest => dest.poster, opt => opt.MapFrom(src => src.PosterImages.FirstOrDefault(e => e.ImageDefault == true).ImageUrl))
            .ReverseMap();

            CreateMap<Banner, BannerDto>().ReverseMap();
            CreateMap<Author, AuthorDto>()
                .ForMember(destination => destination.CountBooks, opt => opt.MapFrom(src => src.Books.Count))
                .ReverseMap();
            CreateMap<AspNetUser, AspNetUserDto>()
                .ForMember(destination => destination.CountAddresses, opt => opt.MapFrom(src => src.Addresses.Count))
                .ForMember(destination => destination.CountFavourites, opt => opt.MapFrom(src => src.Favourites.Count))
                .ForMember(destination => destination.CountNotifications, opt => opt.MapFrom(src => src.Notifications.Count))
                .ForMember(destination => destination.CountOrders, opt => opt.MapFrom(src => src.Orders.Count))
                .ForMember(destination => destination.CountReviews, opt => opt.MapFrom(src => src.Reviews.Count))
                .ForMember(destination => destination.CountRoles, opt => opt.MapFrom(src => src.Roles.Count))
                .ReverseMap();
            CreateMap<AspNetRole, AspNetRoleDto>()
                .ForMember(destination => destination.CountUsers, opt => opt.MapFrom(src => src.Users.Count))
                .ReverseMap();
            CreateMap<Address, AddressDto>()
                .ForMember(destination => destination.CountOrders, opt => opt.MapFrom(src => src.Orders.Count))
                .ReverseMap();

            #endregion
        }
    }
}
