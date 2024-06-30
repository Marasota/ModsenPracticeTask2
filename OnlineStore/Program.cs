using FluentValidation.AspNetCore;
using OnlineStore.BLL.Validators;
using OnlineStore.DAL.Repositories.Implementations;
using OnlineStore.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using OnlineStore.DAL.Entities;
using Microsoft.Extensions.Configuration;
using System.Globalization;


var builder = WebApplication.CreateBuilder(args);

CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

// Получение строки подключения из конфигурации
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Регистрация DbContext с использованием строки подключения
builder.Services.AddDbContext<OnlineStoreDbContext>(options =>
    options.UseSqlServer(connectionString));


// Регистрация репозиториев
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();

// Регистрация сервисов
builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<OrderDTOValidator>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseHttpsRedirection();

app.Run();
