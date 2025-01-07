using Microsoft.EntityFrameworkCore;
using TheWarehouseAPI.Data;
using TheWarehouseAPI.Models;
using TheWarehouseAPI.Repositories;
using TheWarehouseAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
builder.Services.AddDbContext<InventoryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IWarehouseRepository, WarehouseRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<WarehouseService>();
builder.Services.AddScoped<OrderService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void SeedDatabase(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<InventoryContext>();
        context.Database.EnsureCreated();

        // Check if data already exists
        if (!context.Products.Any() && !context.Warehouses.Any())
        {
            // Seed Products
            var products = new List<Product>
            {
                new Product { Code = "P001", Description = "Product 1" },
                new Product { Code = "P002", Description = "Product 2" },
                new Product { Code = "P003", Description = "Product 3" }
            };
            context.Products.AddRange(products);

            // Seed Warehouses
            var warehouses = new List<Warehouse>
            {
                new Warehouse { Code = "W001", Name = "Warehouse 1" },
                new Warehouse { Code = "W002", Name = "Warehouse 2" },
                new Warehouse { Code = "W003", Name = "Warehouse 3" }
            };
            context.Warehouses.AddRange(warehouses);

            // Save changes to the database
            context.SaveChanges();
        }
    }
}