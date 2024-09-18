using AutoMapper;
using AutoMapper.QueryableExtensions;
using FahasaStore.Models;
using FahasaStoreAPI.Models.Entities;
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
            var reversedList = list.AsEnumerable().Reverse().ToList();
            var pluralizedList = reversedList.Select(name => name.Pluralize()).ToList();
            return Ok(new { PluralName = pluralizedList, reversedList = list });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ById(int id)
        {
            var item = await _context.Orders
                .Include(e => e.Address)
                .Include(e => e.PaymentMethod)
                .Include(e => e.User)
                .Include(e => e.Voucher)
                .Include(e => e.Payment)
                .Include(e => e.OrderItems)
                .Include(e => e.OrderStatuses).ThenInclude(e => e.Status)
            .AsNoTracking()
            .ProjectTo<OrderDetail>(_mapper.ConfigurationProvider)
            .FirstAsync(e => e.Id == id);
            return Ok(item); 
        }

    }
}
