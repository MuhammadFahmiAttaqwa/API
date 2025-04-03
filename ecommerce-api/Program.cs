using Application.AutoMapper;
using Application.Helpers;
using Application.Repository.Implementation;
using Application.Repository.Interfaces;
using Application.Service.Implementation;
using Application.Service.Interface;
using Data.EF;
using Data.Entity;
using ecommerce_api.Helpers;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
    x => x.MigrationsAssembly("Data.EF")));
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<DbIntializer>();
builder.Services.AddScoped<UserManager<AppUser>>();
builder.Services.AddScoped<RoleManager<AppRole>>();
builder.Services.AddTransient<DbIntializer>();
builder.Services.AddScoped<TokenHelper>();
builder.Services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, CustomClaimsPrincipalFactory>();
builder.Services.AddTransient(typeof(IUnitOfWork), typeof(EFUnitOfWork));
builder.Services.AddTransient(typeof(IRepository<,>), typeof(EFRepository<,>));

//Repositories
builder.Services.AddTransient<IFunctionRepository,FunctionRepository>();
builder.Services.AddTransient<IProductRepository,ProductRepository>();

//Services
builder.Services.AddTransient<IFunctionService, FunctionService>();
builder.Services.AddTransient<IProductService,  ProductService>();


//Mapper
AutoMapperConfig.RegisterMapping(builder.Services);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin() // Mengizinkan semua domain
              .AllowAnyMethod() // Mengizinkan semua HTTP method (GET, POST, dll)
              .AllowAnyHeader()); // Mengizinkan semua header
});



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Host.UseSerilog((context, config) =>
        config.ReadFrom.Configuration(context.Configuration)
);
builder.Logging.ClearProviders();


var jwtSettings = builder.Configuration.GetSection("Jwt");
var secretKey = jwtSettings.GetValue<string>("SecretKey") ?? throw new ArgumentNullException("JWT SecretKey is missing in configuration");
var issuer = jwtSettings.GetValue<string>("Issuer");
var audience = jwtSettings.GetValue<string>("Audience");
var key = Encoding.UTF8.GetBytes(secretKey);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = issuer,
            ValidAudience = audience,
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });
builder.Services.AddAuthorization();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts = 10;

    options.User.RequireUniqueEmail = true;
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var dbInitializer = services.GetRequiredService<DbIntializer>();
        await dbInitializer.Seed();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowAll");


app.MapControllers();

app.Run();
