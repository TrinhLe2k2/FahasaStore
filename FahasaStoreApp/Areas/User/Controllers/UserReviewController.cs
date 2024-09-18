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
    public class UserReviewController : BaseController<CustomerReviews, ReviewDetail, ReviewExtend, ReviewBase>
    {
        public UserReviewController(IBaseService<CustomerReviews, ReviewDetail, ReviewExtend, ReviewBase> service) : base(service)
        {
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

        public override Task<IActionResult> Index(FilterOptions filterOptions)
        {
            return base.Index(filterOptions);
        }

        public override Task<IActionResult> Filter(FilterOptions filterOptions)
        {
            return base.Filter(filterOptions);
        }
    }
}
