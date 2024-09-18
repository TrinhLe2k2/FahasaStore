using AutoMapper;
using FahasaStore.Models;
using FahasaStoreAPI.Constants;
using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.Entities;
//Ignore
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


            #region Base - Extend - Detail

            CreateMap<Address, AddressBase>().ReverseMap();
            CreateMap<Address, AddressExtend>()
                .ForMember(dest => dest.IsChanger, opt => opt.MapFrom(src => !src.Orders.Any(o => o.AddressId == src.Id)))
                .ReverseMap();
            CreateMap<Address, AddressDetail>()
                .IncludeBase<Address, AddressExtend>()
                .ReverseMap();

            CreateMap<AspNetUser, AspNetUserBase>().ReverseMap();
            CreateMap<AspNetUser, AspNetUserExtend>().ReverseMap();
            CreateMap<AspNetUser, AspNetUserDetail>()
                .IncludeBase<AspNetUser, AspNetUserExtend>()
                .ForMember(destination => destination.DefaultAddress, opt => opt.MapFrom(src => src.Addresses.FirstOrDefault(e => e.Default)))
                .ForMember(destination => destination.Favourites, opt => opt.MapFrom(src => src.Favourites.OrderByDescending(p => p.Id).Take(10)))
                .ForMember(destination => destination.Notifications, opt => opt.MapFrom(src => src.Notifications.OrderByDescending(p => p.Id).Take(10)))
                .ForMember(destination => destination.Orders, opt => opt.MapFrom(src => src.Orders.OrderByDescending(p => p.Id).Take(10)))
                .ForMember(destination => destination.Reviews, opt => opt.MapFrom(src => src.Reviews.OrderByDescending(p => p.Id).Take(10)))
                .ReverseMap();

            CreateMap<Author, AuthorBase>().ReverseMap();
            CreateMap<Author, AuthorExtend>().ReverseMap();
            CreateMap<Author, AuthorDetail>()
                .IncludeBase<Author, AuthorExtend>()
                .ReverseMap();

            CreateMap<Banner, BannerBase>().ReverseMap();
            CreateMap<Banner, BannerExtend>().ReverseMap();
            CreateMap<Banner, BannerDetail>()
                .IncludeBase<Banner, BannerExtend>()
                .ReverseMap();

            CreateMap<Book, BookBase>().ReverseMap();
            CreateMap<Book, BookExtend>()
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
                .ForMember(dest => dest.BookPoster, opt => opt.MapFrom(src => src.PosterImages.FirstOrDefault(e => e.Default == true).ImageUrl))
                .ReverseMap();
            CreateMap<Book, BookDetail>()
                .IncludeBase<Book, BookExtend>()
                .ReverseMap();

            CreateMap<BookPartner, BookPartnerBase>().ReverseMap();
            CreateMap<BookPartner, BookPartnerExtend>()
                .ForMember(dest => dest.PartnerTypeId, opt => opt.MapFrom(src => src.Partner != null ? src.Partner.PartnerTypeId : default))
                .ForMember(dest => dest.PartnerTypeName, opt => opt.MapFrom(src => src.Partner != null && src.Partner.PartnerType != null ? src.Partner.PartnerType.Name : default))
                .ReverseMap();
            CreateMap<BookPartner, BookPartnerDetail>()
                .IncludeBase<BookPartner, BookPartnerExtend>()
                .ReverseMap();

            CreateMap<Cart, CartBase>().ReverseMap();
            CreateMap<Cart, CartExtend>()
                .ForMember(dest => dest.BookIds, opt => opt.MapFrom(src => src.CartItems.Select(ci => ci.BookId.GetValueOrDefault())))
                .ReverseMap();
            CreateMap<Cart, CartDetail>()
                .IncludeBase<Cart, CartExtend>()
                .ReverseMap();

            CreateMap<CartItem, CartItemBase>().ReverseMap();
            CreateMap<CartItem, CartItemExtend>()
                .ForMember(destination => destination.IntoMoney, opt => opt.MapFrom(src => src.Book != null ? src.Quantity * (src.Book.Price - (src.Book.Price * src.Book.DiscountPercentage / 100)) : default))
                .ReverseMap();
            CreateMap<CartItem, CartItemDetail>()
                .IncludeBase<CartItem, CartItemExtend>()
                .ReverseMap();

            CreateMap<Category, CategoryBase>().ReverseMap();
            CreateMap<Category, CategoryExtend>().ReverseMap();
            CreateMap<Category, CategoryDetail>()
                .IncludeBase<Category, CategoryExtend>()
                .ReverseMap();

            CreateMap<CoverType, CoverTypeBase>().ReverseMap();
            CreateMap<CoverType, CoverTypeExtend>().ReverseMap();
            CreateMap<CoverType, CoverTypeDetail>()
                .IncludeBase<CoverType, CoverTypeExtend>()
                .ReverseMap();

            CreateMap<Dimension, DimensionBase>().ReverseMap();
            CreateMap<Dimension, DimensionExtend>().ReverseMap();
            CreateMap<Dimension, DimensionDetail>()
                .IncludeBase<Dimension, DimensionExtend>()
                .ReverseMap();

            CreateMap<Favourite, FavouriteBase>().ReverseMap();
            CreateMap<Favourite, FavouriteExtend>().ReverseMap();
            CreateMap<Favourite, FavouriteDetail>()
                .IncludeBase<Favourite, FavouriteExtend>()
                .ReverseMap();

            CreateMap<FlashSale, FlashSaleBase>().ReverseMap();
            CreateMap<FlashSale, FlashSaleExtend>().ReverseMap();
            CreateMap<FlashSale, FlashSaleDetail>()
                .IncludeBase<FlashSale, FlashSaleExtend>()
                .ForMember(dest => dest.FlashSaleBooks, opt => opt.MapFrom(src => src.FlashSaleBooks.OrderByDescending(e => e.Id).Take(10)))
                .ReverseMap();

            CreateMap<FlashSaleBook, FlashSaleBookBase>().ReverseMap();
            CreateMap<FlashSaleBook, FlashSaleBookExtend>()
                .ForMember(destination => destination.Solded, opt => opt.MapFrom(src =>
                    src.Book != null
                        ? src.Book.OrderItems
                            .Where(oi => src.FlashSale != null && oi.CreatedAt >= src.FlashSale.StartDate && oi.CreatedAt <= src.FlashSale.EndDate)
                            .Sum(oi => oi.Quantity)
                        : 0))
                .ForMember(destination => destination.PriceFS, opt => opt.MapFrom(src => src.Book != null ? src.Book.Price - (src.Book.Price * src.DiscountPercentage / 100) : default))
                .ReverseMap();
            CreateMap<FlashSaleBook, FlashSaleBookDetail>()
                .IncludeBase<FlashSaleBook, FlashSaleBookExtend>()
                .ReverseMap();

            CreateMap<Menu, MenuBase>().ReverseMap();
            CreateMap<Menu, MenuExtend>().ReverseMap();
            CreateMap<Menu, MenuDetail>()
                .IncludeBase<Menu, MenuExtend>()
                .ReverseMap();

            CreateMap<Notification, NotificationBase>().ReverseMap();
            CreateMap<Notification, NotificationExtend>().ReverseMap();
            CreateMap<Notification, NotificationDetail>()
                .IncludeBase<Notification, NotificationExtend>()
                .ReverseMap();

            CreateMap<NotificationType, NotificationTypeBase>().ReverseMap();
            CreateMap<NotificationType, NotificationTypeExtend>().ReverseMap();
            CreateMap<NotificationType, NotificationTypeDetail>()
                .IncludeBase<NotificationType, NotificationTypeExtend>()
                .ReverseMap();

            CreateMap<Order, OrderBase>().ReverseMap();
            CreateMap<Order, OrderExtend>()
                .ForMember(destination => destination.isCancelable, opt => opt.MapFrom(src =>
                    (
                        src.OrderStatuses.OrderBy(e => e.Id).LastOrDefault().Status.Name.Equals(OrderStatusConst.Processing) ||
                        src.OrderStatuses.OrderBy(e => e.Id).LastOrDefault().Status.Name.Equals(OrderStatusConst.Confirmed)
                    ) ? true : false
                 ))
                .ForMember(destination => destination.isReturnable, opt => opt.MapFrom(src =>
                    (
                        src.OrderStatuses.OrderBy(e => e.Id).LastOrDefault().Status.Name.Equals(OrderStatusConst.Completed)
                    ) ? true : false
                 ))
                .ForMember(destination => destination.isCompletable, opt => opt.MapFrom(src =>
                    (
                        src.OrderStatuses.OrderBy(e => e.Id).LastOrDefault().Status.Name.Equals(OrderStatusConst.Shipped)
                    ) ? true : false
                 ))
                .ForMember(destination => destination.QuantityBooksCount, opt => opt.MapFrom(src => src.OrderItems.Sum(e => e.Quantity)))
                .ForMember(destination => destination.IntoMoney, opt => opt.MapFrom(src => src.OrderItems.Sum(e => e.Quantity * (e.Price - (e.Price * e.DiscountPercentage / 100)))))
                .ForMember(destination => destination.ReceiverName, opt => opt.MapFrom(src => src.Address != null ? src.Address.ReceiverName : default))
                .ForMember(destination => destination.OrderLastStatus, opt => opt.MapFrom(src => src.OrderStatuses.OrderBy(os => os.Id).Last().Status.Name))
                .ReverseMap();
            CreateMap<Order, OrderDetail>()
                .IncludeBase<Order, OrderExtend>()
                .ForMember(destination => destination.OrderItems, opt => opt.MapFrom(src => src.OrderItems.OrderByDescending(p => p.Id).Take(10)))
                .ForMember(destination => destination.OrderStatuses, opt => opt.MapFrom(src => src.OrderStatuses.OrderBy(p => p.Id).Take(10)))
                .ReverseMap();

            CreateMap<OrderItem, OrderItemBase>().ReverseMap();
            CreateMap<OrderItem, OrderItemExtend>()
                .ForMember(destination => destination.PriceBook, opt => opt.MapFrom(src => src.Price - (src.Price * src.DiscountPercentage / 100)))
                .ForMember(destination => destination.IntoMoney, opt => opt.MapFrom(src => src.Quantity * (src.Price - (src.Price * src.DiscountPercentage / 100))))
                .ForMember(destination => destination.HasReview, opt => opt.MapFrom(src => src.Review != null))
                .ReverseMap();
            CreateMap<OrderItem, OrderItemDetail>()
                .IncludeBase<OrderItem, OrderItemExtend>()
                .ReverseMap();

            CreateMap<OrderStatus, OrderStatusBase>().ReverseMap();
            CreateMap<OrderStatus, OrderStatusExtend>().ReverseMap();
            CreateMap<OrderStatus, OrderStatusDetail>()
                .IncludeBase<OrderStatus, OrderStatusExtend>()
                .ReverseMap();

            CreateMap<Partner, PartnerBase>().ReverseMap();
            CreateMap<Partner, PartnerExtend>().ReverseMap();
            CreateMap<Partner, PartnerDetail>()
                .IncludeBase<Partner, PartnerExtend>()
                .ReverseMap();

            CreateMap<PartnerType, PartnerTypeBase>().ReverseMap();
            CreateMap<PartnerType, PartnerTypeExtend>().ReverseMap();
            CreateMap<PartnerType, PartnerTypeDetail>()
                .IncludeBase<PartnerType, PartnerTypeExtend>()
                .ReverseMap();

            CreateMap<PaymentMethod, PaymentMethodBase>().ReverseMap();
            CreateMap<PaymentMethod, PaymentMethodExtend>().ReverseMap();
            CreateMap<PaymentMethod, PaymentMethodDetail>()
                .IncludeBase<PaymentMethod, PaymentMethodExtend>()
                .ReverseMap();

            CreateMap<Platform, PlatformBase>().ReverseMap();
            CreateMap<Platform, PlatformExtend>().ReverseMap();
            CreateMap<Platform, PlatformDetail>()
                .IncludeBase<Platform, PlatformExtend>()
                .ReverseMap();

            CreateMap<PosterImage, PosterImageBase>().ReverseMap();
            CreateMap<PosterImage, PosterImageExtend>().ReverseMap();
            CreateMap<PosterImage, PosterImageDetail>()
                .IncludeBase<PosterImage, PosterImageExtend>()
                .ReverseMap();

            CreateMap<Review, ReviewBase>().ReverseMap();
            CreateMap<Review, ReviewExtend>()
                .ForMember(destination => destination.BookPoster, opt => opt.MapFrom(src => src.Book.PosterImages.FirstOrDefault(e => e.Default == true).ImageUrl))
                .ReverseMap();
            CreateMap<Review, ReviewDetail>()
                .IncludeBase<Review, ReviewExtend>()
                .ReverseMap();
            
            CreateMap<Status, StatusBase>().ReverseMap();
            CreateMap<Status, StatusExtend>().ReverseMap();
            CreateMap<Status, StatusDetail>()
                .IncludeBase<Status, StatusExtend>()
                .ReverseMap();

            CreateMap<Subcategory, SubcategoryBase>().ReverseMap();
            CreateMap<Subcategory, SubcategoryExtend>().ReverseMap();
            CreateMap<Subcategory, SubcategoryDetail>()
                .IncludeBase<Subcategory, SubcategoryExtend>()
                .ReverseMap();

            CreateMap<Topic, TopicBase>().ReverseMap();
            CreateMap<Topic, TopicExtend>().ReverseMap();
            CreateMap<Topic, TopicDetail>()
                .IncludeBase<Topic, TopicExtend>()
                .ReverseMap();

            CreateMap<TopicContent, TopicContentBase>().ReverseMap();
            CreateMap<TopicContent, TopicContentExtend>().ReverseMap();
            CreateMap<TopicContent, TopicContentDetail>()
                .IncludeBase<TopicContent, TopicContentExtend>()
                .ReverseMap();

            CreateMap<Voucher, VoucherBase>().ReverseMap();
            CreateMap<Voucher, VoucherExtend>().ReverseMap();

            CreateMap<Voucher, VoucherDetail>()
                .IncludeBase<Voucher, VoucherExtend>()
                .ForMember(destination => destination.Orders, opt => opt.MapFrom(src => src.Orders.OrderByDescending(p => p.Id).Take(10)))
                .ReverseMap();

            CreateMap<Website, WebsiteExtend>().ReverseMap();
            CreateMap<Website, WebsiteDetail>()
                .IncludeBase<Website, WebsiteExtend>()
                .ReverseMap();
            CreateMap<Website, WebsiteBase>().ReverseMap();

            #endregion
        }
    }
}
