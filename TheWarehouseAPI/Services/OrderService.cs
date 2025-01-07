using TheWarehouseAPI.Models;
using TheWarehouseAPI.Repositories;

namespace TheWarehouseAPI.Services;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly IWarehouseRepository _warehouseRepository;

    public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, IWarehouseRepository warehouseRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _warehouseRepository = warehouseRepository;
    }

    public async Task<Order> CreateOrderAsync(Order order)
    {
        // Logic to update quantities in warehouses
        // Fetch product and warehouses, update quantities accordingly
        await _orderRepository.CreateAsync(order);
        return order;
    }
}