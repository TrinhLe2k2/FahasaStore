using FahasaStoreApp.Helpers;
using FahasaStoreApp.Models;
using FahasaStoreApp.Models.DTOs.Entities;
using FahasaStoreApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreApp.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserLogined _userLogined;
        private readonly IUserService _userService;
        private readonly IJwtTokenDecoder _jwtTokenDecoder;

        public AccountsController(UserLogined userLogined, IUserService userService, IJwtTokenDecoder jwtTokenDecoder)
        {
            _userLogined = userLogined;
            _userService = userService;
            _jwtTokenDecoder = jwtTokenDecoder;
        }

        public IActionResult Account()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
                return RedirectToAction("Index", "Home");
            }

            bool isRegistered = await _userService.RegisterAsync(model);
            if (isRegistered)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "login failed. Please try again.");
                return RedirectToAction("Index", "Home");
            }
            var accessToken = await _userService.LoginAsync(model);
            var userClaims = _jwtTokenDecoder.DecodeToken(accessToken).Claims;
            var UserId = userClaims.FirstOrDefault(c => c.Type == "UserId")?.Value;

            if (UserId == null) { return RedirectToAction("LogOut"); }

            //var currentUser = await _userService.GetByIdAsync(UserId);
            //_userLogined.CurrentUser = currentUser;
            //_userLogined.JWToken = accessToken;

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            if (_userLogined.JWToken != null)
            {
                await _userService.LogOutAsync();
                HttpContext.Session.Clear();
            }
            TempData["SuccessMessage"] = "Bạn đã đăng xuất thành công.";
            return RedirectToAction("Index", "Home");
        }
    }
}
