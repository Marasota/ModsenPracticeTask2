using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using OnlineStore.BLL.Services.Interfaces;
using OnlineStore.BLL.Services;
using OnlineStore.BLL.Validators;
using OnlineStore.DAL.Repositories.Implementations;
using OnlineStore.DAL.Repositories.Interfaces;
using OnlineStore.BLL.Services.Implementations;
using OnlineStore.WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();


builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<OrderDTOValidator>());

//auto-validation



var app = builder.Build();


app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();

