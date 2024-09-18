using AutoMapper;
using FahasaStoreApp.Areas.Admin.Services;
using FahasaStoreApp.Areas.Base;
using FahasaStoreApp.Areas.User.Services;
using FahasaStoreApp.Constants;
using FahasaStoreApp.Helpers;
using FahasaStoreApp.Middleware;
using FahasaStoreApp.Services;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMemoryCache();

// Thêm dịch vụ session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60); // Thời gian session timeout
    options.Cookie.HttpOnly = true; // Cookie chỉ có thể truy cập thông qua HTTP
    options.Cookie.IsEssential = true; // Cookie là cần thiết cho ứng dụng
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();

builder.Services.AddScoped(typeof(IBaseService<,,,>), typeof(BaseService<,,,>));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IJwtTokenDecoder, JwtTokenDecoder>();
builder.Services.AddScoped<IMethodsHelper, MethodsHelper>();
builder.Services.AddScoped<IFahasaStoreService, FahasaStoreService>();
builder.Services.AddScoped<IViettelPostService, ViettelPostService>();
builder.Services.AddScoped<ICloudinaryService, CloudinaryService>(); 
builder.Services.AddScoped<IAdminExtendService, AdminExtendService>(); 

#region AddScoped For User
builder.Services.AddScoped<IOrderUserService, OrderUserService>();
#endregion

#region AddScoped For Admin

builder.Services.AddScoped<IAdminAddressService, AdminAddressService>();

builder.Services.AddScoped<IAdminAspNetUserService, AdminAspNetUserService>();

builder.Services.AddScoped<IAdminAuthorService, AdminAuthorService>();

builder.Services.AddScoped<IAdminBannerService, AdminBannerService>();

builder.Services.AddScoped<IAdminBookService, AdminBookService>();

builder.Services.AddScoped<IAdminBookPartnerService, AdminBookPartnerService>();

builder.Services.AddScoped<IAdminCartService, AdminCartService>();

builder.Services.AddScoped<IAdminCartItemService, AdminCartItemService>();

builder.Services.AddScoped<IAdminCategoryService, AdminCategoryService>();

builder.Services.AddScoped<IAdminCoverTypeService, AdminCoverTypeService>();

builder.Services.AddScoped<IAdminDimensionService, AdminDimensionService>();

builder.Services.AddScoped<IAdminFavouriteService, AdminFavouriteService>();

builder.Services.AddScoped<IAdminFlashSaleService, AdminFlashSaleService>();

builder.Services.AddScoped<IAdminFlashSaleBookService, AdminFlashSaleBookService>();

builder.Services.AddScoped<IAdminMenuService, AdminMenuService>();

builder.Services.AddScoped<IAdminNotificationService, AdminNotificationService>();

builder.Services.AddScoped<IAdminNotificationTypeService, AdminNotificationTypeService>();

builder.Services.AddScoped<IAdminOrderService, AdminOrderService>();

builder.Services.AddScoped<IAdminOrderItemService, AdminOrderItemService>();

builder.Services.AddScoped<IAdminOrderStatusService, AdminOrderStatusService>();

builder.Services.AddScoped<IAdminPartnerService, AdminPartnerService>();

builder.Services.AddScoped<IAdminPartnerTypeService, AdminPartnerTypeService>();

builder.Services.AddScoped<IAdminPaymentMethodService, AdminPaymentMethodService>();

builder.Services.AddScoped<IAdminPlatformService, AdminPlatformService>();

builder.Services.AddScoped<IAdminPosterImageService, AdminPosterImageService>();

builder.Services.AddScoped<IAdminReviewService, AdminReviewService>();

builder.Services.AddScoped<IAdminStatusService, AdminStatusService>();

builder.Services.AddScoped<IAdminSubcategoryService, AdminSubcategoryService>();

builder.Services.AddScoped<IAdminTopicService, AdminTopicService>();

builder.Services.AddScoped<IAdminTopicContentService, AdminTopicContentService>();

builder.Services.AddScoped<IAdminVoucherService, AdminVoucherService>();

builder.Services.AddScoped<IAdminWebsiteService, AdminWebsiteService>();

#endregion

//builder.Services.AddScopedServicesFromAssembly(Assembly.GetExecutingAssembly(), "FahasaStoreAdminApp.Services.EntityService");

builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Cấu hình IHttpContextAccessor
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped(provider =>
{
    var httpContextAccessor = provider.GetRequiredService<IHttpContextAccessor>();
    return new UserLogined(httpContextAccessor);
});

// Đăng ký yêu cầu bảo mật và handler
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(AppRole.Admin, policy =>
        policy.Requirements.Add(new AdminRequirement()));
    options.AddPolicy(AppRole.Customer, policy =>
        policy.Requirements.Add(new CustomerRequirement()));
});
builder.Services.AddScoped<IAuthorizationHandler, AdminRequirementHandler>();
builder.Services.AddScoped<IAuthorizationHandler, CustomerRequirementHandler>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Thêm middleware session
app.UseSession();

app.UseMiddleware<LayoutDataMiddleware>();

app.Run();
