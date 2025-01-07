using TheWarehouseAPI.Models;

namespace TheWarehouseAPI.Repositories;

public interface IOrderRepository
{
    Task<Order> CreateAsync(Order order);
}