using Microsoft.EntityFrameworkCore;
using TheWarehouseAPI.Data;
using TheWarehouseAPI.Models;

namespace TheWarehouseAPI.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly InventoryContext _context;

    public ProductRepository(InventoryContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync() => await _context.Products.ToListAsync();
    public async Task<Product> GetByCodeAsync(string code) => await _context.Products.FirstOrDefaultAsync(p => p.Code == code);
    public async Task<Product> CreateAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }
}