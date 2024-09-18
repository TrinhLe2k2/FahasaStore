using FahasaStoreApp.Areas.User.Services;
using FahasaStoreApp.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreApp.Helpers
{
    public class AdminRequirement : IAuthorizationRequirement
    {
        public AdminRequirement()
        {
        }
    }

    public class CustomerRequirement : IAuthorizationRequirement
    {
        public CustomerRequirement()
        {
        }
    }

    public class AdminRequirementHandler : AuthorizationHandler<AdminRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        public AdminRequirementHandler(IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminRequirement requirement)
        {
            var userLoginer = _httpContextAccessor.HttpContext?.Request.Cookies["UserLoginer"];

            if (userLoginer == null)
            {
                context.Fail();
                return;
            }

            var response = await _userService.CheckRoleAccount(AppRole.Admin);
            if (response)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }
    }

    public class CustomerRequirementHandler : AuthorizationHandler<CustomerRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        public CustomerRequirementHandler(IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomerRequirement requirement)
        {
            var userLoginer = _httpContextAccessor.HttpContext?.Request.Cookies["UserLoginer"];

            if (userLoginer == null)
            {
                context.Fail();
                return;
            }

            var response = await _userService.CheckRoleAccount(AppRole.Customer);
            if (response)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }
    }

}
