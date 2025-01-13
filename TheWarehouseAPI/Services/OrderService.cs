using TheWarehouseAPI.DTOs;
using TheWarehouseAPI.Models;
using TheWarehouseAPI.Repositories;

namespace TheWarehouseAPI.Services;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IWarehouseRepository _warehouseRepository;

    public OrderService(IOrderRepository orderRepository, IWarehouseRepository warehouseRepository)
    {
        _orderRepository = orderRepository;
        _warehouseRepository = warehouseRepository;
    }

    public async Task CreateOrderAsync(OrderDTO orderDto)
    {
        var sourceWarehouse = await _warehouseRepository.GetByCodeAsync(orderDto.SourceWarehouseId.ToString());
        var destinationWarehouse = await _warehouseRepository.GetByCodeAsync(orderDto.DestinationWarehouseId.ToString());

        if (sourceWarehouse == null || destinationWarehouse == null)
        {
            throw new Exception("Source or destination warehouse not found.");
        }

        if (!sourceWarehouse.ProductQuantities.ContainsKey(orderDto.ProductId) || 
            sourceWarehouse.ProductQuantities[orderDto.ProductId] < orderDto.Quantity)
        {
            throw new Exception("Insufficient quantity in source warehouse.");
        }

        // Update quantities
        sourceWarehouse.ProductQuantities[orderDto.ProductId] -= orderDto.Quantity;
        if (!destinationWarehouse.ProductQuantities.ContainsKey(orderDto.ProductId))
        {
            destinationWarehouse.ProductQuantities[orderDto.ProductId] = 0;
        }
        destinationWarehouse.ProductQuantities[orderDto.ProductId] += orderDto.Quantity;

        // Create the order
        var order = new Order
        {
            ProductId = orderDto.ProductId,
            SourceWarehouseId = orderDto.SourceWarehouseId,
            DestinationWarehouseId = orderDto.DestinationWarehouseId,
            Quantity = orderDto.Quantity
        };

        await _orderRepository.CreateAsync(order);
    }
}