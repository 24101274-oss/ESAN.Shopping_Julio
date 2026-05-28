using Microsoft.EntityFrameworkCore;
using UESAN.SHOPPING.CORE.core.Entities;
using UESAN.SHOPPING.CORE.core.Interfaces;
using UESAN.SHOPPING.CORE.core.Services;
using UESAN.SHOPPING.CORE.infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var _config = builder.Configuration;
var cnx = _config.GetConnectionString("DevConnection");
builder.Services.AddDbContext<logisticaBDContext>(options => options.UseSqlServer(cnx));

builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
