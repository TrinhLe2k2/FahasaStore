using FahasaStore.Models;
using FahasaStoreApp.Areas.Base;
using FahasaStoreApp.Areas.User.Models;
using FahasaStoreApp.Constants;
using FahasaStoreApp.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreApp.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Policy = AppRole.Customer)]
    public class UserCartItemController : BaseController<CustomerCartItems, CartItemDetail, CartItemDetail, CartItemBase>
    {
        public UserCartItemController(IBaseService<CustomerCartItems, CartItemDetail, CartItemDetail, CartItemBase> service) : base(service)
        {
        }

        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }

        public override Task<IActionResult> Details(int id)
        {
            return base.Details(id);
        }

        public override Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            filterOptions.SortField = "CreatedAt";
            return base.Filter(filterOptions);
        }

        public override async Task<IActionResult> Index(FilterOptions filterOptions)
        {
            filterOptions.SortField = "CreatedAt";
            return await base.Index(filterOptions);
        }
    }
}
