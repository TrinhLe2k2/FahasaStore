using AutoMapper;
using AutoMapper.QueryableExtensions;
using FahasaStore.Models;
using FahasaStoreAPI.Constants;
using FahasaStoreAPI.Helpers;
using FahasaStoreAPI.Identity;
using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.ViewModels;
using FahasaStoreAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using X.PagedList;

namespace FahasaStoreAPI.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly FahasaStoreDBContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UserRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole<int>> roleManager, FahasaStoreDBContext context, IConfiguration configuration, IMapper mapper)
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
                //kiểm tra role Customer đã có
                if (!await _roleManager.RoleExistsAsync(AppRole.Customer))
                {
                    await _roleManager.CreateAsync(new IdentityRole<int>(AppRole.Customer));
                }

                var addToRoleResult = await _userManager.AddToRoleAsync(user, AppRole.Customer);
                // Tạo giỏ hàng cho người dùng này

                var cart = new Cart();
                cart.UserId = user.Id;
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
            }
            return result.Succeeded;
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
                .ProjectTo<AspNetUserDetail>(_mapper.ConfigurationProvider)
                .FirstAsync(e => e.Id == user.Id);
            loginer.Role = roles;
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

            var expires = model.RememberMe ? DateTime.Now.AddDays(30) : DateTime.Now.AddHours(1);

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
                CartId = loginer.Cart != null ? loginer.Cart.Id : 0,
                FullName = loginer.FullName,
                ImageUrl = loginer.ImageUrl
            };

            return userLoginer;
        }
        public async Task<bool> UpdateAsync(AspNetUserExtend model)
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
        public async Task<bool> DeleteAsync(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var result = await _userManager.DeleteAsync(user);
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
    }
}
