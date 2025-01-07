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
    public async Task<IActionResult> GetAll() => Ok(await _warehouseService.GetAllWarehousesAsync());

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] WarehouseDto warehouseDto)
    {
        var warehouse = new Warehouse { Code = warehouseDto.Code, Name = warehouseDto.Name };
        var createdWarehouse = await _warehouseService.CreateWarehouseAsync(warehouse);
        return CreatedAtAction(nameof(GetAll), new { id = createdWarehouse.Id }, createdWarehouse);
    }
}