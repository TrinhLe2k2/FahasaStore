using AutoMapper;
using FahasaStoreAPI;
using FahasaStoreAPI.Base.Implementations;
using FahasaStoreAPI.Base.Interfaces;
using FahasaStoreAPI.Constants;
using FahasaStoreAPI.Identity;
using FahasaStoreAPI.Mappers;
using FahasaStoreAPI.Models.DTOs.Entities;
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

builder.Services.AddScoped<ICloudinaryService, CloudinaryService>();

builder.Services.AddScoped<IFahasaStoreRepository, FahasaStoreRepository>();
builder.Services.AddScoped<IFahasaStoreService, FahasaStoreService>();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
builder.Services.AddScoped(typeof(IBaseService<,,,>), typeof(BaseService<,,,>));

builder.Services.AddScoped(typeof(ItestRepository<,,>), typeof(testRepository<,,>));
builder.Services.AddScoped(typeof(ItestService<,,>), typeof(testService<,,>));

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
    //options.AddPolicy(AppRole.Staff, policy =>
    //{
    //    policy.RequireRole(AppRole.Staff);
    //});
    //options.AddPolicy("AdminOrStaff", policy =>
    //{
    //    policy.RequireRole(AppRole.Admin, AppRole.Staff);
    //});
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
