using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheWarehouseAPI.DTOs;
using TheWarehouseAPI.Models;
using TheWarehouseAPI.Services;

namespace TheWarehouseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Ordercontroller : ControllerBase
    {
        private readonly OrderService _orderService;

        public Ordercontroller(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderDto orderDto)
        {
            var order = new Order
            {
                ProductId = orderDto.ProductId,
                SourceWarehouseId = orderDto.SourceWarehouseId,
                DestinationWarehouseId = orderDto.DestinationWarehouseId,
                Quantity = orderDto.Quantity
            };
            var createdOrder = await _orderService.CreateOrderAsync(order);
            return CreatedAtAction(nameof(Create), new { id = createdOrder.Id }, createdOrder);
        }
    }
}
