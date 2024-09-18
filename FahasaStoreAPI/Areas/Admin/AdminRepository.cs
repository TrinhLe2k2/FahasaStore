using AutoMapper;
using AutoMapper.QueryableExtensions;
using FahasaStore.Models;
using FahasaStoreAPI.Areas.Base;
using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.ViewModels;
using FahasaStoreAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace FahasaStoreAPI.Areas.Admin
{
    #region Address
    public interface IAdminAddressRepository : IAdminBaseRepository<Address, AddressDetail, AddressExtend, AddressBase>
    {
    }

    public class AdminAddressRepository : AdminBaseRepository<Address, AddressDetail, AddressExtend, AddressBase>, IAdminAddressRepository
    {
        public AdminAddressRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }
    }
    #endregion

    #region AspNetUser
    public interface IAdminAspNetUserRepository : IAdminBaseRepository<AspNetUser, AspNetUserDetail, AspNetUserExtend, AspNetUserBase>
    {
    }

    public class AdminAspNetUserRepository : AdminBaseRepository<AspNetUser, AspNetUserDetail, AspNetUserExtend, AspNetUserBase>, IAdminAspNetUserRepository
    {
        public AdminAspNetUserRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Author
    public interface IAdminAuthorRepository : IAdminBaseRepository<Author, AuthorDetail, AuthorExtend, AuthorBase>
    {
    }

    public class AdminAuthorRepository : AdminBaseRepository<Author, AuthorDetail, AuthorExtend, AuthorBase>, IAdminAuthorRepository
    {
        public AdminAuthorRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Banner
    public interface IAdminBannerRepository : IAdminBaseRepository<Banner, BannerDetail, BannerExtend, BannerBase>
    {
    }

    public class AdminBannerRepository : AdminBaseRepository<Banner, BannerDetail, BannerExtend, BannerBase>, IAdminBannerRepository
    {
        public AdminBannerRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Book
    public interface IAdminBookRepository : IAdminBaseRepository<Book, BookDetail, BookExtend, BookBase>
    {
    }

    public class AdminBookRepository : AdminBaseRepository<Book, BookDetail, BookExtend, BookBase>, IAdminBookRepository
    {
        public AdminBookRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }

        public override IQueryable<BookExtend> QueryForFilter()
        {
            var query = _dbSet.AsNoTracking().AsQueryable().ProjectTo<BookExtend>(_mapper.ConfigurationProvider)
                .Select(book => new BookExtend
                {
                    Id = book.Id,
                    Name = book.Name,
                    Price = book.Price,
                    DiscountPercentage = book.DiscountPercentage,
                    Quantity = book.Quantity,
                    CreatedAt = book.CreatedAt,
                    Solded = book.Solded,
                    CurrentPrice = book.CurrentPrice,
                    FavouritesCount = book.FavouritesCount,
                    SubcategoryName = book.SubcategoryName,
                    AuthorName = book.AuthorName,
                    CoverTypeName = book.CoverTypeName,
                    DimensionName = book.DimensionName,
                    BookPoster = book.BookPoster,
                    RateAverage = book.RateAverage,
                    RateCount = book.RateCount,
                });
            return query;
        }
    }
    #endregion

    #region BookPartner
    public interface IAdminBookPartnerRepository : IAdminBaseRepository<BookPartner, BookPartnerDetail, BookPartnerExtend, BookPartnerBase>
    {
    }

    public class AdminBookPartnerRepository : AdminBaseRepository<BookPartner, BookPartnerDetail, BookPartnerExtend, BookPartnerBase>, IAdminBookPartnerRepository
    {
        public AdminBookPartnerRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Cart
    public interface IAdminCartRepository : IAdminBaseRepository<Cart, CartDetail, CartExtend, CartBase>
    {
    }

    public class AdminCartRepository : AdminBaseRepository<Cart, CartDetail, CartExtend, CartBase>, IAdminCartRepository
    {
        public AdminCartRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }
    }
    #endregion

    #region CartItem
    public interface IAdminCartItemRepository : IAdminBaseRepository<CartItem, CartItemDetail, CartItemExtend, CartItemBase>
    {
    }

    public class AdminCartItemRepository : AdminBaseRepository<CartItem, CartItemDetail, CartItemExtend, CartItemBase>, IAdminCartItemRepository
    {
        public AdminCartItemRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Category
    public interface IAdminCategoryRepository : IAdminBaseRepository<Category, CategoryDetail, CategoryExtend, CategoryBase>
    {
    }

    public class AdminCategoryRepository : AdminBaseRepository<Category, CategoryDetail, CategoryExtend, CategoryBase>, IAdminCategoryRepository
    {
        public AdminCategoryRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }
    }
    #endregion

    #region CoverType
    public interface IAdminCoverTypeRepository : IAdminBaseRepository<CoverType, CoverTypeDetail, CoverTypeExtend, CoverTypeBase>
    {
    }

    public class AdminCoverTypeRepository : AdminBaseRepository<CoverType, CoverTypeDetail, CoverTypeExtend, CoverTypeBase>, IAdminCoverTypeRepository
    {
        public AdminCoverTypeRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Dimension
    public interface IAdminDimensionRepository : IAdminBaseRepository<Dimension, DimensionDetail, DimensionExtend, DimensionBase>
    {
    }

    public class AdminDimensionRepository : AdminBaseRepository<Dimension, DimensionDetail, DimensionExtend, DimensionBase>, IAdminDimensionRepository
    {
        public AdminDimensionRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Favourite
    public interface IAdminFavouriteRepository : IAdminBaseRepository<Favourite, FavouriteDetail, FavouriteExtend, FavouriteBase>
    {
    }

    public class AdminFavouriteRepository : AdminBaseRepository<Favourite, FavouriteDetail, FavouriteExtend, FavouriteBase>, IAdminFavouriteRepository
    {
        public AdminFavouriteRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }
    }
    #endregion

    #region FlashSale
    public interface IAdminFlashSaleRepository : IAdminBaseRepository<FlashSale, FlashSaleDetail, FlashSaleExtend, FlashSaleBase>
    {
    }

    public class AdminFlashSaleRepository : AdminBaseRepository<FlashSale, FlashSaleDetail, FlashSaleExtend, FlashSaleBase>, IAdminFlashSaleRepository
    {
        public AdminFlashSaleRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }
    }
    #endregion

    #region FlashSaleBook
    public interface IAdminFlashSaleBookRepository : IAdminBaseRepository<FlashSaleBook, FlashSaleBookDetail, FlashSaleBookExtend, FlashSaleBookBase>
    {
    }

    public class AdminFlashSaleBookRepository : AdminBaseRepository<FlashSaleBook, FlashSaleBookDetail, FlashSaleBookExtend, FlashSaleBookBase>, IAdminFlashSaleBookRepository
    {
        public AdminFlashSaleBookRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Menu
    public interface IAdminMenuRepository : IAdminBaseRepository<Menu, MenuDetail, MenuExtend, MenuBase>
    {
    }

    public class AdminMenuRepository : AdminBaseRepository<Menu, MenuDetail, MenuExtend, MenuBase>, IAdminMenuRepository
    {
        public AdminMenuRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Notification
    public interface IAdminNotificationRepository : IAdminBaseRepository<Notification, NotificationDetail, NotificationExtend, NotificationBase>
    {
    }

    public class AdminNotificationRepository : AdminBaseRepository<Notification, NotificationDetail, NotificationExtend, NotificationBase>, IAdminNotificationRepository
    {
        public AdminNotificationRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }
    }
    #endregion

    #region NotificationType
    public interface IAdminNotificationTypeRepository : IAdminBaseRepository<NotificationType, NotificationTypeDetail, NotificationTypeExtend, NotificationTypeBase>
    {
    }

    public class AdminNotificationTypeRepository : AdminBaseRepository<NotificationType, NotificationTypeDetail, NotificationTypeExtend, NotificationTypeBase>, IAdminNotificationTypeRepository
    {
        public AdminNotificationTypeRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Order
    public interface IAdminOrderRepository : IAdminBaseRepository<Order, OrderDetail, OrderExtend, OrderBase>
    {
    }

    public class AdminOrderRepository : AdminBaseRepository<Order, OrderDetail, OrderExtend, OrderBase>, IAdminOrderRepository
    {
        public AdminOrderRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }
    }
    #endregion

    #region OrderItem
    public interface IAdminOrderItemRepository : IAdminBaseRepository<OrderItem, OrderItemDetail, OrderItemExtend, OrderItemBase>
    {
    }

    public class AdminOrderItemRepository : AdminBaseRepository<OrderItem, OrderItemDetail, OrderItemExtend, OrderItemBase>, IAdminOrderItemRepository
    {
        public AdminOrderItemRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }
    }
    #endregion

    #region OrderStatus
    public interface IAdminOrderStatusRepository : IAdminBaseRepository<OrderStatus, OrderStatusDetail, OrderStatusExtend, OrderStatusBase>
    {
    }

    public class AdminOrderStatusRepository : AdminBaseRepository<OrderStatus, OrderStatusDetail, OrderStatusExtend, OrderStatusBase>, IAdminOrderStatusRepository
    {
        public AdminOrderStatusRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Partner
    public interface IAdminPartnerRepository : IAdminBaseRepository<Partner, PartnerDetail, PartnerExtend, PartnerBase>
    {
    }

    public class AdminPartnerRepository : AdminBaseRepository<Partner, PartnerDetail, PartnerExtend, PartnerBase>, IAdminPartnerRepository
    {
        public AdminPartnerRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }
    }
    #endregion

    #region PartnerType
    public interface IAdminPartnerTypeRepository : IAdminBaseRepository<PartnerType, PartnerTypeDetail, PartnerTypeExtend, PartnerTypeBase>
    {
    }

    public class AdminPartnerTypeRepository : AdminBaseRepository<PartnerType, PartnerTypeDetail, PartnerTypeExtend, PartnerTypeBase>, IAdminPartnerTypeRepository
    {
        public AdminPartnerTypeRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }
    }
    #endregion

    #region PaymentMethod
    public interface IAdminPaymentMethodRepository : IAdminBaseRepository<PaymentMethod, PaymentMethodDetail, PaymentMethodExtend, PaymentMethodBase>
    {
    }

    public class AdminPaymentMethodRepository : AdminBaseRepository<PaymentMethod, PaymentMethodDetail, PaymentMethodExtend, PaymentMethodBase>, IAdminPaymentMethodRepository
    {
        public AdminPaymentMethodRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Platform
    public interface IAdminPlatformRepository : IAdminBaseRepository<Platform, PlatformDetail, PlatformExtend, PlatformBase>
    {
    }

    public class AdminPlatformRepository : AdminBaseRepository<Platform, PlatformDetail, PlatformExtend, PlatformBase>, IAdminPlatformRepository
    {
        public AdminPlatformRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }
    }
    #endregion

    #region PosterImage
    public interface IAdminPosterImageRepository : IAdminBaseRepository<PosterImage, PosterImageDetail, PosterImageExtend, PosterImageBase>
    {
    }

    public class AdminPosterImageRepository : AdminBaseRepository<PosterImage, PosterImageDetail, PosterImageExtend, PosterImageBase>, IAdminPosterImageRepository
    {
        public AdminPosterImageRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Review
    public interface IAdminReviewRepository : IAdminBaseRepository<Review, ReviewDetail, ReviewExtend, ReviewBase>
    {
    }

    public class AdminReviewRepository : AdminBaseRepository<Review, ReviewDetail, ReviewExtend, ReviewBase>, IAdminReviewRepository
    {
        public AdminReviewRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Status
    public interface IAdminStatusRepository : IAdminBaseRepository<Status, StatusDetail, StatusExtend, StatusBase>
    {
    }

    public class AdminStatusRepository : AdminBaseRepository<Status, StatusDetail, StatusExtend, StatusBase>, IAdminStatusRepository
    {
        public AdminStatusRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Subcategory
    public interface IAdminSubcategoryRepository : IAdminBaseRepository<Subcategory, SubcategoryDetail, SubcategoryExtend, SubcategoryBase>
    {
    }

    public class AdminSubcategoryRepository : AdminBaseRepository<Subcategory, SubcategoryDetail, SubcategoryExtend, SubcategoryBase>, IAdminSubcategoryRepository
    {
        public AdminSubcategoryRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Topic
    public interface IAdminTopicRepository : IAdminBaseRepository<Topic, TopicDetail, TopicExtend, TopicBase>
    {
    }

    public class AdminTopicRepository : AdminBaseRepository<Topic, TopicDetail, TopicExtend, TopicBase>, IAdminTopicRepository
    {
        public AdminTopicRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }
    }
    #endregion

    #region TopicContent
    public interface IAdminTopicContentRepository : IAdminBaseRepository<TopicContent, TopicContentDetail, TopicContentExtend, TopicContentBase>
    {
    }

    public class AdminTopicContentRepository : AdminBaseRepository<TopicContent, TopicContentDetail, TopicContentExtend, TopicContentBase>, IAdminTopicContentRepository
    {
        public AdminTopicContentRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Voucher
    public interface IAdminVoucherRepository : IAdminBaseRepository<Voucher, VoucherDetail, VoucherExtend, VoucherBase>
    {
    }

    public class AdminVoucherRepository : AdminBaseRepository<Voucher, VoucherDetail, VoucherExtend, VoucherBase>, IAdminVoucherRepository
    {
        public AdminVoucherRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Website
    public interface IAdminWebsiteRepository : IAdminBaseRepository<Website, WebsiteDetail, WebsiteExtend, WebsiteBase>
    {
    }

    public class AdminWebsiteRepository : AdminBaseRepository<Website, WebsiteDetail, WebsiteExtend, WebsiteBase>, IAdminWebsiteRepository
    {
        public AdminWebsiteRepository(FahasaStoreDBContext context, IMapper mapper, ICloudinaryService cloudinaryService) : base(context, mapper, cloudinaryService)
        {
        }
    }
    #endregion
}