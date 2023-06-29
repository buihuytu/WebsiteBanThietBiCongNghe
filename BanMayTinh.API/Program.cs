global using Microsoft.EntityFrameworkCore;
using BanMayTinh.BUS.IService;
using BanMayTinh.BUS.Service;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                      });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<INewsCategoryService, NewsCategoryService>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<ISliderService, SliderService>();
builder.Services.AddTransient<IBrandService, BrandService>();
builder.Services.AddTransient<INewsService, NewsService>();
builder.Services.AddTransient<IContactService, ContactService>();
builder.Services.AddTransient<IProductImageService, ProductImageService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderDetailService, OrderDetailService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
