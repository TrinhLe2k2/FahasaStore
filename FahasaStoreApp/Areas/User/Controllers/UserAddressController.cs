using FahasaStore.Models;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreApp.Areas.User.Models;
using FahasaStoreApp.Base;
using FahasaStoreApp.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreApp.Areas.User.Controllers
{
    [Area("User")]
    public class UserAddressController : BaseController<CustomerAddress, AddressDetail, AddressExtend, AddressBase>
    {
        public UserAddressController(IBaseService<CustomerAddress, AddressDetail, AddressExtend, AddressBase> service) : base(service)
        {
        }

        public override Task<IActionResult> Index(FilterOptions filterOptions)
        {
            filterOptions.SortField = "Default";
            return base.Index(filterOptions);
        }

        public override Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            filterOptions.SortField = "Default";
            return base.Filter(filterOptions);
        }

        public override Task<IActionResult> FilterSubmit(FilterOptions filterOptions)
        {
            filterOptions.SortField = "Default";
            return base.FilterSubmit(filterOptions);
        }

        public override Task<IActionResult> Create(AddressBase model)
        {
            return base.Create(model);
        }

        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }

        public override Task<IActionResult> Details(int id)
        {
            return base.Details(id);
        }

        public override Task<IActionResult> Edit(int id)
        {
            return base.Edit(id);
        }
    }
}
