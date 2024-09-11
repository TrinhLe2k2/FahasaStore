using FahasaStore.Models;
using FahasaStoreApp.Areas.User.Models;
using FahasaStoreApp.Base;
using FahasaStoreApp.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreApp.Areas.User.Controllers
{
    [Area("User")]
    public class UserReviewController : BaseController<CustomerReview, ReviewDetail, ReviewExtend, ReviewBase>
    {
        public UserReviewController(IBaseService<CustomerReview, ReviewDetail, ReviewExtend, ReviewBase> service) : base(service)
        {
        }

        public override Task<IActionResult> Create(ReviewBase model)
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
