using FahasaStore.Models;
using FahasaStoreApp.Areas.Admin.Models;
using FahasaStoreApp.Areas.Base;
using FahasaStoreApp.Helpers;
using FahasaStoreApp.Models;
using FahasaStoreApp.Services;

namespace FahasaStoreApp.Areas.Admin.Services
{
    #region Address
    public interface IAdminAddressService : IBaseService<AdminAddresses, AddressDetail, AddressExtend, AddressBase>
    {
    }
    public class AdminAddressService : BaseService<AdminAddresses, AddressDetail, AddressExtend, AddressBase>, IAdminAddressService
    {
        public AdminAddressService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion

    #region AspNetUser
    public interface IAdminAspNetUserService : IBaseService<AdminAspNetUsers, AspNetUserDetail, AspNetUserExtend, AspNetUserBase>
    {
    }
    public class AdminAspNetUserService : BaseService<AdminAspNetUsers, AspNetUserDetail, AspNetUserExtend, AspNetUserBase>, IAdminAspNetUserService
    {
        public AdminAspNetUserService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Author
    public interface IAdminAuthorService : IBaseService<AdminAuthors, AuthorDetail, AuthorExtend, AuthorBase>
    {
    }
    public class AdminAuthorService : BaseService<AdminAuthors, AuthorDetail, AuthorExtend, AuthorBase>, IAdminAuthorService
    {
        public AdminAuthorService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Banner
    public interface IAdminBannerService : IBaseService<AdminBanners, BannerDetail, BannerExtend, BannerBase>
    {
    }
    public class AdminBannerService : BaseService<AdminBanners, BannerDetail, BannerExtend, BannerBase>, IAdminBannerService
    {
        public AdminBannerService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Book
    public interface IAdminBookService : IBaseService<AdminBooks, BookDetail, BookExtend, BookBase>
    {
    }
    public class AdminBookService : BaseService<AdminBooks, BookDetail, BookExtend, BookBase>, IAdminBookService
    {
        public AdminBookService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion

    #region BookPartner
    public interface IAdminBookPartnerService : IBaseService<AdminBookPartners, BookPartnerDetail, BookPartnerExtend, BookPartnerBase>
    {
    }
    public class AdminBookPartnerService : BaseService<AdminBookPartners, BookPartnerDetail, BookPartnerExtend, BookPartnerBase>, IAdminBookPartnerService
    {
        public AdminBookPartnerService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Cart
    public interface IAdminCartService : IBaseService<AdminCarts, CartDetail, CartExtend, CartBase>
    {
    }
    public class AdminCartService : BaseService<AdminCarts, CartDetail, CartExtend, CartBase>, IAdminCartService
    {
        public AdminCartService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion

    #region CartItem
    public interface IAdminCartItemService : IBaseService<AdminCartItems, CartItemDetail, CartItemExtend, CartItemBase>
    {
    }
    public class AdminCartItemService : BaseService<AdminCartItems, CartItemDetail, CartItemExtend, CartItemBase>, IAdminCartItemService
    {
        public AdminCartItemService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Category
    public interface IAdminCategoryService : IBaseService<AdminCategories, CategoryDetail, CategoryExtend, CategoryBase>
    {
    }
    public class AdminCategoryService : BaseService<AdminCategories, CategoryDetail, CategoryExtend, CategoryBase>, IAdminCategoryService
    {
        public AdminCategoryService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion

    #region CoverType
    public interface IAdminCoverTypeService : IBaseService<AdminCoverTypes, CoverTypeDetail, CoverTypeExtend, CoverTypeBase>
    {
    }
    public class AdminCoverTypeService : BaseService<AdminCoverTypes, CoverTypeDetail, CoverTypeExtend, CoverTypeBase>, IAdminCoverTypeService
    {
        public AdminCoverTypeService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Dimension
    public interface IAdminDimensionService : IBaseService<AdminDimensions, DimensionDetail, DimensionExtend, DimensionBase>
    {
    }
    public class AdminDimensionService : BaseService<AdminDimensions, DimensionDetail, DimensionExtend, DimensionBase>, IAdminDimensionService
    {
        public AdminDimensionService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Favourite
    public interface IAdminFavouriteService : IBaseService<AdminFavourites, FavouriteDetail, FavouriteExtend, FavouriteBase>
    {
    }
    public class AdminFavouriteService : BaseService<AdminFavourites, FavouriteDetail, FavouriteExtend, FavouriteBase>, IAdminFavouriteService
    {
        public AdminFavouriteService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion

    #region FlashSale
    public interface IAdminFlashSaleService : IBaseService<AdminFlashSales, FlashSaleDetail, FlashSaleExtend, FlashSaleBase>
    {
    }
    public class AdminFlashSaleService : BaseService<AdminFlashSales, FlashSaleDetail, FlashSaleExtend, FlashSaleBase>, IAdminFlashSaleService
    {
        public AdminFlashSaleService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion

    #region FlashSaleBook
    public interface IAdminFlashSaleBookService : IBaseService<AdminFlashSaleBooks, FlashSaleBookDetail, FlashSaleBookExtend, FlashSaleBookBase>
    {
    }
    public class AdminFlashSaleBookService : BaseService<AdminFlashSaleBooks, FlashSaleBookDetail, FlashSaleBookExtend, FlashSaleBookBase>, IAdminFlashSaleBookService
    {
        public AdminFlashSaleBookService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Menu
    public interface IAdminMenuService : IBaseService<AdminMenus, MenuDetail, MenuExtend, MenuBase>
    {
    }
    public class AdminMenuService : BaseService<AdminMenus, MenuDetail, MenuExtend, MenuBase>, IAdminMenuService
    {
        public AdminMenuService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Notification
    public interface IAdminNotificationService : IBaseService<AdminNotifications, NotificationDetail, NotificationExtend, NotificationBase>
    {
    }
    public class AdminNotificationService : BaseService<AdminNotifications, NotificationDetail, NotificationExtend, NotificationBase>, IAdminNotificationService
    {
        public AdminNotificationService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion

    #region NotificationType
    public interface IAdminNotificationTypeService : IBaseService<AdminNotificationTypes, NotificationTypeDetail, NotificationTypeExtend, NotificationTypeBase>
    {
    }
    public class AdminNotificationTypeService : BaseService<AdminNotificationTypes, NotificationTypeDetail, NotificationTypeExtend, NotificationTypeBase>, IAdminNotificationTypeService
    {
        public AdminNotificationTypeService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Order
    public interface IAdminOrderService : IBaseService<AdminOrders, OrderDetail, OrderExtend, OrderBase>
    {
    }
    public class AdminOrderService : BaseService<AdminOrders, OrderDetail, OrderExtend, OrderBase>, IAdminOrderService
    {
        public AdminOrderService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion

    #region OrderItem
    public interface IAdminOrderItemService : IBaseService<AdminOrderItems, OrderItemDetail, OrderItemExtend, OrderItemBase>
    {
    }
    public class AdminOrderItemService : BaseService<AdminOrderItems, OrderItemDetail, OrderItemExtend, OrderItemBase>, IAdminOrderItemService
    {
        public AdminOrderItemService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion

    #region OrderStatus
    public interface IAdminOrderStatusService : IBaseService<AdminOrderStatuses, OrderStatusDetail, OrderStatusExtend, OrderStatusBase>
    {
    }
    public class AdminOrderStatusService : BaseService<AdminOrderStatuses, OrderStatusDetail, OrderStatusExtend, OrderStatusBase>, IAdminOrderStatusService
    {
        public AdminOrderStatusService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Partner
    public interface IAdminPartnerService : IBaseService<AdminPartners, PartnerDetail, PartnerExtend, PartnerBase>
    {
    }
    public class AdminPartnerService : BaseService<AdminPartners, PartnerDetail, PartnerExtend, PartnerBase>, IAdminPartnerService
    {
        public AdminPartnerService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion

    #region PartnerType
    public interface IAdminPartnerTypeService : IBaseService<AdminPartnerTypes, PartnerTypeDetail, PartnerTypeExtend, PartnerTypeBase>
    {
    }
    public class AdminPartnerTypeService : BaseService<AdminPartnerTypes, PartnerTypeDetail, PartnerTypeExtend, PartnerTypeBase>, IAdminPartnerTypeService
    {
        public AdminPartnerTypeService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion

    #region PaymentMethod
    public interface IAdminPaymentMethodService : IBaseService<AdminPaymentMethods, PaymentMethodDetail, PaymentMethodExtend, PaymentMethodBase>
    {
    }
    public class AdminPaymentMethodService : BaseService<AdminPaymentMethods, PaymentMethodDetail, PaymentMethodExtend, PaymentMethodBase>, IAdminPaymentMethodService
    {
        public AdminPaymentMethodService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Platform
    public interface IAdminPlatformService : IBaseService<AdminPlatforms, PlatformDetail, PlatformExtend, PlatformBase>
    {
    }
    public class AdminPlatformService : BaseService<AdminPlatforms, PlatformDetail, PlatformExtend, PlatformBase>, IAdminPlatformService
    {
        public AdminPlatformService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion

    #region PosterImage
    public interface IAdminPosterImageService : IBaseService<AdminPosterImages, PosterImageDetail, PosterImageExtend, PosterImageBase>
    {
    }
    public class AdminPosterImageService : BaseService<AdminPosterImages, PosterImageDetail, PosterImageExtend, PosterImageBase>, IAdminPosterImageService
    {
        public AdminPosterImageService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Review
    public interface IAdminReviewService : IBaseService<AdminReviews, ReviewDetail, ReviewExtend, ReviewBase>
    {
    }
    public class AdminReviewService : BaseService<AdminReviews, ReviewDetail, ReviewExtend, ReviewBase>, IAdminReviewService
    {
        public AdminReviewService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Status
    public interface IAdminStatusService : IBaseService<AdminStatuses, StatusDetail, StatusExtend, StatusBase>
    {
    }
    public class AdminStatusService : BaseService<AdminStatuses, StatusDetail, StatusExtend, StatusBase>, IAdminStatusService
    {
        public AdminStatusService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Subcategory
    public interface IAdminSubcategoryService : IBaseService<AdminSubcategories, SubcategoryDetail, SubcategoryExtend, SubcategoryBase>
    {
    }
    public class AdminSubcategoryService : BaseService<AdminSubcategories, SubcategoryDetail, SubcategoryExtend, SubcategoryBase>, IAdminSubcategoryService
    {
        public AdminSubcategoryService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Topic
    public interface IAdminTopicService : IBaseService<AdminTopics, TopicDetail, TopicExtend, TopicBase>
    {
    }
    public class AdminTopicService : BaseService<AdminTopics, TopicDetail, TopicExtend, TopicBase>, IAdminTopicService
    {
        public AdminTopicService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion

    #region TopicContent
    public interface IAdminTopicContentService : IBaseService<AdminTopicContents, TopicContentDetail, TopicContentExtend, TopicContentBase>
    {
    }
    public class AdminTopicContentService : BaseService<AdminTopicContents, TopicContentDetail, TopicContentExtend, TopicContentBase>, IAdminTopicContentService
    {
        public AdminTopicContentService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Voucher
    public interface IAdminVoucherService : IBaseService<AdminVouchers, VoucherDetail, VoucherExtend, VoucherBase>
    {
    }
    public class AdminVoucherService : BaseService<AdminVouchers, VoucherDetail, VoucherExtend, VoucherBase>, IAdminVoucherService
    {
        public AdminVoucherService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion

    #region Website
    public interface IAdminWebsiteService : IBaseService<AdminWebsites, WebsiteDetail, WebsiteExtend, WebsiteBase>
    {
    }
    public class AdminWebsiteService : BaseService<AdminWebsites, WebsiteDetail, WebsiteExtend, WebsiteBase>, IAdminWebsiteService
    {
        public AdminWebsiteService(IHttpClientFactory httpClientFactory, IMethodsHelper methodsHelper, ICloudinaryService cloudinaryService) : base(httpClientFactory, methodsHelper, cloudinaryService)
        {
        }
    }
    #endregion
}
