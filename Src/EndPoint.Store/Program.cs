using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Store_Website.Application.Interfaces.Contexts;
using Store_Website.Application.Interfaces.FacadPatterns;
using Store_Website.Application.Services.Carts;
using Store_Website.Application.Services.Common.Queries.GetCategory;
using Store_Website.Application.Services.Common.Queries.GetHomePageImages;
using Store_Website.Application.Services.Common.Queries.GetMenuItem;
using Store_Website.Application.Services.Common.Queries.GetSlider;
using Store_Website.Application.Services.Fainances.Commands.AddRequestPay;
using Store_Website.Application.Services.Fainances.Queries.GetRequestPayForAdmin;
using Store_Website.Application.Services.Fainances.Queries.GetRequestPayService;
using Store_Website.Application.Services.HomePages.AddHomePageImages;
using Store_Website.Application.Services.HomePages.AddNewSlider;
using Store_Website.Application.Services.Orders.Commands.AddNewOrder;
using Store_Website.Application.Services.Orders.Queries.GetOrdersForAdmin;
using Store_Website.Application.Services.Orders.Queries.GetUserOrders;
using Store_Website.Application.Services.Products.FacadPattern;
using Store_Website.Application.Services.Users.Commands.EditUser;
using Store_Website.Application.Services.Users.Commands.RegisterUser;
using Store_Website.Application.Services.Users.Commands.RemoveUser;
using Store_Website.Application.Services.Users.Commands.UserLogin;
using Store_Website.Application.Services.Users.Commands.UserSatusChange;
using Store_Website.Application.Services.Users.Queries.GetRoles;
using Store_Website.Application.Services.Users.Queries.GetUsers;
using Store_Website.Common.Roles;
using Store_Website.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    //options.AddPolicy(UserRoles.Admin, policy => policy.RequireRole(UserRoles.Admin));
    //options.AddPolicy(UserRoles.Customer, policy => policy.RequireRole(UserRoles.Customer));
    //options.AddPolicy(UserRoles.Operator, policy => policy.RequireRole(UserRoles.Operator));
    
    options.AddPolicy(UserRoles.مدیر.ToString(), policy => policy.RequireRole(UserRoles.مدیر.ToString()));
    options.AddPolicy(UserRoles.اپراتور.ToString(), policy => policy.RequireRole(UserRoles.اپراتور.ToString()));
    options.AddPolicy(UserRoles.کابر.ToString(), policy => policy.RequireRole(UserRoles.کابر.ToString()));
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = new PathString("/Authentication/Signin");
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
    options.AccessDeniedPath = new PathString("/Authentication/Signin");
});

builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IGetUsersService, GetUsersService>();
builder.Services.AddScoped<IGetRolesService, GetRolesService>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IRemoveUserService, RemoveUserService>();
builder.Services.AddScoped<IUserLoginService, UserLoginService>();
builder.Services.AddScoped<IUserSatusChangeService, UserSatusChangeService>();
builder.Services.AddScoped<IEditUserService, EditUserService>();

//FacadeInject
builder.Services.AddScoped<IProductFacad, ProductFacad>();

//------------------
builder.Services.AddScoped<IGetMenuItemService, GetMenuItemService>();
builder.Services.AddScoped<IGetCategoryService, GetCategoryService>();
builder.Services.AddScoped<IAddNewSliderService, AddNewSliderService>();
builder.Services.AddScoped<IGetSliderService, GetSliderService>();
builder.Services.AddScoped<IAddHomePageImagesService, AddHomePageImagesService>();
builder.Services.AddScoped<IGetHomePageImagesService, GetHomePageImagesService>();

builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAddRequestPayService, AddRequestPayService>();
builder.Services.AddScoped<IGetRequestPayService, GetRequestPayService>();
builder.Services.AddScoped<IAddNewOrderService, AddNewOrderService>();
builder.Services.AddScoped<IGetUserOrdersService, GetUserOrdersService>();
builder.Services.AddScoped<IGetOrdersForAdminService, GetOrdersForAdminService>();
builder.Services.AddScoped<IGetRequestPayForAdminService, GetRequestPayForAdminService>();

string contectionString = @"Data Source=.\SQL2022; Initial Catalog=StoreWebsiteDB; Integrated Security=True;";
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(option => option.UseSqlServer(contectionString));
builder.Services.AddControllersWithViews();


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.Run();
