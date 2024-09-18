using FahasaStoreApp.Areas.Admin.Services;
using FahasaStoreApp.Areas.User.Services;
using FahasaStoreApp.Constants;
using FahasaStoreApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = AppRole.Admin)]
    public class HomeAdminController : Controller
    {
        private readonly IAdminExtendService _adminExtendService;
        private readonly IUserService _userService;

        public HomeAdminController(IAdminExtendService adminExtendService, IUserService userService)
        {
            _adminExtendService = adminExtendService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _adminExtendService.GetYearlyStatisticsAsync();
            return View(response.Data);
        }
        [HttpPost, ActionName("Index")]
        public async Task<IActionResult> IndexSubmit(int year)
        {
            var response = await _adminExtendService.GetYearlyStatisticsAsync(year);
            return View(response.Data);
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
