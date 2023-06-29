using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Security.Policy;
using System.Web.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

#region Session and cookie settings
//builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    //options.Cookie.Name = "mySession";
    options.IdleTimeout = TimeSpan.FromMinutes(15);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
#endregion

builder.Services.AddMemoryCache();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "Login",
    pattern: "Admin/Login",
    defaults: new { area = "Admin",controller = "Auth", action = "Login", id = UrlParameter.Optional });

app.MapControllerRoute(
    name: "Logout",
    pattern: "Admin/Logout",
    defaults: new { area = "Admin", controller = "Auth", action = "Logout", id = UrlParameter.Optional });

app.MapControllerRoute(
    name: "Dashboard",
    pattern: "Admin/Dashboard",
    defaults: new { area = "Admin", controller = "Dashboard", action = "Index", id = UrlParameter.Optional });

app.MapControllerRoute(
    name: "Admin_default",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

/*app.MapControllerRoute(
    name: "category",    // đặt tên route
    defaults: new { controller = "LearnAsp", action = "Index", id = UrlParameter.Optional },
    pattern: "{id:string?}");*/

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Site}/{action=Home}/{id?}");




app.Run();
