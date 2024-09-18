using FahasaStore.Models;
using FahasaStoreAPI.Areas.Base;
using FahasaStoreAPI.Models.Entities;

namespace FahasaStoreAPI.Areas.Admin
{
    #region Address
    public interface IAdminAddressService : IAdminBaseService<Address, AddressDetail, AddressExtend, AddressBase>
    {
    }

    public class AdminAddressService : AdminBaseService<Address, AddressDetail, AddressExtend, AddressBase>, IAdminAddressService
    {
        private readonly IAdminAddressRepository _repository;
        public AdminAddressService(IAdminAddressRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion

    #region AspNetUser
    public interface IAdminAspNetUserService : IAdminBaseService<AspNetUser, AspNetUserDetail, AspNetUserExtend, AspNetUserBase>
    {
    }

    public class AdminAspNetUserService : AdminBaseService<AspNetUser, AspNetUserDetail, AspNetUserExtend, AspNetUserBase>, IAdminAspNetUserService
    {
        private readonly IAdminAspNetUserRepository _repository;
        public AdminAspNetUserService(IAdminAspNetUserRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion

    #region Author
    public interface IAdminAuthorService : IAdminBaseService<Author, AuthorDetail, AuthorExtend, AuthorBase>
    {
    }

    public class AdminAuthorService : AdminBaseService<Author, AuthorDetail, AuthorExtend, AuthorBase>, IAdminAuthorService
    {
        private readonly IAdminAuthorRepository _repository;
        public AdminAuthorService(IAdminAuthorRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion

    #region Banner
    public interface IAdminBannerService : IAdminBaseService<Banner, BannerDetail, BannerExtend, BannerBase>
    {
    }

    public class AdminBannerService : AdminBaseService<Banner, BannerDetail, BannerExtend, BannerBase>, IAdminBannerService
    {
        private readonly IAdminBannerRepository _repository;
        public AdminBannerService(IAdminBannerRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion

    #region Book
    public interface IAdminBookService : IAdminBaseService<Book, BookDetail, BookExtend, BookBase>
    {
    }

    public class AdminBookService : AdminBaseService<Book, BookDetail, BookExtend, BookBase>, IAdminBookService
    {
        private readonly IAdminBookRepository _repository;
        public AdminBookService(IAdminBookRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion

    #region BookPartner
    public interface IAdminBookPartnerService : IAdminBaseService<BookPartner, BookPartnerDetail, BookPartnerExtend, BookPartnerBase>
    {
    }

    public class AdminBookPartnerService : AdminBaseService<BookPartner, BookPartnerDetail, BookPartnerExtend, BookPartnerBase>, IAdminBookPartnerService
    {
        private readonly IAdminBookPartnerRepository _repository;
        public AdminBookPartnerService(IAdminBookPartnerRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion

    #region Cart
    public interface IAdminCartService : IAdminBaseService<Cart, CartDetail, CartExtend, CartBase>
    {
    }

    public class AdminCartService : AdminBaseService<Cart, CartDetail, CartExtend, CartBase>, IAdminCartService
    {
        private readonly IAdminCartRepository _repository;
        public AdminCartService(IAdminCartRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion

    #region CartItem
    public interface IAdminCartItemService : IAdminBaseService<CartItem, CartItemDetail, CartItemExtend, CartItemBase>
    {
    }

    public class AdminCartItemService : AdminBaseService<CartItem, CartItemDetail, CartItemExtend, CartItemBase>, IAdminCartItemService
    {
        private readonly IAdminCartItemRepository _repository;
        public AdminCartItemService(IAdminCartItemRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion

    #region Category
    public interface IAdminCategoryService : IAdminBaseService<Category, CategoryDetail, CategoryExtend, CategoryBase>
    {
    }

    public class AdminCategoryService : AdminBaseService<Category, CategoryDetail, CategoryExtend, CategoryBase>, IAdminCategoryService
    {
        private readonly IAdminCategoryRepository _repository;
        public AdminCategoryService(IAdminCategoryRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion

    #region CoverType
    public interface IAdminCoverTypeService : IAdminBaseService<CoverType, CoverTypeDetail, CoverTypeExtend, CoverTypeBase>
    {
    }

    public class AdminCoverTypeService : AdminBaseService<CoverType, CoverTypeDetail, CoverTypeExtend, CoverTypeBase>, IAdminCoverTypeService
    {
        private readonly IAdminCoverTypeRepository _repository;
        public AdminCoverTypeService(IAdminCoverTypeRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion

    #region Dimension
    public interface IAdminDimensionService : IAdminBaseService<Dimension, DimensionDetail, DimensionExtend, DimensionBase>
    {
    }

    public class AdminDimensionService : AdminBaseService<Dimension, DimensionDetail, DimensionExtend, DimensionBase>, IAdminDimensionService
    {
        private readonly IAdminDimensionRepository _repository;
        public AdminDimensionService(IAdminDimensionRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion

    #region Favourite
    public interface IAdminFavouriteService : IAdminBaseService<Favourite, FavouriteDetail, FavouriteExtend, FavouriteBase>
    {
    }

    public class AdminFavouriteService : AdminBaseService<Favourite, FavouriteDetail, FavouriteExtend, FavouriteBase>, IAdminFavouriteService
    {
        private readonly IAdminFavouriteRepository _repository;
        public AdminFavouriteService(IAdminFavouriteRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion

    #region FlashSale
    public interface IAdminFlashSaleService : IAdminBaseService<FlashSale, FlashSaleDetail, FlashSaleExtend, FlashSaleBase>
    {
    }

    public class AdminFlashSaleService : AdminBaseService<FlashSale, FlashSaleDetail, FlashSaleExtend, FlashSaleBase>, IAdminFlashSaleService
    {
        private readonly IAdminFlashSaleRepository _repository;
        public AdminFlashSaleService(IAdminFlashSaleRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion

    #region FlashSaleBook
    public interface IAdminFlashSaleBookService : IAdminBaseService<FlashSaleBook, FlashSaleBookDetail, FlashSaleBookExtend, FlashSaleBookBase>
    {
    }

    public class AdminFlashSaleBookService : AdminBaseService<FlashSaleBook, FlashSaleBookDetail, FlashSaleBookExtend, FlashSaleBookBase>, IAdminFlashSaleBookService
    {
        private readonly IAdminFlashSaleBookRepository _repository;
        public AdminFlashSaleBookService(IAdminFlashSaleBookRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion

    #region Menu
    public interface IAdminMenuService : IAdminBaseService<Menu, MenuDetail, MenuExtend, MenuBase>
    {
    }

    public class AdminMenuService : AdminBaseService<Menu, MenuDetail, MenuExtend, MenuBase>, IAdminMenuService
    {
        private readonly IAdminMenuRepository _repository;
        public AdminMenuService(IAdminMenuRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion

    #region Notification
    public interface IAdminNotificationService : IAdminBaseService<Notification, NotificationDetail, NotificationExtend, NotificationBase>
    {
    }

    public class AdminNotificationService : AdminBaseService<Notification, NotificationDetail, NotificationExtend, NotificationBase>, IAdminNotificationService
    {
        private readonly IAdminNotificationRepository _repository;
        public AdminNotificationService(IAdminNotificationRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion

    #region NotificationType
    public interface IAdminNotificationTypeService : IAdminBaseService<NotificationType, NotificationTypeDetail, NotificationTypeExtend, NotificationTypeBase>
    {
    }

    public class AdminNotificationTypeService : AdminBaseService<NotificationType, NotificationTypeDetail, NotificationTypeExtend, NotificationTypeBase>, IAdminNotificationTypeService
    {
        private readonly IAdminNotificationTypeRepository _repository;
        public AdminNotificationTypeService(IAdminNotificationTypeRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion

    #region Order
    public interface IAdminOrderService : IAdminBaseService<Order, OrderDetail, OrderExtend, OrderBase>
    {
    }

    public class AdminOrderService : AdminBaseService<Order, OrderDetail, OrderExtend, OrderBase>, IAdminOrderService
    {
        private readonly IAdminOrderRepository _repository;
        public AdminOrderService(IAdminOrderRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion

    #region OrderItem
    public interface IAdminOrderItemService : IAdminBaseService<OrderItem, OrderItemDetail, OrderItemExtend, OrderItemBase>
    {
    }

    public class AdminOrderItemService : AdminBaseService<OrderItem, OrderItemDetail, OrderItemExtend, OrderItemBase>, IAdminOrderItemService
    {
        private readonly IAdminOrderItemRepository _repository;
        public AdminOrderItemService(IAdminOrderItemRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion

    #region OrderStatus
    public interface IAdminOrderStatusService : IAdminBaseService<OrderStatus, OrderStatusDetail, OrderStatusExtend, OrderStatusBase>
    {
    }

    public class AdminOrderStatusService : AdminBaseService<OrderStatus, OrderStatusDetail, OrderStatusExtend, OrderStatusBase>, IAdminOrderStatusService
    {
        private readonly IAdminOrderStatusRepository _repository;
        public AdminOrderStatusService(IAdminOrderStatusRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion

    #region Partner
    public interface IAdminPartnerService : IAdminBaseService<Partner, PartnerDetail, PartnerExtend, PartnerBase>
    {
    }

    public class AdminPartnerService : AdminBaseService<Partner, PartnerDetail, PartnerExtend, PartnerBase>, IAdminPartnerService
    {
        private readonly IAdminPartnerRepository _repository;
        public AdminPartnerService(IAdminPartnerRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion

    #region PartnerType
    public interface IAdminPartnerTypeService : IAdminBaseService<PartnerType, PartnerTypeDetail, PartnerTypeExtend, PartnerTypeBase>
    {
    }

    public class AdminPartnerTypeService : AdminBaseService<PartnerType, PartnerTypeDetail, PartnerTypeExtend, PartnerTypeBase>, IAdminPartnerTypeService
    {
        private readonly IAdminPartnerTypeRepository _repository;
        public AdminPartnerTypeService(IAdminPartnerTypeRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion

    #region PaymentMethod
    public interface IAdminPaymentMethodService : IAdminBaseService<PaymentMethod, PaymentMethodDetail, PaymentMethodExtend, PaymentMethodBase>
    {
    }

    public class AdminPaymentMethodService : AdminBaseService<PaymentMethod, PaymentMethodDetail, PaymentMethodExtend, PaymentMethodBase>, IAdminPaymentMethodService
    {
        private readonly IAdminPaymentMethodRepository _repository;
        public AdminPaymentMethodService(IAdminPaymentMethodRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion

    #region Platform
    public interface IAdminPlatformService : IAdminBaseService<Platform, PlatformDetail, PlatformExtend, PlatformBase>
    {
    }

    public class AdminPlatformService : AdminBaseService<Platform, PlatformDetail, PlatformExtend, PlatformBase>, IAdminPlatformService
    {
        private readonly IAdminPlatformRepository _repository;
        public AdminPlatformService(IAdminPlatformRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion

    #region PosterImage
    public interface IAdminPosterImageService : IAdminBaseService<PosterImage, PosterImageDetail, PosterImageExtend, PosterImageBase>
    {
    }

    public class AdminPosterImageService : AdminBaseService<PosterImage, PosterImageDetail, PosterImageExtend, PosterImageBase>, IAdminPosterImageService
    {
        private readonly IAdminPosterImageRepository _repository;
        public AdminPosterImageService(IAdminPosterImageRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion

    #region Review
    public interface IAdminReviewService : IAdminBaseService<Review, ReviewDetail, ReviewExtend, ReviewBase>
    {
    }

    public class AdminReviewService : AdminBaseService<Review, ReviewDetail, ReviewExtend, ReviewBase>, IAdminReviewService
    {
        private readonly IAdminReviewRepository _repository;
        public AdminReviewService(IAdminReviewRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion

    #region Status
    public interface IAdminStatusService : IAdminBaseService<Status, StatusDetail, StatusExtend, StatusBase>
    {
    }

    public class AdminStatusService : AdminBaseService<Status, StatusDetail, StatusExtend, StatusBase>, IAdminStatusService
    {
        private readonly IAdminStatusRepository _repository;
        public AdminStatusService(IAdminStatusRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion

    #region Subcategory
    public interface IAdminSubcategoryService : IAdminBaseService<Subcategory, SubcategoryDetail, SubcategoryExtend, SubcategoryBase>
    {
    }

    public class AdminSubcategoryService : AdminBaseService<Subcategory, SubcategoryDetail, SubcategoryExtend, SubcategoryBase>, IAdminSubcategoryService
    {
        private readonly IAdminSubcategoryRepository _repository;
        public AdminSubcategoryService(IAdminSubcategoryRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion

    #region Topic
    public interface IAdminTopicService : IAdminBaseService<Topic, TopicDetail, TopicExtend, TopicBase>
    {
    }

    public class AdminTopicService : AdminBaseService<Topic, TopicDetail, TopicExtend, TopicBase>, IAdminTopicService
    {
        private readonly IAdminTopicRepository _repository;
        public AdminTopicService(IAdminTopicRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion

    #region TopicContent
    public interface IAdminTopicContentService : IAdminBaseService<TopicContent, TopicContentDetail, TopicContentExtend, TopicContentBase>
    {
    }

    public class AdminTopicContentService : AdminBaseService<TopicContent, TopicContentDetail, TopicContentExtend, TopicContentBase>, IAdminTopicContentService
    {
        private readonly IAdminTopicContentRepository _repository;
        public AdminTopicContentService(IAdminTopicContentRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion

    #region Voucher
    public interface IAdminVoucherService : IAdminBaseService<Voucher, VoucherDetail, VoucherExtend, VoucherBase>
    {
    }

    public class AdminVoucherService : AdminBaseService<Voucher, VoucherDetail, VoucherExtend, VoucherBase>, IAdminVoucherService
    {
        private readonly IAdminVoucherRepository _repository;
        public AdminVoucherService(IAdminVoucherRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion

    #region Website
    public interface IAdminWebsiteService : IAdminBaseService<Website, WebsiteDetail, WebsiteExtend, WebsiteBase>
    {
    }

    public class AdminWebsiteService : AdminBaseService<Website, WebsiteDetail, WebsiteExtend, WebsiteBase>, IAdminWebsiteService
    {
        private readonly IAdminWebsiteRepository _repository;
        public AdminWebsiteService(IAdminWebsiteRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
    #endregion
}
