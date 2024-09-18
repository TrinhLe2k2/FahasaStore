using AutoMapper;
using AutoMapper.QueryableExtensions;
using FahasaStore.Models;
using FahasaStoreAPI.Constants;
using FahasaStoreAPI.Helpers;
using FahasaStoreAPI.Identity;
using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OfficeOpenXml;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using X.PagedList;

namespace FahasaStoreAPI.Areas.Customer
{
    public interface ICustomerExtendRepository
    {
        Task<bool> RegisterAsync(Register model);
        Task<List<string>> BulkRegisterAsync(IFormFile file);
        Task<UserLoginer?> LoginAsync(Login model);
        Task<bool> UpdateAsync(AspNetUserBase model);
        Task<bool> LogOutAsync();
        Task<bool> AddUserRoleAsync(int userId, string role);
        Task<bool> RemoveUserRoleAsync(int userId, string role);
        Task<PagedVM<NotificationExtend>> GetNotificationsAsync(int userId, int pageNumber, int pageSize);
        Task<NotificationExtend?> GetNotificationDetailsByIdAsync(int userId, int notificationId);
        Task<AspNetUserDetail> GetProfileUserAsync(int userId);
        Task<UserLoginer?> GetUserLoginerAsync(int userId);
    }

    public class CustomerExtendRepository : ICustomerExtendRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly FahasaStoreDBContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public CustomerExtendRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole<int>> roleManager, FahasaStoreDBContext context, IConfiguration configuration, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<bool> RegisterAsync(Register model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email.Split('@')[0],
                Email = model.Email,
                FullName = model.FullName,
                CreatedAt = DateTime.UtcNow
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                #region add role customer
                //kiểm tra role Customer đã có
                if (!await _roleManager.RoleExistsAsync(AppRole.Customer))
                {
                    await _roleManager.CreateAsync(new IdentityRole<int>(AppRole.Customer));
                }
                var addToRoleResult = await _userManager.AddToRoleAsync(user, AppRole.Customer);
                #endregion

                #region add role admin
                //if (!await _roleManager.RoleExistsAsync(AppRole.Admin))
                //{
                //    await _roleManager.CreateAsync(new IdentityRole<int>(AppRole.Admin));
                //}
                //var addToRoleAdmin = await _userManager.AddToRoleAsync(user, AppRole.Admin);
                #endregion

                // Tạo giỏ hàng cho người dùng này

                var cart = new Cart();
                cart.UserId = user.Id;
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
            }
            return result.Succeeded;
        }
        public async Task<List<string>> BulkRegisterAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return new List<string>();
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

            return registrationResults;
        }
        public async Task<UserLoginer?> LoginAsync(Login model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password);
            if (user == null || !passwordValid)
            {
                return null;
            }

            var resultSignIn = await _signInManager.PasswordSignInAsync(user, model.Password, false, lockoutOnFailure: false);
            if (!resultSignIn.Succeeded)
            {
                return null;
            }

            var roles = await _userManager.GetRolesAsync(user);

            var loginer = await _context.AspNetUsers
                .AsNoTracking()
                .ProjectTo<AspNetUserExtend>(_mapper.ConfigurationProvider)
                .FirstAsync(e => e.Id == user.Id);

            var authClaims = new List<Claim>
                {
                    new Claim("UserId", loginer.Id.ToString()),
                    new Claim(ClaimTypes.Email, model.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

            foreach (var role in roles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var expires = model.RememberMe ? DateTime.Now.AddDays(30) : DateTime.Now.AddHours(10);

            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: expires,
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
            );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

            var userLoginer = new UserLoginer
            {
                AccessToken = accessToken,
                UserId = loginer.Id,
                CartId = loginer.CartId,
                FullName = loginer.FullName,
                ImageUrl = loginer.ImageUrl
                //Roles = roles
            };

            return userLoginer;
        }
        public async Task<bool> UpdateAsync(AspNetUserBase model)
        {
            var user = await _userManager.FindByIdAsync(model.Id.ToString());
            if (user == null)
            {
                return false;
            }
            user.FullName = model.FullName;
            user.PublicId = model.PublicId;
            user.ImageUrl = model.ImageUrl;
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }
        public async Task<bool> LogOutAsync()
        {
            await _signInManager.SignOutAsync();
            return true;
        }
        public async Task<bool> AddUserRoleAsync(int userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var result = await _userManager.AddToRoleAsync(user, role);
            return result.Succeeded;
        }
        public async Task<bool> RemoveUserRoleAsync(int userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var result = await _userManager.RemoveFromRoleAsync(user, role);
            return result.Succeeded;
        }
        public async Task<PagedVM<NotificationExtend>> GetNotificationsAsync(int userId, int pageNumber, int pageSize)
        {
            var pageList = await _context.Notifications
                .AsNoTracking()
                .ProjectTo<NotificationExtend>(_mapper.ConfigurationProvider)
                .Where(e => e.UserId == userId || e.UserId == null)
                .OrderByDescending(e => e.Id)
                .ToPagedListAsync(pageNumber, pageSize);
            return MethodsHelper.GetPaged(pageList);
        }
        public async Task<NotificationExtend?> GetNotificationDetailsByIdAsync(int userId, int notificationId)
        {
            var result = await _context.Notifications
                .AsNoTracking()
                .ProjectTo<NotificationExtend>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(e => e.Id == notificationId && (e.UserId == null || e.UserId == userId));

            if (result != null && !result.IsRead)
            {
                var entity = _mapper.Map<Notification>(result);
                entity.IsRead = true;
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return result;
        }
        public async Task<AspNetUserDetail> GetProfileUserAsync(int userId)
        {
            var user = await _context.AspNetUsers.AsNoTracking()
                .ProjectTo<AspNetUserDetail>(_mapper.ConfigurationProvider)
                .FirstAsync(e => e.Id.Equals(userId));
            return user;
        }

        public async Task<UserLoginer?> GetUserLoginerAsync(int userId)
        {
            var userloginer = await _context.AspNetUsers.AsNoTracking()
                .ProjectTo<AspNetUserExtend>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(e => e.Id.Equals(userId));

            if(userloginer == null)
            {
                return null;
            }

            return new UserLoginer
            {
                UserId = userId,
                CartId = userloginer.CartId,
                FullName = userloginer.FullName,
                ImageUrl = userloginer.ImageUrl
            };
        }
    }
}
