using Microsoft.AspNetCore.Mvc;
using TheWarehouseAPI.DTOs;
using TheWarehouseAPI.Models;
using TheWarehouseAPI.Services;

namespace TheWarehouseAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WarehouseController : ControllerBase
{
    private readonly WarehouseService _warehouseService;

    public WarehouseController(WarehouseService warehouseService)
    {
        _warehouseService = warehouseService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var warehouses = await _warehouseService.GetAllWarehousesAsync();
        return Ok(warehouses);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] WarehouseDTO warehouseDto)
    {
        if (string.IsNullOrEmpty(warehouseDto.Code) || string.IsNullOrEmpty(warehouseDto.Name))
        {
            return BadRequest("Warehouse code and name are required.");
        }

        await _warehouseService.CreateWarehouseAsync(warehouseDto);
        return CreatedAtAction(nameof(GetAll), new { code = warehouseDto.Code }, warehouseDto);
    }
    [HttpGet("products")]
    public async Task<IActionResult> GetProductsInWarehouses([FromQuery] ProductInWarehouseQueryDTO queryDto)
    {
        var productsInWarehouses = await _warehouseService.GetProductsInWarehousesAsync(queryDto);
        return Ok(productsInWarehouses);
    }
}