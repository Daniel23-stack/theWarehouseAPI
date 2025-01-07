using TheWarehouseAPI.Models;
using TheWarehouseAPI.Repositories;

namespace TheWarehouseAPI.Services;

public class WarehouseService
{
    private readonly IWarehouseRepository _warehouseRepository;

    public WarehouseService(IWarehouseRepository warehouseRepository)
    {
        _warehouseRepository = warehouseRepository;
    }

    public Task<IEnumerable<Warehouse>> GetAllWarehousesAsync() => _warehouseRepository.GetAllAsync();
    public Task<Warehouse> CreateWarehouseAsync(Warehouse warehouse) => _warehouseRepository.CreateAsync(warehouse);
}