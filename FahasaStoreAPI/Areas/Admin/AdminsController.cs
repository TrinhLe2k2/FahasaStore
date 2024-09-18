using FahasaStore.Models;
using FahasaStoreAPI.Areas.Base;
using FahasaStoreAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreAPI.Areas.Admin
{
    #region Address Ignore
    //[Route("api/[controller]")]
    //[ApiController]
    //public class AdminAddressesController : AdminBaseController<Address, AddressDetail, AddressExtend, AddressBase>
    //{
    //    private readonly IAdminAddressService _service;
    //    public AdminAddressesController(IAdminAddressService service) : base(service)
    //    {
    //        _service = service;
    //    }
    //}
    #endregion

    #region AspNetUser Forbid
    [Route("api/[controller]")]
    [ApiController]
    public class AdminAspNetUsersController : AdminBaseController<AspNetUser, AspNetUserDetail, AspNetUserExtend, AspNetUserBase>
    {
        private readonly IAdminAspNetUserService _service;
        public AdminAspNetUsersController(IAdminAspNetUserService service) : base(service)
        {
            _service = service;
        }

        public override Task<IActionResult> Add(AspNetUserBase model)
        {
            return Task.FromResult<IActionResult>(Forbid());
            //return base.Add(model);
        }

        public override Task<IActionResult> Delete(int id)
        {
            return Task.FromResult<IActionResult>(Forbid());
            //return base.Delete(id);
        }

        public override Task<IActionResult> Update(int id, AspNetUserBase model)
        {
            return Task.FromResult<IActionResult>(Forbid());
            //return base.Update(id, model);
        }
    }
    #endregion

    #region Author
    [Route("api/[controller]")]
    [ApiController]
    public class AdminAuthorsController : AdminBaseController<Author, AuthorDetail, AuthorExtend, AuthorBase>
    {
        private readonly IAdminAuthorService _service;
        public AdminAuthorsController(IAdminAuthorService service) : base(service)
        {
            _service = service;
        }
    }
    #endregion

    #region Banner
    [Route("api/[controller]")]
    [ApiController]
    public class AdminBannersController : AdminBaseController<Banner, BannerDetail, BannerExtend, BannerBase>
    {
        private readonly IAdminBannerService _service;
        public AdminBannersController(IAdminBannerService service) : base(service)
        {
            _service = service;
        }
    }
    #endregion

    #region Book
    [Route("api/[controller]")]
    [ApiController]
    public class AdminBooksController : AdminBaseController<Book, BookDetail, BookExtend, BookBase>
    {
        private readonly IAdminBookService _service;
        public AdminBooksController(IAdminBookService service) : base(service)
        {
            _service = service;
        }
    }
    #endregion

    #region BookPartner
    [Route("api/[controller]")]
    [ApiController]
    public class AdminBookPartnersController : AdminBaseController<BookPartner, BookPartnerDetail, BookPartnerExtend, BookPartnerBase>
    {
        private readonly IAdminBookPartnerService _service;
        public AdminBookPartnersController(IAdminBookPartnerService service) : base(service)
        {
            _service = service;
        }
    }
    #endregion

    #region Cart Ignore
    //[Route("api/[controller]")]
    //[ApiController]
    //public class AdminCartsController : AdminBaseController<Cart, CartDetail, CartExtend, CartBase>
    //{
    //    private readonly IAdminCartService _service;
    //    public AdminCartsController(IAdminCartService service) : base(service)
    //    {
    //        _service = service;
    //    }
    //}
    #endregion

    #region CartItem Ignore
    //[Route("api/[controller]")]
    //[ApiController]
    //public class AdminCartItemsController : AdminBaseController<CartItem, CartItemDetail, CartItemExtend, CartItemBase>
    //{
    //    private readonly IAdminCartItemService _service;
    //    public AdminCartItemsController(IAdminCartItemService service) : base(service)
    //    {
    //        _service = service;
    //    }
    //}
    #endregion

    #region Category
    [Route("api/[controller]")]
    [ApiController]
    public class AdminCategoriesController : AdminBaseController<Category, CategoryDetail, CategoryExtend, CategoryBase>
    {
        private readonly IAdminCategoryService _service;
        public AdminCategoriesController(IAdminCategoryService service) : base(service)
        {
            _service = service;
        }
    }
    #endregion

    #region CoverType
    [Route("api/[controller]")]
    [ApiController]
    public class AdminCoverTypesController : AdminBaseController<CoverType, CoverTypeDetail, CoverTypeExtend, CoverTypeBase>
    {
        private readonly IAdminCoverTypeService _service;
        public AdminCoverTypesController(IAdminCoverTypeService service) : base(service)
        {
            _service = service;
        }
    }
    #endregion

    #region Dimension
    [Route("api/[controller]")]
    [ApiController]
    public class AdminDimensionsController : AdminBaseController<Dimension, DimensionDetail, DimensionExtend, DimensionBase>
    {
        private readonly IAdminDimensionService _service;
        public AdminDimensionsController(IAdminDimensionService service) : base(service)
        {
            _service = service;
        }
    }
    #endregion

    #region Favourite Ignore
    //[Route("api/[controller]")]
    //[ApiController]
    //public class AdminFavouritesController : AdminBaseController<Favourite, FavouriteDetail, FavouriteExtend, FavouriteBase>
    //{
    //    private readonly IAdminFavouriteService _service;
    //    public AdminFavouritesController(IAdminFavouriteService service) : base(service)
    //    {
    //        _service = service;
    //    }
    //}
    #endregion

    #region FlashSale
    [Route("api/[controller]")]
    [ApiController]
    public class AdminFlashSalesController : AdminBaseController<FlashSale, FlashSaleDetail, FlashSaleExtend, FlashSaleBase>
    {
        private readonly IAdminFlashSaleService _service;
        public AdminFlashSalesController(IAdminFlashSaleService service) : base(service)
        {
            _service = service;
        }
    }
    #endregion

    #region FlashSaleBook
    [Route("api/[controller]")]
    [ApiController]
    public class AdminFlashSaleBooksController : AdminBaseController<FlashSaleBook, FlashSaleBookDetail, FlashSaleBookExtend, FlashSaleBookBase>
    {
        private readonly IAdminFlashSaleBookService _service;
        public AdminFlashSaleBooksController(IAdminFlashSaleBookService service) : base(service)
        {
            _service = service;
        }
    }
    #endregion

    #region Menu
    [Route("api/[controller]")]
    [ApiController]
    public class AdminMenusController : AdminBaseController<Menu, MenuDetail, MenuExtend, MenuBase>
    {
        private readonly IAdminMenuService _service;
        public AdminMenusController(IAdminMenuService service) : base(service)
        {
            _service = service;
        }
    }
    #endregion

    #region Notification
    [Route("api/[controller]")]
    [ApiController]
    public class AdminNotificationsController : AdminBaseController<Notification, NotificationDetail, NotificationExtend, NotificationBase>
    {
        private readonly IAdminNotificationService _service;
        public AdminNotificationsController(IAdminNotificationService service) : base(service)
        {
            _service = service;
        }
    }
    #endregion

    #region NotificationType
    [Route("api/[controller]")]
    [ApiController]
    public class AdminNotificationTypesController : AdminBaseController<NotificationType, NotificationTypeDetail, NotificationTypeExtend, NotificationTypeBase>
    {
        private readonly IAdminNotificationTypeService _service;
        public AdminNotificationTypesController(IAdminNotificationTypeService service) : base(service)
        {
            _service = service;
        }
    }
    #endregion

    #region Order
    [Route("api/[controller]")]
    [ApiController]
    public class AdminOrdersController : AdminBaseController<Order, OrderDetail, OrderExtend, OrderBase>
    {
        private readonly IAdminOrderService _service;
        public AdminOrdersController(IAdminOrderService service) : base(service)
        {
            _service = service;
        }
    }
    #endregion

    #region OrderItem Ignore
    //[Route("api/[controller]")]
    //[ApiController]
    //public class AdminOrderItemsController : AdminBaseController<OrderItem, OrderItemDetail, OrderItemExtend, OrderItemBase>
    //{
    //    private readonly IAdminOrderItemService _service;
    //    public AdminOrderItemsController(IAdminOrderItemService service) : base(service)
    //    {
    //        _service = service;
    //    }
    //}
    #endregion

    #region OrderStatus
    [Route("api/[controller]")]
    [ApiController]
    public class AdminOrderStatusesController : AdminBaseController<OrderStatus, OrderStatusDetail, OrderStatusExtend, OrderStatusBase>
    {
        private readonly IAdminOrderStatusService _service;
        public AdminOrderStatusesController(IAdminOrderStatusService service) : base(service)
        {
            _service = service;
        }
    }
    #endregion

    #region Partner
    [Route("api/[controller]")]
    [ApiController]
    public class AdminPartnersController : AdminBaseController<Partner, PartnerDetail, PartnerExtend, PartnerBase>
    {
        private readonly IAdminPartnerService _service;
        public AdminPartnersController(IAdminPartnerService service) : base(service)
        {
            _service = service;
        }
    }
    #endregion

    #region PartnerType
    [Route("api/[controller]")]
    [ApiController]
    public class AdminPartnerTypesController : AdminBaseController<PartnerType, PartnerTypeDetail, PartnerTypeExtend, PartnerTypeBase>
    {
        private readonly IAdminPartnerTypeService _service;
        public AdminPartnerTypesController(IAdminPartnerTypeService service) : base(service)
        {
            _service = service;
        }
    }
    #endregion

    #region PaymentMethod
    [Route("api/[controller]")]
    [ApiController]
    public class AdminPaymentMethodsController : AdminBaseController<PaymentMethod, PaymentMethodDetail, PaymentMethodExtend, PaymentMethodBase>
    {
        private readonly IAdminPaymentMethodService _service;
        public AdminPaymentMethodsController(IAdminPaymentMethodService service) : base(service)
        {
            _service = service;
        }
    }
    #endregion

    #region Platform
    [Route("api/[controller]")]
    [ApiController]
    public class AdminPlatformsController : AdminBaseController<Platform, PlatformDetail, PlatformExtend, PlatformBase>
    {
        private readonly IAdminPlatformService _service;
        public AdminPlatformsController(IAdminPlatformService service) : base(service)
        {
            _service = service;
        }
    }
    #endregion

    #region PosterImage
    [Route("api/[controller]")]
    [ApiController]
    public class AdminPosterImagesController : AdminBaseController<PosterImage, PosterImageDetail, PosterImageExtend, PosterImageBase>
    {
        private readonly IAdminPosterImageService _service;
        public AdminPosterImagesController(IAdminPosterImageService service) : base(service)
        {
            _service = service;
        }
    }
    #endregion

    #region Review
    //[Route("api/[controller]")]
    //[ApiController]
    //public class AdminReviewsController : AdminBaseController<Review, ReviewDetail, ReviewExtend, ReviewBase>
    //{
    //    private readonly IAdminReviewService _service;
    //    public AdminReviewsController(IAdminReviewService service) : base(service)
    //    {
    //        _service = service;
    //    }
    //}
    #endregion

    #region Status
    [Route("api/[controller]")]
    [ApiController]
    public class AdminStatusesController : AdminBaseController<Status, StatusDetail, StatusExtend, StatusBase>
    {
        private readonly IAdminStatusService _service;
        public AdminStatusesController(IAdminStatusService service) : base(service)
        {
            _service = service;
        }
    }
    #endregion

    #region Subcategory
    [Route("api/[controller]")]
    [ApiController]
    public class AdminSubcategoriesController : AdminBaseController<Subcategory, SubcategoryDetail, SubcategoryExtend, SubcategoryBase>
    {
        private readonly IAdminSubcategoryService _service;
        public AdminSubcategoriesController(IAdminSubcategoryService service) : base(service)
        {
            _service = service;
        }
    }
    #endregion

    #region Topic
    [Route("api/[controller]")]
    [ApiController]
    public class AdminTopicsController : AdminBaseController<Topic, TopicDetail, TopicExtend, TopicBase>
    {
        private readonly IAdminTopicService _service;
        public AdminTopicsController(IAdminTopicService service) : base(service)
        {
            _service = service;
        }
    }
    #endregion

    #region TopicContent
    [Route("api/[controller]")]
    [ApiController]
    public class AdminTopicContentsController : AdminBaseController<TopicContent, TopicContentDetail, TopicContentExtend, TopicContentBase>
    {
        private readonly IAdminTopicContentService _service;
        public AdminTopicContentsController(IAdminTopicContentService service) : base(service)
        {
            _service = service;
        }
    }
    #endregion

    #region Voucher
    [Route("api/[controller]")]
    [ApiController]
    public class AdminVouchersController : AdminBaseController<Voucher, VoucherDetail, VoucherExtend, VoucherBase>
    {
        private readonly IAdminVoucherService _service;
        public AdminVouchersController(IAdminVoucherService service) : base(service)
        {
            _service = service;
        }
    }
    #endregion

    #region Website
    [Route("api/[controller]")]
    [ApiController]
    public class AdminWebsitesController : AdminBaseController<Website, WebsiteDetail, WebsiteExtend, WebsiteBase>
    {
        private readonly IAdminWebsiteService _service;
        public AdminWebsitesController(IAdminWebsiteService service) : base(service)
        {
            _service = service;
        }
    }
    #endregion
}
