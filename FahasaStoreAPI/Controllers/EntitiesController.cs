using AutoMapper;
using AutoMapper.QueryableExtensions;
using FahasaStore.Models;
using FahasaStoreAPI.Base.Implementations;
using FahasaStoreAPI.Base.Interfaces;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.ViewModels.Entities;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FahasaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AController : ControllerBase
    {
        private readonly FahasaStoreDBContext _context;
        private readonly IMapper _mapper;

        public AController(FahasaStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("GetEntityPluralName")]
        public ActionResult GetEntityPluralName()
        {
            var list = new List<string>
            {
                 "Website", "Voucher", "TopicContent", "Topic", "Subcategory", "Status", "Review", "PosterImage", "Platform", "PaymentMethod", "Payment", "PartnerType", "Partner", "OrderStatus", "OrderItem", "Order", "NotificationType", "Notification", "Menu", "FlashSaleBook", "FlashSale", "Favourite", "Dimension", "CoverType", "Category", "CartItem", "Cart", "BookPartner", "Book", "Banner", "Author", "AspNetUser", "AspNetRole", "Address"
            };
            var pluralizedList = list.Select(name => name.Pluralize()).ToList();
            return Ok(new { PluralName = pluralizedList, entity = list });
        }


        [HttpGet("Topics")]
        public async Task<ActionResult> Topics()
        {
            var topics = await _context.Topics
                .ProjectTo<TopicExtend>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
            return Ok(_mapper.Map<Topic>(topics));
        }
    }

    // Website
    [Route("api/[controller]")]
    [ApiController]
    public class WebsitesController : BaseController<Website, WebsiteVM>
    {
        public WebsitesController(IBaseService<Website, WebsiteVM> service) : base(service)
        {
        }
    }

    // Voucher
    [Route("api/[controller]")]
    [ApiController]
    public class VouchersController : BaseController<Voucher, VoucherVM>
    {
        public VouchersController(IBaseService<Voucher, VoucherVM> service) : base(service)
        {
        }
    }

    // TopicContent
    [Route("api/[controller]")]
    [ApiController]
    public class TopicContentsController : BaseController<TopicContent, TopicContentVM>
    {
        public TopicContentsController(IBaseService<TopicContent, TopicContentVM> service) : base(service)
        {
        }
    }

    // Topic
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : BaseController<Topic, TopicVM>
    {
        public TopicsController(IBaseService<Topic, TopicVM> service) : base(service)
        {
        }
    }

    // Subcategory
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoriesController : BaseController<Subcategory, SubcategoryVM>
    {
        public SubcategoriesController(IBaseService<Subcategory, SubcategoryVM> service) : base(service)
        {
        }
    }

    // Status
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController : BaseController<Status, StatusVM>
    {
        public StatusesController(IBaseService<Status, StatusVM> service) : base(service)
        {
        }
    }

    // Review
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : BaseController<Review, ReviewVM>
    {
        public ReviewsController(IBaseService<Review, ReviewVM> service) : base(service)
        {
        }
    }

    // PosterImage
    [Route("api/[controller]")]
    [ApiController]
    public class PosterImagesController : BaseController<PosterImage, PosterImageVM>
    {
        public PosterImagesController(IBaseService<PosterImage, PosterImageVM> service) : base(service)
        {
        }
    }

    // Platform
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : BaseController<Models.Entities.Platform, PlatformVM>
    {
        public PlatformsController(IBaseService<Models.Entities.Platform, PlatformVM> service) : base(service)
        {
        }
    }

    // PaymentMethod
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodsController : BaseController<PaymentMethod, PaymentMethodVM>
    {
        public PaymentMethodsController(IBaseService<PaymentMethod, PaymentMethodVM> service) : base(service)
        {
        }
    }

    // Payment
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : BaseController<Payment, PaymentVM>
    {
        public PaymentsController(IBaseService<Payment, PaymentVM> service) : base(service)
        {
        }
    }

    // PartnerType
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerTypesController : BaseController<PartnerType, PartnerTypeVM>
    {
        public PartnerTypesController(IBaseService<PartnerType, PartnerTypeVM> service) : base(service)
        {
        }
    }

    // Partner
    [Route("api/[controller]")]
    [ApiController]
    public class PartnersController : BaseController<Partner, PartnerVM>
    {
        public PartnersController(IBaseService<Partner, PartnerVM> service) : base(service)
        {
        }
    }

    // OrderStatus
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusesController : BaseController<OrderStatus, OrderStatusVM>
    {
        public OrderStatusesController(IBaseService<OrderStatus, OrderStatusVM> service) : base(service)
        {
        }
    }

    // OrderItem
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : BaseController<OrderItem, OrderItemVM>
    {
        public OrderItemsController(IBaseService<OrderItem, OrderItemVM> service) : base(service)
        {
        }
    }

    // Order
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController<Order, OrderVM>
    {
        public OrdersController(IBaseService<Order, OrderVM> service) : base(service)
        {
        }
    }

    // NotificationType
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationTypesController : BaseController<NotificationType, NotificationTypeVM>
    {
        public NotificationTypesController(IBaseService<NotificationType, NotificationTypeVM> service) : base(service)
        {
        }
    }

    // Notification
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : BaseController<Notification, NotificationVM>
    {
        public NotificationsController(IBaseService<Notification, NotificationVM> service) : base(service)
        {
        }
    }

    // Menu
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : BaseController<Menu, MenuVM>
    {
        public MenusController(IBaseService<Menu, MenuVM> service) : base(service)
        {
        }
    }

    // FlashSaleBook
    [Route("api/[controller]")]
    [ApiController]
    public class FlashSaleBooksController : BaseController<FlashSaleBook, FlashSaleBookVM>
    {
        public FlashSaleBooksController(IBaseService<FlashSaleBook, FlashSaleBookVM> service) : base(service)
        {
        }
    }

    // FlashSale
    [Route("api/[controller]")]
    [ApiController]
    public class FlashSalesController : BaseController<FlashSale, FlashSaleVM>
    {
        public FlashSalesController(IBaseService<FlashSale, FlashSaleVM> service) : base(service)
        {
        }
    }

    // Favourite
    [Route("api/[controller]")]
    [ApiController]
    public class FavouritesController : BaseController<Favourite, FavouriteVM>
    {
        public FavouritesController(IBaseService<Favourite, FavouriteVM> service) : base(service)
        {
        }
    }

    // Dimension
    [Route("api/[controller]")]
    [ApiController]
    public class DimensionsController : BaseController<Dimension, DimensionVM>
    {
        public DimensionsController(IBaseService<Dimension, DimensionVM> service) : base(service)
        {
        }
    }

    // CoverType
    [Route("api/[controller]")]
    [ApiController]
    public class CoverTypesController : BaseController<CoverType, CoverTypeVM>
    {
        public CoverTypesController(IBaseService<CoverType, CoverTypeVM> service) : base(service)
        {
        }
    }

    // Category
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController<Category, CategoryVM>
    {
        public CategoriesController(IBaseService<Category, CategoryVM> service) : base(service)
        {
        }
    }

    // CartItem
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : BaseController<CartItem, CartItemVM>
    {
        public CartItemsController(IBaseService<CartItem, CartItemVM> service) : base(service)
        {
        }
    }

    // Cart
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : BaseController<Cart, CartVM>
    {
        public CartsController(IBaseService<Cart, CartVM> service) : base(service)
        {
        }
    }

    // BookPartner
    [Route("api/[controller]")]
    [ApiController]
    public class BookPartnersController : BaseController<BookPartner, BookPartnerVM>
    {
        public BookPartnersController(IBaseService<BookPartner, BookPartnerVM> service) : base(service)
        {
        }
    }

    // Book
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BaseController<Book, BookVM>
    {
        public BooksController(IBaseService<Book, BookVM> service) : base(service)
        {
        }
    }

    // Banner
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : BaseController<Banner, BannerVM>
    {
        public BannersController(IBaseService<Banner, BannerVM> service) : base(service)
        {
        }
    }

    // Author
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : BaseController<Author, AuthorVM>
    {
        public AuthorsController(IBaseService<Author, AuthorVM> service) : base(service)
        {
        }
    }

    // AspNetUser
    [Route("api/[controller]")]
    [ApiController]
    public class AspNetUsersController : BaseController<AspNetUser, AspNetUserVM>
    {
        public AspNetUsersController(IBaseService<AspNetUser, AspNetUserVM> service) : base(service)
        {
        }
    }

    // AspNetRole
    [Route("api/[controller]")]
    [ApiController]
    public class AspNetRolesController : BaseController<AspNetRole, AspNetRoleVM>
    {
        public AspNetRolesController(IBaseService<AspNetRole, AspNetRoleVM> service) : base(service)
        {
        }
    }

    // Address
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : BaseController<Address, AddressVM>
    {
        public AddressesController(IBaseService<Address, AddressVM> service) : base(service)
        {
        }
    }

}


