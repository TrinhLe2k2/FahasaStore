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
    public class UserAddressController : BaseController<CustomerAddresses, AddressDetail, AddressExtend, AddressBase>
    {
        public UserAddressController(IBaseService<CustomerAddresses, AddressDetail, AddressExtend, AddressBase> service) : base(service)
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

        public override Task<IActionResult> Create()
        {
            return base.Create();
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
