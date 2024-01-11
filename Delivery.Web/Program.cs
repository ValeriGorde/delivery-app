using AutoMapper;
using Delivery.BLL.Contracts;
using Delivery.BLL.Contracts.Interfaces;
using Delivery.DAL.Data;
using Delivery.DAL.Repositories;
using Delivery.DAL.Repositories.Base;
using Delivery.DAL.Repositories.Interfaces;
using Delivery.Web.Services.Mapping;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Подключение бд
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));

// Подключение репозиториев моделей
builder.Services
    .AddScoped(typeof(IRepository<>), typeof(BaseRepository<>))
    .AddScoped<IOrderRepository, OrderRepository>();

// Подключение сервисов
builder.Services
    .AddScoped<IOrderService, OrderService>();

// Подключение маппинга
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Order}/{action=Index}/{id?}");

app.Run();
