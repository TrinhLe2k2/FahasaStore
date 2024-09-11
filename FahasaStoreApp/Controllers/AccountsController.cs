using FahasaStoreApp.Helpers;
using FahasaStoreApp.Models.DTOs;
using FahasaStoreApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace FahasaStoreApp.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IUserService _userService;
        private readonly IJwtTokenDecoder _jwtTokenDecoder;

        public AccountsController(IUserService userService, IJwtTokenDecoder jwtTokenDecoder)
        {
            _userService = userService;
            _jwtTokenDecoder = jwtTokenDecoder;
        }

        public IActionResult Account()
        {
            return PartialView();
        }

        public IActionResult Login()
        {
            return PartialView();
        }

        public IActionResult Register()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register model)
        {
            bool isRegistered = await _userService.RegisterAsync(model);
            if (isRegistered)
            {
                return RedirectToAction("Index", "Home");
            }
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
            var userLoginer = await _userService.LoginAsync(model);

            if (userLoginer == null)
            {
                return RedirectToAction("Index", "Home");
            }

            // Lưu token vào cookie
            var accessToken = userLoginer.AccessToken ?? "";
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true, // Ngăn chặn truy cập cookie từ JavaScript, tăng bảo mật
                Secure = false, // Chỉ gửi cookie qua HTTPS, giúp bảo mật
                Expires = model.RememberMe ? DateTimeOffset.Now.AddDays(30) : DateTimeOffset.Now.AddSeconds(10), // Thời gian hết hạn của cookie
                SameSite = SameSiteMode.Strict // Bảo vệ khỏi tấn công CSRF
            };
            Response.Cookies.Append("AccessToken", accessToken, cookieOptions);
            var accessTokenRead = HttpContext.Request.Cookies["AccessToken"];

            // Lưu userVM vào session
            //HttpContext.Session.SetString("UserVM", JsonConvert.SerializeObject(userLoginer.User));

            var userDTO = new UserLoginer
            {
                UserId = userLoginer.UserId,
                FullName = userLoginer.FullName,
                ImageUrl = userLoginer.ImageUrl,
                CartId =userLoginer.CartId
            };

            var userJson = JsonConvert.SerializeObject(userDTO);
            Response.Cookies.Append("UserLoginer", userJson, cookieOptions);
            var userLoginerRead = HttpContext.Request.Cookies["UserLoginer"];

            return RedirectToAction("Index", "HomeUser", new { area = "User" });
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _userService.LogOutAsync();
            Response.Cookies.Delete("AccessToken");
            Response.Cookies.Delete("UserLoginer");
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
