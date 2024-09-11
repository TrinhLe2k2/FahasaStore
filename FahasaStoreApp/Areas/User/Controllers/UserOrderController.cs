using FahasaStore.Models;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreApp.Areas.User.Models;
using FahasaStoreApp.Areas.User.Services;
using FahasaStoreApp.Base;
using FahasaStoreApp.Models;
using FahasaStoreApp.Models.DTOs;
using FahasaStoreApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http;

namespace FahasaStoreApp.Areas.User.Controllers
{
    [Area("User")]
    public class UserOrderController : BaseController<CustomerOrder, OrderDetail, OrderExtend, OrderBase>
    {
        private readonly IBaseService<CustomerAddress, AddressDetail, AddressExtend, AddressBase> _serviceAddress;
        private readonly IBaseService<CustomerCartItem, CartItemDetail, CartItemDetail, CartItemBase> _serviceCartItem;
        private readonly IFahasaStoreService _fahasaStoreService;
        private readonly IOrderUserService _OrderUserService;
        public UserOrderController(
            IOrderUserService service,
            IBaseService<CustomerAddress, AddressDetail, AddressExtend, AddressBase> serviceAddress,
            IBaseService<CustomerCartItem, CartItemDetail, CartItemDetail, CartItemBase> serviceCartItem,
            IFahasaStoreService fahasaStoreService
            ) 
            : base(service)
        {
            _serviceAddress = serviceAddress;
            _serviceCartItem = serviceCartItem;
            _fahasaStoreService = fahasaStoreService;
            _OrderUserService = service;
        }

        public async Task<IActionResult> BuyNow(CartItemBase model)
        {
            var addCI = await _serviceCartItem.AddAsync(model);
            var order = new OrderBase();
            if (addCI.Data != null)
            {
                order.CartItemIds.Add(addCI.Data.Id);
                await Create(order);
                return View();
            }
            return RedirectToAction("Product", "Home", new {id = model.BookId, area = ""});
        }

        public override async Task<IActionResult> Create(OrderBase model)
        {
            var addressResponse = await _serviceAddress.FilterAsync(new FilterOptions { SortField = "Default" });
            var addressSelectList = addressResponse?.Data?.Paged.Items.Select(e => new
            {
                Id = e.Id,
                DisplayText = $"{e.ReceiverName} {e.Phone} - {e.Detail}, {e.Ward}, {e.District}, {e.Province}"
            });
            ViewData["Addresses"] = new SelectList(addressSelectList, "Id", "DisplayText");

            var paymentMethodResponse = await _fahasaStoreService.GetPaymentMethods(1, 10);
            ViewData["PaymentMethods"] = paymentMethodResponse;

            if (model.VoucherId.HasValue)
            {
                ViewData["Voucher"] = await _fahasaStoreService.GetVoucherDetailsByIdAsync(model.VoucherId.Value);
            }

            var filterOptions = new FilterOptions
            {
                IntIds = model.CartItemIds,
            };

            var cartItemResponse = await _serviceCartItem.FilterAsync(filterOptions);

            ViewData["CartItems"] = cartItemResponse.Data;

            return View(model);
        }

        public override Task<IActionResult> Details(int id)
        {
            return base.Details(id);
        }

        public override Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            return base.Filter(filterOptions);
        }

        public override Task<IActionResult> Index(FilterOptions filterOptions)
        {
            return base.Index(filterOptions);
        }

        public IActionResult CancelOrder(int id)
        {
            return PartialView(id);
        }
        [HttpPost, ActionName("CancelOrder")]
        public async Task<IActionResult> ConfirmCancelOrder(int id)
        {
            var cancel = await _OrderUserService.CancelOrderAsync(id);
            return RedirectToAction("Filter");
        }
    }
}
