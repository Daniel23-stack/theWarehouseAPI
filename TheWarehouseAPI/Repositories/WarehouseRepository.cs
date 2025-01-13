using Microsoft.EntityFrameworkCore;
using TheWarehouseAPI.Data;
using TheWarehouseAPI.Models;

namespace TheWarehouseAPI.Repositories;



public class WarehouseRepository : IWarehouseRepository
{

    private readonly InventoryContext _context;

    public WarehouseRepository(InventoryContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Warehouse>> GetAllAsync()
    {
        return await _context.Warehouses.ToListAsync();
    }

    public async Task<Warehouse> GetByCodeAsync(string code) => await _context.Warehouses.FirstOrDefaultAsync(w => w.Code == code);
    public async Task<Warehouse> CreateAsync(Warehouse warehouse)
    {
        _context.Warehouses.Add(warehouse);
        await _context.SaveChangesAsync();
        return warehouse;
    }
}