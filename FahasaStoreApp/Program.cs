using AutoMapper;
using FahasaStoreApp.Base.Implementations;
using FahasaStoreApp.Base.Interfaces;
using FahasaStoreApp.Helpers;
using FahasaStoreApp.Middleware;
using FahasaStoreApp.Services.Implementations;
using FahasaStoreApp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMemoryCache();

// Thêm dịch vụ session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Thời gian session timeout
    options.Cookie.HttpOnly = true; // Cookie chỉ có thể truy cập thông qua HTTP
    options.Cookie.IsEssential = true; // Cookie là cần thiết cho ứng dụng
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();

builder.Services.AddScoped(typeof(IBaseService<,,,>), typeof(BaseService<,,,>));
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IFahasaStoreService, FahasaStoreService>();

//builder.Services.AddScopedServicesFromAssembly(Assembly.GetExecutingAssembly(), "FahasaStoreAdminApp.Services.EntityService");

builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Cấu hình IHttpContextAccessor
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped(provider =>
{
    var httpContextAccessor = provider.GetRequiredService<IHttpContextAccessor>();
    return new UserLogined(httpContextAccessor);
});

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// Thêm middleware session
app.UseSession();

app.UseMiddleware<LayoutDataMiddleware>();

app.Run();
