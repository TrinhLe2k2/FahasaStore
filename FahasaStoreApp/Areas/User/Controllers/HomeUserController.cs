using FahasaStore.Models;
using FahasaStoreApp.Models;
using FahasaStoreApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FahasaStoreApp.Areas.User.Controllers
{
    [Area("User")]
    public class HomeUserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IFahasaStoreService _fahasaStoreService;

        public HomeUserController(IUserService userService, IFahasaStoreService fahasaStoreService)
        {
            _userService = userService;
            _fahasaStoreService = fahasaStoreService;
        }

        public async Task<IActionResult> Index()
        {
            var userLoginerRead = HttpContext.Request.Cookies["UserLoginer"];
            if (string.IsNullOrEmpty(userLoginerRead))
            {
                return RedirectToAction("Error", new ErrorViewModel { ErrorCode = "404", ErrorMessage = "NOT FOUND"});
            }
            var user = await _userService.GetProfileUserAsync();
            return View(user);
        }

        #region Voucher for user

        public async Task<IActionResult> VouchersUser()
        {
            var result = await _fahasaStoreService.GetVouchersAsync(1, 10);
            return View(result);
        }

        public async Task<IActionResult> VouchersUserFilter(int pageNumber = 1, int pageSize = 10, int intoMoney = 0)
        {
            var result = await _fahasaStoreService.GetVouchersAsync(pageNumber, pageSize, intoMoney);
            return PartialView(result);
        }

        public async Task<IActionResult> VoucheUserDetails(int id)
        {
            var result = await _fahasaStoreService.GetVoucherDetailsByIdAsync(id);
            return PartialView(result);
        }
        [HttpGet]
        public async Task<IActionResult> ApplyVoucher(string code, int intoMoney)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return Json(new { success = false, message = "Voucher code is required." });
            }

            var result = await _fahasaStoreService.ApplyVoucherAsync(code, intoMoney);

            if (result == null)
            {
                return Json(new { success = false, message = "Invalid or expired voucher." });
            }

            return Json(new { success = true, data = result });
        }


        #endregion

        #region Notification of user
        public async Task<IActionResult> NotificationsUser()
        {
            var result = await _userService.GetNotificationsAsync(1, 10);
            return PartialView(result);
        }

        public async Task<IActionResult> NotificationsUseFilter(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _userService.GetNotificationsAsync(pageNumber, pageSize);
            return PartialView(result);
        }

        public async Task<IActionResult> NotificationUserDetails(int id)
        {
            var result = await _userService.GetNotificationDetailsByIdAsync(id);
            return PartialView(result);
        }
        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(ErrorViewModel errorViewModel)
        {
            return View(errorViewModel);
        }
    }
}
