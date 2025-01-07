using TheWarehouseAPI.Models;

namespace TheWarehouseAPI.Data;

using Microsoft.EntityFrameworkCore;

public class InventoryContext : DbContext
{
    public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<Order> Orders { get; set; }
}