using AutoMapper;
using FahasaStoreAPI;
using FahasaStoreAPI.Areas.Base;
using FahasaStoreAPI.Areas.Customer;
using FahasaStoreAPI.Constants;
using FahasaStoreAPI.Identity;
using FahasaStoreAPI.Mappers;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Repositories.Implementations;
using FahasaStoreAPI.Repositories.Interfaces;
using FahasaStoreAPI.Services.Extensions;
using FahasaStoreAPI.Services.Implementations;
using FahasaStoreAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Fahasa Store API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
builder.Services.AddDbContext<StoreContext>(option => option.UseSqlServer
    (builder.Configuration.GetConnectionString("myStore")));

builder.Services.AddCors(p => p.AddPolicy("MyCors", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>()
    .AddEntityFrameworkStores<StoreContext>().AddDefaultTokenProviders();

// Register the RoleManager with the appropriate role type
builder.Services.AddScoped<RoleManager<IdentityRole<int>>>();

builder.Services.AddDbContext<FahasaStoreDBContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("myStore"));
});

#region AddScoped
builder.Services.AddScoped<ICloudinaryService, CloudinaryService>();

builder.Services.AddScoped<IBookRecommendationSystem, BookRecommendationSystem>();

builder.Services.AddScoped<IFahasaStoreRepository, FahasaStoreRepository>();
builder.Services.AddScoped<IFahasaStoreService, FahasaStoreService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped(typeof(ICustomerBaseRepository<,,,>), typeof(CustomerBaseRepository<,,,>));
builder.Services.AddScoped(typeof(ICustomerBaseService<,,,>), typeof(CustomerBaseService<,,,>));

#region Customer Repository - Service

builder.Services.AddScoped<ICustomerAddressRepository, CustomerAddressRepository>();
builder.Services.AddScoped<ICustomerAddressService, CustomerAddressService>();

builder.Services.AddScoped<ICustomerOrderRepository, CustomerOrderRepository>();
builder.Services.AddScoped<ICustomerOrderService, CustomerOrderService>();

builder.Services.AddScoped<ICustomerOrderItemRepository, CustomerOrderItemRepository>();
builder.Services.AddScoped<ICustomerOrderItemService, CustomerOrderItemService>();

builder.Services.AddScoped<ICustomerCartItemRepository, CustomerCartItemRepository>();
builder.Services.AddScoped<ICustomerCartItemService, CustomerCartItemService>();

builder.Services.AddScoped<ICustomerReviewRepository, CustomerReviewRepository>();
builder.Services.AddScoped<ICustomerReviewService, CustomerReviewService>();

builder.Services.AddScoped<ICustomerFavouriteRepository, CustomerFavouriteRepository>();
builder.Services.AddScoped<ICustomerFavouriteService, CustomerFavouriteService>();
#endregion

#endregion

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Life cycle DI: AddSingleton(), AddTransient(), AddScoped()
builder.Services.AddMvc(option => option.EnableEndpointRouting = false)
                    .AddNewtonsoftJson(otp => otp.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
// Add Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"])),
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(AppRole.Admin, policy =>
    {
        policy.RequireRole(AppRole.Admin);
    });
    options.AddPolicy(AppRole.Customer, policy =>
    {
        policy.RequireRole(AppRole.Customer);
    });
});

var app = builder.Build();

app.UseCors("MyCors");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
