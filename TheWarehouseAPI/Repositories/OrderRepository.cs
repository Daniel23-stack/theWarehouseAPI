using TheWarehouseAPI.Data;
using TheWarehouseAPI.Models;

namespace TheWarehouseAPI.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly InventoryContext _context;

    public OrderRepository(InventoryContext context)
    {
        _context = context;
    }

    public async Task<Order> CreateAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return order;
    }
}