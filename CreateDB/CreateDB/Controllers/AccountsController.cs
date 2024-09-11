using CreateDB.Identity;
using CreateDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OfficeOpenXml;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CreateDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LogIn(Login model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password);
            if (user == null || !passwordValid)
            {
                return BadRequest();
            }

            var resultSignIn = await _signInManager.PasswordSignInAsync(user, model.Password, false, lockoutOnFailure: false);
            if (!resultSignIn.Succeeded)
            {
                return BadRequest();
            }
            return Ok("Login successed");
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(Register model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email.Split('@')[0],
                Email = model.Email,
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
                CreatedAt = DateTime.UtcNow
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return BadRequest();
            }
            if (!await _roleManager.RoleExistsAsync("Customer"))
            {
                await _roleManager.CreateAsync(new IdentityRole<int>("Customer"));
            }

            var addToRoleResult = await _userManager.AddToRoleAsync(user, "Customer");
            return Ok("Register successed");
        }

        [HttpPost("BulkRegister")]
        public async Task<IActionResult> BulkRegister(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File không hợp lệ.");
            }

            using var package = new ExcelPackage(file.OpenReadStream());
            var worksheet = package.Workbook.Worksheets[0];
            var rowCount = worksheet.Dimension.Rows;

            var registrationResults = new List<string>();

            for (int row = 2; row <= rowCount; row++)
            {
                var fullName = worksheet.Cells[row, 1].Text;
                var email = worksheet.Cells[row, 2].Text;
                var password = worksheet.Cells[row, 3].Text;
                var imageUrl = worksheet.Cells[row, 4].Text;

                var user = new ApplicationUser
                {
                    UserName = email.Split('@')[0],
                    Email = email,
                    FullName = fullName,
                    ImageUrl = imageUrl,
                    CreatedAt = DateTime.UtcNow
                };

                var result = await _userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                {
                    registrationResults.Add($"Dòng {row}: Đăng ký thất bại.");
                }
                else
                {
                    if (!await _roleManager.RoleExistsAsync("Customer"))
                    {
                        await _roleManager.CreateAsync(new IdentityRole<int>("Customer"));
                    }

                    var addToRoleResult = await _userManager.AddToRoleAsync(user, "Customer");
                    registrationResults.Add($"Dòng {row}: Đăng ký thành công.");
                }
            }

            return Ok(registrationResults);
        }
    }
}

