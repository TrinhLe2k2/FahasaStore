using FahasaStore.Models;
using FahasaStoreAPI.Areas.Base;
using FahasaStoreAPI.Areas.Customer;
using FahasaStoreAPI.Constants;
using FahasaStoreAPI.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FahasaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAddressesController : CustomerBaseController<Address, AddressDetail, AddressExtend, AddressBase>
    {
        public CustomerAddressesController(ICustomerAddressService service) : base(service)
        {
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerOrdersController : CustomerBaseController<Order, OrderDetail, OrderExtend, OrderBase>
    {
        private readonly ICustomerOrderService _customerOrderService;
        public CustomerOrdersController(ICustomerOrderService service) : base(service)
        {
            _customerOrderService = service;
        }
        [Authorize(AppRole.Customer)]
        [HttpGet("Cancel")]
        public virtual async Task<IActionResult> Cancel(int orderId)
        {
            var userId = User.FindFirst(c => c.Type == "UserId")?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var result = await _customerOrderService.CancelAsync(orderId, int.Parse(userId));
            return Ok(result);
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerOrderItemsController : CustomerBaseController<OrderItem, OrderItemDetail, OrderItemExtend, OrderItemBase>
    {
        public CustomerOrderItemsController(ICustomerOrderItemService service) : base(service)
        {
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerCartItemsController : CustomerBaseController<CartItem, CartItemDetail, CartItemDetail, CartItemBase>
    {
        public CustomerCartItemsController(ICustomerCartItemService service) : base(service)
        {
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerReviewsController : CustomerBaseController<Review, ReviewDetail, ReviewExtend, ReviewBase>
    {
        public CustomerReviewsController(ICustomerReviewService service) : base(service)
        {
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerFavouritesController : CustomerBaseController<Favourite, FavouriteDetail, FavouriteExtend, FavouriteBase>
    {
        public CustomerFavouritesController(ICustomerFavouriteService service) : base(service)
        {
        }
    }
}
