﻿using FahasaStore.Models;
using FahasaStoreApp.Areas.User.Services;
using FahasaStoreApp.Constants;
using FahasaStoreApp.Models;
using FahasaStoreApp.Models.DTOs;
using FahasaStoreApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FahasaStoreApp.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Policy = AppRole.Customer)]
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
            var isAdmin = await _userService.CheckRoleAccount(AppRole.Admin);
            TempData["IsAdmin"] = isAdmin;
            var user = await _userService.GetProfileUserAsync();
            return View(user);
        }

        public async Task<IActionResult> UpdateUser()
        {
            var user = await _userService.GetProfileUserAsync();
            return PartialView(user);
        }

        [HttpPost, ActionName("UpdateUser")]
        public async Task<IActionResult> UpdateUser(AspNetUserBase model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(model);
            }
            var repository = await _userService.UpdateAsync(model);
            if (repository)
            {
                var expirationDateString = Request.Cookies["UserLoginer_Expires"];
                DateTimeOffset expirationDate;
                if (!string.IsNullOrEmpty(expirationDateString) && DateTimeOffset.TryParse(expirationDateString, out expirationDate))
                {
                    var cookieOptions = new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = false,
                        Expires = expirationDate,
                        SameSite = SameSiteMode.Strict
                    };

                    var userUpdated = await _userService.GetUserLoginerAsync();
                    if (userUpdated == null)
                    {
                        return RedirectToAction("Error", new ErrorViewModel { ErrorCode = "404", ErrorMessage = "NOT FOUND" });
                    }
                    var updatedUserJson = JsonConvert.SerializeObject(userUpdated);

                    Response.Cookies.Append("UserLoginer", updatedUserJson, cookieOptions);
                }
                else
                {
                    return RedirectToAction("Error", new ErrorViewModel { ErrorCode = "404", ErrorMessage = "NOT FOUND" });
                }

                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", new ErrorViewModel { ErrorCode = "404", ErrorMessage = "NOT FOUND" });
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
