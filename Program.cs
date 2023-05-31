using Bmerketo_WebApp.Contexts;
using Bmerketo_WebApp.Factories;
using Bmerketo_WebApp.Helpers;
using Bmerketo_WebApp.Helpers.Repositories;
using Bmerketo_WebApp.Helpers.Services;
using Bmerketo_WebApp.Models.Entities;
using Bmerketo_WebApp.Services;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("IdentitySql")));
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddIdentity<UserEntity, IdentityRole>(x =>
{
	x.SignIn.RequireConfirmedAccount = false;
	x.User.RequireUniqueEmail = true;
	x.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<IdentityContext>().AddClaimsPrincipalFactory<Bmerketo_WebApp.Factories.CustomClaimsPrincipalFactory>();

builder.Services.ConfigureApplicationCookie(x => { x.LoginPath = "/login"; x.AccessDeniedPath = "/denied"; });



//services

builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<UserAdminService>();
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<UserProfileRepository>();


builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<SeedService>();


builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("productSql")));
builder.Services.AddScoped<ShowcaseService>();
builder.Services.AddScoped<UpToSellService>();
builder.Services.AddScoped<ProductService>();

//repositories

builder.Services.AddScoped<ContactFormRepository>();
builder.Services.AddScoped<ProductCategoryRepository>();
builder.Services.AddScoped<ProductImageUrlRepository>();
builder.Services.AddScoped<ProductRelationshipRepository>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductTagRepository>();


var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
