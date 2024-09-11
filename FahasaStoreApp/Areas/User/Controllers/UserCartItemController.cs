using FahasaStore.Models;
using FahasaStoreApp.Areas.User.Models;
using FahasaStoreApp.Base;
using FahasaStoreApp.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreApp.Areas.User.Controllers
{
    [Area("User")]
    public class UserCartItemController : BaseController<CustomerCartItem, CartItemDetail, CartItemDetail, CartItemBase>
    {
        public UserCartItemController(IBaseService<CustomerCartItem, CartItemDetail, CartItemDetail, CartItemBase> service) : base(service)
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
